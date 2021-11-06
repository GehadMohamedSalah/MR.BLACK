using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class ServiceProvider
    {
        public ServiceProvider()
        {
            Advertising = new HashSet<Advertising>();
            Service = new HashSet<Service>();
            ServiceCategoryRequest = new HashSet<ServiceCategoryRequest>();
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

        public int? MembershipId { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("ServiceProvider")]
        public virtual Country Country { get; set; }
        [ForeignKey(nameof(PaymentWayId))]
        [InverseProperty("ServiceProvider")]
        public virtual PaymentWay PaymentWay { get; set; }
        [InverseProperty("Provider")]
        public virtual ICollection<Advertising> Advertising { get; set; }
        [InverseProperty("Provider")]
        public virtual ICollection<Service> Service { get; set; }
        [InverseProperty("Provider")]
        public virtual ICollection<ServiceCategoryRequest> ServiceCategoryRequest { get; set; }
    }
}
