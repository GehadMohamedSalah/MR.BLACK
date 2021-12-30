using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MRBLACK.Models.Database;

namespace MRBLACK.Models.ViewModels
{
    public class ServicePurchaseInvoiceVM
    {
        public int Id { get; set; }
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string InvCode { get; set; }
        public DateTime InvDateTime { get; set; }
        public int? ProviderId { get; set; }
        public int? StudentId { get; set; }
        public int? RequestId { get; set; }
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string RequestCode { get; set; }
        [StringLength(50,ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف ولا اقل من 3 احرف", MinimumLength = 3)]
        public string Copun { get; set; }
        public int? CurrencyTypeId { get; set; }
        public decimal PlatformFees { get; set; }
        public decimal TransferFees { get; set; }
        public decimal TotalCost { get; set; }
        public int? PaymentWayId { get; set; }
        public bool IsPaid { get; set; }
        public int? CopunId { get; set; }
        public List<SubCategoryServiceRequest> RequestContent { get; set; }
        public List<ServicesInServicesPurchaseInvoice> ServiceInvoiceList { get; set; }
        public List<SelectListItem> ProviderList { get; set; }
        public List<SelectListItem> StudentList { get; set; }
        public SelectList RequestList { get; set; }
        public List<CurrencyType> CurrencyTypeList { get; set; }
        public List<PaymentWay> PaymentWayList { get; set; }
        public int FormType { get; set; }
    }

    public class ServiceRequestConnection
    {
        public int SubRequestId { get; set; }
        public int ServiceId { get; set; }
        public decimal ServiceTotalCost { get; set; }
    }
}
