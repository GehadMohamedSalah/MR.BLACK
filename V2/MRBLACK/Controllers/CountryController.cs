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
    public class CountryController : BaseController
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
        public IActionResult Index(string searchStr = "", int pageNumber = 1, int pageSize = 5)
        {
            var model = GetIndexPageDetails("Country");
            if (searchStr != "" && searchStr != null)
                model.SearchStr = searchStr;
            return View(GetPagedListItems(model.SearchStr, model.PageNumber, model.PageSize).Result);
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
        public IActionResult DeleteConfirmed(ConfirmDeleteVM model)
        {
            try
            {
                var item = _Country.GetFirstOrDefault(c => c.Id == (int)model.PkFieldIntVal, "University");
                if(item.University != null && item.University.Count() > 0)
                {
                    return Json(new { IsSuccess = false, Msg = "لا يمكن حذف هذه الدولة" });
                }
                else
                {
                    _Country.Delete((int)model.PkFieldIntVal);
                }
            }
            catch
            {
                return Json(new { IsSuccess = false, Msg = "لا يمكن حذف هذه الدولة" });
            }

            return Json(new { IsSuccess = true, Msg = "تم الحذف بنجاح" });
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
                var searchlist = new List<string>();
                if (searchStr.Contains("_"))
                {
                    searchlist = searchStr.Split("_").ToList();
                }

                filter = f => f.EnName.ToLower().Contains(searchStr) 
                || f.ArName.Contains(searchStr)
                || f.CurrencyType.ArName.Contains(searchStr)
                || ("ctry_"+f.Id.ToString()).Contains(searchStr)
                || f.CountryCode.ToLower().Contains(searchStr)
                || searchlist.Contains(f.ArName.ToLower());
            }

            CreateIndexPageDetailsCookie(new IndexPageDetailsVM()
            {
                ControllerName = "Country",
                SearchStr = searchStr,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

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

        public IActionResult GetCountryCode(int id)
        {
            var country = _Country.GetElement(id);
            return Json(country.CountryCode);
        }


        #region Remote Validation Functions
        public bool IsUniqueRow(string EnName, string ArName, int Id)
        {
            var name = "";
            if (EnName != null)
                name = EnName.ToLower();
            else if (ArName != null)
                name = ArName.ToLower();
            if (Id == 0)
            {
                if (_Country.GetAll(c => c.ArName.ToLower() == name || c.EnName.ToLower() == name).Count() == 0)
                {
                    return true;
                }
            }
            else
            {
                if (_Country.GetAll(c => c.Id != Id && (c.ArName.ToLower() == name || c.EnName.ToLower() == name)).Count() == 0)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}
