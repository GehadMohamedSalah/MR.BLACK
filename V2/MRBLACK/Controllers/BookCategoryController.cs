using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class BookCategoryController : Controller
    {
        private readonly Repository<BookCategory> _BookCategory;
        public BookCategoryController(IRepository<BookCategory> BookCategory)
        {
            _BookCategory = (Repository<BookCategory>)BookCategory;
        }

        #region CRUD OPERTIONS

        #region Get Book Categories
        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            return View(GetPagedListItems("", pageNumber,pageSize).Result);
        }
        #endregion

        #region Create BookCategory
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", new BookCategory());
        }

        [HttpPost]
        public IActionResult Create(BookCategory model)
        {
            if (ModelState.IsValid)
            {
                _BookCategory.Add(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", model);
        }
        #endregion

        #region Edit BookCategory
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            var model = _BookCategory.GetElement(id);
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(BookCategory model)
        {
            if (ModelState.IsValid)
            {
                _BookCategory.Update(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Edit);
            return View("EditCreate", model);
        }
        #endregion

        #region Delete BookCategory
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "BookCategory",
                ActionName = nameof(Delete),
                Title = "حذف من شاشة تصنيفات المقال",
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
                _BookCategory.Delete((int)model.PkFieldIntVal);
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
        public async Task<PagedList<BookCategory>> GetPagedListItems(string searchStr, int pageNumber, int pageSize)
        {
            Expression<Func<BookCategory, bool>> filter = null;
            Func<IQueryable<BookCategory>, IOrderedQueryable<BookCategory>> orderBy = o => o.OrderByDescending(c => c.EnName);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.EnName.ToLower().Contains(searchStr) 
                || f.ArName.Contains(searchStr);
            }
            ViewBag.PageStartRowNum = ((pageNumber - 1) * pageSize) + 1;
            return await PagedList<BookCategory>.CreateAsync(_BookCategory.GetAllAsIQueryable(filter, orderBy),
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber,pageSize).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<BookCategory>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber,pageSize).Result);
            model.GetItemsUrl = "/BookCategory/GetItems";
            model.GetPaginationUrl = "/BookCategory/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion
    }
}
