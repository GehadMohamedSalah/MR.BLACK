using Microsoft.AspNetCore.Authorization;
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

namespace MRBLACK.Controllers
{
    public class CopunController : BaseController
    {
        private readonly Repository<Copun> _Copun;
        private readonly Repository<CurrencyType> _CurrencyType;
        private readonly Repository<ServiceCategory> _ServiceCategory;


        public CopunController(IRepository<Copun> Copun,
            IRepository<CurrencyType> CurrencyType,
            IRepository<ServiceCategory> ServiceCategory)
        {
            _Copun = (Repository<Copun>)Copun;
            _CurrencyType = (Repository<CurrencyType>)CurrencyType;
            _ServiceCategory = (Repository<ServiceCategory>)ServiceCategory;        }

        #region CRUD OPERTIONS

        #region Get Copuns
        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            var model = GetIndexPageDetails("Copun");
            return View(GetPagedListItems(model.SearchStr, model.PageNumber, model.PageSize).Result);
        }
        #endregion

        #region Create Copun
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            FillDropdownLists();
            return View("EditCreate", new Copun());
        }

        [HttpPost]
        public IActionResult Create(Copun model)
        {
            if (ModelState.IsValid)
            {
                if(ValidateModel(model))
                {
                    _Copun.Add(model);
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.ActionName = nameof(Create);
            FillDropdownLists();
            return View("EditCreate", model);
        }
        #endregion

        #region Edit Copun
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            FillDropdownLists();
            var model = _Copun.GetElement(id);
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(Copun model)
        {
            if (ModelState.IsValid)
            {
                if(ValidateModel(model))
                {
                    _Copun.Update(model);
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.ActionName = nameof(Edit);
            FillDropdownLists();
            return View("EditCreate", model);
        }
        #endregion

        #region Delete Copun
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "Copun",
                ActionName = nameof(Delete),
                Title = "حذف من شاشة الكوبونات",
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
                _Copun.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                return Json(new { IsSuccess = false, Msg = "لا يمكن حذف هذا الكوبون" });
            }

            return Json(new { IsSuccess = true, Msg = "تم الحذف بنجاح" });
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<Copun>> GetPagedListItems(string searchStr, int pageNumber, int pageSize)
        {
            Expression<Func<Copun, bool>> filter = null;
            Func<IQueryable<Copun>, IOrderedQueryable<Copun>> orderBy = o => o.OrderByDescending(c => c.NameOrCode);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.NameOrCode.ToLower().Contains(searchStr)
                || ("cop_"+f.Id.ToString()).Contains(searchStr)
                || f.StartDate.ToString().Contains(searchStr)
                || f.EndDate.ToString().Contains(searchStr)
                || f.MinInvoiceVal.ToString().Contains(searchStr)
                || f.AccountStartDate.ToString().Contains(searchStr);
            }

            CreateIndexPageDetailsCookie(new IndexPageDetailsVM()
            {
                ControllerName = "Copun",
                SearchStr = searchStr,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return await PagedList<Copun>.CreateAsync(_Copun.GetAllAsIQueryable(filter, orderBy, "Category"),
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber,pageSize).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<Copun>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber,pageSize).Result);
            model.GetItemsUrl = "/Copun/GetItems";
            model.GetPaginationUrl = "/Copun/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion

        #region FILL DROPDOWN LISTS
        private void FillDropdownLists()
        {
            ViewBag.CurrencyTypeList = new SelectList(_CurrencyType.GetAll(),"Id","ArName");
            ViewBag.CategoryList = new SelectList(_ServiceCategory.GetAll(c => c.ParentCategoryId == null), "Id", "ArName");
        }
        #endregion

        private bool ValidateModel(Copun model)
        {
            var check = 0;

            if (model.Id > 0)
            {
                var copuns = _Copun.GetAll(c => c.NameOrCode.ToLower() == model.NameOrCode && c.Id != model.Id).ToList();
                if (copuns != null && copuns.Count() > 0)
                {
                    ModelState.AddModelError("", "هذا الكود موجود مسبقا لا يمكن تكراره");
                    check++;
                }

            }
            else
            {
                var copuns = _Copun.GetAll(c => c.NameOrCode.ToLower() == model.NameOrCode).ToList();
                if (copuns != null && copuns.Count() > 0)
                {
                    ModelState.AddModelError("", "هذا الكود موجود مسبقا لا يمكن تكراره");
                    check++;
                }
            }

            if (model.StartDate > model.EndDate)
            {
                ModelState.AddModelError("", "تاريخ البدء لا يمكن ان يكون بعد تاريخ الانتهاء");
                check++;
            }

            if(model.AccountStartDate > model.StartDate)
            {
                ModelState.AddModelError("", "تاريخ انشاء الحساب يجب ان يكون قبل تاريخ البدء او في نفس تاريخه");
                check++;
            }
            
            if (check == 0)
                return true;
            return false;
        }
    }
}
