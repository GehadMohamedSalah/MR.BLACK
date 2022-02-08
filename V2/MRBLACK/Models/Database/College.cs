using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class College
    {
        public College()
        {
            Service = new HashSet<Service>();
            ServiceCategoryRequest = new HashSet<ServiceCategoryRequest>();
            Student = new HashSet<Student>();
            UcdsEductionManagement = new HashSet<UcdsEductionManagement>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="هذا الحقل مطلوب ادخاله")]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        [Remote("IsUniqueRow", "College", ErrorMessage = "لا يمكن تكرار الاسم", AdditionalFields = nameof(Id))]
        public string ArName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        [Remote("IsUniqueRow", "College", ErrorMessage = "لا يمكن تكرار الاسم", AdditionalFields = nameof(Id))]
        public string EnName { get; set; }
        public string ImgPath { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [Range(1, Double.MaxValue, ErrorMessage = "يجب ادخال قيمة اكبر من او تساوي ال 1")]
        public int? Years { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [Range(1, Double.MaxValue, ErrorMessage = "يجب ادخال قيمة اكبر من او تساوي ال 1")]
        public int? Terms { get; set; }

        [InverseProperty("College")]
        public virtual ICollection<Service> Service { get; set; }
        [InverseProperty("College")]
        public virtual ICollection<ServiceCategoryRequest> ServiceCategoryRequest { get; set; }
        [InverseProperty("College")]
        public virtual ICollection<Student> Student { get; set; }
        [InverseProperty("College")]
        public virtual ICollection<UcdsEductionManagement> UcdsEductionManagement { get; set; }
    }
}
