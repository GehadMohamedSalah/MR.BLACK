using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("AdvertisingPackage")]
    public partial class AdvertisingPackage
    {
        public AdvertisingPackage()
        {
            AdvertisingPackagePages = new HashSet<AdvertisingPackagePage>();
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
        [InverseProperty("AdvertisingPackages")]
        public virtual CurrencyType CurrencyType { get; set; }
        [InverseProperty(nameof(AdvertisingPackagePage.AdvertisingPackage))]
        public virtual ICollection<AdvertisingPackagePage> AdvertisingPackagePages { get; set; }
    }
}
