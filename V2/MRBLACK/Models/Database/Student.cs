using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("Student")]
    public partial class Student
    {
        public Student()
        {
            ServiceCategoryRequests = new HashSet<ServiceCategoryRequest>();
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

        [ForeignKey(nameof(AcademicYearId))]
        [InverseProperty("Students")]
        public virtual AcademicYear AcademicYear { get; set; }
        [ForeignKey(nameof(CollegeId))]
        [InverseProperty("Students")]
        public virtual College College { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Students")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(PaymentWayId))]
        [InverseProperty("Students")]
        public virtual PaymentWay PaymentWay { get; set; }
        [ForeignKey(nameof(TermId))]
        [InverseProperty("Students")]
        public virtual Term Term { get; set; }
        [ForeignKey(nameof(UniversityId))]
        [InverseProperty("Students")]
        public virtual University University { get; set; }
        [InverseProperty(nameof(ServiceCategoryRequest.Student))]
        public virtual ICollection<ServiceCategoryRequest> ServiceCategoryRequests { get; set; }

        public int? CountryId { get; set; }
    }
}
