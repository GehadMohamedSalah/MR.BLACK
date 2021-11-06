using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class SlideShow
    {
        [Key]
        public int Id { get; set; }
        public string ImgPath { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        [ForeignKey(nameof(Gallery))]
        public int? GalleryImgId { get; set; }
        public Gallery Gallery { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
