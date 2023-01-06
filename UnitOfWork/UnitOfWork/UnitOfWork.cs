using Microsoft.EntityFrameworkCore.ChangeTracking;
using WRMC.Infrastructure.DataAccess.Context;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.UnitOfWork.Repositories;
using WRMC.Infrastructure.UnitOfWork.RepositoriesInterfaces;

namespace WRMC.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Represents the default implementation of the <see cref="IUnitOfWork"/> and <see cref="IUnitOfWork{TContext}"/> interface.
    /// </summary>
    /// <typeparam name="TContext">The type of the db context.</typeparam>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ServerDbContext _serverDbContext;
        private readonly TenantDbContext _tenantDbContext;


        private bool disposed = false;

        private Dictionary<Type, object> repositories;



        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork{TContext}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(TenantDbContext tenantDbContext, ServerDbContext serverDbContext)
        {

            _serverDbContext = serverDbContext;
            _tenantDbContext = tenantDbContext;
        }
        //Server Repositories
        private IRepository<User> _userRepository;
        private IRepository<Role> _roleRepository;
        private IRepository<UserRole> _userRoleRepository;
        private IRepository<UserTenant> _userTenants;
        private IRepository<Tenant> _tenants;
        private IRepository<Culture> _cultures;
        private IRepository<UserClaim> _userClaim;
        private IRepository<UserToken> _userTokens;
        private IRepository<UserSetting> _userSettings;
        private IRepository<UserProfile> _userProfiles;
        private IRepository<AppSetting> _appSettings;
        private IRepository<RoleClaim> _roleClaims;
        private IRepository<UserLogin> _userLogin;
        private IRepository<UserSession> _userSession;
        private IRepository<UserAddress> _userAddresses;
        private IRepository<UserAttachment> _userAttachment;
        private IRepository<UserPhoneNumber> _userPhoneNumbers;

        //Tenant Repositories
        private IRepository<IntroMethod> _introMethods;
        private IRepository<Case> _case;
        private IRepository<Visit> _visit;
        private ISectionRepository _section;
        private IRepository<Region> _region;
        private IRepository<Tasks> _tasks;
        private IRepository<SectionClaim> _sectionClaims;
        private IRepository<MedicalIntake> _medicalIntakes;
        private IRepository<DemographicIntake> _demographicIntakes;















        public ServerDbContext ServerDbContext => _serverDbContext;
        public TenantDbContext TenantDbContext => _tenantDbContext;



        public IRepository<User> Users => _userRepository ??= new Repository<User>(_serverDbContext);

        public IRepository<Role> Roles => _roleRepository ??= new Repository<Role>(_serverDbContext);

        public IRepository<UserRole> UserRoles => _userRoleRepository ??= new Repository<UserRole>(_serverDbContext);

        public IRepository<UserTenant> UserTenants => _userTenants ??= new Repository<UserTenant>(_serverDbContext);

        public IRepository<Tenant> Tenants => _tenants ??= new Repository<Tenant>(_serverDbContext);

        public IRepository<Culture> Cultures => _cultures ??= new Repository<Culture>(_serverDbContext);

        public IRepository<UserClaim> UserClaims => _userClaim ??= new Repository<UserClaim>(_serverDbContext);

        public IRepository<UserToken> UserTokens => _userTokens ??= new Repository<UserToken>(_serverDbContext);

        public IRepository<UserSetting> UserSettings => _userSettings ??= new Repository<UserSetting>(_serverDbContext);

        public IRepository<UserProfile> UserProfiles => _userProfiles ??= new Repository<UserProfile>(_serverDbContext);

        public IRepository<AppSetting> AppSettings => _appSettings ??= new Repository<AppSetting>(_serverDbContext);

        public IRepository<RoleClaim> RoleClaims => _roleClaims ??= new Repository<RoleClaim>(_serverDbContext);

        public IRepository<UserLogin> UserLogins => _userLogin ??= new Repository<UserLogin>(_serverDbContext);

        public IRepository<UserSession> UserSessions => _userSession ??= new Repository<UserSession>(_serverDbContext);

        public IRepository<UserAttachment> UserAttachments => _userAttachment ??= new Repository<UserAttachment>(_serverDbContext);

        public IRepository<UserAddress> UserAddresses => _userAddresses ??= new Repository<UserAddress>(_serverDbContext);

        public IRepository<UserPhoneNumber> UserPhoneNumbers => _userPhoneNumbers ??= new Repository<UserPhoneNumber>(_serverDbContext);

        //====================================================================================================

        public IRepository<IntroMethod> IntroMethods => _introMethods ??= new Repository<IntroMethod>(_tenantDbContext);

        public IRepository<Case> Cases => _case ??= new Repository<Case>(_tenantDbContext);

        public IRepository<Visit> Visits => _visit ??= new Repository<Visit>(_tenantDbContext);

        public ISectionRepository Sections => _section ??= new SectionRepository(_tenantDbContext);

        public IRepository<Region> Regions => _region ??= new Repository<Region>(_tenantDbContext);

        public IRepository<Tasks> Tasks => _tasks ??= new Repository<Tasks>(_tenantDbContext);

        public IRepository<SectionClaim> SectionClaims => _sectionClaims ??= new Repository<SectionClaim>(_tenantDbContext);

        public IRepository<MedicalIntake> MedicalIntakes => _medicalIntakes ??= new Repository<MedicalIntake>(_tenantDbContext);

        public IRepository<DemographicIntake> DemographicIntakes => _demographicIntakes ??= new Repository<DemographicIntake>(_tenantDbContext);



      

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <param name="ensureAutoHistory"><c>True</c> if save changes ensure auto record the change history.</param>
        /// <returns>The number of state entries written to the database.</returns>
        public int SaveChanges()
        {

            return _serverDbContext.SaveChanges();
        }

        /// <summary>
        /// Asynchronously saves all changes made in this unit of work to the database.
        /// </summary>
        /// <param name="ensureAutoHistory"><c>True</c> if save changes ensure auto record the change history.</param>
        /// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous save operation. The task result contains the number of state entities written to database.</returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _serverDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">The disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // clear repositories
                    if (repositories != null)
                    {
                        repositories.Clear();
                    }

                    // dispose the db context.
                    _serverDbContext.Dispose();
                    _tenantDbContext.Dispose();
                }
            }

            disposed = true;
        }

    }

}