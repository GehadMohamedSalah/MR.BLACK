using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MRBLACK.Areas.Identity.Data;
using MRBLACK.Data;

[assembly: HostingStartup(typeof(MRBLACK.Areas.Identity.IdentityHostingStartup))]
namespace MRBLACK.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //services.AddDbContext<IdentitySetupContext>(options =>
                //    options.UseSqlServer(
                //        context.Configuration.GetConnectionString("IdentitySetupContextConnection")));

                //services.AddDefaultIdentity<IdentitySetupUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<IdentitySetupContext>();
            });
        }
    }
}