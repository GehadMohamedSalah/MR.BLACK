using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class Advertising
    {
        public Advertising()
        {
            AdvertisingAttachment = new HashSet<AdvertisingAttachment>();
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
        [InverseProperty(nameof(ServiceProvider.Advertising))]
        public virtual ServiceProvider Provider { get; set; }
        [InverseProperty("Advertising")]
        public virtual ICollection<AdvertisingAttachment> AdvertisingAttachment { get; set; }
    }
}
