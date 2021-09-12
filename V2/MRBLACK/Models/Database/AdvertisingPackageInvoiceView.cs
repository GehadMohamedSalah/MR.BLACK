using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("AdvertisingPackageInvoiceView")]
    public partial class AdvertisingPackageInvoiceView
    {
        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }
        public int? AdvertisingPackageInvoiceId { get; set; }

        [ForeignKey(nameof(AdvertisingPackageInvoiceId))]
        [InverseProperty("AdvertisingPackageInvoiceViews")]
        public virtual AdvertisingPackageInvoice AdvertisingPackageInvoice { get; set; }
    }
}
