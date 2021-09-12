using Microsoft.AspNetCore.Mvc;
using Mr_Black.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mr_Black.Controllers
{
    public class PartialsController : Controller
    {
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
    }
}
