using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mr_Black.Database
{
    public partial class ServicesPurchaseInvoice
    {
        public ServicesPurchaseInvoice()
        {
            ServicesInServicesPurchaseInvoice = new HashSet<ServicesInServicesPurchaseInvoice>();
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
        [InverseProperty("ServicesPurchaseInvoice")]
        public virtual Copun Copun { get; set; }
        [ForeignKey(nameof(CurrencyTypeId))]
        [InverseProperty("ServicesPurchaseInvoice")]
        public virtual CurrencyType CurrencyType { get; set; }
        [InverseProperty("Inv")]
        public virtual ICollection<ServicesInServicesPurchaseInvoice> ServicesInServicesPurchaseInvoice { get; set; }
    }
}
