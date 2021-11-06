using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class Student
    {
        public Student()
        {
            ServiceCategoryRequest = new HashSet<ServiceCategoryRequest>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }
        public int? UniversityId { get; set; }
        public int? CollegeId { get; set; }
        public int? DepartmentId { get; set; }
        public int? AcademicYearId { get; set; }
        public int? TermId { get; set; }
        public int? PaymentWayId { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal WalletBalance { get; set; }
        public int? CountryId { get; set; }
        public int? MembershipId { get; set; }

        [ForeignKey(nameof(AcademicYearId))]
        [InverseProperty("Student")]
        public virtual AcademicYear AcademicYear { get; set; }
        [ForeignKey(nameof(CollegeId))]
        [InverseProperty("Student")]
        public virtual College College { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Student")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(PaymentWayId))]
        [InverseProperty("Student")]
        public virtual PaymentWay PaymentWay { get; set; }
        [ForeignKey(nameof(TermId))]
        [InverseProperty("Student")]
        public virtual Term Term { get; set; }
        [ForeignKey(nameof(UniversityId))]
        [InverseProperty("Student")]
        public virtual University University { get; set; }
        [InverseProperty("Student")]
        public virtual ICollection<ServiceCategoryRequest> ServiceCategoryRequest { get; set; }
    }
}
