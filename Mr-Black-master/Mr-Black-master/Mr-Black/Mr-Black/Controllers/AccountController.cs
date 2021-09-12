using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mr_Black.Database;
using Mr_Black.Models.ViewModels;
using Mr_Black.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mr_Black.Controllers
{
    public class AccountController : Controller
    {
        private readonly Repository<AspNetUsers> _user;
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly SignInManager<AspNetUsers> _signInManager;
        public AccountController(IRepository<AspNetUsers> user, UserManager<AspNetUsers> userManager, SignInManager<AspNetUsers> signInManager)
        {
            _user = (Repository<AspNetUsers>)user;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AspNetUsers()
                {
                    UserName = model.Username,
                    Email = model.Email,
                    PhoneNumber = model.Phone
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //var x = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: true); ;
                    HttpContext.Session.SetString("LoggedUserID", user.Id);
                    HttpContext.Session.SetString("LoggedUserEmail", user.Email);
                    HttpContext.Session.SetString("LoggedUserName", user.UserName);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not created.");
                }
            }
            
            return View(model);
        }

        public ActionResult Login(string returnUrl = "")
        {
            // Clear the existing external cookie to ensure a clean login process
            _signInManager.SignOutAsync();
            return View(new LoginViewModel() { returnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var chkPass = await _signInManager.UserManager.CheckPasswordAsync(user, model.Password);
                if (chkPass)
                {
                    HttpContext.Session.SetString("LoggedUserID",user.Id);
                    HttpContext.Session.SetString("LoggedUserEmail", user.Email);
                    HttpContext.Session.SetString("LoggedUserName", user.UserName);
                    //var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, isPersistent: true, lockoutOnFailure: true);
                    //if(result.Succeeded)
                    //{
                    //    if (model.returnUrl != "")
                    //        return Redirect(model.returnUrl);
                    //    else
                           return RedirectToAction("Index", "Home");
                    //}
                    //else
                    //{
                    //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    //}
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid password.");
                }
                
                
            }
            return View(model);
        }

    }
}
