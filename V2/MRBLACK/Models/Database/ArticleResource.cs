using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class ArticleResource
    {
        [Key]
        public int Id { get; set; }
        public int? ArticleId { get; set; }
        public string ResLink { get; set; }

        [ForeignKey(nameof(ArticleId))]
        [InverseProperty("ArticleResource")]
        public virtual Article Article { get; set; }
    }
}
