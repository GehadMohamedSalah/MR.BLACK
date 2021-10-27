using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MRBLACK.Areas.Identity.Data;
using MRBLACK.Data;
using MRBLACK.Helper;
using MRBLACK.Models.Database;
using MRBLACK.Models.Enums;
using MRBLACK.Models.ViewModels;
using MRBLACK.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MRBLACK.Controllers
{
    [Authorize]
    public class ServicePurchaseInvoiceController : Controller
    {
        private readonly Repository<ServiceCategoryRequest> _ServiceCategoryRequest;
        private readonly Repository<ServiceRequest> _ServiceRequest;
        private readonly Repository<Student> _Student;
        private readonly Repository<ServiceProvider> _Provider;
        private readonly Repository<Country> _Country;
        private readonly Repository<University> _University;
        private readonly Repository<College> _College;
        private readonly Repository<AcademicYear> _AcademicYear;
        private readonly Repository<Department> _Department;
        private readonly Repository<Term> _Term;
        private readonly Repository<Subject> _Subject;
        private readonly Repository<ServiceCategory> _Category;
        private readonly Repository<ServicesPurchaseInvoice> _ServicesPurchaseInvoice;
        private readonly Repository<ServicesInServicesPurchaseInvoice> _ServicesInServicesPurchaseInvoice;
        private readonly Repository<PaymentWay> _PaymentWay;
        private readonly Repository<CurrencyType> _CurrencyType;
        private readonly Repository<SystemSetting> _SystemSetting;
        private readonly Repository<Copun> _Copun;
        private readonly Repository<Service> _Service;

        private readonly IdentitySetupContext _identitySetupContext;

        //private readonly int PageSize;
        public ServicePurchaseInvoiceController(IRepository<ServiceCategoryRequest> ServiceCategoryRequest,
           IRepository<Student> Student,
           IRepository<ServiceProvider> Provider,
           IRepository<ServiceRequest> ServiceRequest,
           IRepository<Country> Country,
           IRepository<University> University,
           IRepository<College> College,
           IRepository<AcademicYear> AcademicYear,
           IRepository<Department> Department,
           IRepository<Term> Term,
           IRepository<Subject> Subject,
           IRepository<ServiceCategory> Category,
           IRepository<ServicesPurchaseInvoice> ServicesPurchaseInvoice,
           IRepository<ServicesInServicesPurchaseInvoice> ServicesInServicesPurchaseInvoice,
           IRepository<PaymentWay> PaymentWay,
           IRepository<CurrencyType> CurrencyType,
           IRepository<SystemSetting> SystemSetting,
           IRepository<Copun> Copun,
           IRepository<Service> Service,
           IdentitySetupContext identitySetupContext)
        {
            _ServiceCategoryRequest = (Repository<ServiceCategoryRequest>)ServiceCategoryRequest;
            _Student = (Repository<Student>)Student;
            _Provider = (Repository<ServiceProvider>)Provider;
            _ServiceRequest = (Repository<ServiceRequest>)ServiceRequest;
            _Country = (Repository<Country>)Country;
            _University = (Repository<University>)University;
            _College = (Repository<College>)College;
            _AcademicYear = (Repository<AcademicYear>)AcademicYear;
            _Department = (Repository<Department>)Department;
            _Term = (Repository<Term>)Term;
            _Subject = (Repository<Subject>)Subject;
            _Category = (Repository<ServiceCategory>)Category;
            _ServicesPurchaseInvoice = (Repository<ServicesPurchaseInvoice>)ServicesPurchaseInvoice;
            _PaymentWay = (Repository<PaymentWay>)PaymentWay;
            _ServicesInServicesPurchaseInvoice = (Repository<ServicesInServicesPurchaseInvoice>)ServicesInServicesPurchaseInvoice;
            _CurrencyType = (Repository<CurrencyType>)CurrencyType;
            _SystemSetting = (Repository<SystemSetting>)SystemSetting;
            _Copun = (Repository<Copun>)Copun;
            _Service = (Repository<Service>)Service;

            _identitySetupContext = identitySetupContext;
            // PageSize = 5;
        }
        public IActionResult Create(int? requestId)
        {
            decimal platformFees = 0;
            if (_SystemSetting.GetAll() != null && _SystemSetting.GetAll().Count() > 0)
            {
                platformFees = _SystemSetting.GetFirstOrDefault().ImprovementFeesForStudent + _SystemSetting.GetFirstOrDefault().SellingFeesForStudent;
            }
            ServicePurchaseInvoiceVM model = new ServicePurchaseInvoiceVM()
            {
                InvCode = "Inv_ " + (_ServicesPurchaseInvoice.GetAll().Count() + 1),
                InvDateTime = DateTime.Now,
                RequestId = requestId,
                ServiceInvoiceList = new List<ServicesInServicesPurchaseInvoice>(),
                RequestContent = new List<SubCategoryServiceRequest>(),
                PlatformFees = platformFees
            };
            List<ServiceProvider> providers = new List<ServiceProvider>();
            List<Student> students = new List<Student>();
            if (requestId != null)
            {
                var request = _ServiceCategoryRequest.GetElement((int)requestId);
                model.FormType = (int)_Category.GetElement((int)request.CategoryId).FormType;

                model.StudentId = (int)request.StudentId;
                model.RequestCode = request.RequestCode;
                _ServiceRequest.GetAll(f => f.ServiceCategoryRequestId == request.Id).ToList().ForEach(c =>
                {
                    var category = _Category.GetElement((int)c.SubCategoryId);
                    model.RequestContent.Add(new SubCategoryServiceRequest()
                    {
                        Id = c.Id,
                        SubCategoryId = (int)c.SubCategoryId,
                        SubCategoryName = category.ArName,
                        TimesOfService = (int)c.TimesOfService,
                        DeliveryPeriodInDays = (int)c.DeliveryPeriodInDays,
                        PaperNum = c.PaperNum,
                        HasIntroAndEnd = c.HasIntroAndEnd,
                        HasMargins = c.HasMargins,
                        HasReference = c.HasReference,
                        HasSpelling = c.HasSpelling,
                        PricingMethod = (int)category.PricingMethod,
                        Price = _Category.GetElement((int)c.SubCategoryId).ServicePrice
                    });
                });

                if (request.ProvidersAccepted != null && request.ProvidersAccepted != "")
                {
                    foreach (var item in request.ProvidersAccepted.Split("_"))
                    {
                        if (item != null && item != "")
                            providers.Add(_Provider.GetElement(Int32.Parse(item)));
                    }
                }

                students.Add(_Student.GetElement((int)request.StudentId));
                model.StudentId = request.StudentId;

            }
            else
            {
                providers = _Provider.GetAll().ToList();
                students = _Student.GetAll().ToList();
            }

            model.ProviderList = GetProviderSelectList(providers);
            model.StudentList = GetStudentSelectList(students);
            model.PaymentWayList = _PaymentWay.GetAll().ToList();
            model.CurrencyTypeList = _CurrencyType.GetAll().ToList();
            return View(model);
        }

        private List<SelectListItem> GetProviderSelectList(List<ServiceProvider> providers)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in providers)
            {
                list.Add(new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = _identitySetupContext.Users.Find(item.UserId).ArName
                });
            }
            return list;
        }

        private List<SelectListItem> GetStudentSelectList(List<Student> students)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in students)
            {
                list.Add(new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = _identitySetupContext.Users.Find(item.UserId).ArName
                });
            }
            return list;
        }
        [HttpPost]
        public IActionResult Create(ServicePurchaseInvoiceVM model)
        {
            decimal platformFees = 0;
            decimal transferFees = 0;
            if (_SystemSetting.GetAll() != null && _SystemSetting.GetAll().Count() > 0)
            {
                platformFees = _SystemSetting.GetFirstOrDefault().ImprovementFeesForStudent + _SystemSetting.GetFirstOrDefault().SellingFeesForStudent;
            }
            var invoice = new ServicesPurchaseInvoice()
            {
                InvNumber = model.InvCode,
                InvDateTime = model.InvDateTime,
                IsPaid = true,
                CurrencyTypeId = model.CurrencyTypeId,
                ProviderId = model.ProviderId,
                StudentId = model.StudentId,
                PaymentWayId = model.PaymentWayId,
                CopunId = model.CopunId,
                ServiceCategoryRequestId = model.RequestId,
                ServicesInServicesPurchaseInvoices = model.ServiceInvoiceList,
                TotalCost = 0,
                Platformrevenue = 0,
                ProviderRevenue = 0
            };

            if(model.ServiceInvoiceList != null && model.ServiceInvoiceList.Count > 0)
            {
                foreach(var item in model.ServiceInvoiceList)
                {
                    var times = model.RequestContent.FirstOrDefault(c => c.Id == item.SubRequestId).TimesOfService;
                    var service = _Service.GetFirstOrDefault(c => c.Id == (int)item.ServiceId, "Category");
                    invoice.TotalCost += service.TotalPrice * times;
                    if(service.Category.PricingMethod == (int)PricingMethod.Gabry)
                    {
                        invoice.Platformrevenue += service.Category.PlatformRevenueFromServPrice * times;
                    }
                    else
                    {
                        invoice.Platformrevenue += (service.TotalPrice * times) * (service.Category.CommissionPercentage / 100);
                    }
                }
            }

            invoice.ProviderRevenue += invoice.TotalCost - invoice.Platformrevenue;

            if (model.PaymentWayId != null)
            {
                transferFees = invoice.TotalCost * (decimal)_PaymentWay.GetElement((int)model.PaymentWayId).TransferFees / 100;
            }

            invoice.Discount = 0;
            if (model.CopunId != null)
            {
                var copun = _Copun.GetElement((int)model.CopunId);
                decimal discount = invoice.TotalCost * (decimal)copun.DiscountPercentage / 100;
                if (copun.DiscountOnWho == 1) {
                    invoice.Platformrevenue -= discount; 
                }
                else
                {
                    invoice.ProviderRevenue -= discount;
                }
                invoice.Discount = discount;
            }


            var totalFees = transferFees + platformFees;
            invoice.Platformrevenue += totalFees;
            invoice.TotalFees = totalFees;
            

            _ServicesPurchaseInvoice.Add(invoice);
            ChangeRequestStatus((int)model.RequestId,model.ProviderId);
            return RedirectToAction("Index","Request");
        }

        private void ChangeRequestStatus(int requestId,int? providerId)
        {
            var req = _ServiceCategoryRequest.GetElement(requestId);
            req.ProviderId = (int)providerId;
            req.Status = (int)Status.Accepted;
            _ServiceCategoryRequest.Update(req);
        }

        public IActionResult GetServiceCost(int? providerId, int? requestId)
        {
            List<ServiceRequestConnection> model = new List<ServiceRequestConnection>();
            if (providerId != null && requestId != null)
            {
                var prov = _Provider.GetFirstOrDefault(c => c.Id == (int)providerId, "Services");
                var req = _ServiceCategoryRequest.GetElement((int)requestId);
                var srInscr = _ServiceRequest.GetAll(c => c.ServiceCategoryRequestId == req.Id).ToList();
                var provServices = prov.Services.Where(c => c.UniversityId == req.UniversityId
                && c.CollegeId == req.CollegeId && c.AcademinYearId == req.AcademinYearId
                && c.DepartmentId == req.DepartmentId
                && c.TermId == req.TermId && c.SubjectId == req.SubjectId).ToList();
                if (provServices != null && provServices.Count > 0)
                {
                    foreach (var c in provServices)
                    {
                        foreach (var x in srInscr)
                        {
                            if (x.SubCategoryId == c.CategoryId
                                && x.HasMargins == c.HasMargins
                                && x.HasReference == c.HasReference
                                && x.HasSpelling == c.HasSpelling
                                && x.HasIntroAndEnd == c.HasIntroAndEnd)
                            {
                                model.Add(new ServiceRequestConnection()
                                {
                                    SubRequestId = x.Id,
                                    ServiceId = c.Id,
                                    ServiceTotalCost = c.TotalPrice * (decimal)x.TimesOfService
                                });
                            }
                        }

                        if(model.Count() == srInscr.Count())
                        {
                            break;
                        }
                    }
                }
            }
            var jsonobj = JsonConvert.SerializeObject(model);
            return Json(jsonobj);
        }

        public IActionResult GetCopunDiscount(string copun,decimal totalServicesCost)
        {
            var myCopun = _Copun.GetFirstOrDefault(c => c.NameOrCode == copun);
            int discount = 0;
            if(myCopun!= null)
            {
                if(myCopun.StartDate <= DateTime.Now && myCopun.EndDate >= DateTime.Now 
                    && myCopun.MinInvoiceVal < totalServicesCost && myCopun.IsPublic == true)
                {
                    discount = (int)myCopun.DiscountPercentage;
                }
            }

            return Json(JsonConvert.SerializeObject(myCopun));
        }
    }
}
