using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
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
        [InverseProperty("BalanceTransfer")]
        public virtual CurrencyType CurrencyType { get; set; }
    }
}
