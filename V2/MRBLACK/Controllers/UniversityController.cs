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
    [Authorize(Roles = "ADMIN")]
    public class UniversityController : Controller
    {
        private readonly Repository<University> _University;
        private readonly Repository<Country> _Country;
        private readonly int PageSize;
        public UniversityController(IRepository<University> University,
            IRepository<Country> Country)
        {
            _University = (Repository<University>)University;
            _Country = (Repository<Country>)Country;
            PageSize = 5;
        }

        #region CRUD OPERTIONS

        #region Get Universities
        public IActionResult Index(int pageNumber = 1)
        {
            return View(GetPagedListItems("", pageNumber).Result);
        }
        #endregion

        #region Create University
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            ViewBag.CountryList = new SelectList(_Country.GetAll(), "Id", "ArName");
            return View("EditCreate", new University());
        }

        [HttpPost]
        public IActionResult Create(University model)
        {
            if (ModelState.IsValid)
            {
                _University.Add(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Create);
            ViewBag.CountryList = new SelectList(_Country.GetAll(), "Id", "ArName");
            return View("EditCreate", model);
        }
        #endregion

        #region Edit University
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            ViewBag.CountryList = new SelectList(_Country.GetAll(), "Id", "ArName");
            var model = _University.GetElement(id);
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(University model)
        {
            if (ModelState.IsValid)
            {
                _University.Update(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Edit);
            ViewBag.CountryList = new SelectList(_Country.GetAll(), "Id", "ArName");
            return View("EditCreate", model);
        }
        #endregion

        #region Delete University
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "University",
                ActionName = nameof(Delete),
                Title = "حذف من شاشة الجامعات",
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
                _University.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                ModelState.AddModelError("", "لا يمكن حذف هذه الجامعة");
                return View("_DeleteView", model);
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<University>> GetPagedListItems(string searchStr, int pageNumber)
        {
            Expression<Func<University, bool>> filter = null;
            Func<IQueryable<University>, IOrderedQueryable<University>> orderBy = o => o.OrderByDescending(c => c.ArName);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.EnName.ToLower().Contains(searchStr) 
                || f.ArName.Contains(searchStr)
                || f.Country.ArName.Contains(searchStr);
            }

            return await PagedList<University>.CreateAsync(_University.GetAllAsIQueryable(filter, orderBy, "Country"),
                pageNumber, PageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1)
        {
            var model = PagedList<University>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber).Result);
            model.GetItemsUrl = "/University/GetItems";
            model.GetPaginationUrl = "/University/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion
    }
}
