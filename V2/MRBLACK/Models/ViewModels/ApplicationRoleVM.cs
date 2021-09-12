using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Models.ViewModels
{
    public class ApplicationRoleVM
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public int Membership { get; set; }
        public string ArName { get; set; }
    }
}
