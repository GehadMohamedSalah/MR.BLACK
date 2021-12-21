using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class CurrencyType
    {
        public CurrencyType()
        {
            AdvertisingPackage = new HashSet<AdvertisingPackage>();
            BalanceTransfer = new HashSet<BalanceTransfer>();
            BookStore = new HashSet<BookStore>();
            Copun = new HashSet<Copun>();
            Country = new HashSet<Country>();
            CurrencyExchange = new HashSet<CurrencyExchange>();
            Service = new HashSet<Service>();
            ServiceCategory = new HashSet<ServiceCategory>();
            ServicesPurchaseInvoice = new HashSet<ServicesPurchaseInvoice>();
            UserBookGift = new HashSet<UserBookGift>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [StringLength(50, ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف")]
        public string ArName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [StringLength(50, ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف")]
        public string EnName { get; set; }
        public bool IsMainCurrency { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public decimal ValueInPound { get; set; }

        [InverseProperty("CurrencyType")]
        public virtual ICollection<AdvertisingPackage> AdvertisingPackage { get; set; }
        [InverseProperty("CurrencyType")]
        public virtual ICollection<BalanceTransfer> BalanceTransfer { get; set; }
        [InverseProperty("CurrencyType")]
        public virtual ICollection<BookStore> BookStore { get; set; }
        [InverseProperty("CurrencyType")]
        public virtual ICollection<Copun> Copun { get; set; }
        [InverseProperty("CurrencyType")]
        public virtual ICollection<Country> Country { get; set; }
        [InverseProperty("Currency")]
        public virtual ICollection<CurrencyExchange> CurrencyExchange { get; set; }
        [InverseProperty("CurrencyType")]
        public virtual ICollection<Service> Service { get; set; }
        [InverseProperty("CurrencyType")]
        public virtual ICollection<ServiceCategory> ServiceCategory { get; set; }
        [InverseProperty("CurrencyType")]
        public virtual ICollection<ServicesPurchaseInvoice> ServicesPurchaseInvoice { get; set; }
        [InverseProperty("CurrencyType")]
        public virtual ICollection<UserBookGift> UserBookGift { get; set; }
    }
}
