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
    public class SubjectController : Controller
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
            ViewBag.searchStr = searchStr;
            return View(GetPagedListItems(searchStr, pageNumber,pageSize).Result);
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
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(ConfirmDeleteVM model)
        {
            try
            {
                _Subject.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                ModelState.AddModelError("", "لا يمكن حذف هذه المادة");
                return View("_DeleteView", model);
            }

            return RedirectToAction(nameof(Index));
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
                || f.UcdsEductionManagement.Any(c => c.Department.ArName.ToLower().Contains(searchStr))
                || f.UcdsEductionManagement.Any(c => c.College.ArName.ToLower().Contains(searchStr))
                || f.UcdsEductionManagement.Any(c => c.University.ArName.ToLower().Contains(searchStr))
                || f.UcdsEductionManagement.Any(c => c.University.Country.ArName.ToLower().Contains(searchStr));
            }
            ViewBag.PageStartRowNum = ((pageNumber - 1) * pageSize) + 1;
            return await PagedList<Subject>.CreateAsync(_Subject.GetAllAsIQueryable(filter, orderBy, "UcdsEductionManagement,UcdsEductionManagement.Department,UcdsEductionManagement.College,UcdsEductionManagement.University,UcdsEductionManagement.University.Country"),
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
            var ucds = _ucds.GetAll(null, null, "University,College,Department,University.Country").ToList();
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

    }
}
