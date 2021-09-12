using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mr_Black.Database
{
    public partial class AdvertisingPackageInvoice
    {
        public AdvertisingPackageInvoice()
        {
            AdvertisingPackageInvoiceView = new HashSet<AdvertisingPackageInvoiceView>();
        }

        [Key]
        public int Id { get; set; }
        public string InvNumber { get; set; }
        public int? AdvertisingPackageRequestId { get; set; }
        public int? ProviderId { get; set; }
        public int? AdvertisingPackageId { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal TotalCost { get; set; }
        public int? NumOfPurchasedTimes { get; set; }
        public int? Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FinishedDateTime { get; set; }

        [ForeignKey(nameof(AdvertisingPackageRequestId))]
        [InverseProperty("AdvertisingPackageInvoice")]
        public virtual AdvertisingPackageRequest AdvertisingPackageRequest { get; set; }
        [InverseProperty("AdvertisingPackageInvoice")]
        public virtual ICollection<AdvertisingPackageInvoiceView> AdvertisingPackageInvoiceView { get; set; }
    }
}
