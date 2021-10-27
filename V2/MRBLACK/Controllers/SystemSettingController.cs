using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MRBLACK.Models.Database;
using MRBLACK.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Controllers
{
    [Authorize(Roles="ADMIN")]
    public class SystemSettingController : Controller
    {
        private readonly Repository<SystemSetting> _SysSetting;
        public SystemSettingController(IRepository<SystemSetting> SysSetting)
        {
            _SysSetting = (Repository<SystemSetting>)SysSetting;
        }
        public IActionResult Index()
        {
            ViewBag.divId = "setting";
            ViewBag.returnActionName = nameof(Index);
            return View("Index", GetSettingDetails());
        }

        public IActionResult SystemFees()
        {
            ViewBag.divId = "fees";
            ViewBag.returnActionName = nameof(SystemFees);
            return View("Index", GetSettingDetails());
        }

        public IActionResult ResearchAdditionRatio()
        {
            ViewBag.divId = "percentage";
            ViewBag.returnActionName = nameof(ResearchAdditionRatio);
            return View("Index", GetSettingDetails());
        }

        public SystemSetting GetSettingDetails()
        {
            var model = _SysSetting.GetFirstOrDefault();
            if (model == null)
            {
                _SysSetting.Add(new SystemSetting());
                model = _SysSetting.GetFirstOrDefault();
            }
            return model;
        }

        [HttpPost]
        public IActionResult SaveSystemSetting(SystemSetting model,string returnActionName)
        {
            _SysSetting.Update(model);
            return RedirectToAction(returnActionName);
        }
    }
}
