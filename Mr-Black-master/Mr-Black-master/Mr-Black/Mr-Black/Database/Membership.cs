using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mr_Black.Database
{
    public partial class Membership
    {
        public Membership()
        {
            AspNetRoles = new HashSet<AspNetRoles>();
            MembershipLink = new HashSet<MembershipLink>();
        }

        [Key]
        public int Id { get; set; }
        public string ArDesc { get; set; }
        public string EnDesc { get; set; }
        public string ImgName { get; set; }
        public string ImgPath { get; set; }

        [InverseProperty("Membership")]
        public virtual ICollection<AspNetRoles> AspNetRoles { get; set; }
        [InverseProperty("Membership")]
        public virtual ICollection<MembershipLink> MembershipLink { get; set; }
    }
}
