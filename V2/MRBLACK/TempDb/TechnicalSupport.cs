using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.TempDb
{
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
