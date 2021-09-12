﻿using Microsoft.AspNetCore.Authorization;
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
    public class TermController : Controller
    {
        private readonly Repository<Term> _Term;
        private readonly int PageSize;
        public TermController(IRepository<Term> Term)
        {
            _Term = (Repository<Term>)Term;
            PageSize = 5;
        }

        #region CRUD OPERTIONS

        #region Get Terms
        public IActionResult Index(int pageNumber = 1)
        {
            return View(GetPagedListItems("", pageNumber).Result);
        }
        #endregion

        #region Create Term
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", new Term());
        }

        [HttpPost]
        public IActionResult Create(Term model)
        {
            if (ModelState.IsValid)
            {
                _Term.Add(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", model);
        }
        #endregion

        #region Edit Term
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            var model = _Term.GetElement(id);
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(Term model)
        {
            if (ModelState.IsValid)
            {
                _Term.Update(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Edit);
            return View("EditCreate", model);
        }
        #endregion

        #region Delete Term
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "Term",
                ActionName = nameof(Delete),
                Title = "حذف من شاشة الترمات",
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
                _Term.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                ModelState.AddModelError("", "لا يمكن حذف هذا الترم");
                return View("_DeleteView", model);
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<Term>> GetPagedListItems(string searchStr, int pageNumber)
        {
            Expression<Func<Term, bool>> filter = null;
            Func<IQueryable<Term>, IOrderedQueryable<Term>> orderBy = o => o.OrderByDescending(c => c.ArName);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.EnName.ToLower().Contains(searchStr)
                || f.ArName.Contains(searchStr);
            }

            return await PagedList<Term>.CreateAsync(_Term.GetAllAsIQueryable(filter, orderBy),
                pageNumber, PageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1)
        {
            var model = PagedList<Term>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber).Result);
            model.GetItemsUrl = "/Term/GetItems";
            model.GetPaginationUrl = "/Term/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion
    }
}