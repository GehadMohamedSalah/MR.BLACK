using Microsoft.AspNetCore.Mvc;
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
        [Required(ErrorMessage = "يجب ادخال هذا الحقل")]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        [Remote("IsUniqueRow", "BookStore", ErrorMessage = "لا يمكن تكرار الاسم", AdditionalFields = nameof(Id))]
        public string ArName { get; set; }
        [StringLength(200, ErrorMessage = "لا يمكن ادخال اكثر من 200 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string ArDesc { get; set; }
        [Required(ErrorMessage = "يجب ادخال هذا الحقل")]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        [Remote("IsUniqueRow", "BookStore", ErrorMessage = "لا يمكن تكرار الاسم", AdditionalFields = nameof(Id))]
        public string EnName { get; set; }
        [StringLength(200, ErrorMessage = "لا يمكن ادخال اكثر من 200 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string EnDesc { get; set; }
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string ArAuthoreName { get; set; }
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string EnAuthoreName { get; set; }
        [Required(ErrorMessage = "يجب ادخال هذا الحقل")]
        public int? BookCategoryId { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        [Range(1, Double.MaxValue, ErrorMessage = "يجب ادخال قيمة اكبر من او تساوي ال 1")]
        [Required(ErrorMessage = "يجب ادخال هذا الحقل")]
        public decimal Price { get; set; }
        public int? CurrencyTypeId { get; set; }
        public string BookPdfPath { get; set; }
        public string BookVoicePath { get; set; }
        public string BookCoverImgPath { get; set; }
        [Range(1, Double.MaxValue, ErrorMessage = "يجب ادخال قيمة اكبر من او تساوي ال 1")]
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
