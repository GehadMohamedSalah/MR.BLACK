using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.TempDb
{
    public partial class Service
    {
        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public int? CurrencyTypeId { get; set; }
        public int? ProviderId { get; set; }
        public int? UniversityId { get; set; }
        public int? CollegeId { get; set; }
        public int? DepartmentId { get; set; }
        public int? AcademinYearId { get; set; }
        public int? TermId { get; set; }
        public int? SubjectId { get; set; }
        public int? MinNumOfPages { get; set; }
        public int? MaxNumOfPages { get; set; }
        public bool HasMargins { get; set; }
        public bool HasReference { get; set; }
        public bool HasSpelling { get; set; }
        public bool HasIntroAndEnd { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal TotalPrice { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Discount { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal PlatformRevenue { get; set; }

        [ForeignKey(nameof(AcademinYearId))]
        [InverseProperty(nameof(AcademicYear.Service))]
        public virtual AcademicYear AcademinYear { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(ServiceCategory.Service))]
        public virtual ServiceCategory Category { get; set; }
        [ForeignKey(nameof(CollegeId))]
        [InverseProperty("Service")]
        public virtual College College { get; set; }
        [ForeignKey(nameof(CurrencyTypeId))]
        [InverseProperty("Service")]
        public virtual CurrencyType CurrencyType { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Service")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(ProviderId))]
        [InverseProperty(nameof(ServiceProvider.Service))]
        public virtual ServiceProvider Provider { get; set; }
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("Service")]
        public virtual Subject Subject { get; set; }
        [ForeignKey(nameof(TermId))]
        [InverseProperty("Service")]
        public virtual Term Term { get; set; }
        [ForeignKey(nameof(UniversityId))]
        [InverseProperty("Service")]
        public virtual University University { get; set; }
    }
}
