using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("College")]
    public partial class College
    {
        public College()
        {
            ServiceCategoryRequests = new HashSet<ServiceCategoryRequest>();
            Services = new HashSet<Service>();
            Students = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }

        [InverseProperty(nameof(ServiceCategoryRequest.College))]
        public virtual ICollection<ServiceCategoryRequest> ServiceCategoryRequests { get; set; }
        [InverseProperty(nameof(Service.College))]
        public virtual ICollection<Service> Services { get; set; }
        [InverseProperty(nameof(Student.College))]
        public virtual ICollection<Student> Students { get; set; }
    }
}
