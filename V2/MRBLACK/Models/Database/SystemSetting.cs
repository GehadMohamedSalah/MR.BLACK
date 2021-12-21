﻿using System;
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
        [StringLength(50, ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف")]
        public string SiteName { get; set; }
        [StringLength(200, ErrorMessage = "لا يمكن ادخال اكثر من 200 حرف")]
        public string SiteDesc { get; set; }
        [StringLength(50, ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف")]
        public string KeyWords { get; set; }
        [StringLength(50, ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف")]
        public string ForbiddenWords { get; set; }
        [EmailAddress(ErrorMessage = "البريد يجب ان يحتوي على @")]
        [StringLength(50, ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف")]
        public string SupportMail { get; set; }
        [EmailAddress(ErrorMessage = "البريد يجب ان يحتوي على @")]
        [StringLength(50, ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف")]
        public string InquiriesMail { get; set; }
        [EmailAddress(ErrorMessage = "البريد يجب ان يحتوي على @")]
        [StringLength(50, ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف")]
        public string HrDeptMail { get; set; }
        [EmailAddress(ErrorMessage = "البريد يجب ان يحتوي على @")]
        [StringLength(50, ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف")]
        public string FinancialManagerMail { get; set; }
        [Column("CEOMail")]
        [EmailAddress(ErrorMessage = "البريد يجب ان يحتوي على @")]
        [StringLength(50, ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف")]
        public string Ceomail { get; set; }
        [EmailAddress(ErrorMessage = "البريد يجب ان يحتوي على @")]
        [StringLength(50, ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف")]
        public string MarketingMail { get; set; }
        [StringLength(50, ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف")]
        public string MinWithdrawalRequest { get; set; }
        [StringLength(50, ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف")]
        public string MaxWorkBalance { get; set; }
        [StringLength(200, ErrorMessage = "لا يمكن ادخال اكثر من 200 حرف")]
        public string SiteClosureMsg { get; set; }
        [StringLength(200, ErrorMessage = "لا يمكن ادخال اكثر من 200 حرف")]
        public string TermsAndConditions { get; set; }
        [StringLength(200, ErrorMessage = "لا يمكن ادخال اكثر من 200 حرف")]
        public string PrivacyPolicy { get; set; }
        [StringLength(200, ErrorMessage = "لا يمكن ادخال اكثر من 200 حرف")]
        public string GuaranteeOfMoneyAndEntitlements { get; set; }
        [StringLength(200, ErrorMessage = "لا يمكن ادخال اكثر من 200 حرف")]
        public string HowDealWithSite { get; set; }
        [StringLength(200, ErrorMessage = "لا يمكن ادخال اكثر من 200 حرف")]
        public string AboutUs { get; set; }
        [StringLength(200, ErrorMessage = "لا يمكن ادخال اكثر من 200 حرف")]
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
