using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("Punishment")]
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
