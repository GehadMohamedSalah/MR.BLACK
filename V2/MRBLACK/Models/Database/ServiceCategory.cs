using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class ServiceCategory
    {
        public ServiceCategory()
        {
            Copun = new HashSet<Copun>();
            InverseParentCategory = new HashSet<ServiceCategory>();
            Service = new HashSet<Service>();
            ServiceCategoryRequest = new HashSet<ServiceCategoryRequest>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string ArName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string EnName { get; set; }
        public int? ParentCategoryId { get; set; }
        public bool AutoAcceptedService { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public int? PricingMethod { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        [Range(0, Double.MaxValue, ErrorMessage = "يجب ادخال قيمة اكبر من او تساوي ال 0")]
        public decimal ServicePrice { get; set; }
        public int? CurrencyTypeId { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        [Range(0, Double.MaxValue, ErrorMessage = "يجب ادخال قيمة اكبر من او تساوي ال 0")]
        public decimal PlatformRevenueFromServPrice { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        [Range(0, Double.MaxValue, ErrorMessage = "يجب ادخال قيمة اكبر من او تساوي ال 0")]
        public decimal CommissionPercentage { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal RevenueFromThisCatgoryToPlatform { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal RevenueFromThisCatgoryToProvider { get; set; }
        public int? FormType { get; set; }
        [StringLength(450)]
        public string AddedByUserId { get; set; }
        public bool IsAccepted { get; set; }
        public string ImgPath { get; set; }

        [ForeignKey(nameof(CurrencyTypeId))]
        [InverseProperty("ServiceCategory")]
        public virtual CurrencyType CurrencyType { get; set; }
        [ForeignKey(nameof(ParentCategoryId))]
        [InverseProperty(nameof(ServiceCategory.InverseParentCategory))]
        public virtual ServiceCategory ParentCategory { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<Copun> Copun { get; set; }
        [InverseProperty(nameof(ServiceCategory.ParentCategory))]
        public virtual ICollection<ServiceCategory> InverseParentCategory { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<Service> Service { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<ServiceCategoryRequest> ServiceCategoryRequest { get; set; }
    }
}
