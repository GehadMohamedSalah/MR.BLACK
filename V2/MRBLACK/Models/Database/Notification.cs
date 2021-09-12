using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("Notification")]
    public partial class Notification
    {
        [Key]
        public int Id { get; set; }
        public int? FromUserId { get; set; }
        public int? ToUserId { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SendingDateTime { get; set; }
        public bool IsSeen { get; set; }
    }
}
