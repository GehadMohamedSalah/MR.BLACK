using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("BalanceTransfer")]
    public partial class BalanceTransfer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal BalanceVal { get; set; }
        public int? CurrencyTypeId { get; set; }
        public string Reason { get; set; }
        public int? AddOrDebitBalance { get; set; }

        [ForeignKey(nameof(CurrencyTypeId))]
        [InverseProperty("BalanceTransfers")]
        public virtual CurrencyType CurrencyType { get; set; }
    }
}
