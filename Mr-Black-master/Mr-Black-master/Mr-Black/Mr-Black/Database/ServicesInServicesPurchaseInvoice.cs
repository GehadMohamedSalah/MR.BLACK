using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mr_Black.Database
{
    public partial class ServicesInServicesPurchaseInvoice
    {
        [Key]
        public int Id { get; set; }
        public int? InvId { get; set; }
        public int? ServiceRequestId { get; set; }

        [ForeignKey(nameof(InvId))]
        [InverseProperty(nameof(ServicesPurchaseInvoice.ServicesInServicesPurchaseInvoice))]
        public virtual ServicesPurchaseInvoice Inv { get; set; }
        [ForeignKey(nameof(ServiceRequestId))]
        [InverseProperty("ServicesInServicesPurchaseInvoice")]
        public virtual ServiceRequest ServiceRequest { get; set; }
    }
}
