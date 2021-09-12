using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mr_Black.Database
{
    public partial class ServiceRequest
    {
        public ServiceRequest()
        {
            ServicesInServicesPurchaseInvoice = new HashSet<ServicesInServicesPurchaseInvoice>();
        }

        [Key]
        public int Id { get; set; }
        public int? ServiceCategoryRequestId { get; set; }
        public int? StudentId { get; set; }
        public int? ServiceId { get; set; }
        public int? TimesOfService { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeliveryDateTime { get; set; }
        public int? DeliveryPeriodInDays { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RequestDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AcceptedDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExecutingDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExecutedDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeliveredDateTime { get; set; }
        public int? Status { get; set; }

        [ForeignKey(nameof(ServiceId))]
        [InverseProperty("ServiceRequest")]
        public virtual Service Service { get; set; }
        [ForeignKey(nameof(StudentId))]
        [InverseProperty("ServiceRequest")]
        public virtual Student Student { get; set; }
        [InverseProperty("ServiceRequest")]
        public virtual ICollection<ServicesInServicesPurchaseInvoice> ServicesInServicesPurchaseInvoice { get; set; }
    }
}
