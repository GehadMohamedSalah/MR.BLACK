using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

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

        public virtual DbSet<AcademicYear> AcademicYears { get; set; }
        public virtual DbSet<Advertising> Advertisings { get; set; }
        public virtual DbSet<AdvertisingAttachment> AdvertisingAttachments { get; set; }
        public virtual DbSet<AdvertisingPackage> AdvertisingPackages { get; set; }
        public virtual DbSet<AdvertisingPackageInvoice> AdvertisingPackageInvoices { get; set; }
        public virtual DbSet<AdvertisingPackageInvoiceView> AdvertisingPackageInvoiceViews { get; set; }
        public virtual DbSet<AdvertisingPackagePage> AdvertisingPackagePages { get; set; }
        public virtual DbSet<AdvertisingPackageRequest> AdvertisingPackageRequests { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleCategory> ArticleCategories { get; set; }
        public virtual DbSet<ArticleResource> ArticleResources { get; set; }
        public virtual DbSet<BalanceTransfer> BalanceTransfers { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
        public virtual DbSet<BookInvoice> BookInvoices { get; set; }
        public virtual DbSet<BookStore> BookStores { get; set; }
        public virtual DbSet<College> Colleges { get; set; }
        public virtual DbSet<Copun> Copuns { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CurrencyExchange> CurrencyExchanges { get; set; }
        public virtual DbSet<CurrencyType> CurrencyTypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Gallery> Galleries { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<MembershipLink> MembershipLinks { get; set; }
        public virtual DbSet<Messaging> Messagings { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<PaymentWay> PaymentWays { get; set; }
        public virtual DbSet<Privilage> Privilages { get; set; }
        public virtual DbSet<Punishment> Punishments { get; set; }
        public virtual DbSet<RequestServiceStep> RequestServiceSteps { get; set; }
        public virtual DbSet<RolePrivilage> RolePrivilages { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }
        public virtual DbSet<ServiceCategoryRequest> ServiceCategoryRequests { get; set; }
        public virtual DbSet<ServiceProvider> ServiceProviders { get; set; }
        public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }
        public virtual DbSet<ServicesInServicesPurchaseInvoice> ServicesInServicesPurchaseInvoices { get; set; }
        public virtual DbSet<ServicesPurchaseInvoice> ServicesPurchaseInvoices { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SystemPage> SystemPages { get; set; }
        public virtual DbSet<SystemSetting> SystemSettings { get; set; }
        public virtual DbSet<TechnicalSupport> TechnicalSupports { get; set; }
        public virtual DbSet<Term> Terms { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<UserBookGift> UserBookGifts { get; set; }
        public virtual DbSet<UserVisit> UserVisits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-8K7QL6F;Database=MRBLACKDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Advertising>(entity =>
            {
                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Advertisings)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK_Advertising_ServiceProvider");
            });

            modelBuilder.Entity<AdvertisingAttachment>(entity =>
            {
                entity.HasOne(d => d.Advertising)
                    .WithMany(p => p.AdvertisingAttachments)
                    .HasForeignKey(d => d.AdvertisingId)
                    .HasConstraintName("FK_AdvertisingAttachment_Advertising");
            });

            modelBuilder.Entity<AdvertisingPackage>(entity =>
            {
                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.AdvertisingPackages)
                    .HasForeignKey(d => d.CurrencyTypeId)
                    .HasConstraintName("FK_AdvertisingPackage_CurrencyType");
            });

            modelBuilder.Entity<AdvertisingPackageInvoice>(entity =>
            {
                entity.HasOne(d => d.AdvertisingPackageRequest)
                    .WithMany(p => p.AdvertisingPackageInvoices)
                    .HasForeignKey(d => d.AdvertisingPackageRequestId)
                    .HasConstraintName("FK_AdvertisingPackageInvoice_AdvertisingPackageRequest");
            });

            modelBuilder.Entity<AdvertisingPackageInvoiceView>(entity =>
            {
                entity.HasOne(d => d.AdvertisingPackageInvoice)
                    .WithMany(p => p.AdvertisingPackageInvoiceViews)
                    .HasForeignKey(d => d.AdvertisingPackageInvoiceId)
                    .HasConstraintName("FK_AdvertisingPackageInvoiceView_AdvertisingPackageInvoice");
            });

            modelBuilder.Entity<AdvertisingPackagePage>(entity =>
            {
                entity.HasOne(d => d.AdvertisingPackage)
                    .WithMany(p => p.AdvertisingPackagePages)
                    .HasForeignKey(d => d.AdvertisingPackageId)
                    .HasConstraintName("FK_AdvertisingPackagePage_AdvertisingPackage");

                entity.HasOne(d => d.SystemPage)
                    .WithMany(p => p.AdvertisingPackagePages)
                    .HasForeignKey(d => d.SystemPageId)
                    .HasConstraintName("FK_AdvertisingPackagePage_SystemPage");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasOne(d => d.ArticleCategory)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.ArticleCategoryId)
                    .HasConstraintName("FK_Article_ArticleCategory");
            });

            modelBuilder.Entity<ArticleResource>(entity =>
            {
                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleResources)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("FK_ArticleResource_Article");
            });

            modelBuilder.Entity<BalanceTransfer>(entity =>
            {
                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.BalanceTransfers)
                    .HasForeignKey(d => d.CurrencyTypeId)
                    .HasConstraintName("FK_BalanceTransfer_CurrencyType");
            });

            modelBuilder.Entity<BookInvoice>(entity =>
            {
                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookInvoices)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_BookInvoice_BookStore");

                entity.HasOne(d => d.Copun)
                    .WithMany(p => p.BookInvoices)
                    .HasForeignKey(d => d.CopunId)
                    .HasConstraintName("FK_BookInvoice_Copun");
            });

            modelBuilder.Entity<BookStore>(entity =>
            {
                entity.HasOne(d => d.BookCategory)
                    .WithMany(p => p.BookStores)
                    .HasForeignKey(d => d.BookCategoryId)
                    .HasConstraintName("FK_BookStore_BookCategory");

                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.BookStores)
                    .HasForeignKey(d => d.CurrencyTypeId)
                    .HasConstraintName("FK_BookStore_CurrencyType");
            });

            modelBuilder.Entity<Copun>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Copuns)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Copun_ServiceCategory");

                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.Copuns)
                    .HasForeignKey(d => d.CurrencyTypeId)
                    .HasConstraintName("FK_Copun_CurrencyType");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.CurrencyTypeId)
                    .HasConstraintName("FK_Country_CurrencyType");
            });

            modelBuilder.Entity<CurrencyExchange>(entity =>
            {
                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.CurrencyExchanges)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("FK_CurrencyExchange_CurrencyType");
            });

            modelBuilder.Entity<MembershipLink>(entity =>
            {
                entity.HasOne(d => d.Membership)
                    .WithMany(p => p.MembershipLinks)
                    .HasForeignKey(d => d.MembershipId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MembershipLink_Membership");
            });

            modelBuilder.Entity<RolePrivilage>(entity =>
            {
                entity.HasOne(d => d.Privilage)
                    .WithMany(p => p.RolePrivilages)
                    .HasForeignKey(d => d.PrivilageId)
                    .HasConstraintName("FK_RolePrivilage_Privilage");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasOne(d => d.AcademinYear)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.AcademinYearId)
                    .HasConstraintName("FK_Service_AcademicYear");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Service_ServiceCategory");

                entity.HasOne(d => d.College)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.CollegeId)
                    .HasConstraintName("FK_Service_College");

                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.CurrencyTypeId)
                    .HasConstraintName("FK_Service_CurrencyType");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Service_Department");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK_Service_ServiceProvider");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Service_Subject");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.TermId)
                    .HasConstraintName("FK_Service_Term");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.UniversityId)
                    .HasConstraintName("FK_Service_University");
            });

            modelBuilder.Entity<ServiceCategory>(entity =>
            {
                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.ServiceCategories)
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
                    .WithMany(p => p.ServiceCategoryRequests)
                    .HasForeignKey(d => d.AcademinYearId)
                    .HasConstraintName("FK_ServiceCategoryRequest_AcademicYear");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ServiceCategoryRequests)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_ServiceCategoryRequest_ServiceCategory");

                entity.HasOne(d => d.College)
                    .WithMany(p => p.ServiceCategoryRequests)
                    .HasForeignKey(d => d.CollegeId)
                    .HasConstraintName("FK_ServiceCategoryRequest_College");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.ServiceCategoryRequests)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_ServiceCategoryRequest_Department");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.ServiceCategoryRequests)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK_ServiceCategoryRequest_ServiceProvider");


                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.ServiceCategoryRequests)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_ServiceCategoryRequest_Subject");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.ServiceCategoryRequests)
                    .HasForeignKey(d => d.TermId)
                    .HasConstraintName("FK_ServiceCategoryRequest_Term");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.ServiceCategoryRequests)
                    .HasForeignKey(d => d.UniversityId)
                    .HasConstraintName("FK_ServiceCategoryRequest_University");
            });

            modelBuilder.Entity<ServiceProvider>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.ServiceProviders)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_ServiceProvider_Country");

                entity.HasOne(d => d.PaymentWay)
                    .WithMany(p => p.ServiceProviders)
                    .HasForeignKey(d => d.PaymentWayId)
                    .HasConstraintName("FK_ServiceProvider_PaymentWay");
            });

            modelBuilder.Entity<ServiceRequest>(entity =>
            {
            });

            modelBuilder.Entity<ServicesInServicesPurchaseInvoice>(entity =>
            {
                entity.HasOne(d => d.Inv)
                    .WithMany(p => p.ServicesInServicesPurchaseInvoices)
                    .HasForeignKey(d => d.InvId)
                    .HasConstraintName("FK_ServicesInServicesPurchaseInvoice_ServicesPurchaseInvoice");
            });

            modelBuilder.Entity<ServicesPurchaseInvoice>(entity =>
            {
                entity.HasOne(d => d.Copun)
                    .WithMany(p => p.ServicesPurchaseInvoices)
                    .HasForeignKey(d => d.CopunId)
                    .HasConstraintName("FK_ServicesPurchaseInvoice_Copun");

                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.ServicesPurchaseInvoices)
                    .HasForeignKey(d => d.CurrencyTypeId)
                    .HasConstraintName("FK_ServicesPurchaseInvoice_CurrencyType");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasOne(d => d.AcademicYear)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.AcademicYearId)
                    .HasConstraintName("FK_Student_AcademicYear");

                entity.HasOne(d => d.College)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CollegeId)
                    .HasConstraintName("FK_Student_College");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Student_Department");

                entity.HasOne(d => d.PaymentWay)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.PaymentWayId)
                    .HasConstraintName("FK_Student_PaymentWay");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.TermId)
                    .HasConstraintName("FK_Student_Term");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.UniversityId)
                    .HasConstraintName("FK_Student_University");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Universities)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_University_Country");
            });

            modelBuilder.Entity<UserBookGift>(entity =>
            {
                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.UserBookGifts)
                    .HasForeignKey(d => d.CurrencyTypeId)
                    .HasConstraintName("FK_UserBookGift_CurrencyType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
