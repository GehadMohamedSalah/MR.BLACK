using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("BookStore")]
    public partial class BookStore
    {
        public BookStore()
        {
            BookInvoices = new HashSet<BookInvoice>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string ArDesc { get; set; }
        public string EnName { get; set; }
        public string EnDesc { get; set; }
        public string ArAuthoreName { get; set; }
        public string EnAuthoreName { get; set; }
        public string BookPath { get; set; }
        public int? BookCategoryId { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Price { get; set; }
        public int? CurrencyTypeId { get; set; }

        [ForeignKey(nameof(BookCategoryId))]
        [InverseProperty("BookStores")]
        public virtual BookCategory BookCategory { get; set; }
        [ForeignKey(nameof(CurrencyTypeId))]
        [InverseProperty("BookStores")]
        public virtual CurrencyType CurrencyType { get; set; }
        [InverseProperty(nameof(BookInvoice.Book))]
        public virtual ICollection<BookInvoice> BookInvoices { get; set; }
    }
}
