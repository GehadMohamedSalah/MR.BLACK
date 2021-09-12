using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("AdvertisingPackageRequest")]
    public partial class AdvertisingPackageRequest
    {
        public AdvertisingPackageRequest()
        {
            AdvertisingPackageInvoices = new HashSet<AdvertisingPackageInvoice>();
        }

        [Key]
        public int Id { get; set; }
        public int? AdvertisingId { get; set; }
        public int? AdvertisingPackageId { get; set; }
        public int? Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RequestDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AcceptedOrRejectedDateTime { get; set; }

        [InverseProperty(nameof(AdvertisingPackageInvoice.AdvertisingPackageRequest))]
        public virtual ICollection<AdvertisingPackageInvoice> AdvertisingPackageInvoices { get; set; }
    }
}
