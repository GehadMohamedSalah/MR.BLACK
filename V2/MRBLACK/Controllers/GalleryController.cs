﻿using Microsoft.AspNetCore.Authorization;
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
using MRBLACK.Models.Enums;

namespace MRBLACK.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class GalleryController : Controller
    {
        private readonly Repository<Gallery> _Gallery;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly Repository<SlideShow> _SlideShow;
        public GalleryController(IRepository<Gallery> Gallery
            , IWebHostEnvironment webHostEnvironment
            , IRepository<SlideShow> SlideShow)
        {
            _Gallery = (Repository<Gallery>)Gallery;
            _webHostEnvironment = webHostEnvironment;
            _SlideShow = (Repository<SlideShow>)SlideShow;
        }

        #region CRUD OPERTIONS

        #region Get Gallery Images
        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            return View(GetPagedListItems("", pageNumber,pageSize).Result);
        }
        #endregion

        #region Create Gallery
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", new Gallery());
        }

        [HttpPost]
        public IActionResult Create(Gallery model, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if(img != null)
                {
                    model.CreatedOn = DateTime.Now;
                    model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/Gallery");
                    _Gallery.Add(model);
                    return RedirectToAction(nameof(Index));
                }
                
            }
            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", model);
        }
        #endregion

        #region Edit Gallery
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            var model = _Gallery.GetElement(id);
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(Gallery model,IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    model.CreatedOn = DateTime.Now;
                    model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/Gallery");
                    _Gallery.Update(model);
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.ActionName = nameof(Edit);
            return View("EditCreate", model);
        }
        #endregion

        #region Delete Gallery
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "Gallery",
                ActionName = nameof(Delete),
                Title = "حذف من معرض الصور",
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
                _Gallery.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                ModelState.AddModelError("", "لا يمكن حذف هذه الصورة من المعرض");
                return View("_DeleteView", model);
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<Gallery>> GetPagedListItems(string searchStr, int pageNumber, int pageSize)
        {
            Expression<Func<Gallery, bool>> filter = null;
            Func<IQueryable<Gallery>, IOrderedQueryable<Gallery>> orderBy = o => o.OrderBy(c => c.GalleryCategoryId);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.CreatedOn.ToString().Contains(searchStr);
            }
            ViewBag.PageStartRowNum = ((pageNumber - 1) * pageSize) + 1;
            return await PagedList<Gallery>.CreateAsync(_Gallery.GetAllAsIQueryable(filter, orderBy, "SlideShow"),
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber,pageSize).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<Gallery>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber,pageSize).Result);
            model.GetItemsUrl = "/Gallery/GetItems";
            model.GetPaginationUrl = "/Gallery/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion

        public IActionResult AddToSlideShow(int id)
        {
            var model = new SlideShow()
            {
                Id = 0,
                GalleryImgId = id,
                Gallery = _Gallery.GetElement(id)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddToSlideShow(SlideShow model)
        {
            if (ModelState.IsValid)
            {
                model.Id = 0;
                model.CreatedOn = DateTime.Now;
                _SlideShow.Add(model);
                return RedirectToAction("Index", "SlideShow");
            }
            return View(model);
        }

    }
}