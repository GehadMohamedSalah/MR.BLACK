using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("ServiceCategory")]
    public partial class ServiceCategory
    {
        public ServiceCategory()
        {
            Copuns = new HashSet<Copun>();
            InverseParentCategory = new HashSet<ServiceCategory>();
            ServiceCategoryRequests = new HashSet<ServiceCategoryRequest>();
            Services = new HashSet<Service>();
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
        public string ImgPath { get; set; }

        [ForeignKey(nameof(CurrencyTypeId))]
        [InverseProperty("ServiceCategories")]
        public virtual CurrencyType CurrencyType { get; set; }
        [ForeignKey(nameof(ParentCategoryId))]
        [InverseProperty(nameof(ServiceCategory.InverseParentCategory))]
        public virtual ServiceCategory ParentCategory { get; set; }
        [InverseProperty(nameof(Copun.Category))]
        public virtual ICollection<Copun> Copuns { get; set; }
        [InverseProperty(nameof(ServiceCategory.ParentCategory))]
        public virtual ICollection<ServiceCategory> InverseParentCategory { get; set; }
        [InverseProperty(nameof(ServiceCategoryRequest.Category))]
        public virtual ICollection<ServiceCategoryRequest> ServiceCategoryRequests { get; set; }
        [InverseProperty(nameof(Service.Category))]
        public virtual ICollection<Service> Services { get; set; }
    }
}
