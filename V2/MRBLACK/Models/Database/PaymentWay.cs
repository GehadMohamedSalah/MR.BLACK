using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("PaymentWay")]
    public partial class PaymentWay
    {
        public PaymentWay()
        {
            ServiceProviders = new HashSet<ServiceProvider>();
            Students = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal? TransferFees { get; set; }
        public string ImgName { get; set; }
        public string ImgPath { get; set; }

        [InverseProperty(nameof(ServiceProvider.PaymentWay))]
        public virtual ICollection<ServiceProvider> ServiceProviders { get; set; }
        [InverseProperty(nameof(Student.PaymentWay))]
        public virtual ICollection<Student> Students { get; set; }
    }
}
