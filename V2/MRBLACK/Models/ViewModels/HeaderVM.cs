using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Models.ViewModels
{
    public class HeaderVM
    {
        public string Name { get; set; }
        public string UserImage { get; set; }
        public int NotificationsNumber { get; set; }
        public List<NotificationVM> Notifications { get; set; } = new List<NotificationVM>();
        public List<NavItem> NavItems { get; set; }
    }

    public class NavItem
    {
        public string ItemName { get; set; }
        public string ItemUrl { get; set; }
    }
}
