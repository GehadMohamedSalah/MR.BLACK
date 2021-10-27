using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MRBLACK.Areas.Identity.Data;
using MRBLACK.Data;
using MRBLACK.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Models
{
    public class IntializeOnProjStart
    {
        public static async void Initialize(IServiceProvider serviceProvider, IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();

            IdentitySetupContext context = scope.ServiceProvider.GetRequiredService<IdentitySetupContext>();
            UserManager<IdentitySetupUser> _userManager = scope.ServiceProvider.GetService<UserManager<IdentitySetupUser>>();

            ApplicationDbContext appContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
            if (appContext.CurrencyType.Where(c => c.IsMainCurrency == true).Count() == 0)
            {
                appContext.CurrencyType.Add(new CurrencyType()
                {
                    ArName = "الجنيه",
                    EnName = "Pound",
                    ValueInPound = 1,
                    IsMainCurrency = true
                });
                await appContext.SaveChangesAsync();
            }

            // var context = serviceProvider.GetService<ApplicationDbContext>();
            var adminRole = new IdentitySetupRole();
            if (context.Roles.Where(c => c.Name.ToLower() == "admin").Count() == 0)
            {
                adminRole = new IdentitySetupRole()
                {
                    Name = "ADMIN",
                    ArName = "ادمن",
                    NormalizedName = "ADMIN",
                    CanBeEditedOrDeleted = false,
                    IsDeleted = false
                };
                context.Roles.Add(adminRole);
            }
            else
            {
                adminRole = context.Roles.Where(c => c.Name.ToLower() == "admin").FirstOrDefault();
            }
            var admin = new IdentitySetupUser();
            if (context.Users.Where(c => c.UserName == "Sameh").Count() == 0)
            {
                admin = new IdentitySetupUser()
                {
                    ArName = "سامح",
                    EnName = "Sameh",
                    UserName = "Sameh",
                    Email = "sameh@gmail.com",
                    PhoneNumber = "01111111111",
                    RedirectUrl = "/Home/Index"
                };
                await _userManager.CreateAsync(admin, "123456");
            }
            else
            {
                admin = context.Users.Where(c => c.UserName == "Sameh").FirstOrDefault();
            }

            await context.SaveChangesAsync();

            if (context.UserRoles.Where(c => c.RoleId == adminRole.Id && c.UserId == admin.Id).Count() == 0)
            {
                context.UserRoles.Add(new IdentityUserRole<string>()
                {
                    UserId = admin.Id,
                    RoleId = adminRole.Id
                });
                await context.SaveChangesAsync();
            }
        }

    }
}
