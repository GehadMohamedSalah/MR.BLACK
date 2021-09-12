using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mr_Black.Database
{
    public partial class MembershipLink
    {
        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public string ArDesc { get; set; }
        public string EnDesc { get; set; }
        public string Link { get; set; }
        public int? MembershipId { get; set; }

        [ForeignKey(nameof(MembershipId))]
        [InverseProperty("MembershipLink")]
        public virtual Membership Membership { get; set; }
    }
}
