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
    public class CountryController : Controller
    {
        private readonly Repository<Country> _Country;
        private readonly Repository<CurrencyType> _CurrencyType;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CountryController(IRepository<Country> Country,
            IRepository<CurrencyType> CurrencyType
            , IWebHostEnvironment webHostEnvironment)
        {
            _Country = (Repository<Country>)Country;
            _CurrencyType = (Repository<CurrencyType>)CurrencyType;
            _webHostEnvironment = webHostEnvironment;
        }

        #region CRUD OPERTIONS

        #region Get Countries
        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            return View(GetPagedListItems("", pageNumber,pageSize).Result);
        }
        #endregion

        #region Create Country
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            ViewBag.CurrencyTypeList = new SelectList(_CurrencyType.GetAll(), "Id", "ArName");
            return View("EditCreate", new Country());
        }

        [HttpPost]
        public IActionResult Create(Country model, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if(img != null)
                {
                    model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/Countries");
                }
                _Country.Add(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Create);
            ViewBag.CurrencyTypeList = new SelectList(_CurrencyType.GetAll(), "Id", "ArName");
            return View("EditCreate", model);
        }
        #endregion

        #region Edit Country
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            ViewBag.CurrencyTypeList = new SelectList(_CurrencyType.GetAll(), "Id", "ArName");
            var model = _Country.GetElement(id);
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(Country model,IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/Countries");
                }
                _Country.Update(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Edit);
            ViewBag.CurrencyTypeList = new SelectList(_CurrencyType.GetAll(), "Id", "ArName");
            return View("EditCreate", model);
        }
        #endregion

        #region Delete Country
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "Country",
                ActionName = nameof(Delete),
                Title = "حذف من شاشة انواع الدول",
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
                _Country.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                ModelState.AddModelError("", "لا يمكن حذف هذه الدولة");
                return View("_DeleteView", model);
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<Country>> GetPagedListItems(string searchStr, int pageNumber, int pageSize)
        {
            Expression<Func<Country, bool>> filter = null;
            Func<IQueryable<Country>, IOrderedQueryable<Country>> orderBy = o => o.OrderByDescending(c => c.EnName);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.EnName.ToLower().Contains(searchStr) 
                || f.ArName.Contains(searchStr)
                || f.CurrencyType.ArName.Contains(searchStr);
            }
            ViewBag.PageStartRowNum = ((pageNumber - 1) * pageSize) + 1;
            return await PagedList<Country>.CreateAsync(_Country.GetAllAsIQueryable(filter, orderBy,"CurrencyType,University"),
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber,pageSize).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<Country>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber,pageSize).Result);
            model.GetItemsUrl = "/Country/GetItems";
            model.GetPaginationUrl = "/Country/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion


        public IActionResult RemoveImage(int id)
        {
            var item = _Country.GetElement(id);
            item.ImgPath = null;
            _Country.Update(item);
            return RedirectToAction(nameof(Index));
        }
    }
}
