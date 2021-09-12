using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mr_Black.Database
{
    //[NotMapped]
    public partial class AspNetUsers: IdentityUser
    {
        public AspNetUsers()
        {
            AdvertisingPackageInvoiceView = new HashSet<AdvertisingPackageInvoiceView>();
            BalanceTransfer = new HashSet<BalanceTransfer>();
            BookInvoice = new HashSet<BookInvoice>();
            MessagingFromUser = new HashSet<Messaging>();
            MessagingToUser = new HashSet<Messaging>();
            Punishment = new HashSet<Punishment>();
            ServiceProvider = new HashSet<ServiceProvider>();
            Student = new HashSet<Student>();
            TechnicalSupportFromUser = new HashSet<TechnicalSupport>();
            TechnicalSupportRepliedByUser = new HashSet<TechnicalSupport>();
            UserBookGift = new HashSet<UserBookGift>();
        }

        [StringLength(50)]
        public string ArName { get; set; }
        [StringLength(50)]
        public string EnName { get; set; }
        public int? Gender { get; set; }
        [StringLength(450)]

        [InverseProperty("User")]
        public virtual ICollection<AdvertisingPackageInvoiceView> AdvertisingPackageInvoiceView { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<BalanceTransfer> BalanceTransfer { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<BookInvoice> BookInvoice { get; set; }
        [InverseProperty(nameof(Messaging.FromUser))]
        public virtual ICollection<Messaging> MessagingFromUser { get; set; }
        [InverseProperty(nameof(Messaging.ToUser))]
        public virtual ICollection<Messaging> MessagingToUser { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Punishment> Punishment { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ServiceProvider> ServiceProvider { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Student> Student { get; set; }
        [InverseProperty(nameof(TechnicalSupport.FromUser))]
        public virtual ICollection<TechnicalSupport> TechnicalSupportFromUser { get; set; }
        [InverseProperty(nameof(TechnicalSupport.RepliedByUser))]
        public virtual ICollection<TechnicalSupport> TechnicalSupportRepliedByUser { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserBookGift> UserBookGift { get; set; }
    }
}
