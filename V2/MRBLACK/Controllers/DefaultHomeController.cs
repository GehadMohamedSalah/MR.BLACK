using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MRBLACK.Areas.Identity.Data;
using MRBLACK.Data;
using MRBLACK.Helper;
using MRBLACK.Models;
using MRBLACK.Models.Database;
using MRBLACK.Models.ViewModels;
using MRBLACK.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MRBLACK.Controllers
{
    [Authorize]
    public class DefaultHomeController : Controller
    {
        private readonly Repository<ServiceProvider> _Provider;
        private readonly Repository<Student> _Student;
        private readonly UserManager<IdentitySetupUser> _userManager;
        private readonly Repository<SystemSetting> _systemSetting;
        private readonly Repository<Student> _student;
        private readonly Repository<ServiceProvider> _provider;
        private readonly Repository<BookStore> _book;
        private readonly Repository<Service> _service;


        public DefaultHomeController(IRepository<ServiceProvider> Provider
            , IRepository<Student> Student
            , UserManager<IdentitySetupUser> userManager
            , IRepository<SystemSetting> systemSetting
            , IRepository<Student> student
            , IRepository<ServiceProvider> provider
            , IRepository<BookStore> book
            , IRepository<Service> service

            )
        {
            _userManager = userManager;
            _Provider = (Repository<ServiceProvider>)Provider;
            _Student = (Repository<Student>)Student;
            _systemSetting = (Repository<SystemSetting>)systemSetting;
            _student = (Repository<Student>)student;
            _provider = (Repository<ServiceProvider>)provider;
            _book = (Repository<BookStore>)book;
            _service = (Repository<Service>)service;
        }
        private ServiceProvider provider;
        private Student student;
        public IActionResult Index()
        {
            var currentUserId = _userManager.GetUserId(User);
            provider = _Provider.GetFirstOrDefault(c => c.UserId == currentUserId);
            student = _Student.GetFirstOrDefault(c => c.UserId == currentUserId);
            if (provider != null)
            {
                return Redirect(nameof(ProviderHomePage));
            }
            else if (student != null)
            {
                return Redirect(nameof(StudentHomePage));
            }
            return View();
        }

        public IActionResult ProviderHomePage()
        {
            //provider = _Provider.GetFirstOrDefault(c => c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
            //totalRenenue = _Invoice.GetAll(c => c.ProviderId == provider.Id).ToList().Sum(x => x.ProviderRevenue);
            return View();
        }

        public IActionResult StudentHomePage()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult About()
        {
            var item = new SystemSetting();
            item = _systemSetting.GetFirstOrDefault();
            var model = new AboutUsVM()
            {
                AboutUs = item.AboutUs,
                AppWorking = item.HowDealWithSite,
                Students = _student.GetAll().Count(),
                Providers = _provider.GetAll().Count(),
                Services = _service.GetAll().Count(),
                Books = _book.GetAll().Count()
            };
            return View(model);
        }
    }
}
