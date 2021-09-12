using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

namespace MRBLACK.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class CurrencyTypeController : Controller
    {
        private readonly Repository<CurrencyType> _currencyType;
        private readonly int PageSize;
        public CurrencyTypeController(IRepository<CurrencyType> currencyType)
        {
            _currencyType = (Repository<CurrencyType>)currencyType;
            PageSize = 5;
        }

        #region CRUD OPERTIONS

        #region Get Currency Types
        public IActionResult Index(int pageNumber = 1)
        {
            return View(GetPagedListItems("",pageNumber).Result);
        }
        #endregion

        #region Create Currency Type
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", new CurrencyType());
        }

        [HttpPost]
        public IActionResult Create(CurrencyType model)
        {
            if (ModelState.IsValid)
            {
                _currencyType.Add(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", model);
        }
        #endregion

        #region Edit Currency Type
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            var model = _currencyType.GetElement(id);
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(CurrencyType model)
        {
            if (ModelState.IsValid)
            {
                _currencyType.Update(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Edit);
            return View("EditCreate", model);
        }
        #endregion

        #region Delete Currency Type
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "CurrencyType",
                ActionName = nameof(Delete),
                Title = "حذف من شاشة انواع العملات",
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
                _currencyType.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                ModelState.AddModelError("", "لا يمكن حذف هذه العملة");
                return View("_DeleteView", model);
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<CurrencyType>> GetPagedListItems(string searchStr, int pageNumber)
        {
            Expression<Func<CurrencyType, bool>> filter = null;
            Func<IQueryable<CurrencyType>, IOrderedQueryable<CurrencyType>> orderBy = o => o.OrderByDescending(c => c.IsMainCurrency);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.EnName.ToLower().Contains(searchStr) 
                || f.ArName.Contains(searchStr);
            }
            
            return await PagedList<CurrencyType>.CreateAsync(_currencyType.GetAllAsIQueryable(filter, orderBy),
                pageNumber, PageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1)
        {
            var model = PagedList<CurrencyType>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber).Result);
            model.GetItemsUrl = "/CurrencyType/GetItems";
            model.GetPaginationUrl = "/CurrencyType/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion

    }
}
