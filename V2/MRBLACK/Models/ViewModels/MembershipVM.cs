using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MRBLACK.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Models.ViewModels
{
    public class MembershipVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        [Remote("IsUniqueRow", "Membership", ErrorMessage = "لا يمكن تكرار الاسم", AdditionalFields = nameof(Id))]
        public string EnName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        [Remote("IsUniqueRow", "Membership", ErrorMessage = "لا يمكن تكرار الاسم", AdditionalFields = nameof(Id))]
        public string ArName { get; set; }
        public IFormFile FormFile { get; set; }
        public string ImgPath { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public int MembershipType { get; set; }
        public List<MembershipLink> MembershipLinkList { get; set; }
        public List<int> DeletedLinks { get; set; }
    }
}
