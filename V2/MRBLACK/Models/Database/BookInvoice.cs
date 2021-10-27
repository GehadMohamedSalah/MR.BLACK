using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class BookInvoice
    {
        [Key]
        public int Id { get; set; }
        public string InvNumber { get; set; }
        public int? BookId { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }
        public int? CopunId { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Discount { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal TotalCost { get; set; }
        [Column("IsAGift")]
        public bool IsAgift { get; set; }

        [ForeignKey(nameof(BookId))]
        [InverseProperty(nameof(BookStore.BookInvoice))]
        public virtual BookStore Book { get; set; }
        [ForeignKey(nameof(CopunId))]
        [InverseProperty("BookInvoice")]
        public virtual Copun Copun { get; set; }
    }
}
