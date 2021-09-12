using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("Advertising")]
    public partial class Advertising
    {
        public Advertising()
        {
            AdvertisingAttachments = new HashSet<AdvertisingAttachment>();
        }

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ProviderId { get; set; }
        public bool IsAccepted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }
        public string EditedTitle { get; set; }
        public string EditedDesc { get; set; }
        public string IsEditAccepted { get; set; }

        [ForeignKey(nameof(ProviderId))]
        [InverseProperty(nameof(ServiceProvider.Advertisings))]
        public virtual ServiceProvider Provider { get; set; }
        [InverseProperty(nameof(AdvertisingAttachment.Advertising))]
        public virtual ICollection<AdvertisingAttachment> AdvertisingAttachments { get; set; }
    }
}
