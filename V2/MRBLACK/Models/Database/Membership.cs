using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MRBLACK.Areas.Identity.Data;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("Membership")]
    public partial class Membership
    {
        public Membership()
        {
            MembershipLinks = new HashSet<MembershipLink>();
            IdentitySetupRoles = new HashSet<IdentitySetupRole>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public string ImgPath { get; set; }
        public int? MembershipType { get; set; }
        [InverseProperty(nameof(MembershipLink.Membership))]
        public virtual ICollection<MembershipLink> MembershipLinks { get; set; }
        public virtual ICollection<IdentitySetupRole> IdentitySetupRoles { get; set; }
    }
}
