using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("UserBookGift")]
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
        [InverseProperty("UserBookGifts")]
        public virtual CurrencyType CurrencyType { get; set; }
    }
}
