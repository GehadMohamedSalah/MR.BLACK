using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.TempDb
{
    public partial class PaymentWay
    {
        public PaymentWay()
        {
            ServiceProvider = new HashSet<ServiceProvider>();
            Student = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal? TransferFees { get; set; }
        public string ImgName { get; set; }
        public string ImgPath { get; set; }

        [InverseProperty("PaymentWay")]
        public virtual ICollection<ServiceProvider> ServiceProvider { get; set; }
        [InverseProperty("PaymentWay")]
        public virtual ICollection<Student> Student { get; set; }
    }
}
