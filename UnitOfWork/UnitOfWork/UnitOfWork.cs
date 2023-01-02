// Copyright (c) Arch team. All rights reserved.
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data;
using System.Text.RegularExpressions;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.UnitOfWork.Repositories;
using WRMC.Infrastructure.UnitOfWork.RepositoriesInterfaces;

namespace WRMC.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Represents the default implementation of the <see cref="IUnitOfWork"/> and <see cref="IUnitOfWork{TContext}"/> interface.
    /// </summary>
    /// <typeparam name="TContext">The type of the db context.</typeparam>
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly TContext _context;


        private bool disposed = false;

        private Dictionary<Type, object> repositories;


        private IRepository<User> _userRepository;
        public IRepository<User> Users => _userRepository ??= new Repository<User>(_context);
        private IRepository<Role> _roleRepository;
        public IRepository<Role> Roles => _roleRepository ??= new Repository<Role>(_context);

        private IRepository<UserRole> _userRoleRepository;
        public IRepository<UserRole> UserRoles => _userRoleRepository ??= new Repository<UserRole>(_context);

        private IRepository<UserTenant> _userTenants;
        public IRepository<UserTenant> UserTenants => _userTenants ??= new Repository<UserTenant>(_context);

        private IRepository<Tenant> _tenants;
        public IRepository<Tenant> Tenants => _tenants ??= new Repository<Tenant>(_context);

        private IRepository<Culture> _cultures;
        public IRepository<Culture> Cultures => _cultures ??= new Repository<Culture>(_context);

        private IRepository<UserClaim> _userClaim;
        public IRepository<UserClaim> UserClaims => _userClaim ??= new Repository<UserClaim>(_context);

        private IRepository<UserToken> _userTokens;
        public IRepository<UserToken> UserTokens => _userTokens ??= new Repository<UserToken>(_context);


        private IRepository<UserSetting> _userSettings;
        public IRepository<UserSetting> UserSettings => _userSettings ??= new Repository<UserSetting>(_context);

        private IRepository<UserProfile> _userProfiles;
        public IRepository<UserProfile> UserProfiles => _userProfiles ??= new Repository<UserProfile>(_context);


        private IRepository<IntroMethod> _introductionInfo;
        public IRepository<IntroMethod> IntroMethods => _introductionInfo ??= new Repository<IntroMethod>(_context);


        private IRepository<AppSetting> _appSettings;
        public IRepository<AppSetting> AppSettings => _appSettings ??= new Repository<AppSetting>(_context);

        private IRepository<RoleClaim> _roleClaims;
        public IRepository<RoleClaim> RoleClaims => _roleClaims ??= new Repository<RoleClaim>(_context);

        private IRepository<UserLogin> _userLogin;
        public IRepository<UserLogin> UserLogins => _userLogin ??= new Repository<UserLogin>(_context);

        private IRepository<UserSession> _userSession;
        public IRepository<UserSession> UserSessions => _userSession ??= new Repository<UserSession>(_context);

        //====================================================================================================
        private IRepository<Case> _case;
        public IRepository<Case> Cases => _case ??= new Repository<Case>(_context);

        private IRepository<Visit> _visit;
        public IRepository<Visit> Visits => _visit ??= new Repository<Visit>(_context);

        private ISectionRepository _section;
        public ISectionRepository Sections => _section ??= new SectionRepository(_context);

        private IRepository<Region> _region;
        public IRepository<Region> Regions => _region ??= new Repository<Region>(_context);


        private IRepository<Tasks> _tasks;
        public IRepository<Tasks> Tasks => _tasks ??= new Repository<Tasks>(_context);


        private IRepository<SectionClaim> _sectionClaims;
        public IRepository<SectionClaim> SectionClaims => _sectionClaims ??= new Repository<SectionClaim>(_context);


        private IRepository<UserAttachment> _userAttachment;
        public IRepository<UserAttachment> UserAttachments => _userAttachment ??= new Repository<UserAttachment>(_context);


        private IRepository<UserAddress> _userAddresses;
        public IRepository<UserAddress> UserAddresses => _userAddresses ??= new Repository<UserAddress>(_context);


        private IRepository<UserPhoneNumber> _userPhoneNumbers;
        public IRepository<UserPhoneNumber> UserPhoneNumbers => _userPhoneNumbers ??= new Repository<UserPhoneNumber>(_context);


        private IRepository<MedicalIntake> _medicalIntakes;
        public IRepository<MedicalIntake> MedicalIntakes => _medicalIntakes ??= new Repository<MedicalIntake>(_context);


        private IRepository<DemographicIntake> _demographicIntakes;
        public IRepository<DemographicIntake> DemographicIntakes => _demographicIntakes ??= new Repository<DemographicIntake>(_context);












        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork{TContext}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(TContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Gets the db context.
        /// </summary>
        /// <returns>The instance of type <typeparamref name="TContext"/>.</returns>
        public TContext DbContext => _context;

        /// <summary>
        /// Changes the database name. This require the databases in the same machine. NOTE: This only work for MySQL right now.
        /// </summary>
        /// <param name="database">The database name.</param>
        /// <remarks>
        /// This only been used for supporting multiple databases in the same model. This require the databases in the same machine.
        /// </remarks>
        public void ChangeDatabase(string database)
        {
            var connection = _context.Database.GetDbConnection();
            if (connection.State.HasFlag(ConnectionState.Open))
            {
                connection.ChangeDatabase(database);
            }
            else
            {
                var connectionString = Regex.Replace(connection.ConnectionString.Replace(" ", ""), @"(?<=[Dd]atabase=)\w+(?=;)", database, RegexOptions.Singleline);
                connection.ConnectionString = connectionString;
            }

            // Following code only working for mysql.
            var items = _context.Model.GetEntityTypes();
            foreach (var item in items)
            {
                if (item is IConventionEntityType entityType)
                {
                    entityType.SetSchema(database);
                }
            }
        }

        /// <summary>
        /// Gets the specified repository for the <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="hasCustomRepository"><c>True</c> if providing custom repositry</param>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>An instance of type inherited from <see cref="IRepository{TEntity}"/> interface.</returns>
        public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
            }

            // what's the best way to support custom reposity?
            if (hasCustomRepository)
            {
                var customRepo = _context.GetService<IRepository<TEntity>>();
                if (customRepo != null)
                {
                    return customRepo;
                }
            }

            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new Repository<TEntity>(_context);
            }

            return (IRepository<TEntity>)repositories[type];
        }

        /// <summary>
        /// Executes the specified raw SQL command.
        /// </summary>
        /// <param name="sql">The raw SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The number of state entities written to database.</returns>
        public int ExecuteSqlCommand(string sql, params object[] parameters) => _context.Database.ExecuteSqlRaw(sql, parameters);

        /// <summary>
        /// Uses raw SQL queries to fetch the specified <typeparamref name="TEntity" /> data.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="sql">The raw SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>An <see cref="IQueryable{T}" /> that contains elements that satisfy the condition specified by raw SQL.</returns>
        public IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class => _context.Set<TEntity>().FromSqlRaw(sql, parameters);

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <param name="ensureAutoHistory"><c>True</c> if save changes ensure auto record the change history.</param>
        /// <returns>The number of state entries written to the database.</returns>
        public int SaveChanges()
        {

            return _context.SaveChanges();
        }

        /// <summary>
        /// Asynchronously saves all changes made in this unit of work to the database.
        /// </summary>
        /// <param name="ensureAutoHistory"><c>True</c> if save changes ensure auto record the change history.</param>
        /// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous save operation. The task result contains the number of state entities written to database.</returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
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
                    _context.Dispose();
                }
            }

            disposed = true;
        }

        public void TrackGraph(object rootEntity, Action<EntityEntryGraphNode> callback)
        {
            _context.ChangeTracker.TrackGraph(rootEntity, callback);
        }
    }

}