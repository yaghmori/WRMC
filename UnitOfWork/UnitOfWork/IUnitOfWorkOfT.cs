using Microsoft.EntityFrameworkCore;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.UnitOfWork.Repositories;
using WRMC.Infrastructure.UnitOfWork.RepositoriesInterfaces;

namespace WRMC.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Defines the interface(s) for generic unit of work.
    /// </summary>
    public interface IUnitOfWork<TContext> where TContext : DbContext
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

        /// <summary>
        /// Gets the db context.
        /// </summary>
        /// <returns>The instance of type <typeparamref name="TContext"/>.</returns>
        TContext DbContext { get; }

        /// <summary>
        /// Saves all changes made in this context to the database with distributed transaction.
        /// </summary>
        /// <param name="ensureAutoHistory"><c>True</c> if save changes ensure auto record the change history.</param>
        /// <param name="unitOfWorks">An optional <see cref="IUnitOfWork"/> array.</param>
        /// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous save operation. The task result contains the number of state entities written to database.</returns>
        Task<int> SaveChangesAsync();


        /// <summary>
        /// Executes the specified raw SQL command.
        /// </summary>
        /// <param name="sql">The raw SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The number of state entities written to database.</returns>
        int ExecuteSqlCommand(string sql, params object[] parameters);

        /// <summary>
        /// Uses raw SQL queries to fetch the specified <typeparamref name="TEntity"/> data.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="sql">The raw SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>An <see cref="IQueryable{T}"/> that contains elements that satisfy the condition specified by raw SQL.</returns>
        IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class;


    }
}

