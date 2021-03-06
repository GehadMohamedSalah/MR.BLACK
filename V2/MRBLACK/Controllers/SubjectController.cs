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
    public class SubjectController : BaseController
    {
        private readonly Repository<Subject> _Subject;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly Repository<UcdsEductionManagement> _ucds;

        public SubjectController(IRepository<Subject> Subject
            , IWebHostEnvironment webHostEnvironment
            , IRepository<UcdsEductionManagement> ucds)
        {
            _Subject = (Repository<Subject>)Subject;
            _webHostEnvironment = webHostEnvironment;
            _ucds = (Repository<UcdsEductionManagement>)ucds;
        }

        #region CRUD OPERTIONS

        #region Get Subjects
        public IActionResult Index(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = GetIndexPageDetails("Subject");
            if (searchStr != "" && searchStr != null)
                model.SearchStr = searchStr;
            return View(GetPagedListItems(model.SearchStr, model.PageNumber, model.PageSize).Result);
        }
        #endregion

        #region Create Subject
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            FillDropdownLists();
            return View("EditCreate", new Subject());
        }

        [HttpPost]
        public IActionResult Create(Subject model, IFormFile img,List<int> UCDS)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/Subjects");
                }
                _Subject.Add(model);
                AddDelSubjectsFromUCDS(model, UCDS);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Create);
            FillDropdownLists();
            return View("EditCreate", model);
        }
        #endregion

        #region Edit Subject
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            FillDropdownLists();
            var model = _Subject.GetFirstOrDefault(c => c.Id == id, "UcdsEductionManagement,UcdsEductionManagement.Department,UcdsEductionManagement.College,UcdsEductionManagement.University,UcdsEductionManagement.University.Country");
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(Subject model, IFormFile img,List<int> UCDS)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/Subjects");
                }
                _Subject.Update(model);
                AddDelSubjectsFromUCDS(model, UCDS);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Edit);
            FillDropdownLists();
            return View("EditCreate", model);
        }
        #endregion

        #region Delete Subject
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "Subject",
                ActionName = nameof(Delete),
                Title = "حذف من شاشة المواد",
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
                var item = _Subject.GetFirstOrDefault(c => c.Id == (int)model.PkFieldIntVal, "UcdsEductionManagement");
                if (item.UcdsEductionManagement != null && item.UcdsEductionManagement.Count() > 0)
                {
                    return Json(new { IsSuccess = false, Msg = "لا يمكن حذف هذه المادة" });
                }
                else
                {
                    _Subject.Delete((int)model.PkFieldIntVal);
                }
            }
            catch
            {
                return Json(new { IsSuccess = false, Msg = "لا يمكن حذف هذه المادة" });
            }

            return Json(new { IsSuccess = true, Msg = "تم الحذف بنجاح" });
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<Subject>> GetPagedListItems(string searchStr, int pageNumber, int pageSize)
        {
            Expression<Func<Subject, bool>> filter = null;
            Func<IQueryable<Subject>, IOrderedQueryable<Subject>> orderBy = o => o.OrderByDescending(c => c.ArName);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.EnName.ToLower().Contains(searchStr)
                || f.ArName.Contains(searchStr)
                || f.UcdsEductionManagement.Where(c => c.Department.ArName.ToLower().Contains(searchStr)).Count()>0
                || f.UcdsEductionManagement.Where(c => c.College.ArName.ToLower().Contains(searchStr)).Count()>0
                || f.UcdsEductionManagement.Where(c => c.University.ArName.ToLower().Contains(searchStr)).Count()>0
                || f.UcdsEductionManagement.Where(c => c.University.Country.ArName.ToLower().Contains(searchStr)).Count()>0
                || ("sub_"+f.Id.ToString()).Contains(searchStr);
            }

            CreateIndexPageDetailsCookie(new IndexPageDetailsVM()
            {
                ControllerName = "Subject",
                SearchStr = searchStr,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return await PagedList<Subject>.CreateAsync(_Subject.GetAllAsIQueryable(filter, orderBy, "UcdsEductionManagement,UcdsEductionManagement.Department,UcdsEductionManagement.College,UcdsEductionManagement.University,UcdsEductionManagement.University.Country,ServiceCategoryRequest,Service"),
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber,pageSize).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<Subject>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber,pageSize).Result);
            model.GetItemsUrl = "/Subject/GetItems";
            model.GetPaginationUrl = "/Subject/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion


        private void FillDropdownLists()
        {
            var ucds = _ucds.GetAll(c=> c.UniversityId != null && c.CollegeId != null && c.DepartmentId != null, null, "University,College,Department,University.Country").ToList();
            var lst = new List<UcdsEductionManagement>();
            if (ucds != null && ucds.Count() > 0)
            {
                foreach (var item in ucds)
                {
                    if (lst.Where(c => c.University.CountryId == item.University.CountryId
                     && c.UniversityId == item.UniversityId
                     && c.CollegeId == item.CollegeId
                     && c.DepartmentId == item.DepartmentId).Count() == 0)
                    {
                        lst.Add(item);
                    }
                }
            }

            ViewBag.DepartmentCollegeUniversityCountryList = lst;
        }

        private void AddDelSubjectsFromUCDS(Subject model, List<int> UCDS)
        {
            try
            {
                var oldUCDS = new List<UcdsEductionManagement>();
                oldUCDS = _ucds.GetAll(c => c.SubjectId == model.Id).ToList();
                if (oldUCDS != null && oldUCDS.Count() > 0)
                {
                    oldUCDS.ForEach(c =>
                    {
                        c.SubjectId = null;
                        _ucds.Update(c);
                    });
                }

                foreach (var item in UCDS)
                {
                    var ucds = _ucds.GetElement(item);
                    if (ucds.SubjectId == null)
                    {
                        ucds.SubjectId = model.Id;
                        _ucds.Update(ucds);
                    }
                    else
                    {
                        var newUcds = new UcdsEductionManagement()
                        {
                            UniversityId = ucds.UniversityId,
                            CollegeId = ucds.CollegeId,
                            DepartmentId = ucds.DepartmentId,
                            SubjectId = model.Id
                        };
                        _ucds.Add(newUcds);
                    }
                }
            }
            catch (Exception e)
            {
                var x = e.Message;
            }
        }

        public IActionResult RemoveImage(int id)
        {
            var item = _Subject.GetElement(id);
            item.ImgPath = null;
            _Subject.Update(item);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult SubjectDepartments(int id)
        {
            var model = _Subject.GetFirstOrDefault(c => c.Id == id , "UcdsEductionManagement,UcdsEductionManagement.University,UcdsEductionManagement.College,UcdsEductionManagement.University.Country,UcdsEductionManagement.Department");
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
                if (_Subject.GetAll(c => c.ArName.ToLower() == name || c.EnName.ToLower() == name).Count() == 0)
                {
                    return true;
                }
            }
            else
            {
                if (_Subject.GetAll(c => c.Id != Id && (c.ArName.ToLower() == name || c.EnName.ToLower() == name)).Count() == 0)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

    }
}
