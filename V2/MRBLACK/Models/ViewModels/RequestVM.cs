using Microsoft.AspNetCore.Mvc.Rendering;
using MRBLACK.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Models.ViewModels
{
    public class RequestVM
    {
        public ServiceCategoryRequest ServiceCategoryRequest { get; set; }
        public SelectList MainCategoryList { get; set; }
        public SelectList CountryList{ get; set; }
        public SelectList UniversityList{ get; set; }
        public SelectList CollegeList{ get; set; }
        public SelectList AcademicYearList{ get; set; }
        public SelectList DepartmentList { get; set; }
        public SelectList TermList{ get; set; }
        public SelectList SubjectList{ get; set; }
        public List<SelectListItem> ProviderList{ get; set; }
        public List<SubCategoryServiceRequest> ServiceRequestCollection { get; set; }
        public SelectList SubCategoryList { get; set; }
        public bool CanEdited { get; set; }
        public int FormType { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class SubCategoryServiceRequest
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int TimesOfService { get; set; }
        public int DeliveryPeriodInDays { get; set; }
        public int? PaperNum { get; set; }
        public bool HasMargins { get; set; }
        public bool HasSpelling { get; set; }
        public bool HasReference { get; set; }
        public bool HasIntroAndEnd { get; set; }
        public decimal Price { get; set; }
        public int PricingMethod { get; set; }
    }

    public class RequestIndexVM
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string RequestDateTime { get; set; }
        public int Status { get; set; }
        public decimal Total { get; set; }
        public string ProvidersAccepted { get; set; }
    }
}
