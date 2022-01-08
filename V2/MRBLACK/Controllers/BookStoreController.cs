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
    public class BookStoreController : BaseController
    {
        private readonly Repository<BookStore> _BookStore;
        private readonly Repository<BookCategory> _BookCategory;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookStoreController(IRepository<BookStore> BookStore
             , IWebHostEnvironment webHostEnvironment
            ,IRepository<BookCategory> BookCategory)
        {
            _BookStore = (Repository<BookStore>)BookStore;
            _webHostEnvironment = webHostEnvironment;
            _BookCategory = (Repository<BookCategory>)BookCategory;
        }

        #region CRUD OPERTIONS

        #region Get BookStores
        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            var model = GetIndexPageDetails("BookStore");
            return View(GetPagedListItems(model.SearchStr, model.PageNumber, model.PageSize).Result);
        }
        #endregion

        #region Create BookStore
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            FillDropdownLists();
            return View("EditCreate", new BookStore());
        }

        [HttpPost]
        public IActionResult Create(BookStore model,IFormFile cover, IFormFile pdf, IFormFile voice)
        {
            if (ModelState.IsValid)
            {
                var books = _BookStore.GetAll(c => c.EnName.ToLower() == model.EnName.ToLower() || c.ArName.ToLower() == model.ArName.ToLower());
                if(books == null || books.Count() == 0)
                {
                    if (IsBookFilesValid(cover, pdf, voice))
                    {
                        if (cover != null)
                        {
                            model.BookCoverImgPath = FileHelper.UploadBookFile(_webHostEnvironment, model.EnName, cover);
                        }
                        if (pdf != null)
                        {
                            model.BookPdfPath = FileHelper.UploadBookFile(_webHostEnvironment, model.EnName, pdf);
                        }
                        if (voice != null)
                        {
                            model.BookVoicePath = FileHelper.UploadBookFile(_webHostEnvironment, model.EnName, voice);
                        }
                        _BookStore.Add(model);
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    ModelState.AddModelError("", "اسم هذا الكتاب موجود بالفعل لا يمكن تكراره");
                }
            }
            ViewBag.ActionName = nameof(Create);
            FillDropdownLists();
            return View("EditCreate", model);
        }
        #endregion

        #region Edit BookStore
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            FillDropdownLists();
            var model = _BookStore.GetElement(id);
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(BookStore model, IFormFile cover, IFormFile pdf, IFormFile voice)
        {
            if (ModelState.IsValid)
            {
                var books = _BookStore.GetAll(c => (c.EnName.ToLower() == model.EnName.ToLower() || c.ArName.ToLower() == model.ArName.ToLower()) && c.Id != model.Id);
                if(books == null || books.Count() == 0)
                {
                    if (IsBookFilesValid(cover, pdf, voice))
                    {
                        if (cover != null)
                        {
                            model.BookCoverImgPath = FileHelper.UploadBookFile(_webHostEnvironment, model.EnName, cover);
                        }
                        if (pdf != null)
                        {
                            model.BookPdfPath = FileHelper.UploadBookFile(_webHostEnvironment, model.EnName, pdf);
                        }
                        if (voice != null)
                        {
                            model.BookVoicePath = FileHelper.UploadBookFile(_webHostEnvironment, model.EnName, voice);
                        }
                        _BookStore.Update(model);
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    ModelState.AddModelError("", "اسم هذا الكتاب موجود بالفعل لا يمكن تكراره");
                }
            }
            ViewBag.ActionName = nameof(Edit);
            FillDropdownLists();
            return View("EditCreate", model);
        }
        #endregion

        #region Delete BookStore
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "BookStore",
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
                _BookStore.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                return Json(new { IsSuccess = false, Msg = "لا يمكن حذف هذا الكتاب" });
            }

            return Json(new { IsSuccess = true, Msg = "تم الحذف بنجاح" });
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<BookStore>> GetPagedListItems(string searchStr, int pageNumber, int pageSize)
        {
            Expression<Func<BookStore, bool>> filter = null;
            Func<IQueryable<BookStore>, IOrderedQueryable<BookStore>> orderBy = o => o.OrderByDescending(c => c.ArName);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.ArName.Contains(searchStr)
                || f.BookCategory.ArName.Contains(searchStr)
                || f.Price.ToString().Contains(searchStr)
                || f.ArAuthoreName.Contains(searchStr);
            }


            CreateIndexPageDetailsCookie(new IndexPageDetailsVM()
            {
                ControllerName = "BookStore",
                SearchStr = searchStr,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return await PagedList<BookStore>.CreateAsync(_BookStore.GetAllAsIQueryable(filter, orderBy, "BookCategory"),
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber,pageSize).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<BookStore>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber,pageSize).Result);
            model.GetItemsUrl = "/BookStore/GetItems";
            model.GetPaginationUrl = "/BookStore/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion

        private void FillDropdownLists()
        {
            ViewBag.BookCategoryList = new SelectList(_BookCategory.GetAll(), "Id", "ArName");
        }

        private bool IsBookFilesValid(IFormFile cover,IFormFile pdf, IFormFile voice)
        {
            var result = 0;
            if(cover != null)
            {
                if (cover.FileName.ToLower().Contains("jpg") || cover.FileName.ToLower().Contains("png") || cover.FileName.ToLower().Contains("jpeg"))
                {
                    
                }
                else
                {
                    ModelState.AddModelError("", "مسار صورة الغلاف خاطئ يجب ان يحتوي على jpg, png, jpeg فقط");
                    result++;
                }
            }
            if (pdf != null)
            {
                if (!pdf.FileName.ToLower().Contains("pdf"))
                {
                    ModelState.AddModelError("", "مسار الكتاب خاطئ يجب ان يكون pdf فقط");
                    result++;
                }
            }
            if (voice != null)
            {
                if (voice.FileName.ToLower().Contains("mb3"))
                {
                    ModelState.AddModelError("", "مسار الصوت خاطئ يجب ان يكون mb3 فقط");
                    result++;
                }
            }
            if (result == 0)
                return true;
            return false;

        }

    }
}
