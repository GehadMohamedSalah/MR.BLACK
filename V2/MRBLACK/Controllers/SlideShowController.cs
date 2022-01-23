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
    public class SlideShowController : BaseController
    {
        private readonly Repository<SlideShow> _SlideShow;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SlideShowController(IRepository<SlideShow> SlideShow
            , IWebHostEnvironment webHostEnvironment)
        {
            _SlideShow = (Repository<SlideShow>)SlideShow;
            _webHostEnvironment = webHostEnvironment;
        }

        #region CRUD OPERTIONS

        #region Get SlideShow Images
        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            var model = GetIndexPageDetails("SlideShow");
            return View(GetPagedListItems(model.SearchStr, model.PageNumber, model.PageSize).Result);
        }
        #endregion

        #region Create SlideShow
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", new SlideShow());
        }

        [HttpPost]
        public IActionResult Create(SlideShow model, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if(img != null)
                {
                    model.CreatedOn = DateTime.Now;
                    model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/SlideShow");
                    _SlideShow.Add(model);
                    return RedirectToAction(nameof(Index));
                }
                
            }
            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", model);
        }
        #endregion

        #region Edit SlideShow
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            var model = _SlideShow.GetElement(id);
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(SlideShow model,IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    model.GalleryImgId = null;
                    model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/SlideShow");
                }
                _SlideShow.Update(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Edit);
            return View("EditCreate", model);
        }
        #endregion

        #region Delete SlideShow
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "SlideShow",
                ActionName = nameof(Delete),
                Title = "حذف من الاسليدشو",
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
                _SlideShow.Delete((int)model.PkFieldIntVal);
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
        public async Task<PagedList<SlideShow>> GetPagedListItems(string searchStr, int pageNumber, int pageSize)
        {
            Expression<Func<SlideShow, bool>> filter = null;
            Func<IQueryable<SlideShow>, IOrderedQueryable<SlideShow>> orderBy = o => o.OrderByDescending(c => c.CreatedOn);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.CreatedOn.ToString().Contains(searchStr) 
               || (f.Link != null && f.Link.ToLower().Contains(searchStr)
               || (f.Text != null && f.Text.ToLower().Contains(searchStr)))
               || ("ssh_"  + f.Id.ToString()).Contains(searchStr);
            }

            CreateIndexPageDetailsCookie(new IndexPageDetailsVM()
            {
                ControllerName = "SlideShow",
                SearchStr = searchStr,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return await PagedList<SlideShow>.CreateAsync(_SlideShow.GetAllAsIQueryable(filter, orderBy,"Gallery"),
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber,pageSize).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<SlideShow>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber,pageSize).Result);
            model.GetItemsUrl = "/SlideShow/GetItems";
            model.GetPaginationUrl = "/SlideShow/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion
    }
}
