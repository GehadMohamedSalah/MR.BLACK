﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MRBLACK.Areas.Identity.Data;
using MRBLACK.Models;
using MRBLACK.Models.Database;
using MRBLACK.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MRBLACK.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Repository<ServiceProvider> _Provider;
        private readonly Repository<Student> _Student;
        private readonly Repository<ServicesPurchaseInvoice> _Invoice;
        private readonly UserManager<IdentitySetupUser> _userManager;

        public HomeController(ILogger<HomeController> logger,
            IRepository<ServiceProvider> Provider,
            IRepository<Student> Student,
            IRepository<ServicesPurchaseInvoice> Invoice
            ,UserManager<IdentitySetupUser> userManager)
        {
            _logger = logger;
            _Provider = (Repository<ServiceProvider>)Provider;
            _Student = (Repository<Student>)Student;
            _Invoice = (Repository<ServicesPurchaseInvoice>)Invoice;
            _userManager = userManager;
        }
        private ServiceProvider provider;
        private Student student;
        public async Task<IActionResult> Index()
        {
            var appUser = await _userManager.GetUserAsync(User);
            var currentUserId = appUser.Id;
            provider = _Provider.GetFirstOrDefault(c => c.UserId == currentUserId);
            student = _Student.GetFirstOrDefault(c => c.UserId == currentUserId);
            if (provider != null)
                return RedirectToAction(nameof(ProviderHomePage));
            if (student != null)
                return RedirectToAction(nameof(StudentHomePage));
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ProviderHomePage()
        {
            //provider = _Provider.GetFirstOrDefault(c => c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
            //totalRenenue = _Invoice.GetAll(c => c.ProviderId == provider.Id).ToList().Sum(x => x.ProviderRevenue);
            return View();
        }

        public IActionResult StudentHomePage()
        {
            return View();
        }
    }
}
