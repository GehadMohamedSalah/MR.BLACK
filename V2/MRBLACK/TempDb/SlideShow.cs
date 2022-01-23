using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.TempDb
{
    public partial class SlideShow
    {
        [Key]
        public int Id { get; set; }
        public string ImgPath { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public int? GalleryImgId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(GalleryImgId))]
        [InverseProperty(nameof(Gallery.SlideShow))]
        public virtual Gallery GalleryImg { get; set; }
    }
}
