using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mr_Black.Models.ViewModels
{
    public class HeaderVM
    {
        public string Name { get; set; }
        public string UserImage { get; set; }
        public int NotificationsNumber { get; set; }
        public List<NotificationVM> Notifications { get; set; } = new List<NotificationVM>();
    }
}
