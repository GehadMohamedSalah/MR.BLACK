using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mr_Black.Database
{
    public partial class CurrencyExchange
    {
        [Key]
        public int Id { get; set; }
        public int? CurrencyId { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal? CurrencyValInhMainCurrency { get; set; }

        [ForeignKey(nameof(CurrencyId))]
        [InverseProperty(nameof(CurrencyType.CurrencyExchange))]
        public virtual CurrencyType Currency { get; set; }
    }
}
