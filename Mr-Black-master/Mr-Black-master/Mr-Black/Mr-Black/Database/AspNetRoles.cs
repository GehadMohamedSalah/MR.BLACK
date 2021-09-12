using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mr_Black.Database
{
    [NotMapped]
    public partial class AspNetRoles : IdentityRole
    {
        public AspNetRoles()
        {
            RolePrivilage = new HashSet<RolePrivilage>();
        }
        [StringLength(256)]
        public string ArName { get; set; }
        public bool CanEditedOrDeleted { get; set; }
        public bool IsMembershipRole { get; set; }
        public int? MembershipId { get; set; }

        [ForeignKey(nameof(MembershipId))]
        [InverseProperty("AspNetRoles")]
        public virtual Membership Membership { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<RolePrivilage> RolePrivilage { get; set; }
    }
}
