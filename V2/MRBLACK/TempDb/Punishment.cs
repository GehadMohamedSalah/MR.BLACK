using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.TempDb
{
    public partial class Punishment
    {
        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }
        public int? PunishmentType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PunishmentDateTime { get; set; }
        public int? BanPeriodInDays { get; set; }
    }
}
