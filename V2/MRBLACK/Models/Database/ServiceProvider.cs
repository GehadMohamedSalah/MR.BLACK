using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("ServiceProvider")]
    public partial class ServiceProvider
    {
        public ServiceProvider()
        {
            Advertisings = new HashSet<Advertising>();
            ServiceCategoryRequests = new HashSet<ServiceCategoryRequest>();
            Services = new HashSet<Service>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }
        public int? CountryId { get; set; }
        public string JobDesc { get; set; }
        public int? PaymentWayId { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal OutstandingBalances { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal WithdrawableBalances { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal WithdrawnBalances { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("ServiceProviders")]
        public virtual Country Country { get; set; }
        [ForeignKey(nameof(PaymentWayId))]
        [InverseProperty("ServiceProviders")]
        public virtual PaymentWay PaymentWay { get; set; }
        [InverseProperty(nameof(Advertising.Provider))]
        public virtual ICollection<Advertising> Advertisings { get; set; }
        [InverseProperty(nameof(ServiceCategoryRequest.ProviderIdSelectedFromStudentNavigation))]
        public virtual ICollection<ServiceCategoryRequest> ServiceCategoryRequests { get; set; }
        [InverseProperty(nameof(Service.Provider))]
        public virtual ICollection<Service> Services { get; set; }
    }
}
