using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MRBLACK.Areas.Identity.Data;
using MRBLACK.Data;
using MRBLACK.Helper;
using MRBLACK.Models.Database;
using MRBLACK.Models.ViewModels;
using MRBLACK.Repository;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace MRBLACK.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class MembershipController : BaseController
    {
        private readonly Repository<Membership> _Membership;
        private readonly Repository<MembershipLink> _MembershipLink;
        private readonly IdentitySetupContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly Repository<Student> _student;
        private readonly Repository<ServiceProvider> _provider;
        public MembershipController(IRepository<Membership> Membership,
            IdentitySetupContext context,
            IRepository<MembershipLink> MembershipLink,
            IWebHostEnvironment webHostEnvironment
            , IRepository<Student> student
            , IRepository<ServiceProvider> provider)
        {
            _Membership = (Repository<Membership>)Membership;
            _context = context;
            _MembershipLink = (Repository<MembershipLink>)MembershipLink;
            _webHostEnvironment = webHostEnvironment;
            _student = (Repository<Student>)student;
            _provider = (Repository<ServiceProvider>)provider;
        }

        #region CRUD OPERTIONS

        #region Get Memberships
        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            var model = GetIndexPageDetails("Membership");
            return View(GetPagedListItems(model.SearchStr, model.PageNumber, model.PageSize).Result);
        }
        #endregion

        #region Create Membership
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", new MembershipVM() { MembershipLinkList = new List<MembershipLink>() });
        }

        [HttpPost]
        public IActionResult Create(MembershipVM model)
        {
            if (ModelState.IsValid)
            {
                //upload image 
                var filePath = FileHelper.UploadFile(model.FormFile, _webHostEnvironment, "Images");

                //create obj form Membership
                var ms = new Membership()
                {
                    ArName = model.ArName,
                    EnName = model.EnName,
                    ImgPath = filePath,
                    MembershipType = model.MembershipType
                };

                //add list of links to Membership obj
                if (model.MembershipLinkList != null)
                {
                    foreach (var item in model.MembershipLinkList)
                    {
                        ms.MembershipLink.Add(item);
                    }
                }

                //save Membership obj
                _Membership.Add(ms);

                //create role for Membership obj
                CreateRoleForMembership(ms);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", model);
        }

        #endregion

        #region Edit Membership
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);

            //get Membership obj with it's links
            Expression<Func<Membership, bool>> filter = f => f.Id == id;
            var ms = _Membership.GetFirstOrDefault(c => c.Id == id, "MembershipLink");

            //set Membership obj to MembershipVM
            var model = new MembershipVM();
            if (ms != null)
            {
                model.Id = ms.Id;
                model.EnName = ms.EnName;
                model.ArName = ms.ArName;
                model.ImgPath = ms.ImgPath;
                model.MembershipType = (int)ms.MembershipType;
                model.MembershipLinkList = new List<MembershipLink>();
                model.MembershipLinkList.AddRange(ms.MembershipLink);
            }
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(MembershipVM model)
        {
            if (ModelState.IsValid)
            {
                //get MembershipVM obj
                var ms = _Membership.GetElement(model.Id);

                //set new values to Membership obj
                ms.EnName = model.EnName;
                ms.ArName = model.ArName;
                ms.MembershipType = model.MembershipType;
                //upload image
                if (model.FormFile != null)
                {
                    ms.ImgPath = FileHelper.UploadFile(model.FormFile, _webHostEnvironment, "Images");
                }

                //add Membership links to Membership obj
                if (model.MembershipLinkList != null)
                {
                    foreach (var item in model.MembershipLinkList)
                    {
                        ms.MembershipLink.Add(item);
                    }
                }

                //save Membership obj updates
                _Membership.Update(ms);

                //update role of Membership obj 
                UpdateRoleForMembership(ms);

                //delete links of Membership obj
                DeleteMembershipLinks(model.DeletedLinks);

                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Edit);
            return View("EditCreate", model);
        }
        #endregion

        #region Delete Membership
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "Membership",
                ActionName = nameof(Delete),
                Title = "حذف من شاشة العضويات",
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
                _Membership.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                return Json(new { IsSuccess = false, Msg = "لا يمكن حذف هذه العضوية" });
            }

            return Json(new { IsSuccess = true, Msg = "تم الحذف بنجاح" });
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<Membership>> GetPagedListItems(string searchStr, int pageNumber, int pageSize = 5)
        {
            Expression<Func<Membership, bool>> filter = null;
            Func<IQueryable<Membership>, IOrderedQueryable<Membership>> orderBy = o => o.OrderByDescending(c => c.ArName);

            if (searchStr != "" && searchStr != null)
            {
                int memType = 0;

                if (searchStr.Contains("طالب"))
                    memType = 1;

                if (searchStr.Contains("مقدم خدمة"))
                    memType = 2;
                
                if (searchStr.Contains("معلن"))
                    memType = 3;
                
                searchStr = searchStr.ToLower();
                filter = f => f.EnName.ToLower().Contains(searchStr)
                || f.ArName.Contains(searchStr) 
                || ("mem_"+f.Id.ToString()).Contains(searchStr)
                || (memType != 0 && f.MembershipType == memType);
            }

           

            var memUsers = new Dictionary<int, int>();
            foreach (var item in _Membership.GetAll(filter, orderBy))
            {
                var usersInMem = _student.GetAll(c => c.MembershipId == item.Id).Count()
                    + _provider.GetAll(c => c.MembershipId == item.Id).Count();
                memUsers.Add(item.Id, usersInMem);
            }
            ViewBag.MembershipUsers = memUsers;

            CreateIndexPageDetailsCookie(new IndexPageDetailsVM()
            {
                ControllerName = "Membership",
                SearchStr = searchStr,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return await PagedList<Membership>.CreateAsync(_Membership.GetAllAsIQueryable(filter, orderBy),
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber,pageSize).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<Membership>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber,pageSize).Result);
            model.GetItemsUrl = "/Membership/GetItems";
            model.GetPaginationUrl = "/Membership/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion

        #region Membership Link

        private void DeleteMembershipLinks(List<int> deletedLinks)
        {
            if (deletedLinks != null)
            {
                foreach (var item in deletedLinks)
                {
                    _MembershipLink.Delete(item);
                }
            }
        }

        #endregion

        #region Role Membership 
        private bool CreateRoleForMembership(Membership ms)
        {
            try
            {
                _context.Add(new IdentitySetupRole()
                {
                    Name = ms.EnName,
                    ArName = ms.ArName,
                    MembershipId = ms.Id,
                    CanBeEditedOrDeleted = true,
                    IsDeleted = false,
                    NormalizedName = ms.EnName
                });
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool UpdateRoleForMembership(Membership ms)
        {
            try
            {
                var role = _context.Roles.Where(c => c.MembershipId == ms.Id);
                if (role != null)
                {
                    role.First().ArName = ms.ArName;
                    role.First().Name = ms.EnName;
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion
    }
}
