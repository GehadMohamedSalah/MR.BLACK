using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MRBLACK.Areas.Identity.Data;

namespace MRBLACK.Data
{
    public class IdentitySetupContext : IdentityDbContext<IdentitySetupUser,IdentitySetupRole,string>
    {
        public IdentitySetupContext(DbContextOptions<IdentitySetupContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentitySetupUser>(entity =>
            {
                entity.Property(c => c.Code).ValueGeneratedOnAdd();
                entity.Property(c => c.Code).ValueGeneratedOnAddOrUpdate();
            });

            builder.Entity<IdentitySetupRole>(entity =>
            {
                entity.Property(c => c.Code).ValueGeneratedOnAdd();
                entity.Property(c => c.Code).ValueGeneratedOnAddOrUpdate();
            });

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }
        DbSet<IdentitySetupRole> IdentitySetupRole { get; set; }
    }
}
