using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MRBLACK.Models.Database;
using Microsoft.EntityFrameworkCore;
using MRBLACK.Data;
using MRBLACK.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using MRBLACK.Repository;
using MRBLACK.Models;

namespace MRBLACK
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
            services.AddDbContext<ApplicationDbContext>(options =>
                //options.UseSqlServer("Server=DESKTOP-8K7QL6F;Database=MRBLACKDB_Live;Trusted_Connection=True;")
            options.UseSqlServer("Data Source=SQL5108.site4now.net;Initial Catalog=db_a6e36f_mrblack;User Id=db_a6e36f_mrblack_admin;Password=MRBLACK_123456")
            );
            services.AddDbContext<IdentitySetupContext>(options =>
            //    options.UseSqlServer("Server=DESKTOP-8K7QL6F;Database=MRBLACKDB_Live;Trusted_Connection=True;")
            options.UseSqlServer("Data Source=SQL5108.site4now.net;Initial Catalog=db_a6e36f_mrblack;User Id=db_a6e36f_mrblack_admin;Password=MRBLACK_123456")
            );

            services.AddIdentity<IdentitySetupUser, IdentitySetupRole>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<IdentitySetupContext>().AddDefaultTokenProviders();

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
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddControllers();

            //session
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.IsEssential = true;
            });


            //cookies
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Home/Error";
                options.SlidingExpiration = true;
            });

            //localiztion
            services.AddLocalization(opts =>
            {
                opts.ResourcesPath = "Resources";
            });

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
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                });
            services.AddCors();

            services.AddScoped<IRepository<CurrencyType>, Repository<CurrencyType>>();
            services.AddScoped<IRepository<Membership>, Repository<Membership>>();
            services.AddScoped<IRepository<MembershipLink>, Repository<MembershipLink>>();
            services.AddScoped<IRepository<Country>, Repository<Country>>();
            services.AddScoped<IRepository<University>, Repository<University>>();
            services.AddScoped<IRepository<College>, Repository<College>>();
            services.AddScoped<IRepository<AcademicYear>, Repository<AcademicYear>>();
            services.AddScoped<IRepository<Term>, Repository<Term>>();
            services.AddScoped<IRepository<Subject>, Repository<Subject>>();
            services.AddScoped<IRepository<Department>, Repository<Department>>();
            services.AddScoped<IRepository<ServiceCategory>, Repository<ServiceCategory>>();
            services.AddScoped<IRepository<Service>, Repository<Service>>();
            services.AddScoped<IRepository<Models.Database.ServiceProvider>, Repository<Models.Database.ServiceProvider>>();
            services.AddScoped<IRepository<ServiceCategoryRequest>, Repository<ServiceCategoryRequest>>();
            services.AddScoped<IRepository<ServiceRequest>, Repository<ServiceRequest>>();
            services.AddScoped<IRepository<Student>, Repository<Student>>();
            services.AddScoped<IRepository<ServicesPurchaseInvoice>, Repository<ServicesPurchaseInvoice>>();
            services.AddScoped<IRepository<ServicesInServicesPurchaseInvoice>, Repository<ServicesInServicesPurchaseInvoice>>();
            services.AddScoped<IRepository<PaymentWay>, Repository<PaymentWay>>();
            services.AddScoped<IRepository<SystemSetting>, Repository<SystemSetting>>();
            services.AddScoped<IRepository<Copun>, Repository<Copun>>();
            services.AddScoped<IRepository<Article>, Repository<Article>>();
            services.AddScoped<IRepository<ArticleCategory>, Repository<ArticleCategory>>();
            services.AddScoped<IRepository<ArticleResource>, Repository<ArticleResource>>();
            services.AddScoped<IRepository<UcdsEductionManagement>, Repository<UcdsEductionManagement>>();
            services.AddScoped<IRepository<SlideShow>, Repository<SlideShow>>();
            services.AddScoped<IRepository<Gallery>, Repository<Gallery>>();
            services.AddScoped<IRepository<BookStore>, Repository<BookStore>>();
            services.AddScoped<IRepository<BookCategory>, Repository<BookCategory>>();
            services.AddScoped<IRepository<Group>, Repository<Group>>();



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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            IntializeOnProjStart.Initialize(app.ApplicationServices, app);
        }
    }
}
