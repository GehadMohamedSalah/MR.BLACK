using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.TempDb
{
    public partial class SystemPage
    {
        public SystemPage()
        {
            AdvertisingPackagePage = new HashSet<AdvertisingPackagePage>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }

        [InverseProperty("SystemPage")]
        public virtual ICollection<AdvertisingPackagePage> AdvertisingPackagePage { get; set; }
    }
}
