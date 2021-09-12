using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using MRBLACK.Areas.Identity.Data;
using MRBLACK.Data;
using MRBLACK.Models.Database;

namespace MRBLACK.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentitySetupUser> _signInManager;
        private readonly UserManager<IdentitySetupUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IdentitySetupContext _identityDb;
        private ApplicationDbContext appDb;
        public RegisterModel(
            UserManager<IdentitySetupUser> userManager,
            SignInManager<IdentitySetupUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IdentitySetupContext identityDb)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            appDb = new ApplicationDbContext();
            _identityDb = identityDb;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public SelectList MembershipList { get; set; }
        public SelectList CountryList { get; set; }

        public class InputModel
        {
            public string ID { get; set; }
            [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
            public string ArName { get; set; }
            [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
            public string EnName { get; set; }
            [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
            public string Username { get; set; }
            [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
            [StringLength(11, MinimumLength = 11, ErrorMessage = "رقم الهاتف يتكون من 11 رقم فقط")]
            public string Phone { get; set; }
            [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
            [EmailAddress(ErrorMessage = "البريد يجب ان يحتوي على @ ")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
            [StringLength(100, ErrorMessage = "كلمة المرور لا يجب ان تقل عن 6 احرف", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "كلمتا المرور غير متطابقتان")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
            public int MembershipId { get; set; }
            [Required(ErrorMessage = "هذا الحقل مطلوب ادخاله")]
            public int CountryId { get; set; }

        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            FillLists();
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new IdentitySetupUser
                {
                    UserName = Input.Username,
                    Email = Input.Email,
                    ArName = Input.ArName,
                    EnName = Input.EnName,
                    PhoneNumber = Input.Phone
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    //add user to provider or student according to membership
                    var isproviderMembership = ProviderMembership();
                    if (isproviderMembership)
                    {
                        user.RedirectUrl = "/Home/ProviderHomePage";
                        _identityDb.SaveChanges();
                        CreateProvider(user.Id);
                    }

                    else
                    {
                        user.RedirectUrl = "/Home/StudentHomePage";
                        _identityDb.SaveChanges();
                        CreateStudent(user.Id);
                    }

                    //assign user to role according to selected membership
                    AssignUserToRole(user.Id);
                    return Redirect("/Identity/Account/Login");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            FillLists();
            return Page();
        }

        private bool ProviderMembership()
        {
            var membership = appDb.Memberships.FirstOrDefault(c => c.Id == Input.MembershipId);
            return membership.IsProvider;
        }

        private void CreateProvider(string userId)
        {
            appDb.ServiceProviders.Add(new ServiceProvider()
            {
                UserId = userId,
                CountryId = Input.CountryId,
            });
            appDb.SaveChanges();
        }

        private void CreateStudent(string userId)
        {
            appDb.Students.Add(new Student()
            {
                UserId = userId
            });
            appDb.SaveChanges();
        }

        private void AssignUserToRole(string userId)
        {
            var roles = _identityDb.Roles.Where(c => c.MembershipId == Input.MembershipId);
            if(roles != null)
            {
                _identityDb.UserRoles.Add(new IdentityUserRole<string>()
                {
                    UserId = userId,
                    RoleId = roles.First().Id
                });
                _identityDb.SaveChanges();
            }            
        }

        private void FillLists()
        {
            MembershipList = new SelectList(appDb.Memberships.ToList(), "Id", "ArName");
            CountryList = new SelectList(appDb.Countries.ToList(), "Id", "ArName");
        }
    }
}
