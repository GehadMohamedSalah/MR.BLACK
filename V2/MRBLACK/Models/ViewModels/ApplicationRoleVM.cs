using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Models.ViewModels
{
    public class ApplicationRoleVM
    {
        public string Id { get; set; }
        [Required]
        public string RoleName { get; set; }
        public int Membership { get; set; }
        [Required]
        public string ArName { get; set; }
    }
}
