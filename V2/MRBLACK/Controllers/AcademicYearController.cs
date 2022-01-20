using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
using Newtonsoft.Json;


namespace MRBLACK.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AcademicYearController : BaseController
    {
        private readonly Repository<AcademicYear> _AcademicYear;
        private readonly int PageSize;
        public AcademicYearController(IRepository<AcademicYear> AcademicYear)
        {
            _AcademicYear = (Repository<AcademicYear>)AcademicYear;
            PageSize = 5;
        }

        #region CRUD OPERTIONS

        #region Get AcademicYears
        public IActionResult Index(int pageNumber = 1,int pageSize = 5)
        {
            var model = GetIndexPageDetails("AcademicYear");
            return View(GetPagedListItems(model.SearchStr, model.PageNumber,model.PageSize).Result);
        }
        #endregion

        #region Create AcademicYear
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", new AcademicYear());
        }

        [HttpPost]
        public IActionResult Create(AcademicYear model)
        {
            if (ModelState.IsValid)
            {
                _AcademicYear.Add(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", model);
        }
        #endregion

        #region Edit AcademicYear
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            var model = _AcademicYear.GetElement(id);
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(AcademicYear model)
        {
            if (ModelState.IsValid)
            {
                _AcademicYear.Update(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Edit);
            return View("EditCreate", model);
        }
        #endregion

        #region Delete AcademicYear
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "AcademicYear",
                ActionName = nameof(Delete),
                Title = "حذف من شاشة السنين الدراسية",
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
                _AcademicYear.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                return Json(new { IsSuccess = false, Msg = "لا يمكن حذف هذه السنة الدراسية" });
            }

            return Json(new { IsSuccess = true, Msg = "تم الحذف بنجاح" });
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<AcademicYear>> GetPagedListItems(string searchStr, int pageNumber,int pageSize)
        {
            Expression<Func<AcademicYear, bool>> filter = null;
            Func<IQueryable<AcademicYear>, IOrderedQueryable<AcademicYear>> orderBy = o => o.OrderByDescending(c => c.ArName);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.EnName.ToLower().Contains(searchStr)
                || f.ArName.Contains(searchStr) || ("ay_"+f.Id.ToString()).Contains(searchStr);
            }
            
            CreateIndexPageDetailsCookie(new IndexPageDetailsVM()
            {
                ControllerName = "AcademicYear",
                SearchStr = searchStr,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return await PagedList<AcademicYear>.CreateAsync(_AcademicYear.GetAllAsIQueryable(filter, orderBy),
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber,pageSize).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<AcademicYear>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber,pageSize).Result);
            model.GetItemsUrl = "/AcademicYear/GetItems";
            model.GetPaginationUrl = "/AcademicYear/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion

        
    }
}
