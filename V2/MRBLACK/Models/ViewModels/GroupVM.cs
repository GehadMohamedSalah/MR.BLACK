using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Models.ViewModels
{
    public class GroupVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [StringLength(50, ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        [Remote("IsUniqueRow", "Group", ErrorMessage = "لا يمكن تكرار الاسم", AdditionalFields = nameof(Id))]
        public string ArName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [StringLength(50, ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        [Remote("IsUniqueRow", "Group", ErrorMessage = "لا يمكن تكرار الاسم", AdditionalFields = nameof(Id))]
        public string EnName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public string SelectedDept { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }
    }
}
