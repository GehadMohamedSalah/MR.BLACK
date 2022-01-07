using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MRBLACK.Areas.Identity.Data;
using MRBLACK.Data;
using MRBLACK.Helper;
using MRBLACK.Models.Database;
using MRBLACK.Models.ViewModels;
using MRBLACK.Repository;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using MRBLACK.Models.Enums;
using System.Security.Claims;

namespace MRBLACK.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class SupervisorController : BaseController
    {
        private readonly IdentitySetupContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly Repository<Country> _country;
        private readonly UserManager<IdentitySetupUser> _userManager;
        private readonly SignInManager<IdentitySetupUser> _signInManager;
        public SupervisorController(
            IdentitySetupContext context,
            IWebHostEnvironment webHostEnvironment
            , IRepository<Country> country
            ,UserManager<IdentitySetupUser> userManager
            , SignInManager<IdentitySetupUser> signInManager)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _country = (Repository<Country>)country;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region CRUD OPERTIONS

        #region Get Supervisors
        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            var model = GetIndexPageDetails("Supervisor");
            return View(GetPagedListItems(model.SearchStr, model.PageNumber, model.PageSize).Result);
        }
        #endregion

        #region Create Supervisor
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            var model = new SupervisorVM()
            {
                CountryList = new SelectList(_country.GetAll(), "Id", "ArName"),
                RoleList = _context.Roles.Where(c => c.MembershipId == null && c.IsDeleted == false).Select(c => new SelectListItem()
                {
                    Value = c.Id,
                    Text = c.ArName
                }).ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupervisorVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentitySetupUser
                {
                    ArName = model.Name,
                    EnName = model.Name,
                    Gender = model.Gender,
                    CountryId = model.CountryId,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.Phone,
                    UserType = (int)UserType.Supervisor,
                    RedirectUrl = "/Home/Index",
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                var role = _context.Roles.FirstOrDefault(c => c.Id == model.RoleId);
                
                if (result.Succeeded)
                {
                    await _context.UserRoles.AddAsync(new IdentityUserRole<string>()
                    {
                        UserId = user.Id,
                        RoleId = role.Id
                    });
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                List<string> errorlist = new List<string>();
                foreach (var error in result.Errors)
                {
                    var x = error.Code;
                    var errorMsg = "";
                    if(error.Code == "DuplicateUserName" || error.Code == "DuplicateEmail")
                    {
                        errorMsg = "هذ البريد مضاف مسبقا";
                    }
                    else
                    {
                        errorMsg = error.Description;
                    }
                    if (!errorlist.Contains(errorMsg))
                    {
                        errorlist.Add(errorMsg);
                        ModelState.AddModelError(string.Empty, errorMsg);
                    }
                }
            }

            ViewBag.ActionName = nameof(Create);
            model.CountryList = new SelectList(_country.GetAll(), "Id", "ArName");
            model.RoleList = _context.Roles.Where(c => c.MembershipId == null && c.IsDeleted == false).Select(c => new SelectListItem()
            {
                Value = c.Id,
                Text = c.ArName
            }).ToList();
            return View(model);
        }

        #endregion

        #region Edit Supervisor
        public IActionResult Edit(string id)
        {
            ViewBag.ActionName = nameof(Edit);
            var user = _userManager.Users.FirstOrDefault(c => c.Id == id);
            var model = new SupervisorEditVM()
            {
                Id=user.Id,
                Name = user.ArName,
                Gender = (int)user.Gender,
                CountryId = (int)user.CountryId,
                Email = user.Email,
                Phone = user.PhoneNumber,
                CountryList = new SelectList(_country.GetAll(), "Id", "ArName"),
                RoleList = _context.Roles.Where(c => c.MembershipId == null && c.IsDeleted == false).Select(c => new SelectListItem()
                {
                    Value = c.Id,
                    Text = c.ArName
                }).ToList(),
                RoleId = _context.UserRoles.FirstOrDefault(c => c.UserId == id).RoleId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SupervisorEditVM model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.FirstOrDefault(c => c.Id == model.Id);
                user.ArName = model.Name;
                user.EnName = model.Name;
                user.Email = model.Email;
                user.PhoneNumber = model.Phone;
                user.UserName = model.Email;
                user.Gender = model.Gender;
                user.CountryId = model.CountryId;
                user.UserType = (int)UserType.Supervisor;
                user.RedirectUrl = "/Home/Index";

                var result = await _userManager.UpdateAsync(user);
                var passRemoved = true;
                var passAdded = true;
                if(model.Password != null) 
                {
                    passRemoved = (await _userManager.RemovePasswordAsync(user)).Succeeded;
                    passAdded = (await _userManager.AddPasswordAsync(user, model.Password)).Succeeded;
                }
               
                if (result.Succeeded && passRemoved && passAdded)
                {
                    var roles = _userManager.GetRolesAsync(user).Result;
                    var x = await _userManager.RemoveFromRolesAsync(user, roles);
                    if (x.Succeeded)
                    {
                        await _context.UserRoles.AddAsync(new IdentityUserRole<string>()
                        {
                            UserId = user.Id,
                            RoleId = model.RoleId
                        });
                        await _context.SaveChangesAsync();
                    }
                    
                    return RedirectToAction(nameof(Index));
                }
                List<string> errorlist = new List<string>();
                foreach (var error in result.Errors)
                {
                    var x = error.Code;
                    var errorMsg = "";
                    if (error.Code == "DuplicateUserName" || error.Code == "DuplicateEmail")
                    {
                        errorMsg = "هذ البريد مضاف مسبقا";
                    }
                    else
                    {
                        errorMsg = error.Description;
                    }
                    if (!errorlist.Contains(errorMsg))
                    {
                        errorlist.Add(errorMsg);
                        ModelState.AddModelError(string.Empty, errorMsg);
                    }
                }
                //foreach (var error in result1.Errors)
                //{
                //    ModelState.AddModelError(string.Empty, error.Description);
                //}
                //foreach (var error in result2.Errors)
                //{
                //    ModelState.AddModelError(string.Empty, error.Description);
                //}
            }
            ViewBag.ActionName = nameof(Edit);
            model.CountryList = new SelectList(_country.GetAll(), "Id", "ArName");
            model.RoleList = _context.Roles.Where(c => c.MembershipId == null && c.IsDeleted == false).Select(c => new SelectListItem()
            {
                Value = c.Id,
                Text = c.ArName
            }).ToList();
            return View(model);
        }
        #endregion

        #region Delete Supervisor
        public IActionResult Delete(string id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "Supervisor",
                ActionName = nameof(Delete),
                Title = "حذف من شاشة المشرفين",
                PkFieldStrVal = id,
                PkFieldIntVal = null
            };
            return View("_DeleteView", model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(ConfirmDeleteVM model)
        {
            try
            {
               var user =  _userManager.Users.FirstOrDefault(c => c.Id == model.PkFieldStrVal);
                user.IsDeleted = true;
                await _userManager.UpdateAsync(user);
                if(user.Id == User.FindFirstValue(ClaimTypes.NameIdentifier))
                {
                    await _signInManager.SignOutAsync();
                }
            }
            catch
            {
                return Json(new { IsSuccess = false, Msg = "لا يمكن حذف هذا المشرف" });
            }

            return Json(new { IsSuccess = true, Msg = "تم الحذف بنجاح" });
        }
        #endregion

        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<IdentitySetupUser>> GetPagedListItems(string searchStr, int pageNumber, int pageSize = 5)
        {
            var users = _userManager.Users.Where(c => c.IsDeleted == false && (c.UserType == (int)UserType.Supervisor || c.UserType == (int)UserType.Admin));
            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                users = users.Where(c => c.ArName.ToLower().Contains(searchStr)
                 || c.Email.ToLower().Contains(searchStr)
                || c.PhoneNumber.Contains(searchStr));
            }
            ViewBag.CountryList = new SelectList(_country.GetAll(), "Id", "ArName");

            CreateIndexPageDetailsCookie(new IndexPageDetailsVM()
            {
                ControllerName = "Supervisor",
                SearchStr = searchStr,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return await PagedList<IdentitySetupUser>.CreateAsync(users,
                pageNumber, pageSize);

        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1)
        {
            var model = PagedList<IdentitySetupUser>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber).Result);
            model.GetItemsUrl = "/Supervisor/GetItems";
            model.GetPaginationUrl = "/Supervisor/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion
    }
}
