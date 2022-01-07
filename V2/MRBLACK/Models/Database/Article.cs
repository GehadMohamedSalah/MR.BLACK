using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class Article
    {
        public Article()
        {
            ArticleResource = new HashSet<ArticleResource>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "يجب ادخال هذا الحقل")]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string ArName { get; set; }
        [StringLength(200, ErrorMessage = "لا يمكن ادخال اكثر من 200 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string ArDesc { get; set; }
        [StringLength(200, ErrorMessage = "لا يمكن ادخال اكثر من 200 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string ArContent { get; set; }
        [Required(ErrorMessage = "يجب ادخال هذا الحقل")]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string EnName { get; set; }
        [StringLength(200, ErrorMessage = "لا يمكن ادخال اكثر من 200 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string EnDesc { get; set; }
        [StringLength(200, ErrorMessage = "لا يمكن ادخال اكثر من 200 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string EnContent { get; set; }
        [StringLength(100, ErrorMessage = "لا يمكن ادخال اكثر من 100 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string Link { get; set; }
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string WriterName { get; set; }
        public string ImgPath { get; set; }
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string ArKeywords { get; set; }
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string EnKeywords { get; set; }
        [Required(ErrorMessage = "يجب ادخال هذا الحقل")]
        public int? ArticleCategoryId { get; set; }
        [StringLength(200, ErrorMessage = "لا يمكن ادخال اكثر من 200 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string Instructions { get; set; }
        public int? ViewsNum { get; set; }
        public int? Status { get; set; }
        public DateTime CreatedOn { get; set; }
        [Required(ErrorMessage = "يجب ادخال هذا الحقل")]
        public DateTime PublishOn { get; set; }
        [ForeignKey(nameof(ArticleCategoryId))]
        [InverseProperty("Article")]
        public virtual ArticleCategory ArticleCategory { get; set; }
        [InverseProperty("Article")]
        public virtual ICollection<ArticleResource> ArticleResource { get; set; }
    }
}
