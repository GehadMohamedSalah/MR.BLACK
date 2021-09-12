using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("Messaging")]
    public partial class Messaging
    {
        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        public string FromUserId { get; set; }
        [StringLength(450)]
        public string ToUserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
