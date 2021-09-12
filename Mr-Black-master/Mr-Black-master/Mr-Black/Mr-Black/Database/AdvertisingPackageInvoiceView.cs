using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mr_Black.Database
{
    public partial class AdvertisingPackageInvoiceView
    {
        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }
        public int? AdvertisingPackageInvoiceId { get; set; }

        [ForeignKey(nameof(AdvertisingPackageInvoiceId))]
        [InverseProperty("AdvertisingPackageInvoiceView")]
        public virtual AdvertisingPackageInvoice AdvertisingPackageInvoice { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUsers.AdvertisingPackageInvoiceView))]
        public virtual AspNetUsers User { get; set; }
    }
}
