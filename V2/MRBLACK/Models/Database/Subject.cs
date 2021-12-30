using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class Subject
    {
        public Subject()
        {
            Service = new HashSet<Service>();
            ServiceCategoryRequest = new HashSet<ServiceCategoryRequest>();
            UcdsEductionManagement = new HashSet<UcdsEductionManagement>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string ArName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string EnName { get; set; }
        public string ImgPath { get; set; }

        [InverseProperty("Subject")]
        public virtual ICollection<Service> Service { get; set; }
        [InverseProperty("Subject")]
        public virtual ICollection<ServiceCategoryRequest> ServiceCategoryRequest { get; set; }
        [InverseProperty("Subject")]
        public virtual ICollection<UcdsEductionManagement> UcdsEductionManagement { get; set; }
    }
}
