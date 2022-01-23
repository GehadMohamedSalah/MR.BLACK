using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.TempDb
{
    public partial class Country
    {
        public Country()
        {
            ServiceProvider = new HashSet<ServiceProvider>();
            University = new HashSet<University>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public int? CurrencyTypeId { get; set; }
        public string ImgPath { get; set; }
        [StringLength(50)]
        public string CountryCode { get; set; }

        [ForeignKey(nameof(CurrencyTypeId))]
        [InverseProperty("Country")]
        public virtual CurrencyType CurrencyType { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<ServiceProvider> ServiceProvider { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<University> University { get; set; }
    }
}
