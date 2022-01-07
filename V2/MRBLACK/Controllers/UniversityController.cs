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
    public class UniversityController : BaseController
    {
        private readonly Repository<University> _University;
        private readonly Repository<Country> _Country;
        private readonly IWebHostEnvironment _webHostEnvironment;
        //private readonly int PageSize;
        public UniversityController(IRepository<University> University,
            IRepository<Country> Country
            , IWebHostEnvironment webHostEnvironment)
        {
            _University = (Repository<University>)University;
            _Country = (Repository<Country>)Country;
            //PageSize = 5;
            _webHostEnvironment = webHostEnvironment;
        }

        #region CRUD OPERTIONS

        #region Get Universities
        public IActionResult Index(string searchStr = "" ,int pageNumber = 1, int pageSize = 5)
        {
            var model = GetIndexPageDetails("University");
            if (searchStr != "" && searchStr != null)
                model.SearchStr = searchStr;
            return View(GetPagedListItems(model.SearchStr, model.PageNumber, model.PageSize).Result);
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
        public IActionResult Create(University model, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/Universities");
                }
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
        public IActionResult Edit(University model, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/Universities");
                }
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
        public IActionResult DeleteConfirmed(ConfirmDeleteVM model)
        {
            try
            {
                var item = _University.GetFirstOrDefault(c => c.Id == (int)model.PkFieldIntVal, "UcdsEductionManagement");
                if (item.UcdsEductionManagement != null && item.UcdsEductionManagement.Count() > 0)
                {
                    return Json(new { IsSuccess = false, Msg = "لا يمكن حذف هذه الجامعة" });
                }
                else
                {
                    _University.Delete((int)model.PkFieldIntVal);
                }
            }
            catch
            {
                return Json(new { IsSuccess = false, Msg = "لا يمكن حذف هذه الجامعة" });
            }

            return Json(new { IsSuccess = true, Msg = "تم الحذف بنجاح" });
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<University>> GetPagedListItems(string searchStr, int pageNumber, int pageSize)
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

            CreateIndexPageDetailsCookie(new IndexPageDetailsVM()
            {
                ControllerName = "University",
                SearchStr = searchStr,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return await PagedList<University>.CreateAsync(_University.GetAllAsIQueryable(filter, orderBy, "Country,UcdsEductionManagement"),
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber,pageSize).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<University>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber,pageSize).Result);
            model.GetItemsUrl = "/University/GetItems";
            model.GetPaginationUrl = "/University/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion

        public IActionResult RemoveImage(int id)
        {
            var item = _University.GetElement(id);
            item.ImgPath = null;
            _University.Update(item);
            return RedirectToAction(nameof(Index));
        }
    }
}
