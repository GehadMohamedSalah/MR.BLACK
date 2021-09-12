using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("Article")]
    public partial class Article
    {
        public Article()
        {
            ArticleResources = new HashSet<ArticleResource>();
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

        [ForeignKey(nameof(ArticleCategoryId))]
        [InverseProperty("Articles")]
        public virtual ArticleCategory ArticleCategory { get; set; }
        [InverseProperty(nameof(ArticleResource.Article))]
        public virtual ICollection<ArticleResource> ArticleResources { get; set; }
    }
}
