using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mr_Black.Database
{
    public partial class UserBookGift
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal MaxBookPrice { get; set; }
        public int? CurrencyTypeId { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }
        public bool GiftIsDelivered { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeliveredDateTime { get; set; }

        [ForeignKey(nameof(CurrencyTypeId))]
        [InverseProperty("UserBookGift")]
        public virtual CurrencyType CurrencyType { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUsers.UserBookGift))]
        public virtual AspNetUsers User { get; set; }
    }
}
