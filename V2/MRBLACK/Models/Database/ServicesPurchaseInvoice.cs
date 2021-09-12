using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("ServicesPurchaseInvoice")]
    public partial class ServicesPurchaseInvoice
    {
        public ServicesPurchaseInvoice()
        {
            ServicesInServicesPurchaseInvoices = new HashSet<ServicesInServicesPurchaseInvoice>();
        }

        [Key]
        public int Id { get; set; }
        public string InvNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? InvDateTime { get; set; }
        public int? ProviderId { get; set; }
        public int? StudentId { get; set; }
        public int? CopunId { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal TotalCost { get; set; }
        public int? CurrencyTypeId { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal ProviderRevenue { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Platformrevenue { get; set; }

        [ForeignKey(nameof(CopunId))]
        [InverseProperty("ServicesPurchaseInvoices")]
        public virtual Copun Copun { get; set; }
        [ForeignKey(nameof(CurrencyTypeId))]
        [InverseProperty("ServicesPurchaseInvoices")]
        public virtual CurrencyType CurrencyType { get; set; }
        [InverseProperty(nameof(ServicesInServicesPurchaseInvoice.Inv))]
        public virtual ICollection<ServicesInServicesPurchaseInvoice> ServicesInServicesPurchaseInvoices { get; set; }
    }
}
