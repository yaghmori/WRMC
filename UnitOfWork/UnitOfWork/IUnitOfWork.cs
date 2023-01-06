using WRMC.Infrastructure.DataAccess.Context;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.UnitOfWork.RepositoriesInterfaces;

namespace WRMC.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {

        IRepository<User> Users { get; }
        IRepository<UserSetting> UserSettings { get; }
        IRepository<UserProfile> UserProfiles { get; }
        IRepository<Role> Roles { get; }
        IRepository<RoleClaim> RoleClaims { get; }
        IRepository<UserRole> UserRoles { get; }
        IRepository<UserTenant> UserTenants { get; }
        IRepository<UserToken> UserTokens { get; }
        IRepository<Tenant> Tenants { get; }
        IRepository<Culture> Cultures { get; }
        IRepository<UserClaim> UserClaims { get; }
        IRepository<UserLogin> UserLogins { get; }
        IRepository<AppSetting> AppSettings { get; }
        IRepository<UserSession> UserSessions { get; }
        ISectionRepository Sections{ get; }
        IRepository<SectionClaim> SectionClaims { get; }
        IRepository<Region> Regions { get; }
        IRepository<Tasks> Tasks { get; }
        IRepository<Visit> Visits { get; }
        IRepository<Case> Cases { get; }
        IRepository<IntroMethod> IntroMethods { get; }
        IRepository<UserAttachment> UserAttachments { get; }
        IRepository<UserAddress> UserAddresses { get; }
        IRepository<UserPhoneNumber> UserPhoneNumbers { get; }
        IRepository<MedicalIntake> MedicalIntakes { get; }
        IRepository<DemographicIntake> DemographicIntakes { get; }

        TenantDbContext TenantDbContext { get; }
        ServerDbContext ServerDbContext { get; }


    }
}

