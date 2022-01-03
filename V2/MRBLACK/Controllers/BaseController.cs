using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRBLACK.Models.ViewModels;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace MRBLACK.Controllers
{
    public class BaseController : Controller
    {
        public void CreateIndexPageDetailsCookie(IndexPageDetailsVM indexPageDetailsVM)
        {
            List<IndexPageDetailsVM> jsonIndexPageDetails = new List<IndexPageDetailsVM>();
            var strIndexPageDetails = Request.Cookies["IndexPageDetails"];
            if (strIndexPageDetails != null && strIndexPageDetails != "")
            {
                jsonIndexPageDetails = JsonConvert.DeserializeObject<List<IndexPageDetailsVM>>(strIndexPageDetails);
                if (jsonIndexPageDetails.FirstOrDefault(c => c.ControllerName == indexPageDetailsVM.ControllerName) != null)
                {
                    jsonIndexPageDetails.FirstOrDefault(c => c.ControllerName == indexPageDetailsVM.ControllerName).SearchStr = indexPageDetailsVM.SearchStr;
                    jsonIndexPageDetails.FirstOrDefault(c => c.ControllerName == indexPageDetailsVM.ControllerName).PageNumber = indexPageDetailsVM.PageNumber;
                    jsonIndexPageDetails.FirstOrDefault(c => c.ControllerName == indexPageDetailsVM.ControllerName).PageSize = indexPageDetailsVM.PageSize;
                }
                else
                {
                    jsonIndexPageDetails.Add(indexPageDetailsVM);
                }
                Response.Cookies.Delete("IndexPageDetails");
            }
            else
            {
                jsonIndexPageDetails.Add(indexPageDetailsVM);
            }

            strIndexPageDetails = JsonConvert.SerializeObject(jsonIndexPageDetails);
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(1000);
            Response.Cookies.Append("IndexPageDetails", strIndexPageDetails, option);

            ViewBag.PageStartRowNum = ((indexPageDetailsVM.PageNumber - 1) * indexPageDetailsVM.PageSize) + 1;
            ViewBag.Entires = indexPageDetailsVM.PageSize;
            ViewBag.SearchStr = indexPageDetailsVM.SearchStr;
        }

        public IndexPageDetailsVM GetIndexPageDetails(string tableName)
        {
            var model = new IndexPageDetailsVM();
            List<IndexPageDetailsVM> jsonIndexPageDetails = new List<IndexPageDetailsVM>();
            var strIndexPageDetails = Request.Cookies["IndexPageDetails"];
            if (strIndexPageDetails != null && strIndexPageDetails != "")
            {
                jsonIndexPageDetails = JsonConvert.DeserializeObject<List<IndexPageDetailsVM>>(strIndexPageDetails);
                model = jsonIndexPageDetails.FirstOrDefault(c => c.ControllerName == tableName);
                if (model == null || model.PageNumber == 0)
                {
                    model = new IndexPageDetailsVM()
                    {
                        ControllerName = tableName,
                        SearchStr = "",
                        PageNumber = 1,
                        PageSize = 5
                    };
                }
            }
            else
            {
                model = new IndexPageDetailsVM()
                {
                    ControllerName = tableName,
                    SearchStr = "",
                    PageNumber = 1,
                    PageSize = 5
                };
            }
            return model;
        }

        public IActionResult BackToDefault(string controllerName)
        {
            CreateIndexPageDetailsCookie(new IndexPageDetailsVM()
            {
                ControllerName = controllerName,
                SearchStr = "",
                PageNumber = 1,
                PageSize = 5
            });
            return RedirectToAction("Index",controllerName);
        }
    }
}
