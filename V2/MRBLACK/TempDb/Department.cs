using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.TempDb
{
    public partial class Department
    {
        public Department()
        {
            Group = new HashSet<Group>();
            Service = new HashSet<Service>();
            ServiceCategoryRequest = new HashSet<ServiceCategoryRequest>();
            Student = new HashSet<Student>();
            UcdsEductionManagement = new HashSet<UcdsEductionManagement>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public string ImgPath { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<Group> Group { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<Service> Service { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<ServiceCategoryRequest> ServiceCategoryRequest { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<Student> Student { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<UcdsEductionManagement> UcdsEductionManagement { get; set; }
    }
}
