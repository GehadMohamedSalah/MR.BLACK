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

namespace MRBLACK.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class MembershipController : Controller
    {
        private readonly Repository<Membership> _Membership;
        private readonly Repository<MembershipLink> _MembershipLink;
        private readonly IdentitySetupContext _context;
        private readonly int PageSize;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MembershipController(IRepository<Membership> Membership,
            IdentitySetupContext context,
            IRepository<MembershipLink> MembershipLink,
            IWebHostEnvironment webHostEnvironment)
        {
            _Membership = (Repository<Membership>)Membership;
            _context = context;
            _MembershipLink = (Repository<MembershipLink>)MembershipLink;
            _webHostEnvironment = webHostEnvironment;
            PageSize = 5;
        }

        #region CRUD OPERTIONS

        #region Get Memberships
        public IActionResult Index(int pageNumber = 1)
        {
            return View(GetPagedListItems("", pageNumber).Result);
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
                        ms.MembershipLinks.Add(item);
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
            var ms = _Membership.GetAll(filter, null, "MembershipLinks");

            //set Membership obj to MembershipVM
            var model = new MembershipVM();
            if (ms != null)
            {
                model.Id = ms.First().Id;
                model.EnName = ms.First().EnName;
                model.ArName = ms.First().ArName;
                model.ImgPath = ms.First().ImgPath;
                model.MembershipType = (int)ms.First().MembershipType;
                model.MembershipLinkList = new List<MembershipLink>();
                if (ms.First().MembershipLinks != null)
                {
                    model.MembershipLinkList.AddRange(ms.First().MembershipLinks);
                }
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
                        ms.MembershipLinks.Add(item);
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
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(ConfirmDeleteVM model)
        {
            try
            {
                _Membership.Delete((int)model.PkFieldIntVal);
            }
            catch (Exception e)
            {
                var x = e.Message;
                ModelState.AddModelError("", "لا يمكن حذف هذه العضوية");
                return View("_DeleteView", model);
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<Membership>> GetPagedListItems(string searchStr, int pageNumber)
        {
            Expression<Func<Membership, bool>> filter = null;
            Func<IQueryable<Membership>, IOrderedQueryable<Membership>> orderBy = o => o.OrderByDescending(c => c.ArName);

            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                filter = f => f.EnName.ToLower().Contains(searchStr)
                || f.ArName.Contains(searchStr);
            }

            return await PagedList<Membership>.CreateAsync(_Membership.GetAllAsIQueryable(filter, orderBy),
                pageNumber, PageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1)
        {
            var model = PagedList<Membership>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber).Result);
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
