using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class BookStore
    {
        public BookStore()
        {
            BookInvoice = new HashSet<BookInvoice>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string ArName { get; set; }
        public string ArDesc { get; set; }
        [Required]
        public string EnName { get; set; }
        public string EnDesc { get; set; }
        public string ArAuthoreName { get; set; }
        public string EnAuthoreName { get; set; }
        [Required]
        public int? BookCategoryId { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Price { get; set; }
        public int? CurrencyTypeId { get; set; }
        public string BookPdfPath { get; set; }
        public string BookVoicePath { get; set; }
        public string BookCoverImgPath { get; set; }
        public int? PaperNum { get; set; }
        [ForeignKey(nameof(BookCategoryId))]
        [InverseProperty("BookStore")]
        public virtual BookCategory BookCategory { get; set; }
        [ForeignKey(nameof(CurrencyTypeId))]
        [InverseProperty("BookStore")]
        public virtual CurrencyType CurrencyType { get; set; }
        [InverseProperty("Book")]
        public virtual ICollection<BookInvoice> BookInvoice { get; set; }
    }
}
