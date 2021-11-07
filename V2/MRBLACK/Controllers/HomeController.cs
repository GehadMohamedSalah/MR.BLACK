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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Repository<ServiceProvider> _Provider;
        private readonly Repository<Student> _Student;
        private readonly Repository<ServiceCategory> _category;
        private readonly IRepository<SlideShow> _slideShow;
        private readonly IdentitySetupContext _context;
        private readonly IRepository<Service> _service;
        private readonly Repository<ServicesPurchaseInvoice> _Invoice;
        private readonly UserManager<IdentitySetupUser> _userManager;

        public HomeController(ILogger<HomeController> logger,
            IRepository<ServiceProvider> Provider,
            IRepository<Student> Student,
            IdentitySetupContext context,
            UserManager<IdentitySetupUser> userManager,
            IRepository<ServicesPurchaseInvoice> Invoice,
            IRepository<SlideShow> slideShow,
            IRepository<Service> service,
            IRepository<ServiceCategory> category)
        {
            _logger = logger;
            _context = context;
            _Provider = (Repository<ServiceProvider>)Provider;
            _Student = (Repository<Student>)Student;
            _Invoice = (Repository<ServicesPurchaseInvoice>)Invoice;
            _userManager = userManager;
            _category = (Repository<ServiceCategory>)category;
            _slideShow = slideShow;
            _service = service;
        }
        private ServiceProvider provider;
        private Student student;
        public async Task<IActionResult> Index()
        {
            /* var user = await _userManager.GetUserAsync(User);
             provider = _Provider.GetFirstOrDefault(c => c.UserId == user.Id);
             student = _Student.GetFirstOrDefault(c => c.UserId == user.Id);
             if (provider != null)
                 return RedirectToAction(nameof(ProviderHomePage));
             if (student != null)
                 return RedirectToAction(nameof(StudentHomePage));*/
            var vm = new IndexPageVm();
            vm.SlideShow =  _slideShow.GetAllAsIQueryable().Select(x => new SlideShowVm()
            {
                ImageUrl = x.ImgPath,
                Caption = x.Text,
                Link = x.Link
            }).ToList();
            vm.categoryWithServices = GeneralHelper.GetParentNodesInAllCategories(_category).Select(x =>
            new CategoryWithServiceIndex() { CategoryName = x.EnName,Id=x.Id }).ToList();
            for(int i = 0; i <vm.categoryWithServices.Count;i++)
            {
                var leefCategories = GeneralHelper.
                    GetSpecificChildernCategories(_category, vm.categoryWithServices[i].Id,
                    new List<ServiceCategory>()).Select(x=>x.Id).ToList();

                var services = _service.GetAllAsIQueryable(x =>
                  (x.CategoryId.HasValue ? leefCategories.Contains(x.CategoryId.Value) : false)
                , null, "Provider,Category").ToList();
                foreach(var item in services)
                {
                    vm.categoryWithServices[i].Services.Add(new ServiceInIndexVm()
                    {
                        Description = item.Description,
                        ImageUrl = item.ImgPath,
                        Name = item.EnName,
                        TotalPrice = item.TotalPrice,
                        Id = item.Id,
                        LeefCategoryName = item.Category.EnName,
                        ProviderImageUrl = (_context.Users.FirstOrDefault(p => p.Id == item.Provider.UserId).ImgPath),
                        ProviderName = _context.Users.FirstOrDefault(p => p.Id == item.Provider.UserId).EnName,
                        ProviderRate = 0,

                    });
                }
            }
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
    }
}
