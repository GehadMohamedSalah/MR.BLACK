﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class Service
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public string ArName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public string EnName { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public int? CategoryId { get; set; }
        public int? CurrencyTypeId { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public int? ProviderId { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public int? UniversityId { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public int? CollegeId { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public int? DepartmentId { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public int? AcademinYearId { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public int? TermId { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
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
        public string ImgPath { get; set; }
        public string AnotherImgPath { get; set; }
        public int? FormTypeId { get; set; }

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
