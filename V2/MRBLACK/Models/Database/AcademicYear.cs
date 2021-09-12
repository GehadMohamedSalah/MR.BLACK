using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("AcademicYear")]
    public partial class AcademicYear
    {
        public AcademicYear()
        {
            ServiceCategoryRequests = new HashSet<ServiceCategoryRequest>();
            Services = new HashSet<Service>();
            Students = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }

        [InverseProperty(nameof(ServiceCategoryRequest.AcademinYear))]
        public virtual ICollection<ServiceCategoryRequest> ServiceCategoryRequests { get; set; }
        [InverseProperty(nameof(Service.AcademinYear))]
        public virtual ICollection<Service> Services { get; set; }
        [InverseProperty(nameof(Student.AcademicYear))]
        public virtual ICollection<Student> Students { get; set; }
    }
}
