using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WRMC.Core.Shared.Constant;
using WRMC.Infrastructure.Domain.Entities;

namespace WRMC.Infrastructure.DataAccess.Context
{
    public class TenantDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantDbContext(DbContextOptions<TenantDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public static string ConnectionString { get; set; } = string.Empty;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(ConnectionString))
                optionsBuilder.UseSqlServer(ConnectionString);
        }

        public virtual DbSet<IntroMethod> IntroMethods { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<MedicalIntake> MedicalIntakes { get; set; }
        public virtual DbSet<DemographicIntake> DemographicIntakes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MedicalIntake>(b =>
            {
                b.HasQueryFilter(x => x.IsDeleted == false);
            });
            builder.Entity<DemographicIntake>(b =>
            {
                b.HasQueryFilter(x => x.IsDeleted == false);
            });
            builder.Entity<IntroMethod>(b =>
            {
                b.HasData(Seed.IntroMethods);

                b.HasQueryFilter(x => x.IsDeleted == false);
            });
            builder.Entity<Visit>(b =>
            {
                b.HasQueryFilter(x => x.IsDeleted == false);
            });
            builder.Entity<Case>(b =>
            {
                b.HasQueryFilter(x => x.IsDeleted == false);
            });
            builder.Entity<Tasks>(b =>
            {
                b.HasOne(e => e.Visit).WithMany(e => e.Tasks).HasForeignKey(e => e.VisitId);
                b.HasOne(e => e.Section).WithMany(e => e.VisitSections).HasForeignKey(e => e.SectionId);

                b.HasQueryFilter(x => x.IsDeleted == false);
            });
            builder.Entity<Section>(b =>
            {
                b.HasData(Seed.Sections);
                b.HasQueryFilter(x => x.IsDeleted == false);
                b.HasOne(x => x.Parent).WithMany(x => x.Sections).HasForeignKey(x => x.ParentId).IsRequired(false);
            });

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var userId = _httpContextAccessor.HttpContext.User?.FindFirst(x => x.Type == ApplicationClaimTypes.UserId)?.Value;
            var ip = _httpContextAccessor.HttpContext.Request?.HttpContext?.Connection?.RemoteIpAddress?.ToString();

            ChangeTracker.DetectChanges();
            var entities = ChangeTracker.Entries<IAuditEntity>();



            foreach (var item in entities.Where(s => s.State == EntityState.Added))
            {
                item.Entity.CreatedDate = DateTime.UtcNow;
                item.Entity.CreatedIpAddress = ip;
                item.Entity.CreatedUserId = userId;
                item.Entity.IsDeleted = false;
            }

            foreach (var item in entities.Where(s => s.State == EntityState.Modified))
            {
                item.Entity.ModifiedDate = DateTime.UtcNow;
                item.Entity.ModifiedIpAddress = ip;
                item.Entity.ModifiedUserId = userId;
            }

            foreach (var item in entities.Where(s => s.State == EntityState.Deleted))
            {
                item.State = EntityState.Modified;
                item.Entity.DeletedDate = DateTime.UtcNow;
                item.Entity.DeletedIpAddress = ip;
                item.Entity.DeletedUserId = userId;
                item.Entity.IsDeleted = true;

            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }

}

