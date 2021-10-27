using Microsoft.AspNetCore.Authorization;
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

namespace MRBLACK.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class DepartmentController : Controller
    {
        private readonly Repository<Department> _Department;
        private readonly int PageSize;
        public DepartmentController(IRepository<Department> Department)
        {
            _Department = (Repository<Department>)Department;
            PageSize = 5;
        }

        #region CRUD OPERTIONS

        #region Get Departments
        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            return View(GetPagedListItems("", pageNumber,pageSize).Result);
        }
        #endregion

        #region Create Department
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", new Department());
        }

        [HttpPost]
        public IActionResult Create(Department model)
        {
            if (ModelState.IsValid)
            {
                _Department.Add(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", model);
        }
        #endregion

        #region Edit Department
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            var model = _Department.GetElement(id);
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(Department model)
        {
            if (ModelState.IsValid)
            {
                _Department.Update(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Edit);
            return View("EditCreate", model);
        }
        #endregion

        #region Delete Department
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "Department",
                ActionName = nameof(Delete),
                Title = "حذف من شاشة الاقسام",
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
                _Department.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                ModelState.AddModelError("", "لا يمكن حذف هذا القسم");
                return View("_DeleteView", model);
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<Department>> GetPagedListItems(string searchStr, int pageNumber, int pageSize)
        {
            Expression<Func<Department, bool>> filter = null;
            Func<IQueryable<Department>, IOrderedQueryable<Department>> orderBy = o => o.OrderByDescending(c => c.ArName);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.EnName.ToLower().Contains(searchStr)
                || f.ArName.Contains(searchStr);
            }
            ViewBag.PageStartRowNum = ((pageNumber - 1) * pageSize) + 1;
            return await PagedList<Department>.CreateAsync(_Department.GetAllAsIQueryable(filter, orderBy),
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber,pageSize).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<Department>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber,pageSize).Result);
            model.GetItemsUrl = "/Department/GetItems";
            model.GetPaginationUrl = "/Department/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion
    }
}
