using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.TempDb
{
    public partial class AdvertisingPackageRequest
    {
        public AdvertisingPackageRequest()
        {
            AdvertisingPackageInvoice = new HashSet<AdvertisingPackageInvoice>();
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

        [InverseProperty("AdvertisingPackageRequest")]
        public virtual ICollection<AdvertisingPackageInvoice> AdvertisingPackageInvoice { get; set; }
    }
}
