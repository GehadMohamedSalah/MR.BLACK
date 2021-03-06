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
    public partial class ArticleCategory
    {
        public ArticleCategory()
        {
            Article = new HashSet<Article>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "يجب ادخال هذا الحقل")]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        [Remote("IsUniqueRow", "ArticleCategory", ErrorMessage = "لا يمكن تكرار الاسم", AdditionalFields = nameof(Id))]
        public string ArName { get; set; }
        [Required(ErrorMessage = "يجب ادخال هذا الحقل")]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        [Remote("IsUniqueRow", "ArticleCategory", ErrorMessage = "لا يمكن تكرار الاسم", AdditionalFields = nameof(Id))]
        public string EnName { get; set; }

        [InverseProperty("ArticleCategory")]
        public virtual ICollection<Article> Article { get; set; }
    }
}
