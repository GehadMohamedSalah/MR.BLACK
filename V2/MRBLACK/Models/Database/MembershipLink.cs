using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("MembershipLink")]
    public partial class MembershipLink
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public int? MembershipId { get; set; }

        [ForeignKey(nameof(MembershipId))]
        [InverseProperty("MembershipLinks")]
        public virtual Membership Membership { get; set; }
    }
}
