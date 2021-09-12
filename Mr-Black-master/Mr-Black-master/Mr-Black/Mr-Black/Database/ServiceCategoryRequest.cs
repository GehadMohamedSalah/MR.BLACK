using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mr_Black.Database
{
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
        [InverseProperty(nameof(AcademicYear.ServiceCategoryRequest))]
        public virtual AcademicYear AcademinYear { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(ServiceCategory.ServiceCategoryRequest))]
        public virtual ServiceCategory Category { get; set; }
        [ForeignKey(nameof(CollegeId))]
        [InverseProperty("ServiceCategoryRequest")]
        public virtual College College { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("ServiceCategoryRequest")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(ProviderIdSelectedFromStudent))]
        [InverseProperty(nameof(ServiceProvider.ServiceCategoryRequest))]
        public virtual ServiceProvider ProviderIdSelectedFromStudentNavigation { get; set; }
        [ForeignKey(nameof(StudentId))]
        [InverseProperty("ServiceCategoryRequest")]
        public virtual Student Student { get; set; }
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("ServiceCategoryRequest")]
        public virtual Subject Subject { get; set; }
        [ForeignKey(nameof(TermId))]
        [InverseProperty("ServiceCategoryRequest")]
        public virtual Term Term { get; set; }
        [ForeignKey(nameof(UniversityId))]
        [InverseProperty("ServiceCategoryRequest")]
        public virtual University University { get; set; }
    }
}
