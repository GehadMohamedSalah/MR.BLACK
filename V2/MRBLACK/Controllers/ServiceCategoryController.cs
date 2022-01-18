using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MRBLACK.Areas.Identity.Data;
using MRBLACK.Helper;
using MRBLACK.Models.Database;
using MRBLACK.Models.ViewModels;
using MRBLACK.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
//using Microsoft.AspNet.Identity;
using System.Security.Claims;
using MRBLACK.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace MRBLACK.Controllers
{
    [Authorize]
    public class ServiceCategoryController : BaseController
    {
        private readonly Repository<ServiceCategory> _ServiceCategory;
        private readonly Repository<CurrencyType> _CurrencyType;
        private readonly IdentitySetupContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServiceCategoryController(IRepository<ServiceCategory> ServiceCategory,
            IRepository<CurrencyType> CurrencyType,
            IdentitySetupContext context
             , IWebHostEnvironment webHostEnvironment)
        {
            _ServiceCategory = (Repository<ServiceCategory>)ServiceCategory;
            _CurrencyType = (Repository<CurrencyType>)CurrencyType;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        #region CRUD OPERTIONS

        #region Get ServiceCategorys
        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            var model = GetIndexPageDetails("ServiceCategory");
            return View(GetPagedListItems(model.SearchStr, model.PageNumber, model.PageSize).Result);
        }
        #endregion

        #region Create ServiceCategory
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            FillSelectLists();
            return View("EditCreate", new ServiceCategory());
        }

        [HttpPost]
        public IActionResult Create(ServiceCategory model,IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/Categories");
                }
                if (GeneralHelper.GetLoggedUserRole(User.FindFirstValue(ClaimTypes.NameIdentifier),_context) == "ADMIN")
                    model.IsAccepted = true;
                _ServiceCategory.Add(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Create);
            FillSelectLists();
            return View("EditCreate", model);
        }
        #endregion

        #region Edit ServiceCategory
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            FillSelectLists();
            Expression<Func<ServiceCategory, bool>> filter = f => f.Id == id;
            var categories = _ServiceCategory.GetAll(filter, null, "ParentCategory");
            var model = new ServiceCategory();
            if(categories != null)
            {
                model = categories.First();
            }
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(ServiceCategory model, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/Categories");
                }
                model.IsAccepted = true;
                _ServiceCategory.Update(model);
                //var childern = new List<ServiceCategory>();
                //GeneralHelper.GetSpecificChildernCategories(_ServiceCategory, model.Id, childern);
                //if(childern != null && childern.Count() > 0)
                //{
                //    childern.ForEach(c =>
                //    {
                //        c.FormType = model.FormType;
                //        c.PricingMethod = model.PricingMethod;
                //        c.ServicePrice = model.ServicePrice;
                //        c.PlatformRevenueFromServPrice = model.PlatformRevenueFromServPrice;
                //        c.CommissionPercentage = model.CommissionPercentage;
                //        c.CurrencyTypeId = model.CurrencyTypeId;
                //        c.AutoAcceptedService = model.AutoAcceptedService;
                //        _ServiceCategory.Update(c);
                //    });
                //}
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Edit);
            FillSelectLists();
            return View("EditCreate", model);
        }
        #endregion

        #region Delete ServiceCategory
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "ServiceCategory",
                ActionName = nameof(Delete),
                Title = "حذف من شاشة تصنيفات الخدمات",
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
                _ServiceCategory.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                return Json(new { IsSuccess = false, Msg = "لا يمكن حذف هذا التصنيف" });
            }

            return Json(new { IsSuccess = true, Msg = "تم الحذف بنجاح" });
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<ServiceCategory>> GetPagedListItems(string searchStr, int pageNumber, int pageSize)
        {
            Expression<Func<ServiceCategory, bool>> filter = null;
            Func<IQueryable<ServiceCategory>, IOrderedQueryable<ServiceCategory>> orderBy = o => o.OrderByDescending(c => c.ArName);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.EnName.ToLower().Contains(searchStr)
                || f.ArName.Contains(searchStr) || f.Id.ToString().Contains(searchStr);
            }

            CreateIndexPageDetailsCookie(new IndexPageDetailsVM()
            {
                ControllerName = "ServiceCategory",
                SearchStr = searchStr,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return await PagedList<ServiceCategory>.CreateAsync(_ServiceCategory.GetAllAsIQueryable(filter, orderBy, "ParentCategory,InverseParentCategory,Service"),
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber,pageSize).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<ServiceCategory>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber,pageSize).Result);
            model.GetItemsUrl = "/ServiceCategory/GetItems";
            model.GetPaginationUrl = "/ServiceCategory/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion

        #region Fill Select Lists

        private void FillSelectLists()
        {
            Expression<Func<ServiceCategory, bool>> filter = f => f.IsAccepted == true;
            ViewBag.ParentCategoryList = new SelectList(_ServiceCategory.GetAll(filter), "Id", "ArName");
            ViewBag.CurrencyTypeList = new SelectList(_CurrencyType.GetAll(), "Id", "ArName");
        }

        #endregion


        #region AJAX CALL
        public IActionResult GetParentCategoryDetails(int categoryId)
        {
            var result = JsonConvert.SerializeObject(_ServiceCategory.GetElement(categoryId));
            return Json(result);
        }
        #endregion

        public IActionResult RemoveImage(int id)
        {
            var item = _ServiceCategory.GetElement(id);
            item.ImgPath = null;
            _ServiceCategory.Update(item);
            return RedirectToAction(nameof(Index));
        }
    }
}
