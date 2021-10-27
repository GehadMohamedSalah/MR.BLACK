using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.TempDb
{
    public partial class AdvertisingPackagePage
    {
        [Key]
        public int Id { get; set; }
        public int? AdvertisingPackageId { get; set; }
        public int? SystemPageId { get; set; }

        [ForeignKey(nameof(AdvertisingPackageId))]
        [InverseProperty("AdvertisingPackagePage")]
        public virtual AdvertisingPackage AdvertisingPackage { get; set; }
        [ForeignKey(nameof(SystemPageId))]
        [InverseProperty("AdvertisingPackagePage")]
        public virtual SystemPage SystemPage { get; set; }
    }
}
