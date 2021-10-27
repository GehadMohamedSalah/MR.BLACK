using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.TempDb
{
    public partial class AdvertisingAttachment
    {
        [Key]
        public int Id { get; set; }
        public int? AdvertisingId { get; set; }
        public string AttachPath { get; set; }
        public string EditedAttachPath { get; set; }

        [ForeignKey(nameof(AdvertisingId))]
        [InverseProperty("AdvertisingAttachment")]
        public virtual Advertising Advertising { get; set; }
    }
}
