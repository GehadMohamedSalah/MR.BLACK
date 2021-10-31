using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Models.ViewModels
{
    public class SupervisorVM
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public string Name { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "رقم الهاتف يتكون من 11 رقم فقط")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [EmailAddress(ErrorMessage = "البريد يجب ان يحتوي على @ ")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [StringLength(100, ErrorMessage = "كلمة المرور لا يجب ان تقل عن 6 احرف", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "كلمتا المرور غير متطابقتان")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public int MembershipId { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public int CountryId { get; set; }
        public int Gender { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public string RoleId { get; set; }
        public SelectList CountryList { get; set; }
        public List<SelectListItem> RoleList { get; set; }
    }
}
