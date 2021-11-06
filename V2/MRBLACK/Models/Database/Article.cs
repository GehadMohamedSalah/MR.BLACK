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
        public string ArName { get; set; }
        public string ArDesc { get; set; }
        public string ArContent { get; set; }
        public string EnName { get; set; }
        public string EnDesc { get; set; }
        public string EnContent { get; set; }
        public string Link { get; set; }
        public string WriterName { get; set; }
        public string ImgPath { get; set; }
        public string ArKeywords { get; set; }
        public string EnKeywords { get; set; }
        public int? ArticleCategoryId { get; set; }
        public string Instructions { get; set; }
        public int? ViewsNum { get; set; }
        public int? Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime PublishOn { get; set; }
        [ForeignKey(nameof(ArticleCategoryId))]
        [InverseProperty("Article")]
        public virtual ArticleCategory ArticleCategory { get; set; }
        [InverseProperty("Article")]
        public virtual ICollection<ArticleResource> ArticleResource { get; set; }
    }
}
