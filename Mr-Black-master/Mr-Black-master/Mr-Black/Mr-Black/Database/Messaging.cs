using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mr_Black.Database
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

        [ForeignKey(nameof(FromUserId))]
        [InverseProperty(nameof(AspNetUsers.MessagingFromUser))]
        public virtual AspNetUsers FromUser { get; set; }
        [ForeignKey(nameof(ToUserId))]
        [InverseProperty(nameof(AspNetUsers.MessagingToUser))]
        public virtual AspNetUsers ToUser { get; set; }
    }
}
