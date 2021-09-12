using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("University")]
    public partial class University
    {
        public University()
        {
            ServiceCategoryRequests = new HashSet<ServiceCategoryRequest>();
            Services = new HashSet<Service>();
            Students = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public int? CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("Universities")]
        public virtual Country Country { get; set; }
        [InverseProperty(nameof(ServiceCategoryRequest.University))]
        public virtual ICollection<ServiceCategoryRequest> ServiceCategoryRequests { get; set; }
        [InverseProperty(nameof(Service.University))]
        public virtual ICollection<Service> Services { get; set; }
        [InverseProperty(nameof(Student.University))]
        public virtual ICollection<Student> Students { get; set; }
    }
}
