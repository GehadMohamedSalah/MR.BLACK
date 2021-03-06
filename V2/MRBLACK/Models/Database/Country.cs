using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
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
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        [Remote("IsUniqueRow", "Country", ErrorMessage = "لا يمكن تكرار الاسم", AdditionalFields = nameof(Id))]
        public string ArName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        [Remote("IsUniqueRow", "Country", ErrorMessage = "لا يمكن تكرار الاسم", AdditionalFields = nameof(Id))]
        public string EnName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        public int? CurrencyTypeId { get; set; }
        public string ImgPath { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
        [StringLength(10, ErrorMessage = "لا يمكن ادخال اكثر من 10 ارقام او رموز ولا اقل من رقم واحد او رمز", MinimumLength = 1)]
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
