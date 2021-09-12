using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("Privilage")]
    public partial class Privilage
    {
        public Privilage()
        {
            RolePrivilages = new HashSet<RolePrivilage>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public int? OrderNum { get; set; }

        [InverseProperty(nameof(RolePrivilage.Privilage))]
        public virtual ICollection<RolePrivilage> RolePrivilages { get; set; }
    }
}
