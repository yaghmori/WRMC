using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WRMC.Core.Shared.Constant;
using WRMC.Infrastructure.Domain.Entities;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace WRMC.Infrastructure.DataAccess.Context
{
    public class ServerDbContext : IdentityDbContext<
        User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPasswordHasher<User> _passwordHasher;

        public ServerDbContext(DbContextOptions<ServerDbContext> options, IHttpContextAccessor httpContextAccessor, IPasswordHasher<User> passwordHasher)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            _passwordHasher = passwordHasher;
        }
        public virtual DbSet<Tenant> Tenant { get; set; }
        public virtual DbSet<UserTenant> UserTenants { get; set; }
        public virtual DbSet<AppSetting> AppSettings { get; set; }
        public virtual DbSet<UserSetting> UserSettings { get; set; }
        public virtual DbSet<Culture> Cultures { get; set; }
        public virtual DbSet<UserSession> UserSessions { get; set; }
        public virtual DbSet<UserAttachment> UserAttachment { get; set; }
        public virtual DbSet<UserPhoneNumber> UserPhoneNumbers { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var user = new User
            {
                Id = Guid.NewGuid(),
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = "admin@wrmc.com",
                EmailConfirmed = true,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@WRMC.COM",
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, "123456789");
            var userProfile = new UserProfile
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                FirstName = "Test name",
                LastName = "Test family",
                Gender = Domain.Enums.GenderEnum.Male
            };
                 
            var userSettings = new UserSetting
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                RightToLeft = false,
                Culture = "en-US",
                DarkMode = false,
            };

            foreach (var item in Seed.UserPhoneNumbers)
            {
                item.UserId = user.Id;
            }
            foreach (var item in Seed.UserAddress)
            {
                item.UserId = user.Id;
            }


            builder.Entity<User>(b =>
            {
                b.HasData(user);
                b.HasQueryFilter(x => x.IsDeleted == false);
                b.ToTable("Users");
                b.HasMany<UserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
                b.HasMany<UserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
                b.HasMany<UserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
                b.HasMany<UserSession>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
                b.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
                b.HasMany<UserAddress>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
                b.HasMany<UserPhoneNumber>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
                b.HasMany<UserAttachment>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
                b.HasOne(b => b.UserProfile).WithOne(i => i.User).HasForeignKey<UserProfile>(b => b.UserId);
                b.HasOne(b => b.UserSetting).WithOne(i => i.User).HasForeignKey<UserSetting>(b => b.UserId);

                b.Property(x => x.Id).HasColumnOrder(0);

                b.Property(x => x.UserName).HasColumnOrder(4);
                b.Property(x => x.NormalizedUserName).HasColumnOrder(5);

                b.Property(x => x.Email).HasColumnOrder(6);
                b.Property(x => x.NormalizedEmail).HasColumnOrder(7);
                b.Property(x => x.EmailConfirmed).HasColumnOrder(8);
                b.Property(x => x.EmailToken).HasColumnOrder(9);
                b.Property(x => x.EmailTokenExpires).HasColumnOrder(10);

                b.Property(x => x.PasswordHash).HasColumnOrder(11);
                b.Property(x => x.PasswordToken).HasColumnOrder(12);
                b.Property(x => x.PasswordTokenExpires).HasColumnOrder(13);
                b.Property(x => x.PasswordResetAt).HasColumnOrder(14);

                b.Property(x => x.PhoneNumber).HasColumnOrder(15);
                b.Property(x => x.PhoneNumberConfirmed).HasColumnOrder(16);
                b.Property(x => x.PhoneNumberToken).HasColumnOrder(17);
                b.Property(x => x.PhoneNumberTokenExpires).HasColumnOrder(18);

                b.Property(x => x.TwoFactorEnabled).HasColumnOrder(19);
                b.Property(x => x.IsActive).HasColumnOrder(20);
                b.Property(x => x.LockoutEnabled).HasColumnOrder(21);
                b.Property(x => x.LockoutEnd).HasColumnOrder(22);
                b.Property(x => x.AccessFailedCount).HasColumnOrder(23);
                b.Property(x => x.SecurityStamp).HasColumnOrder(24);
                b.Property(x => x.ConcurrencyStamp).HasColumnOrder(25);

            });
            builder.Entity<UserSetting>(b =>
            {
                b.HasData(userSettings);
                b.HasQueryFilter(x => x.IsDeleted == false);
            });
            builder.Entity<UserProfile>(b =>
            {
                b.HasData(userProfile);
                b.HasQueryFilter(x => x.IsDeleted == false);
            });
            builder.Entity<AppSetting>(b =>
            {
                b.HasData(new AppSetting
                {
                    Id = Guid.NewGuid(),
                    Key = ApplicationConstants.DefaultConnectionString,
                    Value = "Server=.;Database={0};Integrated Security = True;",
                });
                //b.HasQueryFilter(x => x.IsDeleted == false);
            });
            builder.Entity<Tenant>(b =>
            {
                b.HasQueryFilter(x => x.IsDeleted == false);

            });
            builder.Entity<Culture>(b =>
            {
                b.HasData(Seed.Cultures);
                b.HasQueryFilter(x => x.IsDeleted == false);
            });
            builder.Entity<UserClaim>(b =>
            {
                b.HasQueryFilter(x => x.IsDeleted == false);
                b.ToTable("UserClaims");
                b.HasOne(e => e.User).WithMany(e => e.UserClaims).HasForeignKey(e => e.UserId);

                b.Property(x => x.Id).HasColumnOrder(0);
                b.Property(x => x.UserId).HasColumnOrder(1);
                b.Property(x => x.ClaimType).HasColumnOrder(2);
                b.Property(x => x.ClaimValue).HasColumnOrder(3);
            });
            builder.Entity<UserLogin>(b =>
            {
                b.HasKey(x => x.Id);

                b.HasQueryFilter(x => x.IsDeleted == false);
                b.ToTable("UserLogins");
                b.HasOne(e => e.User).WithMany(e => e.UserLogins).HasForeignKey(e => e.UserId);
                b.Property(x => x.Id).HasColumnOrder(0);
                b.Property(x => x.UserId).HasColumnOrder(1);
                b.Property(x => x.LoginProvider).HasColumnOrder(2);
                b.Property(x => x.ProviderKey).HasColumnOrder(3);
                b.Property(x => x.ProviderDisplayName).HasColumnOrder(4);

            });
            builder.Entity<UserSession>(b =>
            {
                b.HasQueryFilter(x => x.IsDeleted == false);
                b.ToTable("UserSessions");
                b.HasOne(e => e.User).WithMany(e => e.UserSessions).HasForeignKey(e => e.UserId);
            });
            builder.Entity<UserToken>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasQueryFilter(x => x.IsDeleted == false);
                b.ToTable("UserTokens");
                b.HasOne(e => e.User).WithMany(e => e.UserTokens).HasForeignKey(e => e.UserId);
                b.Property(x => x.Id).HasColumnOrder(0);
                b.Property(x => x.UserId).HasColumnOrder(1);
                b.Property(x => x.LoginProvider).HasColumnOrder(2);
                b.Property(x => x.Name).HasColumnOrder(3);
                b.Property(x => x.Value).HasColumnOrder(4);

            });
            builder.Entity<UserTenant>(b =>
            {
                b.HasQueryFilter(x => x.IsDeleted == false);
            });
            builder.Entity<UserAttachment>(b =>
            {
                b.HasQueryFilter(x => x.IsDeleted == false);
                b.HasOne(e => e.User).WithMany(e => e.UserImages).HasForeignKey(e => e.UserId);
            });
            builder.Entity<UserPhoneNumber>(b =>
            {
                b.HasData(Seed.UserPhoneNumbers);
                b.HasQueryFilter(x => x.IsDeleted == false);
                b.HasOne(e => e.User).WithMany(e => e.UserPhoneNumbers).HasForeignKey(e => e.UserId);
                b.Property(x => x.Id).HasColumnOrder(0);
                b.Property(x => x.CreatedDate).HasColumnOrder(100);
                b.Property(x => x.CreatedUserId).HasColumnOrder(101);
                b.Property(x => x.CreatedIpAddress).HasColumnOrder(102);
                b.Property(x => x.ModifiedDate).HasColumnOrder(103);
                b.Property(x => x.ModifiedUserId).HasColumnOrder(104);
                b.Property(x => x.ModifiedIpAddress).HasColumnOrder(105);
                b.Property(x => x.DeletedDate).HasColumnOrder(106);
                b.Property(x => x.DeletedUserId).HasColumnOrder(107);
                b.Property(x => x.DeletedIpAddress).HasColumnOrder(108);
                b.Property(x => x.IsDeleted).HasColumnOrder(109);

            });
            builder.Entity<UserAddress>(b =>
            {
                b.HasData(Seed.UserAddress);
                b.HasQueryFilter(x => x.IsDeleted == false);
                b.HasOne(e => e.User).WithMany(e => e.UserAddresses).HasForeignKey(e => e.UserId);
            });
            builder.Entity<Role>(b =>
            {
                b.Property(x => x.Id).HasColumnOrder(0);
                b.Property(x => x.Name).HasColumnOrder(1);
                b.Property(x => x.NormalizedName).HasColumnOrder(2);
                b.Property(x => x.ConcurrencyStamp).HasColumnOrder(3);

                b.HasData(Seed.Roles);
                b.HasQueryFilter(x => x.IsDeleted == false);
                b.ToTable("Roles");
                b.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
                b.HasMany<RoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            });
            builder.Entity<RoleClaim>(b =>
            {
                b.Property(x => x.Id).HasColumnOrder(0);
                b.Property(x => x.RoleId).HasColumnOrder(1);
                b.Property(x => x.ClaimType).HasColumnOrder(2);
                b.Property(x => x.ClaimValue).HasColumnOrder(3);

                b.HasQueryFilter(x => x.IsDeleted == false);
                b.ToTable("RoleClaims");
                b.HasOne(e => e.Role).WithMany(e => e.RoleClaims).HasForeignKey(e => e.RoleId);
                var i = 1;
                foreach (var item in ApplicationPermissions.GetPermissions())
                {
                    builder.Entity<RoleClaim>().HasData(new RoleClaim
                    {
                        Id = i,
                        RoleId = Seed.Roles.FirstOrDefault(x => x.Name == ApplicationRoles.Administrator)!.Id,
                        ClaimType = ApplicationClaimTypes.Permission,
                        ClaimValue = item,
                    }); ;
                    i++;
                }
            });
            builder.Entity<UserRole>(b =>
            {
                b.HasQueryFilter(x => x.IsDeleted == false);

                b.HasKey(x => x.Id);
                b.HasData(new UserRole { Id = Guid.NewGuid(), UserId = user.Id, RoleId = Seed.Roles.FirstOrDefault(x => x.Name == ApplicationRoles.Administrator)!.Id });
                b.ToTable("UserRoles");
                b.HasOne(e => e.User).WithMany(e => e.UserRoles).HasForeignKey(e => e.UserId);
                b.HasOne(e => e.Role).WithMany(e => e.UserRoles).HasForeignKey(e => e.RoleId);
                b.Property(x => x.Id).HasColumnOrder(0);
                b.Property(x => x.UserId).HasColumnOrder(1);
                b.Property(x => x.RoleId).HasColumnOrder(2);

            });
            builder.Entity<Region>(b =>
            {
                b.HasData(Seed.Countries);
                b.HasData(Seed.States);
                //b.HasData(Seed.Cities);
                b.HasQueryFilter(x => x.IsDeleted == false);

            });


        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(x => x.Type == ApplicationClaimTypes.UserId)?.Value;
            var ip = _httpContextAccessor.HttpContext?.Request?.HttpContext?.Connection?.RemoteIpAddress?.ToString();

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
                switch (item.Metadata.GetTableName())
                {
                    case "UserRoles":
                        item.State = EntityState.Deleted;
                        break;
                    case "UserClaims":
                        item.State = EntityState.Deleted;
                        break;
                    case "RoleClaims":
                        item.State = EntityState.Deleted;
                        break;
                    case "UserTokens":
                        item.State = EntityState.Deleted;
                        break;
                    case "UserLogins":
                        item.State = EntityState.Deleted;
                        break;
                    case "Regions":
                        item.State = EntityState.Deleted;
                        break;

                    default:
                        item.State = EntityState.Modified;
                        item.Entity.DeletedDate = DateTime.UtcNow;
                        item.Entity.DeletedIpAddress = ip;
                        item.Entity.DeletedUserId = userId;
                        item.Entity.IsDeleted = true;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }

}

