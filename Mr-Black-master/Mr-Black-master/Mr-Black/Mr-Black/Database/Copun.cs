using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mr_Black.Database
{
    public partial class Copun
    {
        public Copun()
        {
            BookInvoice = new HashSet<BookInvoice>();
            ServicesPurchaseInvoice = new HashSet<ServicesPurchaseInvoice>();
        }

        [Key]
        public int Id { get; set; }
        public string NameOrCode { get; set; }
        public bool IsPublic { get; set; }
        public int? CategoryId { get; set; }
        public int? DiscountPercentage { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal? MinInvoiceVal { get; set; }
        public int? CurrencyTypeId { get; set; }
        public int? DiscountOnWho { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(ServiceCategory.Copun))]
        public virtual ServiceCategory Category { get; set; }
        [ForeignKey(nameof(CurrencyTypeId))]
        [InverseProperty("Copun")]
        public virtual CurrencyType CurrencyType { get; set; }
        [InverseProperty("Copun")]
        public virtual ICollection<BookInvoice> BookInvoice { get; set; }
        [InverseProperty("Copun")]
        public virtual ICollection<ServicesPurchaseInvoice> ServicesPurchaseInvoice { get; set; }
    }
}
