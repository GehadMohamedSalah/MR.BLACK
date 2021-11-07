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
            IRepository<ServiceCategory> category,
            IRepository<Service> service,
            IdentitySetupContext context,
            IRepository<SlideShow> slideShow,
            IRepository<ServicesPurchaseInvoice> Invoice)
        {
            _logger = logger;
            _context = context;
            _service = service;
            _slideShow = slideShow;
            _category = (Repository<ServiceCategory>)category;
            _Provider = (Repository<ServiceProvider>)Provider;
            _Student = (Repository<Student>)Student;
            _Invoice = (Repository<ServicesPurchaseInvoice>)Invoice;
        }
        private ServiceProvider provider;
        private Student student;
        public async Task<IActionResult> Index()
        {
            var vm = new IndexPageVm();
            vm.SlideShow = _slideShow.GetAllAsIQueryable().
                Select(x => new SlideShowVm()
                {
                    Caption = x.Text,
                    ImageUrl = x.ImgPath,
                    Link = x.Link
                }).ToList();
            vm.categoryWithServices = GeneralHelper.GetParentNodesInAllCategories(_category)
                .Select(x => new CategoryWithServiceIndex()
                {
                    CategoryName = x.EnName,
                    Id = x.Id
                }).ToList();
            for(int i = 0; i < vm.categoryWithServices.Count; i++)
            {
                var LeefCategoies = GeneralHelper.GetSpecificChildernCategories(_category
                    , vm.categoryWithServices[i].Id, new List<ServiceCategory>()).Select(x=>x.Id)
                    .ToList();

                var services = _service.GetAllAsIQueryable(x =>
                (x.CategoryId.HasValue ? LeefCategoies.Contains(x.CategoryId.Value) : false),
                null, "Category,Provider");
                foreach(var item in services)
                {
                    var user = _context.Users.FirstOrDefault(x => x.Id == item.Provider.UserId);
                    vm.categoryWithServices[i].Services.Add(new ServiceInIndexVm()
                    {
                        Id = item.Id,
                        Description = item.Description,
                        ImageUrl = item.ImgPath,
                        LeefCategoryName = item.Category.EnName,
                        Name = item.EnName,
                        TotalPrice = item.TotalPrice,
                        ProviderImageUrl = user.ImgPath,
                        ProviderName = user.EnName,
                        ProviderRate = 0
                    });
                }
            }
            var providers = _Provider.GetAllAsIQueryable().ToList();
            foreach(var provider in providers)
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == provider.UserId);
                vm.Providers.Add(new ProvidersInIndexVm()
                {
                    Description = provider.JobDesc,
                    Id = provider.Id,
                    ImageUrl = user.ImgPath,
                    Name = user.EnName,
                    Rate = 0
                });
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
