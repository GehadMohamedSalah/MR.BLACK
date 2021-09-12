using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("Term")]
    public partial class Term
    {
        public Term()
        {
            ServiceCategoryRequests = new HashSet<ServiceCategoryRequest>();
            Services = new HashSet<Service>();
            Students = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }

        [InverseProperty(nameof(ServiceCategoryRequest.Term))]
        public virtual ICollection<ServiceCategoryRequest> ServiceCategoryRequests { get; set; }
        [InverseProperty(nameof(Service.Term))]
        public virtual ICollection<Service> Services { get; set; }
        [InverseProperty(nameof(Student.Term))]
        public virtual ICollection<Student> Students { get; set; }
    }
}
