using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.TempDb
{
    public partial class BookCategory
    {
        public BookCategory()
        {
            BookStore = new HashSet<BookStore>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }

        [InverseProperty("BookCategory")]
        public virtual ICollection<BookStore> BookStore { get; set; }
    }
}
