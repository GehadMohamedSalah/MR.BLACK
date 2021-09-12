using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mr_Black.Database
{
    public partial class University
    {
        public University()
        {
            Service = new HashSet<Service>();
            ServiceCategoryRequest = new HashSet<ServiceCategoryRequest>();
            Student = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public int? CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("University")]
        public virtual Country Country { get; set; }
        [InverseProperty("University")]
        public virtual ICollection<Service> Service { get; set; }
        [InverseProperty("University")]
        public virtual ICollection<ServiceCategoryRequest> ServiceCategoryRequest { get; set; }
        [InverseProperty("University")]
        public virtual ICollection<Student> Student { get; set; }
    }
}
