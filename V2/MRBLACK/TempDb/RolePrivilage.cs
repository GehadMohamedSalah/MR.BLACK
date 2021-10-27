using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.TempDb
{
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
        [InverseProperty("RolePrivilage")]
        public virtual Privilage Privilage { get; set; }
    }
}
