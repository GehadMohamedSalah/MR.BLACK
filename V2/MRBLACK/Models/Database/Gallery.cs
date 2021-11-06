using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class Gallery
    {
        public Gallery()
        {
            SlideShow = new HashSet<SlideShow>();
        }
        [Key]
        public int Id { get; set; }
        public string ImgPath { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? GalleryCategoryId { get; set; }
        [InverseProperty("Gallery")]
        public virtual ICollection<SlideShow> SlideShow { get; set; }
    }
}
