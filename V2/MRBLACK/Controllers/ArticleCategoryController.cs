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
    public class ArticleCategoryController : BaseController
    {
        private readonly Repository<ArticleCategory> _ArticleCategory;
        public ArticleCategoryController(IRepository<ArticleCategory> ArticleCategory)
        {
            _ArticleCategory = (Repository<ArticleCategory>)ArticleCategory;
        }

        #region CRUD OPERTIONS

        #region Get Article Categories
        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            var model = GetIndexPageDetails("ArticleCategory");
            return View(GetPagedListItems(model.SearchStr, model.PageNumber, model.PageSize).Result);
        }
        #endregion

        #region Create ArticleCategory
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", new ArticleCategory());
        }

        [HttpPost]
        public IActionResult Create(ArticleCategory model)
        {
            if (ModelState.IsValid)
            {
                _ArticleCategory.Add(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", model);
        }
        #endregion

        #region Edit ArticleCategory
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            var model = _ArticleCategory.GetElement(id);
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(ArticleCategory model)
        {
            if (ModelState.IsValid)
            {
                _ArticleCategory.Update(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Edit);
            return View("EditCreate", model);
        }
        #endregion

        #region Delete ArticleCategory
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "ArticleCategory",
                ActionName = nameof(Delete),
                Title = "حذف من شاشة تصنيفات المقال",
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
                _ArticleCategory.Delete((int)model.PkFieldIntVal);
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
        public async Task<PagedList<ArticleCategory>> GetPagedListItems(string searchStr, int pageNumber, int pageSize)
        {
            Expression<Func<ArticleCategory, bool>> filter = null;
            Func<IQueryable<ArticleCategory>, IOrderedQueryable<ArticleCategory>> orderBy = o => o.OrderByDescending(c => c.EnName);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.EnName.ToLower().Contains(searchStr) 
                || f.ArName.Contains(searchStr) || f.Id.ToString().Contains(searchStr);
            }

            CreateIndexPageDetailsCookie(new IndexPageDetailsVM()
            {
                ControllerName = "ArticleCategory",
                SearchStr = searchStr,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return await PagedList<ArticleCategory>.CreateAsync(_ArticleCategory.GetAllAsIQueryable(filter, orderBy),
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber,pageSize).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<ArticleCategory>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber,pageSize).Result);
            model.GetItemsUrl = "/ArticleCategory/GetItems";
            model.GetPaginationUrl = "/ArticleCategory/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion
    }
}
