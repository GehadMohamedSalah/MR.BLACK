using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("AdvertisingPackageInvoice")]
    public partial class AdvertisingPackageInvoice
    {
        public AdvertisingPackageInvoice()
        {
            AdvertisingPackageInvoiceViews = new HashSet<AdvertisingPackageInvoiceView>();
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
        [InverseProperty("AdvertisingPackageInvoices")]
        public virtual AdvertisingPackageRequest AdvertisingPackageRequest { get; set; }
        [InverseProperty(nameof(AdvertisingPackageInvoiceView.AdvertisingPackageInvoice))]
        public virtual ICollection<AdvertisingPackageInvoiceView> AdvertisingPackageInvoiceViews { get; set; }
    }
}
