using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("CurrencyExchange")]
    public partial class CurrencyExchange
    {
        [Key]
        public int Id { get; set; }
        public int? CurrencyId { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal? CurrencyValInhMainCurrency { get; set; }

        [ForeignKey(nameof(CurrencyId))]
        [InverseProperty(nameof(CurrencyType.CurrencyExchanges))]
        public virtual CurrencyType Currency { get; set; }
    }
}
