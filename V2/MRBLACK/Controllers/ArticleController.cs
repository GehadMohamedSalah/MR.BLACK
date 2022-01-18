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
    public class ArticleController : BaseController
    {
        private readonly Repository<Article> _Article;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly Repository<ArticleCategory> _category;
        private readonly Repository<ArticleResource> _artResouce;

        public ArticleController(IRepository<Article> Article
            , IWebHostEnvironment webHostEnvironment
            ,IRepository<ArticleCategory> category,
            IRepository<ArticleResource> artResouce)
        {
            _Article = (Repository<Article>)Article;
            _webHostEnvironment = webHostEnvironment;
            _category = (Repository<ArticleCategory>)category;
            _artResouce = (Repository<ArticleResource>)artResouce;
        }

        #region CRUD OPERTIONS

        #region Get Articles
        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            var model = GetIndexPageDetails("Article");
            return View(GetPagedListItems(model.SearchStr, model.PageNumber, model.PageSize).Result);
        }
        #endregion

        #region Create Article
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            FillDropdownLists();
            return View("EditCreate", new Article() { ArticleResource = new List<ArticleResource>(),CreatedOn=DateTime.Now,PublishOn =DateTime.Now }) ;
        }

        [HttpPost]
        public IActionResult Create(Article model,IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    model.CreatedOn = DateTime.Now;
                    model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/Articles");
                }
                _Article.Add(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Create);
            FillDropdownLists();
            return View("EditCreate", model);
        }
        #endregion

        #region Edit Article
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            FillDropdownLists();
            var model = _Article.GetFirstOrDefault(c => c.Id == id, "ArticleResource");
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(Article model, IFormFile img, List<int> deletedResources)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/Articles");
                }
                if(deletedResources != null && deletedResources.Count > 0)
                {
                    foreach(var item in deletedResources)
                    {
                        _artResouce.Delete(item);
                    }
                }
                _Article.Update(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Edit);
            FillDropdownLists();
            return View("EditCreate", model);
        }
        #endregion

        #region Delete Article
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "Article",
                ActionName = nameof(Delete),
                Title = "حذف من المدونة",
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
                _Article.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                return Json(new { IsSuccess = false, Msg = "لا يمكن حذف هذا المقال" });
            }

            return Json(new { IsSuccess = true, Msg = "تم الحذف بنجاح" });
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<Article>> GetPagedListItems(string searchStr, int pageNumber, int pageSize)
        {
            Expression<Func<Article, bool>> filter = null;
            Func<IQueryable<Article>, IOrderedQueryable<Article>> orderBy = o => o.OrderByDescending(c => c.CreatedOn);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.EnName.ToLower().Contains(searchStr)
                || f.ArName.Contains(searchStr)
                || f.WriterName.ToLower().Contains(searchStr)
                || f.ArticleCategory.ArName.ToLower().Contains(searchStr)
                || f.CreatedOn.ToString().Contains(searchStr)
                || f.Id.ToString().Contains(searchStr);
            }

            CreateIndexPageDetailsCookie(new IndexPageDetailsVM()
            {
                ControllerName = "Article",
                SearchStr = searchStr,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return await PagedList<Article>.CreateAsync(_Article.GetAllAsIQueryable(filter, orderBy, "ArticleCategory"),
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber, pageSize).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<Article>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber, pageSize).Result);
            model.GetItemsUrl = "/Article/GetItems";
            model.GetPaginationUrl = "/Article/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion

        private void FillDropdownLists()
        {
            ViewBag.ArticleCategoryList = new SelectList(_category.GetAll(), "Id", "ArName");
        }

        public IActionResult RemoveImage(int id)
        {
            var item = _Article.GetElement(id);
            item.ImgPath = null;
            _Article.Update(item);
            return RedirectToAction(nameof(Index));
        }
    }
}
