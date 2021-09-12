using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("SystemPage")]
    public partial class SystemPage
    {
        public SystemPage()
        {
            AdvertisingPackagePages = new HashSet<AdvertisingPackagePage>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }

        [InverseProperty(nameof(AdvertisingPackagePage.SystemPage))]
        public virtual ICollection<AdvertisingPackagePage> AdvertisingPackagePages { get; set; }
    }
}
