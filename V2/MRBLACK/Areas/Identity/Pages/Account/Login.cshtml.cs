using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MRBLACK.Areas.Identity.Data;
using MRBLACK.Models.Database;

namespace MRBLACK.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<IdentitySetupUser> _userManager;
        private readonly SignInManager<IdentitySetupUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private ApplicationDbContext db;
        public LoginModel(SignInManager<IdentitySetupUser> signInManager, 
            ILogger<LoginModel> logger,
            UserManager<IdentitySetupUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            db = new ApplicationDbContext();
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage ="يجب ادخال البريد الالكتروني")]
            [EmailAddress (ErrorMessage ="البريد يجب ان يحتوي على @")]
            public string Email { get; set; }

            [Required(ErrorMessage = "يجب ادخال كلمة المرور")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if(user != null)
                {
                    var chkPass = await _userManager.CheckPasswordAsync(user, Input.Password);
                    if (chkPass)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                        if (result.Succeeded)
                        {
                            if (returnUrl != "" && returnUrl != null && returnUrl != "/")
                            {
                                return LocalRedirect(returnUrl);
                            }
                            else
                            {
                                return Redirect("/DefaultHome/Index");
                            }

                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Password wrong.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "This email is not exists");
                }
            }
                

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
