using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("TechnicalSupport")]
    public partial class TechnicalSupport
    {
        [Key]
        public int Id { get; set; }
        public int? Type { get; set; }
        public string Title { get; set; }
        public string SentMessage { get; set; }
        public string ReplyMessage { get; set; }
        public string SendFromUserId { get; set; }
        [StringLength(450)]
        public string RepliedByUserId { get; set; }
        [Column("IPAddress")]
        public string Ipaddress { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [StringLength(450)]
        public string FromUserId { get; set; }
    }
}
