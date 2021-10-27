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

namespace MRBLACK.Controllers
{
    [Authorize]
    public class RequestController : Controller
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
        private readonly Repository<ServicesPurchaseInvoice> _Invoice;

        private readonly IdentitySetupContext _identitySetupContext;


        private readonly int PageSize;
        public RequestController(IRepository<ServiceCategoryRequest> ServiceCategoryRequest,
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
            IRepository<ServicesPurchaseInvoice> Invoice,

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
            _Invoice = (Repository<ServicesPurchaseInvoice>)Invoice;
            _identitySetupContext = identitySetupContext;
            PageSize = 5;
        }

        #region CRUD OPERTIONS

        #region Get ServiceCategoryRequests
        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            var stu = _Student.GetFirstOrDefault(c => c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.IsStudent = false;
            if (stu != null)
                ViewBag.IsStudent = true;
            return View(GetPagedListItems("", pageNumber,pageSize));
        }
        #endregion

        #region Create ServiceCategoryRequest
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            var stu = _Student.GetFirstOrDefault(f => f.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier), "University");

            var model = new RequestVM()
            {
                ServiceCategoryRequest = new ServiceCategoryRequest()
                {
                    RequestCode = "Req_" + (_ServiceCategoryRequest.GetAll().Count() + 1),
                    RequestDateTime = DateTime.Now,
                    StudentId = stu.Id,
                    UniversityId = stu.UniversityId,
                    University = stu.University,
                    CollegeId = stu.CollegeId,
                    AcademinYearId = stu.AcademicYearId,
                    TermId = stu.TermId,
                    DepartmentId = stu.DepartmentId,
                    Status = (int)Status.Pending
                },
                ServiceRequestCollection = new List<SubCategoryServiceRequest>(),
                CanEdited = true,
            };
            model = FillDropdownLists(model);
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Create(RequestVM model)
        {
            if (ModelState.IsValid)
            {
                _ServiceCategoryRequest.Add(model.ServiceCategoryRequest);
                model.ServiceRequestCollection.Where(x => x.TimesOfService > 0).ToList().ForEach(c =>
                {
                    _ServiceRequest.Add(new ServiceRequest()
                    {
                        ServiceCategoryRequestId = model.ServiceCategoryRequest.Id,
                        Status = (int)Status.Pending,
                        SubCategoryId = c.SubCategoryId,
                        TimesOfService = c.TimesOfService,
                        DeliveryPeriodInDays = c.DeliveryPeriodInDays,
                        PaperNum = c.PaperNum,
                        HasIntroAndEnd = c.HasIntroAndEnd,
                        HasMargins = c.HasMargins,
                        HasReference = c.HasReference,
                        HasSpelling = c.HasSpelling
                    });

                });

                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Create);
            model = FillDropdownLists(model);
            return View("EditCreate", model);
        }
        #endregion

        #region Edit ServiceCategoryRequest
        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = nameof(Edit);
            var model = GetSharedDetails(_ServiceCategoryRequest.GetElement(id));
            model = FillDropdownLists(model);
            return View("EditCreate", model);
        }

        [HttpPost]
        public IActionResult Edit(RequestVM model)
        {
            if (ModelState.IsValid)
            {
                _ServiceCategoryRequest.Update(model.ServiceCategoryRequest);
                model.ServiceRequestCollection.ForEach(c =>
                {
                    var sr = _ServiceRequest.GetElement(c.Id);
                    sr.SubCategoryId = (int)c.SubCategoryId;
                    sr.TimesOfService = (int)c.TimesOfService;
                    sr.DeliveryPeriodInDays = (int)c.DeliveryPeriodInDays;
                    sr.PaperNum = c.PaperNum;
                    sr.HasIntroAndEnd = c.HasIntroAndEnd;
                    sr.HasMargins = c.HasMargins;
                    sr.HasReference = c.HasReference;
                    sr.HasSpelling = c.HasSpelling;
                    _ServiceRequest.Update(sr);
                });
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Edit);
            model = FillDropdownLists(model);
            return View("EditCreate", model);
        }
        #endregion

        #region Delete ServiceCategoryRequest
        public IActionResult Delete(int id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "Request",
                ActionName = nameof(Delete),
                Title = "حذف من شاشة الطلبات",
                PkFieldStrVal = null,
                PkFieldIntVal = id
            };
            return View("_DeleteView", model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(ConfirmDeleteVM model)
        {
            try
            {
                _ServiceRequest.DeleteRange(_ServiceRequest.GetAll(c => c.ServiceCategoryRequestId == model.PkFieldIntVal));
                _ServiceCategoryRequest.Delete((int)model.PkFieldIntVal);
            }
            catch
            {
                ModelState.AddModelError("", "لا يمكن حذف هذا الطلب");
                return View("_DeleteView", model);
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Details of ServiceCategoryRequest
        public IActionResult Details(int id)
        {
            ViewBag.IsStudent = _Student.GetFirstOrDefault(c => c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.IsProvider = _Provider.GetFirstOrDefault(c => c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));

            var ele = _ServiceCategoryRequest.GetFirstOrDefault(c => c.Id == id,
                "University,University.Country,College,AcademinYear,Department,Subject,Term,Category,Student");
            ViewBag.StudentName = _identitySetupContext.Users.Find(ele.Student.UserId).ArName;
            var model = GetSharedDetails(ele);
            ViewBag.TotalCostInvoice = "";
            var invoice = _Invoice.GetFirstOrDefault(c => c.ServiceCategoryRequestId == id);
            if (invoice != null)
                ViewBag.TotalCostInvoice = "اجمالي سعر الخدمات : " + invoice.TotalCost + " /// الرسوم : " + invoice.TotalFees
                    +" /// الخصم " + invoice.Discount + " === " + (invoice.TotalCost + invoice.TotalFees - invoice.Discount);
            return View(model);
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public PagedList<RequestIndexVM> GetPagedListItems(string searchStr, int pageNumber, int pageSize)
        {
            var srInscr = _ServiceRequest.GetAll();
            if (searchStr == null)
                searchStr = "";
            searchStr = searchStr.ToLower();
            IQueryable<ServiceCategoryRequest> requests = _ServiceCategoryRequest.GetAllAsIQueryable(null, o => o.OrderByDescending(c => c.RequestCode), "");
            var stu = _Student.GetFirstOrDefault(f => f.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            var prov = _Provider.GetFirstOrDefault(f => f.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier), "Services,Services.Category");
            List<ServiceCategoryRequest> filteredRequests = new List<ServiceCategoryRequest>();
            filteredRequests = requests.ToList();

            if (stu != null)
            {
                filteredRequests = requests.Where(c => c.StudentId == stu.Id).ToList();
            }
            else if (prov != null)
            {
                filteredRequests = requests.Where(c => c.ProviderId != null && c.ProviderId == prov.Id).ToList();
                if (prov.Service != null)
                {

                    foreach (var req in requests)
                    {
                        if (req.ProviderId == null)
                        {
                            //service request in service category request
                            var srInscr1 = srInscr.Where(c => c.ServiceCategoryRequestId == req.Id);
                            var suitable = 0;
                            var provServices = prov.Service.Where(c => c.UniversityId == req.UniversityId
                            && c.CollegeId == req.CollegeId && c.AcademinYearId == req.AcademinYearId
                            && c.DepartmentId == req.DepartmentId
                            && c.TermId == req.TermId && c.SubjectId == req.SubjectId).ToList();
                            if (provServices != null && provServices.Count > 0)
                            {
                                foreach (var c in provServices)
                                {
                                    if (srInscr1.Where(x => x.SubCategoryId == c.CategoryId).Count() > 0
                                    && (srInscr1.Where(x => x.HasMargins == c.HasMargins).Count() > 0)
                                    && (srInscr1.Where(x => x.HasReference == c.HasReference).Count() > 0)
                                    && (srInscr1.Where(x => x.HasSpelling == c.HasSpelling).Count() > 0)
                                    && (srInscr1.Where(x => x.HasIntroAndEnd == c.HasIntroAndEnd).Count() > 0))
                                    {
                                        suitable++;
                                    }
                                }
                            }
                            //if (prov.Services.Where(c => c.UniversityId == req.UniversityId
                            //&& c.CollegeId == req.CollegeId && c.AcademinYearId == req.AcademinYearId
                            //&& c.DepartmentId == req.DepartmentId
                            //&& c.TermId == req.TermId && c.SubjectId == req.SubjectId
                            //&& (srInscr1.Where(x => x.SubCategoryId == c.CategoryId).Count() > 0)
                            //&& (srInscr1.Where(x => x.HasMargins == c.HasMargins).Count() > 0)
                            //&& (srInscr1.Where(x => x.HasReference == c.HasReference).Count() > 0)
                            //&& (srInscr1.Where(x => x.HasSpelling == c.HasSpelling).Count() > 0)
                            //&& (srInscr1.Where(x => x.HasIntroAndEnd == c.HasIntroAndEnd).Count() > 0)).Count() > 0)
                            //{
                            //    suitable = true;
                            //}

                            if (suitable != 0 && suitable == srInscr1.Count())
                            {
                                filteredRequests.Add(req);
                            }
                        }
                    }
                }
            }
            var sentItems = new List<RequestIndexVM>();
            foreach (var item in filteredRequests)
            {
                sentItems.Add(new RequestIndexVM()
                {
                    Id = item.Id,
                    Code = item.RequestCode,
                    RequestDateTime = item.RequestDateTime.ToString(),
                    StudentId = (int)item.StudentId,
                    StudentName = _identitySetupContext.Users.Find(_Student.GetElement((int)item.StudentId).UserId).ArName,
                    Status = (int)item.Status,
                    Total = CalculateRequestTotal(item.Id),
                    ProvidersAccepted = item.ProvidersAccepted
                });
            }
            sentItems = sentItems.Where(c => c.Code.ToLower().Contains(searchStr)).ToList();
            ViewBag.PageStartRowNum = ((pageNumber - 1) * pageSize) + 1;
            return PagedList<RequestIndexVM>.Create(sentItems,
                pageNumber, pageSize);
        }

        private decimal CalculateRequestTotal(int id)
        {
            var invoice = _Invoice.GetFirstOrDefault(c => c.ServiceCategoryRequestId == id);
            var subReqs = _ServiceRequest.GetAll(c => c.ServiceCategoryRequestId == id);
            decimal total = 0;
            if(invoice != null)
            {
                total = invoice.TotalCost + invoice.TotalFees - invoice.Discount;
            }
            else
            {
                foreach (var item in subReqs)
                {
                    var subCategory = _Category.GetElement((int)item.SubCategoryId);
                    if (subCategory.PricingMethod == (int)PricingMethod.Gabry)
                    {
                        total += (subCategory.ServicePrice * (decimal)item.TimesOfService);
                    }
                    else
                    {

                    }
                }
            }
            return total;
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber,pageSize).ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1, int pageSize = 5)
        {
            var model = PagedList<RequestIndexVM>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber,pageSize));
            model.GetItemsUrl = "/Request/GetItems";
            model.GetPaginationUrl = "/Request/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion

        #region Fill Dropdown Lists

        private RequestVM FillDropdownLists(RequestVM model)
        {
            model.CountryList = new SelectList(_Country.GetAll(), "Id", "ArName");
            model.UniversityList = new SelectList(_University.GetAll(), "Id", "ArName");
            model.CollegeList = new SelectList(_College.GetAll(), "Id", "ArName");
            model.AcademicYearList = new SelectList(_AcademicYear.GetAll(), "Id", "ArName");
            model.DepartmentList = new SelectList(_Department.GetAll(), "Id", "ArName");
            model.TermList = new SelectList(_Term.GetAll(), "Id", "ArName");
            model.SubjectList = new SelectList(_Subject.GetAll(), "Id", "ArName");
            model.MainCategoryList = new SelectList(GeneralHelper.GetParentNodesInAllCategories(_Category), "Id", "ArName");
            model.SubCategoryList = new SelectList(GeneralHelper.GetLastNodesInAllCategories(_Category), "Id", "ArName");
            if (model.ServiceCategoryRequest.ProvidersAccepted != null)
            {
                model.ProviderList = new List<SelectListItem>();
                var provIds = model.ServiceCategoryRequest.ProvidersAccepted.Split("_");
                var provider = new ServiceProvider();
                foreach (var item in provIds)
                {
                    provider = _Provider.GetElement(Int32.Parse(item));
                    model.ProviderList.Add(new SelectListItem()
                    {
                        Value = provider.Id.ToString(),
                        Text = _identitySetupContext.Users.Find(provider.UserId).ArName
                    });
                }
            }
            return model;
        }

        #endregion

        #region Ajax Call

        public IActionResult GetSubCategoriesForParentCategory(int MainCategoryId)
        {
            RequestVM req = new RequestVM()
            {
                ServiceCategoryRequest = new ServiceCategoryRequest(),
                ServiceRequestCollection = new List<SubCategoryServiceRequest>()
            };
            req.FormType = (int)_Category.GetElement(MainCategoryId).FormType;
            var lastnodes = new List<ServiceCategory>();
            GetLastNodesForCategory(MainCategoryId, in lastnodes);
            foreach (var item in lastnodes)
            {
                req.ServiceRequestCollection.Add(new SubCategoryServiceRequest()
                {
                    SubCategoryId = item.Id,
                    SubCategoryName = item.ArName,
                    Price = item.ServicePrice,
                    PricingMethod = (int)item.PricingMethod
                });
            }
            return PartialView("_ServiceRequestCollection", req);
        }

        private void GetLastNodesForCategory(int parentid, in List<ServiceCategory> lastnodes)
        {
            var parent = _Category.GetFirstOrDefault(c => c.Id == parentid, "InverseParentCategory");
            if (parent.InverseParentCategory != null && parent.InverseParentCategory.Count() > 0)
            {
                foreach (var item in parent.InverseParentCategory)
                {
                    var child = _Category.GetFirstOrDefault(c => c.Id == item.Id, "InverseParentCategory");
                    if (child.InverseParentCategory != null && child.InverseParentCategory.Count() > 0)
                    {
                        GetLastNodesForCategory(child.Id, lastnodes);
                    }
                    else
                    {
                        lastnodes.Add(child);
                    }
                }
            }
            else
            {
                lastnodes.Add(parent);
            }
        }

        #endregion

        #region Request Shared Details
        private RequestVM GetSharedDetails(ServiceCategoryRequest element)
        {

            var model = new RequestVM()
            {
                ServiceCategoryRequest = element,
                ServiceRequestCollection = new List<SubCategoryServiceRequest>(),
                CanEdited = true,
                FormType = (int)_Category.GetElement((int)element.CategoryId).FormType
            };
            _ServiceRequest.GetAll(f => f.ServiceCategoryRequestId == element.Id).ToList().ForEach(c =>
            {
                model.ServiceRequestCollection.Add(new SubCategoryServiceRequest()
                {
                    Id = c.Id,
                    SubCategoryId = (int)c.SubCategoryId,
                    SubCategoryName = _Category.GetElement((int)c.SubCategoryId).ArName,
                    TimesOfService = (int)c.TimesOfService,
                    DeliveryPeriodInDays = (int)c.DeliveryPeriodInDays,
                    PaperNum = c.PaperNum,
                    HasIntroAndEnd = c.HasIntroAndEnd,
                    HasMargins = c.HasMargins,
                    HasReference = c.HasReference,
                    HasSpelling = c.HasSpelling,
                    PricingMethod = (int)_Category.GetElement((int)c.SubCategoryId).PricingMethod,
                    Price = _Category.GetElement((int)c.SubCategoryId).ServicePrice
                });
            });
            //مش هتقدر تعدل او تمسح الطلب لو في مقدمي خدمة شافوه وقبلوه او ان الطلب ده مبقاش ف قايمة الانتظار
            if (element.ProvidersAccepted != null || element.Status != (int)Status.Pending)
            {
                model.CanEdited = false;
            }
            //في حالة ان في مقدمي خدمة شافوه وقبلوه بس الطلب لسه ف قايمة الانتظار هتقدر تحذف بس متعدلش
            else if (element.ProvidersAccepted != null && element.Status == (int)Status.Pending)
            {
                model.CanEdited = false;
            }
            return model;
        }
        #endregion

        #region Request Actions

        public IActionResult ChangeStatus(int requestId, int status)
        {
            var req = _ServiceCategoryRequest.GetElement(requestId);
            req.Status = status;
            if (status == (int)Status.Accepted)
            {
                var prov = _Provider.GetFirstOrDefault(c => c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (prov != null)
                {
                    if (req.ProvidersAccepted == null)
                        req.ProvidersAccepted = "";
                    req.ProvidersAccepted += "_" + prov.Id;
                }
                req.Status = (int)Status.Pending;
            }
            _ServiceCategoryRequest.Update(req);
            return RedirectToAction(nameof(Details), nameof(Request), new { id = requestId });
        }

        #endregion
    }

}
