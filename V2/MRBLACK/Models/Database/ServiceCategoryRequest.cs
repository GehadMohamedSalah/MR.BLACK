using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("ServiceCategoryRequest")]
    public partial class ServiceCategoryRequest
    {
        [Key]
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int? UniversityId { get; set; }
        public int? CollegeId { get; set; }
        public int? DepartmentId { get; set; }
        public int? AcademinYearId { get; set; }
        public int? TermId { get; set; }
        public int? SubjectId { get; set; }
        public int? StudentId { get; set; }
        public string ProvidersAccepted { get; set; }
        public int? ProviderIdSelectedFromStudent { get; set; }
        public bool HasMargins { get; set; }
        public bool HasSpelling { get; set; }
        public bool HasReference { get; set; }
        public bool HasIntroAndEnd { get; set; }

        [ForeignKey(nameof(AcademinYearId))]
        [InverseProperty(nameof(AcademicYear.ServiceCategoryRequests))]
        public virtual AcademicYear AcademinYear { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(ServiceCategory.ServiceCategoryRequests))]
        public virtual ServiceCategory Category { get; set; }
        [ForeignKey(nameof(CollegeId))]
        [InverseProperty("ServiceCategoryRequests")]
        public virtual College College { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("ServiceCategoryRequests")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(ProviderIdSelectedFromStudent))]
        [InverseProperty(nameof(ServiceProvider.ServiceCategoryRequests))]
        public virtual ServiceProvider ProviderIdSelectedFromStudentNavigation { get; set; }
        [ForeignKey(nameof(StudentId))]
        [InverseProperty("ServiceCategoryRequests")]
        public virtual Student Student { get; set; }
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("ServiceCategoryRequests")]
        public virtual Subject Subject { get; set; }
        [ForeignKey(nameof(TermId))]
        [InverseProperty("ServiceCategoryRequests")]
        public virtual Term Term { get; set; }
        [ForeignKey(nameof(UniversityId))]
        [InverseProperty("ServiceCategoryRequests")]
        public virtual University University { get; set; }
    }
}
