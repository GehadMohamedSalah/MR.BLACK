using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
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
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public string NameOrCode { get; set; }
        public bool IsPublic { get; set; }
        public int? CategoryId { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public int? DiscountPercentage { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public decimal? MinInvoiceVal { get; set; }
        public int? CurrencyTypeId { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public int? DiscountOnWho { get; set; }
        [Column(TypeName = "datetime")]
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public DateTime? AccountStartDate { get; set; }
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
