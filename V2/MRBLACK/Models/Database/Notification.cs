using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
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
