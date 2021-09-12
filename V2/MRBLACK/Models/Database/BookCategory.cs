using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("BookCategory")]
    public partial class BookCategory
    {
        public BookCategory()
        {
            BookStores = new HashSet<BookStore>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }

        [InverseProperty(nameof(BookStore.BookCategory))]
        public virtual ICollection<BookStore> BookStores { get; set; }
    }
}
