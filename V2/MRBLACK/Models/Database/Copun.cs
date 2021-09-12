using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("Copun")]
    public partial class Copun
    {
        public Copun()
        {
            BookInvoices = new HashSet<BookInvoice>();
            ServicesPurchaseInvoices = new HashSet<ServicesPurchaseInvoice>();
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
        [InverseProperty(nameof(ServiceCategory.Copuns))]
        public virtual ServiceCategory Category { get; set; }
        [ForeignKey(nameof(CurrencyTypeId))]
        [InverseProperty("Copuns")]
        public virtual CurrencyType CurrencyType { get; set; }
        [InverseProperty(nameof(BookInvoice.Copun))]
        public virtual ICollection<BookInvoice> BookInvoices { get; set; }
        [InverseProperty(nameof(ServicesPurchaseInvoice.Copun))]
        public virtual ICollection<ServicesPurchaseInvoice> ServicesPurchaseInvoices { get; set; }
    }
}
