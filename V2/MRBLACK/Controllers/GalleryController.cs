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
using MRBLACK.Models.Enums;

namespace MRBLACK.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class GalleryController : BaseController
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
            var model = GetIndexPageDetails("Gallery");
            return View(GetPagedListItems(model.SearchStr, model.PageNumber, model.PageSize).Result);
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
                }
                _Gallery.Update(model);
                return RedirectToAction(nameof(Index));
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
        public IActionResult DeleteConfirmed(ConfirmDeleteVM model)
        {
            try
            {
                _Gallery.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                return Json(new { IsSuccess = false, Msg = "لا يمكن حذف هذه الصورة" });
            }

            return Json(new { IsSuccess = true, Msg = "تم الحذف بنجاح" });
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
                var cateId = 0;
                if ("التعليم الالكتروني (مستر بلاك بورد)".Contains(searchStr))
                    cateId = 1;
                if ("اعداد بحوث ورسائل علمية".Contains(searchStr))
                    cateId = 2;
                if ("ملخصات ومراجعات نهائية للمواد الجامعية".Contains(searchStr))
                    cateId = 3;
                if ("كتابة ابداعية وتفريغ نصي وكتابة محتوى".Contains(searchStr))
                    cateId = 4;
                if ("مشاريع التخرج".Contains(searchStr))
                    cateId = 5;

                filter = f => f.CreatedOn.ToString().Contains(searchStr)
                || (cateId != 0 && f.GalleryCategoryId == cateId);
            }

            CreateIndexPageDetailsCookie(new IndexPageDetailsVM()
            {
                ControllerName = "Gallery",
                SearchStr = searchStr,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

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
