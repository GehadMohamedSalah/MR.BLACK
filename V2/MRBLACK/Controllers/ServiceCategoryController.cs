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

namespace MRBLACK.Controllers
{
    [Authorize]
    public class ServiceCategoryController : Controller
    {
        private readonly Repository<ServiceCategory> _ServiceCategory;
        private readonly Repository<CurrencyType> _CurrencyType;
        private readonly IdentitySetupContext _context;
        private readonly int PageSize;
        private string LoggedUserRole;
        public ServiceCategoryController(IRepository<ServiceCategory> ServiceCategory,
            IRepository<CurrencyType> CurrencyType,
            IdentitySetupContext context)
        {
            _ServiceCategory = (Repository<ServiceCategory>)ServiceCategory;
            _CurrencyType = (Repository<CurrencyType>)CurrencyType;
            _context = context;
            PageSize = 5;
        }

        private void SetLoggedUserData()
        {
            var LoggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            if(LoggedUserRole == null)
            {
                var roles = _context.UserRoles.Where(c => c.UserId == LoggedUserId);
                if (roles != null)
                {
                    LoggedUserRole = _context.Roles.Find(roles.First().RoleId).Name;
                }
            }
        }

        #region CRUD OPERTIONS

        #region Get ServiceCategorys
        public IActionResult Index(int pageNumber = 1)
        {
            return View(GetPagedListItems("", pageNumber).Result);
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
        public IActionResult Create(ServiceCategory model)
        {
            if (ModelState.IsValid)
            {
                SetLoggedUserData();
                if (LoggedUserRole == "ADMIN")
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
        public IActionResult Edit(ServiceCategory model)
        {
            if (ModelState.IsValid)
            {
                _ServiceCategory.Update(model);
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
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(ConfirmDeleteVM model)
        {
            try
            {
                _ServiceCategory.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                ModelState.AddModelError("", "لا يمكن حذف هذا التصنيف");
                return View("_DeleteView", model);
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<ServiceCategory>> GetPagedListItems(string searchStr, int pageNumber)
        {
            Expression<Func<ServiceCategory, bool>> filter = null;
            Func<IQueryable<ServiceCategory>, IOrderedQueryable<ServiceCategory>> orderBy = o => o.OrderByDescending(c => c.ArName);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.EnName.ToLower().Contains(searchStr)
                || f.ArName.Contains(searchStr);
            }

            return await PagedList<ServiceCategory>.CreateAsync(_ServiceCategory.GetAllAsIQueryable(filter, orderBy),
                pageNumber, PageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1)
        {
            var model = PagedList<ServiceCategory>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber).Result);
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
    }
}
