using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mr_Black.Database
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
        public string ArName { get; set; }
        public string EnName { get; set; }
        public int? ParentCategoryId { get; set; }
        public bool AutoAcceptedService { get; set; }
        public int? PricingMethod { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal ServicePrice { get; set; }
        public int? CurrencyTypeId { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal PlatformRevenueFromServPrice { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal CommissionPercentage { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal RevenueFromThisCatgoryToPlatform { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal RevenueFromThisCatgoryToProvider { get; set; }
        public int? FormType { get; set; }
        [StringLength(450)]
        public string AddedByUserId { get; set; }
        public bool IsAccepted { get; set; }

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
