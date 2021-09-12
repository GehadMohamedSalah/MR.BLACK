using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mr_Black.Database
{
    public partial class AdvertisingPackage
    {
        public AdvertisingPackage()
        {
            AdvertisingPackagePage = new HashSet<AdvertisingPackagePage>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public int? NumberOfViews { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Price { get; set; }
        public int? CurrencyTypeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpirationDateTime { get; set; }
        public int? PlaceOfAdvertising { get; set; }

        [ForeignKey(nameof(CurrencyTypeId))]
        [InverseProperty("AdvertisingPackage")]
        public virtual CurrencyType CurrencyType { get; set; }
        [InverseProperty("AdvertisingPackage")]
        public virtual ICollection<AdvertisingPackagePage> AdvertisingPackagePage { get; set; }
    }
}
