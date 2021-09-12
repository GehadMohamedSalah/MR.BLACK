using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("Gallery")]
    public partial class Gallery
    {
        [Key]
        public int Id { get; set; }
        public string ImgPath { get; set; }
    }
}
