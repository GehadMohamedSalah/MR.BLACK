using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("ServicesInServicesPurchaseInvoice")]
    public partial class ServicesInServicesPurchaseInvoice
    {
        [Key]
        public int Id { get; set; }
        public int? InvId { get; set; }
        public int? ServiceId { get; set; }
        public int? SubRequestId { get; set; }
        [ForeignKey(nameof(InvId))]
        [InverseProperty(nameof(ServicesPurchaseInvoice.ServicesInServicesPurchaseInvoices))]
        public virtual ServicesPurchaseInvoice Inv { get; set; }
    }
}
