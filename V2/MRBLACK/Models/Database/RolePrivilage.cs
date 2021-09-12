using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("RolePrivilage")]
    public partial class RolePrivilage
    {
        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        public string RoleId { get; set; }
        public int? PrivilageId { get; set; }
        public bool CanShow { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

        [ForeignKey(nameof(PrivilageId))]
        [InverseProperty("RolePrivilages")]
        public virtual Privilage Privilage { get; set; }
    }
}
