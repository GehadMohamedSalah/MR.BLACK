using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.TempDb
{
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
