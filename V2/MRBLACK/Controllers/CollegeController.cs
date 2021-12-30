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
    public class CollegeController : Controller
    {
        private readonly Repository<College> _College;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly Repository<Country> _country;
        private readonly Repository<University> _university;
        private readonly Repository<UcdsEductionManagement> _ucds;
        public CollegeController(IRepository<College> College
            , IWebHostEnvironment webHostEnvironment
            ,IRepository<Country> country
            ,IRepository<University> university,
            IRepository<UcdsEductionManagement> ucds)
        {
            _College = (Repository<College>)College;
            _webHostEnvironment = webHostEnvironment;
            _country = (Repository<Country>)country;
            _university = (Repository<University>)university;
            _ucds = (Repository<UcdsEductionManagement>)ucds;
        }

        #region CRUD OPERTIONS

        #region Get College
        public IActionResult Index(string searchStr = "", int pageNumber = 1, int pageSize = 5)
        {
            ViewBag.searchStr = searchStr;
            return View(GetPagedListItems(searchStr, pageNumber,pageSize).Result);
        }
        #endregion

        #region Create College
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            FillDropdownLists(null);
            return View("EditCreate", new College() { UcdsEductionManagement = new List<UcdsEductionManagement>()});
        }

        [HttpPost]
        public IActionResult Create(College model, IFormFile img,List<int> Universities)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/Colleges");
                }

                model = AddDelUniversityFromUCDS(model, Universities);

                _College.Add(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Create);
            FillDropdownLists(null);
            return View("EditCreate", model);
        }
        #endregion

        #region Edit College
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            var model = _College.GetFirstOrDefault(c => c.Id == id, "UcdsEductionManagement,UcdsEductionManagement.University,UcdsEductionManagement.University.Country");
            FillDropdownLists(model);
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(College model, IFormFile img,List<int> Universities)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    model.ImgPath = FileHelper.UploadFile(img, _webHostEnvironment, "Uploads/Images/Colleges");
                }

                model = AddDelUniversityFromUCDS(model, Universities);
                
                _College.Update(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Edit);
            FillDropdownLists(model);
            return View("EditCreate", model);
        }
        #endregion

        #region Delete College
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "College",
                ActionName = nameof(Delete),
                Title = "حذف من شاشة الكليات",
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
                _College.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                return Json(new { IsSuccess = false, Msg = "لا يمكن حذف هذه الكلية" });
            }

            return Json(new { IsSuccess = true, Msg = "تم الحذف بنجاح" });
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<College>> GetPagedListItems(string searchStr, int pageNumber, int pageSize)
        {
            Expression<Func<College, bool>> filter = null;
            Func<IQueryable<College>, IOrderedQueryable<College>> orderBy = o => o.OrderByDescending(c => c.ArName);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.EnName.ToLower().Contains(searchStr)
                || f.ArName.Contains(searchStr)
                || f.UcdsEductionManagement.Any(c => c.University.ArName.ToLower().Contains(searchStr));
            }
            ViewBag.PageStartRowNum = ((pageNumber - 1) * pageSize) + 1;
            return await PagedList<College>.CreateAsync(_College.GetAllAsIQueryable(filter, orderBy, "UcdsEductionManagement,UcdsEductionManagement.University,UcdsEductionManagement.University.Country"),
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber,pageSize).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<College>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber,pageSize).Result);
            model.GetItemsUrl = "/College/GetItems";
            model.GetPaginationUrl = "/College/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion

        private void FillDropdownLists(College college)
        {
            ViewBag.UniversityCountryList = _university.GetAll(null, null, "Country");
        }

        private College AddDelUniversityFromUCDS(College model,List<int> Universities)
        {
            model.UcdsEductionManagement = new List<UcdsEductionManagement>();
            var oldsuc = new List<UcdsEductionManagement>();
            var newsuc = new List<UcdsEductionManagement>();

            if (model.Id>0)
                   oldsuc = _ucds.GetAll(c => c.CollegeId == model.Id).ToList();

            //add new universities to model
            if (Universities != null && Universities.Count() > 0)
            {
                foreach (var item in Universities)
                {
                    if (oldsuc.Where(c => c.UniversityId == item).Count() == 0)
                    {
                        model.UcdsEductionManagement.Add(new UcdsEductionManagement()
                        {
                            UniversityId = item
                        });
                    }
                    newsuc.Add(new UcdsEductionManagement()
                    {
                        UniversityId = item
                    });
                }
            }

            //delete old universities that is not exist in new one
            if (newsuc != null && newsuc.Count() > 0
                && oldsuc != null && oldsuc.Count() > 0)
            {
                var deletedItems = new List<UcdsEductionManagement>();
                foreach (var x in oldsuc)
                {
                    var m = Universities.Where(c => c == x.UniversityId).Count();
                    if (m == 0)
                    {
                        deletedItems.Add(x);
                    }
                }
                
                if (deletedItems != null && deletedItems.Count() > 0)
                {
                    foreach (var item in deletedItems)
                    {
                        _ucds.Delete(item.Id);
                    }
                }
            }
            return model;
        }

        public IActionResult RemoveImage(int id)
        {
            var item = _College.GetElement(id);
            item.ImgPath = null;
            _College.Update(item);
            return RedirectToAction(nameof(Index));
        }
    }
}
