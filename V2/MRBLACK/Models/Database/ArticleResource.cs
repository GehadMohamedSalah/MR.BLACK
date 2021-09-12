using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("ArticleResource")]
    public partial class ArticleResource
    {
        [Key]
        public int Id { get; set; }
        public int? ArticleId { get; set; }
        public string ResLink { get; set; }

        [ForeignKey(nameof(ArticleId))]
        [InverseProperty("ArticleResources")]
        public virtual Article Article { get; set; }
    }
}
