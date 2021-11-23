using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class Membership
    {
        public Membership()
        {
            MembershipLink = new HashSet<MembershipLink>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public string ArName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public string EnName { get; set; }
        public string ImgPath { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public int? MembershipType { get; set; }

        [InverseProperty("Membership")]
        public virtual ICollection<MembershipLink> MembershipLink { get; set; }
    }
}
