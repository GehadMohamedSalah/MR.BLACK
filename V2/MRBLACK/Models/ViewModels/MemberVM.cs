using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Models.ViewModels
{
    public class MemberVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string MembershipNumber { get; set; }
        [Required(ErrorMessage = "يجب ادخال البريد الالكتروني")]
        [EmailAddress(ErrorMessage = "البريد يجب ان يحتوي على @")]
        public string Email { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "رقم الهاتف يتكون من 11 رقم فقط")]
        public string Phone { get; set; }
        [Required]
        public string MembershipType { get; set; }
        public string Gender { get; set; }
        public decimal Balance { get; set; }
        public int Code { get; set; }
    }
}
