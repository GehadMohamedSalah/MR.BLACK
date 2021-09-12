using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using Mr_Black.Database;
using Mr_Black.Repository;
using Mr_Black.Models.ViewModels;
//using Microsoft.AspNetCore.Identity.IdentityBuilder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Mr_Black
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //database
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer("Server=DESKTOP-8K7QL6F;Database=MRBLACK;Trusted_Connection=True;"));

            //identity
            services.AddIdentity<AspNetUsers, AspNetRoles>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.Configure<PasswordHasherOptions>(options =>
                options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2
            );

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddControllers();
            //scope repository
            services.AddScoped<IRepository<AspNetUsers>, Repository<AspNetUsers>>();
            //services.AddScoped<IRepository<AspNetRole>, Repository<AspNetRole>>();
            //session
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(15);
                options.Cookie.IsEssential = true;
            });

            //cookies
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(1000);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Home/Error";
                options.SlidingExpiration = true;
            });

            //localiztion
            services.AddLocalization(opts =>
            {
                opts.ResourcesPath = "Resources";
            });
            //services.AddRazorPages();
            //    .AddRazorPagesOptions(options => {
            //        options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "/Account/Login");
            //    })
            //    .AddControllersAsServices()
            //        .AddViewLocalization(opts => { opts.ResourcesPath = "Resources"; })
            //        .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            //        .AddDataAnnotationsLocalization()
            //    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

           

            services.Configure<RequestLocalizationOptions>(opts =>
            {
                var supportedCultures = new List<CultureInfo> {
                    new CultureInfo("en"),

                    new CultureInfo("ar")
                  };

                opts.DefaultRequestCulture = new RequestCulture("ar");
                // Formatting numbers, dates, etc.
                opts.SupportedCultures = supportedCultures;
                // UI strings that we have localized.
                opts.SupportedUICultures = supportedCultures;
            });

            services.Configure<SecurityStampValidatorOptions>(options => options.ValidationInterval = TimeSpan.FromSeconds(10));
            services.AddAuthentication()
                .Services.ConfigureApplicationCookie(options =>
                {
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromDays(10);
                });
            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
               // endpoints.MapRazorPages();
            });


            //intialize some actions when app start
            Identity_SampleData.Initialize(app.ApplicationServices, app);
            // enable local 'App_Data' folder to access local documents
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(env.ContentRootPath, "App_Data"));
            // enable Web Sockets
            app.UseWebSockets();

        }
    }
}
