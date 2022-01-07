using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MRBLACK.Areas.Identity.Data;
using MRBLACK.Data;
using MRBLACK.Helper;
using MRBLACK.Models.Database;
using MRBLACK.Models.ViewModels;
using MRBLACK.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace MRBLACK.Controllers
{
    [Authorize]
    public class ServiceController : BaseController
    {
        private readonly Repository<Service> _Service;
        private readonly Repository<Country> _Country;
        private readonly Repository<University> _University;
        private readonly Repository<College> _College;
        private readonly Repository<Department> _Department;
        private readonly Repository<AcademicYear> _AcademicYear;
        private readonly Repository<Term> _Term;
        private readonly Repository<Subject> _Subject;
        private readonly Repository<ServiceProvider> _Provider;
        private readonly Repository<ServiceCategory> _Category;
        private readonly Repository<CurrencyType> _CurrencyType;
        private readonly IdentitySetupContext _identitySetuoContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        //private readonly int PageSize;
        public ServiceController(IRepository<Service> Service,
            IRepository<Country> Country,
            IRepository<College> College,
            IRepository<University> University,
            IRepository<Department> Department,
            IRepository<AcademicYear> AcademicYear,
            IRepository<Term> Term,
            IRepository<Subject> Subject,
            IRepository<ServiceCategory> Category,
            IRepository<ServiceProvider> Provider,
            IRepository<CurrencyType> CurrencyType,
            IdentitySetupContext identitySetuoContext
            , IWebHostEnvironment webHostEnvironment)
        {
            _Service = (Repository<Service>)Service;
            _Country = (Repository<Country>)Country;
            _University = (Repository<University>)University;
            _College = (Repository<College>)College;
            _Department = (Repository<Department>)Department;
            _AcademicYear = (Repository<AcademicYear>)AcademicYear;
            _Term = (Repository<Term>)Term;
            _Subject = (Repository<Subject>)Subject;
            _Category = (Repository<ServiceCategory>)Category;
            _Provider = (Repository<ServiceProvider>)Provider;
            _CurrencyType = (Repository<CurrencyType>)CurrencyType;
            _identitySetuoContext = identitySetuoContext;
            _webHostEnvironment = webHostEnvironment;
            //PageSize = 5;
        }

        #region CRUD OPERTIONS

        #region Get Services
        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            var model = GetIndexPageDetails("Service");
            return View(GetPagedListItems(model.SearchStr, model.PageNumber, model.PageSize).Result);
        }
        #endregion

        #region Create Service
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            FillDropdownLists();
            return View("EditCreate", new Service());
        }

        [HttpPost]
        public IActionResult Create(Service model,IFormFile img, IFormFile anotherImg)
        {
            if (ModelState.IsValid)
            {
                if (!CheckServiceExisting(model))
                {
                    if(img != null)
                    {
                        model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/Services");
                    }
                    if (anotherImg != null)
                    {
                        model.AnotherImgPath = FileHelper.UploadFile(anotherImg, _webHostEnvironment, "Uploads/Images/Services");
                    }
                    model.FormTypeId = _Category.GetElement((int)model.CategoryId).FormType;
                    _Service.Add(model);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "لا يمكن اضافة هذه الخدمة لانه يوجد خدمة بنفس المواصفات");
                }
            }
            ViewBag.ActionName = nameof(Create);
            FillDropdownLists(model.CategoryId);
            return View("EditCreate", model);
        }
        #endregion

        #region Edit Service
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            var model = _Service.GetFirstOrDefault(c => c.Id == id , "Category");
            FillDropdownLists(model.CategoryId);
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(Service model, IFormFile img, IFormFile anotherImg)
        {
            if (ModelState.IsValid)
            {
                if (!CheckServiceExisting(model))
                {
                    if (img != null)
                    {
                        model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/Services");
                    }
                    if (anotherImg != null)
                    {
                        model.AnotherImgPath = FileHelper.UploadFile(anotherImg, _webHostEnvironment, "Uploads/Images/Services");
                    }
                    model.FormTypeId = _Category.GetElement((int)model.CategoryId).FormType;
                    _Service.Update(model);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "لا يمكن اضافة هذه الخدمة لانه يوجد خدمة بنفس المواصفات");
                }
            }
            ViewBag.ActionName = nameof(Edit);
            FillDropdownLists(model.CategoryId);
            return View("EditCreate", model);
        }
        #endregion

        #region Delete Service
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "Service",
                ActionName = nameof(Delete),
                Title = "حذف من شاشة السنين الدراسية",
                PkFieldStrVal = null,
                PkFieldIntVal = id
            };
            return View("_DeleteView", model);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(ConfirmDeleteVM model)
        {
            try
            {
                _Service.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                return Json(new { IsSuccess = false, Msg = "لا يمكن حذف هذه الخدمة" });
            }

            return Json(new { IsSuccess = true, Msg = "تم الحذف بنجاح" });
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<Service>> GetPagedListItems(string searchStr, int pageNumber, int pageSize)
        {
            Expression<Func<Service, bool>> filter = null;
            Func<IQueryable<Service>, IOrderedQueryable<Service>> orderBy = o => o.OrderByDescending(c => c.ArName);

            if (searchStr == null)
                searchStr = "";
            searchStr = searchStr.ToLower();
            int providerId = -1;
            if (GeneralHelper.GetLoggedUserRole(User.FindFirstValue(ClaimTypes.NameIdentifier), _identitySetuoContext) != "ADMIN")
            {
                Expression<Func<ServiceProvider, bool>> filter1 = f => f.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier);
                var provider = _Provider.GetFirstOrDefault(filter1);
                if (provider != null)
                {
                    providerId = provider.Id;
                }
            }

            if(providerId != -1)
            {
                filter = f => f.ProviderId == providerId &&
                   ( f.EnName.ToLower().Contains(searchStr) ||
                    f.ArName.Contains(searchStr));
            }
            else
            {
                filter = f => f.EnName.ToLower().Contains(searchStr) ||
                    f.ArName.Contains(searchStr);
            }

            CreateIndexPageDetailsCookie(new IndexPageDetailsVM()
            {
                ControllerName = "Service",
                SearchStr = searchStr,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return await PagedList<Service>.CreateAsync(_Service.GetAllAsIQueryable(filter, orderBy, "Category"),
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber,pageSize).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<Service>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber,pageSize).Result);
            model.GetItemsUrl = "/Service/GetItems";
            model.GetPaginationUrl = "/Service/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion

        #region Fill Dropdown Lists
        private void FillDropdownLists(int? categoryId = -1)
        {
            ViewBag.CountryList = new SelectList(_Country.GetAll(), "Id", "ArName");
            ViewBag.UniversityList = new SelectList(_University.GetAll(), "Id", "ArName");
            ViewBag.CollegeList = new SelectList(_College.GetAll(), "Id", "ArName");
            ViewBag.DepartmentList = new SelectList(_Department.GetAll(), "Id", "ArName");
            ViewBag.AcademicYearList = new SelectList(_AcademicYear.GetAll(), "Id", "ArName");
            ViewBag.TermList = new SelectList(_Term.GetAll(), "Id", "ArName");
            ViewBag.SubjectList = new SelectList(_Subject.GetAll(), "Id", "ArName");
            ViewBag.ProviderList = GetUsersProviders();
            ViewBag.CategoryList = new SelectList(GeneralHelper.GetLastNodesInAllCategories(_Category), "Id", "ArName");
            ViewBag.CurrencyTypeList = new SelectList(_CurrencyType.GetAll(), "Id", "ArName");
            ViewBag.PlatformCommission = 0;
            ViewBag.PlatformCommissionVal = 0;

            if (categoryId != -1)
            {
                var category = _Category.GetElement((int)categoryId);
                ViewBag.PlatformCommission = category.CommissionPercentage;
                ViewBag.PlatformCommissionVal = category.PlatformRevenueFromServPrice;
            }

        }

        private List<SelectListItem> GetUsersProviders()
        {
            List<SelectListItem> users = new List<SelectListItem>();
            var user = new IdentitySetupUser();
            if (GeneralHelper.GetLoggedUserRole(User.FindFirstValue(ClaimTypes.NameIdentifier), _identitySetuoContext) == "ADMIN")
            {
                foreach (var item in _Provider.GetAll())
                {
                    user = _identitySetuoContext.Users.Find(item.UserId);
                    if (user != null)
                        users.Add(new SelectListItem()
                        {
                            Value = item.Id.ToString(),
                            Text = user.ArName
                        });
                }
            }
            else
            {
                Expression<Func<ServiceProvider, bool>> filter = f => f.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier);
                var providers = _Provider.GetAll(filter);
                user = _identitySetuoContext.Users.Find(User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (providers != null && providers.Count() > 0)
                {
                    if (user != null)
                        users.Add(new SelectListItem()
                        {
                            Value = providers.First().Id.ToString(),
                            Text = user.ArName
                        });
                }
            }

            return users;
        }

        #endregion

        #region Ajax Requests
        public IActionResult GetCountryUniversities(int CountryId)
        {
            Expression<Func<University, bool>> filter = f => f.CountryId == CountryId;
            var x = new SelectList(_University.GetAll(filter), "Id", "ArName");
            return Json(x);
        }

        public IActionResult GetServiceCategoryDetails(int CategoryId)
        {
            var category = _Category.GetElement(CategoryId);
            return Json(JsonConvert.SerializeObject(category));
        }

        public IActionResult GetUCDSByUniversity(int? universityId, int? collegeId, int? departmentId, int? subjectId)
        {
            Dictionary<string, List<SelectListItem>> result = new Dictionary<string, List<SelectListItem>>();
            if(universityId != null)
            {

            }
            return Json(result);
        }

        #endregion

        private bool CheckServiceExisting(Service model)
        {
            Expression<Func<Service, bool>> filter = f => f.UniversityId == model.UniversityId &&
             f.CollegeId == model.CollegeId &&
             f.DepartmentId == model.DepartmentId &&
             f.AcademinYearId == model.AcademinYearId &&
             f.TermId == model.TermId &&
             f.SubjectId == model.SubjectId &&
             f.CategoryId == model.CategoryId &&
             f.ProviderId == model.ProviderId;
            if(model.Id != 0)
            {
                filter = f => f.Id != model.Id && f.UniversityId == model.UniversityId &&
                         f.CollegeId == model.CollegeId &&
                         f.DepartmentId == model.DepartmentId &&
                         f.AcademinYearId == model.AcademinYearId &&
                         f.TermId == model.TermId &&
                         f.SubjectId == model.SubjectId &&
                         f.CategoryId == model.CategoryId &&
                         f.ProviderId == model.ProviderId;
            }
            if(_Service.GetAll(filter) != null && _Service.GetAll(filter).Count() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
