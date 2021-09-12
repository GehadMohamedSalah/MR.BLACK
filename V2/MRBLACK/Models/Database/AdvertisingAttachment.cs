using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("AdvertisingAttachment")]
    public partial class AdvertisingAttachment
    {
        [Key]
        public int Id { get; set; }
        public int? AdvertisingId { get; set; }
        public string AttachPath { get; set; }
        public string EditedAttachPath { get; set; }

        [ForeignKey(nameof(AdvertisingId))]
        [InverseProperty("AdvertisingAttachments")]
        public virtual Advertising Advertising { get; set; }
    }
}
