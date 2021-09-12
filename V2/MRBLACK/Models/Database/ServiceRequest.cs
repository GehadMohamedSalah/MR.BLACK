using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("ServiceRequest")]
    public partial class ServiceRequest
    {
        public ServiceRequest()
        {
            ServicesInServicesPurchaseInvoices = new HashSet<ServicesInServicesPurchaseInvoice>();
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
        [InverseProperty("ServiceRequests")]
        public virtual Service Service { get; set; }
        [ForeignKey(nameof(StudentId))]
        [InverseProperty("ServiceRequests")]
        public virtual Student Student { get; set; }
        [InverseProperty(nameof(ServicesInServicesPurchaseInvoice.ServiceRequest))]
        public virtual ICollection<ServicesInServicesPurchaseInvoice> ServicesInServicesPurchaseInvoices { get; set; }
    }
}
