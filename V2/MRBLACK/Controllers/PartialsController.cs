using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MRBLACK.Areas.Identity.Data;
using MRBLACK.Models.Database;
using MRBLACK.Models.ViewModels;
using MRBLACK.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MRBLACK.Controllers
{
    public class PartialsController : Controller
    {
        private readonly Repository<ServiceProvider> _Provider;
        private readonly Repository<Student> _student;
        private readonly UserManager<IdentitySetupUser> _userManager;
        public PartialsController(IRepository<ServiceProvider> Provider
            , UserManager<IdentitySetupUser> userManager
            ,IRepository<Student> student)
        {
            _Provider = (Repository<ServiceProvider>)Provider;
            _userManager = userManager;
            _student = (Repository<Student>)student;
        }
        public ActionResult Header()
        {
            HeaderVM headerVM = new HeaderVM()
            {
                Name = "Admin Mr Black",
            };

            /*  var Notifications = db.Notifications.Where(d => !d.IsDeleted && d.UserId == CurrentUserId).OrderByDescending(d => d.CreatedOn).ToList();*/
            headerVM.NotificationsNumber = 0; /*Notifications.Count(d => !d.IsSeen && !d.IsDeleted);*/
            /* if (Notifications != null && Notifications.Count > 0)
             {
                 foreach (var item in Notifications)
                 {
                     headerVM.Notifications.Add(new NotificationVM()
                     {
                         Body = item.Body,
                         NotificationType = item.NotificationType,
                         IsSeen = item.IsSeen,
                         RequestId = item.RequestId,
                         Id = item.Id,
                         Title = item.Title,
                         Link = item.NotificationLink
                     });
                 }
             }*/
            return PartialView(headerVM);
        }
        public ActionResult AdminSideMenu()
        {
            SideMenuVM sideMenuVM = new SideMenuVM()
            {
                Name = "Admin Mr Black",
                /*Complaints = db.Complaints.Count(w => w.IsDeleted == false && w.IsViewed == false)*/
            };
            return PartialView(sideMenuVM);
        }

        public async Task<ActionResult> UserHeader()
        {
            HeaderVM headerVM = new HeaderVM()
            {
                Name = "User Mr Black",
            };
            headerVM.NavItems = new List<NavItem>();

            var appUser = await _userManager.GetUserAsync(User);
            Expression<Func<ServiceProvider, bool>> filter1 = f => f.UserId == appUser.Id;

            if(_Provider.GetAll(filter1) != null && _Provider.GetAll(filter1).Count() > 0)
            {
                headerVM.NavItems.Add(new NavItem()
                {
                    ItemName="خدماتي",
                    ItemUrl="/Service/Index"
                });
                headerVM.NavItems.Add(new NavItem()
                {
                    ItemName = "الطلبات",
                    ItemUrl = "/Request/Index"
                });
            }
            else
            {
                headerVM.NavItems.Add(new NavItem()
                {
                    ItemName = "الطلبات",
                    ItemUrl = "/Request/Index"
                });
            }

            headerVM.NotificationsNumber = 0;
            return PartialView(headerVM);
        }

        public async Task<ActionResult> UserNavItems()
        {
            HeaderVM headerVM = new HeaderVM()
            {
                Name = User.Identity.Name,
            };
            headerVM.NavItems = new List<NavItem>();

            var appUser = await _userManager.GetUserAsync(User);
            Expression<Func<ServiceProvider, bool>> filter1 = f => f.UserId == appUser.Id;

            if (_Provider.GetAll(filter1) != null && _Provider.GetAll(filter1).Count() > 0)
            {
                headerVM.NavItems.Add(new NavItem()
                {
                    ItemName = "My Services",
                    ItemUrl = "/Service/Index"
                });
                headerVM.NavItems.Add(new NavItem()
                {
                    ItemName = "My Requests",
                    ItemUrl = "/Request/Index"
                });
            }
            else
            {
                headerVM.NavItems.Add(new NavItem()
                {
                    ItemName = "My Requests",
                    ItemUrl = "/Request/Index"
                });
            }

            headerVM.NotificationsNumber = 0;
            return PartialView("UserNavItems", headerVM);
        }

        public IActionResult WebsiteFooter()
        {
            return PartialView();
        }

        public async Task<ActionResult> SiteNavItems()
        {
            HeaderVM headerVM = new HeaderVM()
            {
                Name = User.Identity.Name,
            };
            headerVM.NavItems = new List<NavItem>();

            var appUser = await _userManager.GetUserAsync(User);
            Expression<Func<ServiceProvider, bool>> filter1 = f => f.UserId == appUser.Id;
            var provider = _Provider.GetFirstOrDefault(c => c.UserId == appUser.Id);
            var student = _student.GetFirstOrDefault(c => c.UserId == appUser.Id);
            if (provider != null)
            {
                headerVM.NavItems.Add(new NavItem()
                {
                    ItemName = "My Services",
                    ItemUrl = "/Service/Index"
                });
                headerVM.NavItems.Add(new NavItem()
                {
                    ItemName = "My Requests",
                    ItemUrl = "/Request/Index"
                });
            }
            else if(student != null)
            {
                headerVM.NavItems.Add(new NavItem()
                {
                    ItemName = "My Requests",
                    ItemUrl = "/Request/Index"
                });
            }
            else
            {
                headerVM.NavItems.Add(new NavItem()
                {
                    ItemName = "Dashboard",
                    ItemUrl = "/DefaultHome/Index"
                });
            }

            headerVM.NotificationsNumber = 0;
            return PartialView("UserNavItems", headerVM);
        }

        public IActionResult SiteFooter()
        {
            return PartialView();
        }
    }
}
