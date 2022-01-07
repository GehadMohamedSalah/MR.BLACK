using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MRBLACK.Areas.Identity.Data;
using MRBLACK.Helper;
using MRBLACK.Models.Database;
using MRBLACK.Models.Enums;
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
    public class MemberController : BaseController
    {
        private readonly Repository<Student> _student;
        private readonly Repository<ServiceProvider> _provider;
        private readonly UserManager<IdentitySetupUser> _userManager;
        private readonly Repository<Membership> _membership;
        public MemberController(IRepository<Student> student
            , UserManager<IdentitySetupUser> userManager
            ,IRepository<ServiceProvider> provider
            ,IRepository<Membership> membership)
        {
            _student = (Repository<Student>)student;
            _userManager = userManager;
            _provider = (Repository<ServiceProvider>)provider;
            _membership = (Repository<Membership>)membership;
        }

        #region CRUD OPERTIONS

        #region Get Book Categories
        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            var model = GetIndexPageDetails("Member");
            return View(GetPagedListItems(model.SearchStr, model.PageNumber, model.PageSize));
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public PagedList<MemberVM> GetPagedListItems(string searchStr, int pageNumber, int pageSize)
        {
            var users = _userManager.Users.Where(c => c.UserType == (int)UserType.Member);
            List<MemberVM> members = new List<MemberVM>();
            foreach(var item in users)
            {
                var memType = "";
                var stu = _student.GetFirstOrDefault(c => c.UserId == item.Id);
                if(stu != null)
                {
                    memType = _membership.GetElement((int)stu.MembershipId).ArName;
                }
                else
                {
                    var prov = _provider.GetFirstOrDefault(c => c.UserId == item.Id);
                    if(prov != null) 
                    {
                        memType = _membership.GetElement((int)prov.MembershipId).ArName;
                    }
                }
                members.Add(new MemberVM()
                {
                    Name = item.ArName,
                    MembershipNumber = "",
                    MembershipType = memType,
                    Email = item.Email,
                    Phone = item.PhoneNumber,
                    Gender = item.Gender != null ? (item.Gender == 1 ? "ذكر" : "انثى") :"غير ذلك" ,
                    Balance = 0
                });
            }

            if (searchStr != null && searchStr != "")
            {
                searchStr = searchStr.ToLower();
                members = members.Where(c => c.Name.ToLower().Contains(searchStr)
                || c.Email.ToLower().Contains(searchStr)
                || c.MembershipNumber.ToLower().Contains(searchStr)
                || c.MembershipType.ToLower().Contains(searchStr)
                || c.Phone.Contains(searchStr)
                || c.Gender.ToLower().Contains(searchStr)
                || c.Balance.ToString().Contains(searchStr)).ToList();
            }

            CreateIndexPageDetailsCookie(new IndexPageDetailsVM()
            {
                ControllerName = "Member",
                SearchStr = searchStr,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return PagedList<MemberVM>.Create(members,
                pageNumber, pageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber, pageSize).ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<MemberVM>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber, pageSize));
            model.GetItemsUrl = "/Member/GetItems";
            model.GetPaginationUrl = "/Member/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion
    }
}
