using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class Privilage
    {
        public Privilage()
        {
            RolePrivilage = new HashSet<RolePrivilage>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public int? OrderNum { get; set; }

        [InverseProperty("Privilage")]
        public virtual ICollection<RolePrivilage> RolePrivilage { get; set; }
    }
}
