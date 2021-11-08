using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MRBLACK.Controllers
{
    ///[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Repository<ServiceProvider> _Provider;
        private readonly Repository<Student> _Student;
        private readonly Repository<ServiceCategory> _category;
        private readonly IRepository<Country> _country;
        private readonly IRepository<SlideShow> _slideShow;
        private readonly IdentitySetupContext _context;
        private readonly IRepository<Service> _service;
        private readonly IRepository<University> _university;
        private readonly Repository<ServicesPurchaseInvoice> _Invoice;
        private readonly UserManager<IdentitySetupUser> _userManager;
        private readonly Repository<BookStore> _book;
        private readonly Repository<BookCategory> _bookCategory;
        public HomeController(ILogger<HomeController> logger,
            IRepository<ServiceProvider> Provider,
            IRepository<Student> Student,
            IRepository<ServiceCategory> category,
            IRepository<Service> service,
            IdentitySetupContext context,
            IRepository<SlideShow> slideShow,
            IRepository<University> university,
            IRepository<Country> country,
            IRepository<ServicesPurchaseInvoice> Invoice
            ,IRepository<BookStore> book
            ,IRepository<BookCategory> bookCategory)
        {
            _logger = logger;
            _context = context;
            _service = service;
            _slideShow = slideShow;
            _university = university;
            _country = country;
            _category = (Repository<ServiceCategory>)category;
            _Provider = (Repository<ServiceProvider>)Provider;
            _Student = (Repository<Student>)Student;
            _Invoice = (Repository<ServicesPurchaseInvoice>)Invoice;
            _book = (Repository<BookStore>)book;
            _bookCategory = (Repository<BookCategory>)bookCategory;
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
            var providers = _Provider.GetAllAsIQueryable(x=>x.IsSponsered).ToList();
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
            vm.Students = _Student.GetAll().Count();
            vm.CountProviders = _Provider.GetAll().Count();
            vm.Books = _book.GetAll().Count();
            vm.Services = _service.GetAll().Count();
            return View(vm);
        }
        public async Task<IActionResult> Services(int CategoryId = -1, int UniversityId=-1
            , int pageNumber = 1, int pageSize = 10)
        {
            ViewBag.University = _university.GetAll().ToList();
            ViewBag.Categories = GeneralHelper.GetParentNodesInAllCategories(_category);
            return View(GetPagedListItems(CategoryId,UniversityId, pageNumber, pageSize).Result);
        }
        public async Task<IActionResult> Providers(int CountryId = -1,int pageNumber = 1, int pageSize = 10)
        {
            ViewBag.Countries = _country.GetAll().ToList();
            return View(GetPagedListItems(CountryId, pageNumber, pageSize).Result);
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
        #region Providers PAGINATION METHODS
        public async Task<PagedList<ProvidersInIndexVm>> GetPagedListItems(int CountruId, int pageNumber, int pageSize)
        {
            Func<IQueryable<ServiceProvider>, IOrderedQueryable<ServiceProvider>> orderBy = o => o.OrderByDescending(c => c.Id);
            var vm = new List<ProvidersInIndexVm>();
            var providers = _Provider.GetAllAsIQueryable(x => (CountruId == -1?true:x.CountryId==CountruId)).ToList();
            foreach (var provider in providers)
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == provider.UserId);
                vm.Add(new ProvidersInIndexVm()
                {
                    Description = provider.JobDesc,
                    Id = provider.Id,
                    ImageUrl = user.ImgPath,
                    Name = user.EnName,
                    Rate = 0
                });
            }
            ViewBag.PageStartRowNum = ((pageNumber - 1) * pageSize) + 1;
            return PagedList<ProvidersInIndexVm>.CreateAsync(vm, pageNumber, pageSize);
        }
        public IActionResult GetProvidersItems(int countruId, int pageNumber = 1, int pageSize = 12)
        {
            return PartialView("_ProviderTableList", GetPagedListItems(countruId, pageNumber, pageSize).Result.ToList());
        }
        public IActionResult GetProvidersPagination(int countruId, int pageNumber = 1, int pageSize = 12)
        {
            var model = PagedList<ProvidersInIndexVm>.GetPaginationObject(GetPagedListItems(countruId, pageNumber, pageSize).Result);
            model.GetItemsUrl = "/Home/GetItems";
            model.GetPaginationUrl = "/Home/GetPagination";
            return PartialView("_ProviderPagination", model);
        }
        #endregion
        #region PAGINATION METHODS
        public async Task<PagedList<ServiceInIndexVm>> GetPagedListItems(int CategoryId, int UniversityId
            , int pageNumber, int pageSize)
        {
            Func<IQueryable<Service>, IOrderedQueryable<Service>> orderBy = o => o.OrderByDescending(c => c.Id);
            var vm = new List<ServiceInIndexVm>();
            var LeefCategoies = new List<int>();
            if (CategoryId == -1)
                LeefCategoies = GeneralHelper.GetLastNodesInAllCategories(_category)
              .Select(x => x.Id).ToList();
            else
                LeefCategoies = GeneralHelper.GetSpecificChildernCategories(_category, CategoryId, new List<ServiceCategory>())
              .Select(x => x.Id).ToList();

            var services = _service.GetAllAsIQueryable(x =>
                (x.CategoryId.HasValue ? LeefCategoies.Contains(x.CategoryId.Value) : false)
                && (UniversityId == -1 ? true : x.UniversityId == UniversityId),
                null, "Category,Provider");
            foreach (var item in services)
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == item.Provider.UserId);
                vm.Add(new ServiceInIndexVm()
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
            ViewBag.PageStartRowNum = ((pageNumber - 1) * pageSize) + 1;
            return PagedList<ServiceInIndexVm>.CreateAsync(vm, pageNumber, pageSize);
        }
        public IActionResult GetItems(int categoryId, int universityId, int pageNumber = 1, int pageSize = 12)
        {
            return PartialView("_ServiceTableList", GetPagedListItems(categoryId, universityId, pageNumber, pageSize).Result.ToList());
        }
        public IActionResult GetPagination(int categoryId, int universityId, int pageNumber = 1, int pageSize = 12)
        {
            var model = PagedList<ServiceInIndexVm>.GetPaginationObject(GetPagedListItems(categoryId, universityId, pageNumber, pageSize).Result);
            model.GetItemsUrl = "/Home/GetItems";
            model.GetPaginationUrl = "/Home/GetPagination";
            return PartialView("_ServicePagination", model);
        }
        #endregion

        public IActionResult Books(int id = 0)
        {
            ViewBag.SelectedCategory = id;
            ViewBag.BookCategoryList = new SelectList(_bookCategory.GetAll(), "Id", "EnName");
            var books = new List<BookStore>();
            if(id != 0)
            {
                books = _book.GetAll(c => c.BookCategoryId == id, null, "BookCategory").ToList();
            }
            else
            {
                books = _book.GetAll(null, null, "BookCategory").ToList();
            }
            return View(books);
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
