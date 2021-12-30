using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class BookCategory
    {
        public BookCategory()
        {
            BookStore = new HashSet<BookStore>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string ArName { get; set; }
        [Required]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string EnName { get; set; }

        [InverseProperty("BookCategory")]
        public virtual ICollection<BookStore> BookStore { get; set; }
    }
}
