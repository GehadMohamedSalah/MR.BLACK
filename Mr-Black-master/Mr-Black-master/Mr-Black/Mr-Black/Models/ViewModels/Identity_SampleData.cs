using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mr_Black.Database;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Mr_Black.Models.ViewModels
{
    public class Identity_SampleData
    {
        public static async void Initialize(IServiceProvider serviceProvider, IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();

            ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await context.SaveChangesAsync();
        }
    }
}
