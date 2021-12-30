using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MRBLACK.Models.Database;

namespace MRBLACK.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the IdentitySetupUser class
    public class IdentitySetupUser : IdentityUser
    {
        [StringLength(50)]
        public string ArName { get; set; }
        [StringLength(50)]
        public string EnName { get; set; }
        public int? Gender { get; set; }
        public string RedirectUrl { get; set; }
        public int? CountryId { get; set; }
        public bool IsDeleted { get; set; }
        public int? UserType { get; set; }
        public string ImgPath { get; set; }
    }

    public class IdentitySetupRole : IdentityRole
    {
        public IdentitySetupRole(string name)
        : base(name)
        { }
        public IdentitySetupRole()
        { }

        [Required(ErrorMessage ="هذا الحقل مطلوب ادخاله")]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string ArName { get; set; }


        [ForeignKey(nameof(Membership))]
        public int? MembershipId { get; set; }
        public Membership Membership { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public override string Name { get => base.Name; set => base.Name = value; }

        public bool CanBeEditedOrDeleted { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}
