using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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

namespace MRBLACK.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class DepartmentController : BaseController
    {
        private readonly Repository<Department> _Department;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly Repository<UcdsEductionManagement> _ucds;
        private readonly Repository<Group> _group;
        public DepartmentController(IRepository<Department> Department
            , IWebHostEnvironment webHostEnvironment
            , IRepository<UcdsEductionManagement> ucds
            , IRepository<Group> group)
        {
            _Department = (Repository<Department>)Department;
            _webHostEnvironment = webHostEnvironment;
            _ucds = (Repository<UcdsEductionManagement>)ucds;
            _group = (Repository<Group>)group;
        }

        #region CRUD OPERTIONS

        #region Get Departments
        public IActionResult Index(string searchStr = "", int pageNumber = 1, int pageSize = 5)
        {
            var model = GetIndexPageDetails("Department");
            if (searchStr != "" && searchStr != null)
                model.SearchStr = searchStr;
            return View(GetPagedListItems(model.SearchStr, model.PageNumber, model.PageSize).Result);
        }
        #endregion

        #region Create Department
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            FillDropdownLists();
            return View("EditCreate", new Department());
        }

        [HttpPost]
        public IActionResult Create(Department model, IFormFile img, List<int> UCDS)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/Departments");
                }
                _Department.Add(model);
                AddDelDepartmentsFromUCDS(model, UCDS);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Create);
            FillDropdownLists();
            return View("EditCreate", model);
        }
        #endregion

        #region Edit Department
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            FillDropdownLists();
            var model = _Department.GetFirstOrDefault(c => c.Id == id, "UcdsEductionManagement,UcdsEductionManagement.College,UcdsEductionManagement.University,UcdsEductionManagement.University.Country");
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(Department model, IFormFile img, List<int> UCDS)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/Departments");
                }
                _Department.Update(model);
                AddDelDepartmentsFromUCDS(model, UCDS);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Edit);
            FillDropdownLists();
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
        public IActionResult DeleteConfirmed(ConfirmDeleteVM model)
        {
            try
            {
                var item = _Department.GetFirstOrDefault(c => c.Id == (int)model.PkFieldIntVal, "UcdsEductionManagement,Groups");
                if (item.UcdsEductionManagement.Where(c => c.SubjectId != null) != null && item.UcdsEductionManagement.Where(c => c.SubjectId != null).Count() > 0
                    && item.Groups != null && item.Groups.Count() > 0)
                {
                    return Json(new { IsSuccess = false, Msg = "لا يمكن حذف هذا القسم" });
                }
                else
                {
                    List<UcdsEductionManagement> ucds = new List<UcdsEductionManagement>();
                    ucds = item.UcdsEductionManagement.ToList();
                    ucds.ForEach(c =>
                    {
                        c.DepartmentId = null;
                        _ucds.Update(c);
                    });

                    _Department.Delete((int)model.PkFieldIntVal);
                }
            }
            catch (Exception e)
            {
                return Json(new { IsSuccess = false, Msg = e.InnerException });
            }

            return Json(new { IsSuccess = true, Msg = "تم الحذف بنجاح" });
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
                var searchlist = new List<string>();
                if (searchStr.Contains("_"))
                {
                    searchlist = searchStr.Split("_").ToList();
                }
                filter = f => f.EnName.ToLower().Contains(searchStr)
                || f.ArName.Contains(searchStr)
                || f.UcdsEductionManagement.Any(c => c.College.ArName.ToLower().Contains(searchStr))
                || f.UcdsEductionManagement.Any(c => c.University.ArName.ToLower().Contains(searchStr))
                || f.UcdsEductionManagement.Any(c => c.University.Country.ArName.ToLower().Contains(searchStr))
                || ("dpt_" + f.Id.ToString()).Contains(searchStr)
                || searchlist.Contains(f.ArName.ToLower());
            }

            CreateIndexPageDetailsCookie(new IndexPageDetailsVM()
            {
                ControllerName = "Department",
                SearchStr = searchStr,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return await PagedList<Department>.CreateAsync(_Department.GetAllAsIQueryable(filter, orderBy, "UcdsEductionManagement,UcdsEductionManagement.College,UcdsEductionManagement.University,UcdsEductionManagement.University.Country,Groups"),
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber, pageSize).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<Department>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber, pageSize).Result);
            model.GetItemsUrl = "/Department/GetItems";
            model.GetPaginationUrl = "/Department/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion


        private void FillDropdownLists()
        {
            var ucds = new List<UcdsEductionManagement>();
            ucds = _ucds.GetAll(c => c.UniversityId != null && c.CollegeId != null, null, "University,College,University.Country").ToList();
            var lst = new List<UcdsEductionManagement>();
            if (ucds != null && ucds.Count() > 0)
            {
                foreach (var item in ucds)
                {
                    if (lst.Where(c => c.University.CountryId == item.University.CountryId
                     && c.UniversityId == item.UniversityId
                     && c.CollegeId == item.CollegeId).Count() == 0)
                    {
                        lst.Add(item);
                    }
                }
            }

            ViewBag.CollegeUniversityCountryList = lst;
        }

        private void AddDelDepartmentsFromUCDS(Department model, List<int> UCDS)
        {
            try
            {
                var oldUCDS = new List<UcdsEductionManagement>();
                oldUCDS = _ucds.GetAll(c => c.DepartmentId == model.Id).ToList();
                var deptGroups = new List<Group>();
                if (model != null && model.Id > 0)
                {
                    deptGroups = _group.GetAll(c => c.DepartmentId == model.Id).ToList();
                }

                if (oldUCDS != null && oldUCDS.Count() > 0)
                {
                    oldUCDS.ForEach(c =>
                    {
                        c.DepartmentId = null;
                        _ucds.Update(c);
                    });
                }

                List<UcdsEductionManagement> newItems = new List<UcdsEductionManagement>();

                foreach (var item in UCDS)
                {
                    var ucds = _ucds.GetElement(item);
                    if (ucds.DepartmentId == null)
                    {
                        ucds.DepartmentId = model.Id;
                        _ucds.Update(ucds);
                        newItems.Add(ucds);
                    }
                    else
                    {
                        var newUcds = new UcdsEductionManagement()
                        {
                            UniversityId = ucds.UniversityId,
                            CollegeId = ucds.CollegeId,
                            DepartmentId = model.Id
                        };
                        _ucds.Add(newUcds);
                        newItems.Add(newUcds);
                    }
                }

                var deletedGroups = new List<Group>();
                foreach (var group in deptGroups)
                {
                    var check = newItems.Where(c => c.CollegeId == group.DptCollegeId && c.UniversityId == group.DptUniversityId).ToList();
                    if (check == null || check.Count == 0)
                    {
                        deletedGroups.Add(group);
                    }
                }

                if(deletedGroups != null && deletedGroups.Count()>0)
                    _group.DeleteRange(deletedGroups);

            }
            catch (Exception e)
            {
                var x = e.Message;
            }
        }

        public IActionResult RemoveImage(int id)
        {
            var item = _Department.GetElement(id);
            item.ImgPath = null;
            _Department.Update(item);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DepartmentColleges(int id)
        {
            var model = _Department.GetFirstOrDefault(c => c.Id == id, "UcdsEductionManagement,UcdsEductionManagement.University,UcdsEductionManagement.College,UcdsEductionManagement.University.Country");
            return View(model);
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
                if (_Department.GetAll(c => c.ArName.ToLower() == name || c.EnName.ToLower() == name).Count() == 0)
                {
                    return true;
                }
            }
            else
            {
                if (_Department.GetAll(c => c.Id != Id && (c.ArName.ToLower() == name || c.EnName.ToLower() == name)).Count() == 0)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

    }
}
