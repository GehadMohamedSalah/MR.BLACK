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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MRBLACK.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class GroupController : BaseController
    {
        private readonly Repository<Group> _Group;
        private readonly Repository<Department> _department;
        private readonly int PageSize;
        public GroupController(IRepository<Group> Group
            ,IRepository<Department> department)
        {
            _Group = (Repository<Group>)Group;
            _department = (Repository<Department>)department;
            PageSize = 5;
        }

        #region CRUD OPERTIONS

        #region Get Groups
        public IActionResult Index(string searchStr = "", int pageNumber = 1, int pageSize = 5)
        {
            var model = GetIndexPageDetails("Group");
            if (searchStr != "" && searchStr != null)
                model.SearchStr = searchStr;
            return View(GetPagedListItems(model.SearchStr, model.PageNumber, model.PageSize).Result);
        }
        #endregion

        #region Create Group
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            var model = new GroupVM();
            model.DepartmentList = FillDropDownLists();
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Create(GroupVM model)
        {
            if (ModelState.IsValid)
            {
                List<string> arr = model.SelectedDept.Split("_").ToList();
                var newItem = new Group();
                newItem.ArName = model.ArName;
                newItem.EnName = model.EnName;
                newItem.DptCountryId = Int32.Parse(arr[0]);
                newItem.DptUniversityId = Int32.Parse(arr[1]);
                newItem.DptCollegeId = Int32.Parse(arr[2]);
                newItem.DepartmentId = Int32.Parse(arr[3]);
                _Group.Add(newItem);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Create);
            model.DepartmentList = FillDropDownLists();
            return View("EditCreate", model);
        }
        #endregion

        #region Edit Group
        public IActionResult Edit(int id)
        {
            var model = _Group.GetElement(id);
            var item = new GroupVM()
            {
                DepartmentList = FillDropDownLists(),
                Id = model.Id,
                ArName = model.ArName,
                EnName = model.EnName,
                SelectedDept = model.DptCountryId + "_" + model.DptUniversityId + "_" + model.DptCollegeId + "_" + model.DepartmentId
            };
            ViewBag.ActionName = nameof(Edit);
            return View("EditCreate", item);
        }

        [HttpPost]
        public IActionResult Edit(GroupVM model)
        {
            if (ModelState.IsValid)
            {
                List<string> arr = model.SelectedDept.Split("_").ToList();
                var item = _Group.GetElement(model.Id);
                item.ArName = model.ArName;
                item.EnName = model.EnName;
                item.DptCountryId = Int32.Parse(arr[0]);
                item.DptUniversityId = Int32.Parse(arr[1]);
                item.DptCollegeId = Int32.Parse(arr[2]);
                item.DepartmentId = Int32.Parse(arr[3]);
                _Group.Update(item);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Edit);
            model.DepartmentList = FillDropDownLists();
            return View("EditCreate", model);
        }
        #endregion

        #region Delete Group
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "Group",
                ActionName = nameof(Delete),
                Title = "حذف من شاشة المجموعات",
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
                _Group.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                return Json(new { IsSuccess = false, Msg = "لا يمكن حذف هذه المجموعة" });
            }

            return Json(new { IsSuccess = true, Msg = "تم الحذف بنجاح" });
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<Group>> GetPagedListItems(string searchStr, int pageNumber, int pageSize)
        {
            Expression<Func<Group, bool>> filter = null;
            Func<IQueryable<Group>, IOrderedQueryable<Group>> orderBy = o => o.OrderByDescending(c => c.ArName);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.EnName.ToLower().Contains(searchStr)
                || f.ArName.Contains(searchStr) || ("grp_" + f.Id.ToString()).Contains(searchStr)
                || f.Department.ArName.ToLower().Contains(searchStr);
            }

            CreateIndexPageDetailsCookie(new IndexPageDetailsVM()
            {
                ControllerName = "Group",
                SearchStr = searchStr,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return await PagedList<Group>.CreateAsync(_Group.GetAllAsIQueryable(filter, orderBy, "Department,Department.UcdsEductionManagement,Department.UcdsEductionManagement.College,Department.UcdsEductionManagement.University,Department.UcdsEductionManagement.University.Country"),
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber, pageSize).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<Group>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber, pageSize).Result);
            model.GetItemsUrl = "/Group/GetItems";
            model.GetPaginationUrl = "/Group/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion


        private List<SelectListItem> FillDropDownLists()
        {
            var depts = _department.GetAll(null, null, "UcdsEductionManagement,UcdsEductionManagement.University,UcdsEductionManagement.College,UcdsEductionManagement.University.Country");
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            if (depts != null && depts.Count() > 0)
            {
                foreach (var dpt in depts)
                {
                    if (dpt.UcdsEductionManagement != null && dpt.UcdsEductionManagement.Count() > 0)
                    {
                        foreach (var item in dpt.UcdsEductionManagement)
                        {
                            if (item.DepartmentId != null)
                            {
                                var myVal = item.University.CountryId + "_" + item.UniversityId + "_" + item.CollegeId + "_" + item.DepartmentId;
                                if (selectListItems.Where(c => c.Value == myVal).Count() == 0)
                                {
                                    selectListItems.Add(new SelectListItem()
                                    {
                                        Value = myVal,
                                        Text = item.Department.ArName + " - " + item.College.ArName + " - " + item.University.ArName + " - " + item.University.Country.ArName
                                    });
                                }
                            }
                        }
                    }
                }
            }

            return selectListItems;
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
                if (_Group.GetAll(c => c.ArName.ToLower() == name || c.EnName.ToLower() == name).Count() == 0)
                {
                    return true;
                }
            }
            else
            {
                if (_Group.GetAll(c => c.Id != Id && (c.ArName.ToLower() == name || c.EnName.ToLower() == name)).Count() == 0)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

    }
}
