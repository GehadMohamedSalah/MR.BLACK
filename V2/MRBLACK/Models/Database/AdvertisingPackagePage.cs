using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("AdvertisingPackagePage")]
    public partial class AdvertisingPackagePage
    {
        [Key]
        public int Id { get; set; }
        public int? AdvertisingPackageId { get; set; }
        public int? SystemPageId { get; set; }

        [ForeignKey(nameof(AdvertisingPackageId))]
        [InverseProperty("AdvertisingPackagePages")]
        public virtual AdvertisingPackage AdvertisingPackage { get; set; }
        [ForeignKey(nameof(SystemPageId))]
        [InverseProperty("AdvertisingPackagePages")]
        public virtual SystemPage SystemPage { get; set; }
    }
}
