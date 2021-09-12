using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("CurrencyType")]
    public partial class CurrencyType
    {
        public CurrencyType()
        {
            AdvertisingPackages = new HashSet<AdvertisingPackage>();
            BalanceTransfers = new HashSet<BalanceTransfer>();
            BookStores = new HashSet<BookStore>();
            Copuns = new HashSet<Copun>();
            Countries = new HashSet<Country>();
            CurrencyExchanges = new HashSet<CurrencyExchange>();
            ServiceCategories = new HashSet<ServiceCategory>();
            Services = new HashSet<Service>();
            ServicesPurchaseInvoices = new HashSet<ServicesPurchaseInvoice>();
            UserBookGifts = new HashSet<UserBookGift>();
        }

        [Key]
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public bool IsMainCurrency { get; set; }
        public decimal ValueInPound { get; set; }

        [InverseProperty(nameof(AdvertisingPackage.CurrencyType))]
        public virtual ICollection<AdvertisingPackage> AdvertisingPackages { get; set; }
        [InverseProperty(nameof(BalanceTransfer.CurrencyType))]
        public virtual ICollection<BalanceTransfer> BalanceTransfers { get; set; }
        [InverseProperty(nameof(BookStore.CurrencyType))]
        public virtual ICollection<BookStore> BookStores { get; set; }
        [InverseProperty(nameof(Copun.CurrencyType))]
        public virtual ICollection<Copun> Copuns { get; set; }
        [InverseProperty(nameof(Country.CurrencyType))]
        public virtual ICollection<Country> Countries { get; set; }
        [InverseProperty(nameof(CurrencyExchange.Currency))]
        public virtual ICollection<CurrencyExchange> CurrencyExchanges { get; set; }
        [InverseProperty(nameof(ServiceCategory.CurrencyType))]
        public virtual ICollection<ServiceCategory> ServiceCategories { get; set; }
        [InverseProperty(nameof(Service.CurrencyType))]
        public virtual ICollection<Service> Services { get; set; }
        [InverseProperty(nameof(ServicesPurchaseInvoice.CurrencyType))]
        public virtual ICollection<ServicesPurchaseInvoice> ServicesPurchaseInvoices { get; set; }
        [InverseProperty(nameof(UserBookGift.CurrencyType))]
        public virtual ICollection<UserBookGift> UserBookGifts { get; set; }
    }
}
