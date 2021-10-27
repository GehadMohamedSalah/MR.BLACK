using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    [Table("UCDS_EductionManagement")]
    public partial class UcdsEductionManagement
    {
        [Key]
        public int Id { get; set; }
        public int? UniversityId { get; set; }
        public int? CollegeId { get; set; }
        public int? DepartmentId { get; set; }
        public int? SubjectId { get; set; }

        [ForeignKey(nameof(CollegeId))]
        [InverseProperty("UcdsEductionManagement")]
        public virtual College College { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("UcdsEductionManagement")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("UcdsEductionManagement")]
        public virtual Subject Subject { get; set; }
        [ForeignKey(nameof(UniversityId))]
        [InverseProperty("UcdsEductionManagement")]
        public virtual University University { get; set; }
    }
}
