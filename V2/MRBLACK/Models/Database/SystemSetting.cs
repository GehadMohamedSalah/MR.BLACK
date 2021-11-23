using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class SystemSetting
    {
        [Key]
        public int Id { get; set; }
        public string SiteName { get; set; }
        public string SiteDesc { get; set; }
        public string KeyWords { get; set; }
        public string ForbiddenWords { get; set; }
        [EmailAddress(ErrorMessage = "البريد يجب ان يحتوي على @")]
        public string SupportMail { get; set; }
        [EmailAddress(ErrorMessage = "البريد يجب ان يحتوي على @")]
        public string InquiriesMail { get; set; }
        [EmailAddress(ErrorMessage = "البريد يجب ان يحتوي على @")]
        public string HrDeptMail { get; set; }
        [EmailAddress(ErrorMessage = "البريد يجب ان يحتوي على @")]
        public string FinancialManagerMail { get; set; }
        [Column("CEOMail")]
        [EmailAddress(ErrorMessage = "البريد يجب ان يحتوي على @")]
        public string Ceomail { get; set; }
        [EmailAddress(ErrorMessage = "البريد يجب ان يحتوي على @")]
        public string MarketingMail { get; set; }
        public string MinWithdrawalRequest { get; set; }
        public string MaxWorkBalance { get; set; }
        public string SiteClosureMsg { get; set; }
        public string TermsAndConditions { get; set; }
        public string PrivacyPolicy { get; set; }
        public string GuaranteeOfMoneyAndEntitlements { get; set; }
        public string HowDealWithSite { get; set; }
        public string AboutUs { get; set; }
        public string TextOfContact { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal ImprovementFeesForStudent { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal ImprovementFeesForServiceProvider { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal SellingFeesForStudent { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal SellingFeesForServiceProvider { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal CurrentBalaces { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal TransferedBalances { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal TotalRevenue { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal ServiceMarginsPercentage { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal ServiceReferencePercentage { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal ServiceSpellingPercentage { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal ServiceIntroAndEndPercentage { get; set; }
    }
}
