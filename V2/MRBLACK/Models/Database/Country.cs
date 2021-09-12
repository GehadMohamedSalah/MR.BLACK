using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("Country")]
    public partial class Country
    {
        public Country()
        {
            ServiceProviders = new HashSet<ServiceProvider>();
            Universities = new HashSet<University>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public int? CurrencyTypeId { get; set; }

        [ForeignKey(nameof(CurrencyTypeId))]
        [InverseProperty("Countries")]
        public virtual CurrencyType CurrencyType { get; set; }
        [InverseProperty(nameof(ServiceProvider.Country))]
        public virtual ICollection<ServiceProvider> ServiceProviders { get; set; }
        [InverseProperty(nameof(University.Country))]
        public virtual ICollection<University> Universities { get; set; }
    }
}
