using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Models
{
    public class IdentitySetupRole : IdentityRole
    {
        [StringLength(256)]
        public string ArName { get; set; }
        public bool CanEditedOrDeleted { get; set; }
        public bool IsMembershipRole { get; set; }
        public int? MembershipId { get; set; }
    }
}
