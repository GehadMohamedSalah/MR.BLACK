using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcademicYear> AcademicYear { get; set; }
        public virtual DbSet<Advertising> Advertising { get; set; }
        public virtual DbSet<AdvertisingAttachment> AdvertisingAttachment { get; set; }
        public virtual DbSet<AdvertisingPackage> AdvertisingPackage { get; set; }
        public virtual DbSet<AdvertisingPackageInvoice> AdvertisingPackageInvoice { get; set; }
        public virtual DbSet<AdvertisingPackageInvoiceView> AdvertisingPackageInvoiceView { get; set; }
        public virtual DbSet<AdvertisingPackagePage> AdvertisingPackagePage { get; set; }
        public virtual DbSet<AdvertisingPackageRequest> AdvertisingPackageRequest { get; set; }
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<ArticleCategory> ArticleCategory { get; set; }
        public virtual DbSet<ArticleResource> ArticleResource { get; set; }
        public virtual DbSet<BalanceTransfer> BalanceTransfer { get; set; }
        public virtual DbSet<BookCategory> BookCategory { get; set; }
        public virtual DbSet<BookInvoice> BookInvoice { get; set; }
        public virtual DbSet<BookStore> BookStore { get; set; }
        public virtual DbSet<College> College { get; set; }
        public virtual DbSet<Copun> Copun { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CurrencyExchange> CurrencyExchange { get; set; }
        public virtual DbSet<CurrencyType> CurrencyType { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Gallery> Gallery { get; set; }
        public virtual DbSet<Membership> Membership { get; set; }
        public virtual DbSet<MembershipLink> MembershipLink { get; set; }
        public virtual DbSet<Messaging> Messaging { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<PaymentWay> PaymentWay { get; set; }
        public virtual DbSet<Privilage> Privilage { get; set; }
        public virtual DbSet<Punishment> Punishment { get; set; }
        public virtual DbSet<RequestServiceStep> RequestServiceStep { get; set; }
        public virtual DbSet<RolePrivilage> RolePrivilage { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceCategory> ServiceCategory { get; set; }
        public virtual DbSet<ServiceCategoryRequest> ServiceCategoryRequest { get; set; }
        public virtual DbSet<ServiceProvider> ServiceProvider { get; set; }
        public virtual DbSet<ServiceRequest> ServiceRequest { get; set; }
        public virtual DbSet<ServicesInServicesPurchaseInvoice> ServicesInServicesPurchaseInvoice { get; set; }
        public virtual DbSet<ServicesPurchaseInvoice> ServicesPurchaseInvoice { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<SystemPage> SystemPage { get; set; }
        public virtual DbSet<SystemSetting> SystemSetting { get; set; }
        public virtual DbSet<TechnicalSupport> TechnicalSupport { get; set; }
        public virtual DbSet<Term> Term { get; set; }
        public virtual DbSet<UcdsEductionManagement> UcdsEductionManagement { get; set; }
        public virtual DbSet<University> University { get; set; }
        public virtual DbSet<UserBookGift> UserBookGift { get; set; }
        public virtual DbSet<UserVisit> UserVisit { get; set; }
        public virtual DbSet<SlideShow> SlideShow { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SQL5108.site4now.net;Initial Catalog=db_a6e36f_mrblack;User Id=db_a6e36f_mrblack_admin;Password=MRBLACK_123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertising>(entity =>
            {
                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Advertising)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK_Advertising_ServiceProvider");
            });

            modelBuilder.Entity<AdvertisingAttachment>(entity =>
            {
                entity.HasOne(d => d.Advertising)
                    .WithMany(p => p.AdvertisingAttachment)
                    .HasForeignKey(d => d.AdvertisingId)
                    .HasConstraintName("FK_AdvertisingAttachment_Advertising");
            });

            modelBuilder.Entity<AdvertisingPackage>(entity =>
            {
                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.AdvertisingPackage)
                    .HasForeignKey(d => d.CurrencyTypeId)
                    .HasConstraintName("FK_AdvertisingPackage_CurrencyType");
            });

            modelBuilder.Entity<AdvertisingPackageInvoice>(entity =>
            {
                entity.HasOne(d => d.AdvertisingPackageRequest)
                    .WithMany(p => p.AdvertisingPackageInvoice)
                    .HasForeignKey(d => d.AdvertisingPackageRequestId)
                    .HasConstraintName("FK_AdvertisingPackageInvoice_AdvertisingPackageRequest");
            });

            modelBuilder.Entity<AdvertisingPackageInvoiceView>(entity =>
            {
                entity.HasOne(d => d.AdvertisingPackageInvoice)
                    .WithMany(p => p.AdvertisingPackageInvoiceView)
                    .HasForeignKey(d => d.AdvertisingPackageInvoiceId)
                    .HasConstraintName("FK_AdvertisingPackageInvoiceView_AdvertisingPackageInvoice");
            });

            modelBuilder.Entity<AdvertisingPackagePage>(entity =>
            {
                entity.HasOne(d => d.AdvertisingPackage)
                    .WithMany(p => p.AdvertisingPackagePage)
                    .HasForeignKey(d => d.AdvertisingPackageId)
                    .HasConstraintName("FK_AdvertisingPackagePage_AdvertisingPackage");

                entity.HasOne(d => d.SystemPage)
                    .WithMany(p => p.AdvertisingPackagePage)
                    .HasForeignKey(d => d.SystemPageId)
                    .HasConstraintName("FK_AdvertisingPackagePage_SystemPage");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasOne(d => d.ArticleCategory)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.ArticleCategoryId)
                    .HasConstraintName("FK_Article_ArticleCategory");
            });

            modelBuilder.Entity<ArticleResource>(entity =>
            {
                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleResource)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("FK_ArticleResource_Article");
            });


            modelBuilder.Entity<BalanceTransfer>(entity =>
            {
                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.BalanceTransfer)
                    .HasForeignKey(d => d.CurrencyTypeId)
                    .HasConstraintName("FK_BalanceTransfer_CurrencyType");
            });

            modelBuilder.Entity<BookInvoice>(entity =>
            {
                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookInvoice)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_BookInvoice_BookStore");

                entity.HasOne(d => d.Copun)
                    .WithMany(p => p.BookInvoice)
                    .HasForeignKey(d => d.CopunId)
                    .HasConstraintName("FK_BookInvoice_Copun");
            });

            modelBuilder.Entity<BookStore>(entity =>
            {
                entity.HasOne(d => d.BookCategory)
                    .WithMany(p => p.BookStore)
                    .HasForeignKey(d => d.BookCategoryId)
                    .HasConstraintName("FK_BookStore_BookCategory");

                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.BookStore)
                    .HasForeignKey(d => d.CurrencyTypeId)
                    .HasConstraintName("FK_BookStore_CurrencyType");
            });

            modelBuilder.Entity<Copun>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Copun)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Copun_ServiceCategory");

                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.Copun)
                    .HasForeignKey(d => d.CurrencyTypeId)
                    .HasConstraintName("FK_Copun_CurrencyType");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.Country)
                    .HasForeignKey(d => d.CurrencyTypeId)
                    .HasConstraintName("FK_Country_CurrencyType");
            });

            modelBuilder.Entity<CurrencyExchange>(entity =>
            {
                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.CurrencyExchange)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("FK_CurrencyExchange_CurrencyType");
            });

            modelBuilder.Entity<CurrencyType>(entity =>
            {
                entity.Property(e => e.ValueInPound).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<MembershipLink>(entity =>
            {
                entity.HasOne(d => d.Membership)
                    .WithMany(p => p.MembershipLink)
                    .HasForeignKey(d => d.MembershipId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MembershipLink_Membership");
            });

            modelBuilder.Entity<RolePrivilage>(entity =>
            {
                entity.HasOne(d => d.Privilage)
                    .WithMany(p => p.RolePrivilage)
                    .HasForeignKey(d => d.PrivilageId)
                    .HasConstraintName("FK_RolePrivilage_Privilage");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasOne(d => d.AcademinYear)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.AcademinYearId)
                    .HasConstraintName("FK_Service_AcademicYear");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Service_ServiceCategory");

                entity.HasOne(d => d.College)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.CollegeId)
                    .HasConstraintName("FK_Service_College");

                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.CurrencyTypeId)
                    .HasConstraintName("FK_Service_CurrencyType");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Service_Department");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK_Service_ServiceProvider");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Service_Subject");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.TermId)
                    .HasConstraintName("FK_Service_Term");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.UniversityId)
                    .HasConstraintName("FK_Service_University");
            });

            modelBuilder.Entity<ServiceCategory>(entity =>
            {
                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.ServiceCategory)
                    .HasForeignKey(d => d.CurrencyTypeId)
                    .HasConstraintName("FK_ServiceCategory_CurrencyType");

                entity.HasOne(d => d.ParentCategory)
                    .WithMany(p => p.InverseParentCategory)
                    .HasForeignKey(d => d.ParentCategoryId)
                    .HasConstraintName("FK_ServiceCategory_ServiceCategory1");
            });

            modelBuilder.Entity<ServiceCategoryRequest>(entity =>
            {
                entity.HasOne(d => d.AcademinYear)
                    .WithMany(p => p.ServiceCategoryRequest)
                    .HasForeignKey(d => d.AcademinYearId)
                    .HasConstraintName("FK_ServiceCategoryRequest_AcademicYear");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ServiceCategoryRequest)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_ServiceCategoryRequest_ServiceCategory");

                entity.HasOne(d => d.College)
                    .WithMany(p => p.ServiceCategoryRequest)
                    .HasForeignKey(d => d.CollegeId)
                    .HasConstraintName("FK_ServiceCategoryRequest_College");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.ServiceCategoryRequest)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_ServiceCategoryRequest_Department");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.ServiceCategoryRequest)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK_ServiceCategoryRequest_ServiceProvider");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ServiceCategoryRequest)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_ServiceCategoryRequest_Student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.ServiceCategoryRequest)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_ServiceCategoryRequest_Subject");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.ServiceCategoryRequest)
                    .HasForeignKey(d => d.TermId)
                    .HasConstraintName("FK_ServiceCategoryRequest_Term");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.ServiceCategoryRequest)
                    .HasForeignKey(d => d.UniversityId)
                    .HasConstraintName("FK_ServiceCategoryRequest_University");
            });

            modelBuilder.Entity<ServiceProvider>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.ServiceProvider)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_ServiceProvider_Country");

                entity.HasOne(d => d.PaymentWay)
                    .WithMany(p => p.ServiceProvider)
                    .HasForeignKey(d => d.PaymentWayId)
                    .HasConstraintName("FK_ServiceProvider_PaymentWay");
            });

            modelBuilder.Entity<ServicesInServicesPurchaseInvoice>(entity =>
            {
                entity.HasOne(d => d.Inv)
                    .WithMany(p => p.ServicesInServicesPurchaseInvoice)
                    .HasForeignKey(d => d.InvId)
                    .HasConstraintName("FK_ServicesInServicesPurchaseInvoice_ServicesPurchaseInvoice");
            });

            modelBuilder.Entity<ServicesPurchaseInvoice>(entity =>
            {
                entity.HasOne(d => d.Copun)
                    .WithMany(p => p.ServicesPurchaseInvoice)
                    .HasForeignKey(d => d.CopunId)
                    .HasConstraintName("FK_ServicesPurchaseInvoice_Copun");

                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.ServicesPurchaseInvoice)
                    .HasForeignKey(d => d.CurrencyTypeId)
                    .HasConstraintName("FK_ServicesPurchaseInvoice_CurrencyType");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasOne(d => d.AcademicYear)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.AcademicYearId)
                    .HasConstraintName("FK_Student_AcademicYear");

                entity.HasOne(d => d.College)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.CollegeId)
                    .HasConstraintName("FK_Student_College");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Student_Department");

                entity.HasOne(d => d.PaymentWay)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.PaymentWayId)
                    .HasConstraintName("FK_Student_PaymentWay");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.TermId)
                    .HasConstraintName("FK_Student_Term");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.UniversityId)
                    .HasConstraintName("FK_Student_University");
            });

            modelBuilder.Entity<UcdsEductionManagement>(entity =>
            {
                entity.HasOne(d => d.College)
                    .WithMany(p => p.UcdsEductionManagement)
                    .HasForeignKey(d => d.CollegeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UCDS_EductionManagement_College");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.UcdsEductionManagement)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UCDS_EductionManagement_Department");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.UcdsEductionManagement)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UCDS_EductionManagement_Subject");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.UcdsEductionManagement)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UCDS_EductionManagement_University");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.University)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_University_Country");
            });

            modelBuilder.Entity<UserBookGift>(entity =>
            {
                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.UserBookGift)
                    .HasForeignKey(d => d.CurrencyTypeId)
                    .HasConstraintName("FK_UserBookGift_CurrencyType");
            });

            modelBuilder.Entity<SlideShow>(entity =>
            {
                entity.HasOne(d => d.Gallery)
                    .WithMany(p => p.SlideShow)
                    .HasForeignKey(d => d.GalleryImgId)
                    .HasConstraintName("FK_SlideShow_Gallery");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
