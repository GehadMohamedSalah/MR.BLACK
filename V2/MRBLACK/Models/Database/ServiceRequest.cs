using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class ServiceRequest
    {
        [Key]
        public int Id { get; set; }
        public int? ServiceCategoryRequestId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? TimesOfService { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeliveryDateTime { get; set; }
        public int? DeliveryPeriodInDays { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExecutingDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExecutedDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeliveredDateTime { get; set; }
        public int? Status { get; set; }
        public int? PaperNum { get; set; }
        public bool HasMargins { get; set; }
        public bool HasSpelling { get; set; }
        public bool HasReference { get; set; }
        public bool HasIntroAndEnd { get; set; }
    }
}
