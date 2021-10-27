using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("Service")]
    public partial class Service
    {
        public Service()
        {
        }

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
        [InverseProperty(nameof(AcademicYear.Services))]
        public virtual AcademicYear AcademinYear { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(ServiceCategory.Services))]
        public virtual ServiceCategory Category { get; set; }
        [ForeignKey(nameof(CollegeId))]
        [InverseProperty("Services")]
        public virtual College College { get; set; }
        [ForeignKey(nameof(CurrencyTypeId))]
        [InverseProperty("Services")]
        public virtual CurrencyType CurrencyType { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Services")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(ProviderId))]
        [InverseProperty(nameof(ServiceProvider.Services))]
        public virtual ServiceProvider Provider { get; set; }
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("Services")]
        public virtual Subject Subject { get; set; }
        [ForeignKey(nameof(TermId))]
        [InverseProperty("Services")]
        public virtual Term Term { get; set; }
        [ForeignKey(nameof(UniversityId))]
        [InverseProperty("Services")]
        public virtual University University { get; set; }
    }
}
