using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WRMC.Infrastructure.Domain.Entities;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.Constants;

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
        public virtual DbSet<AppSetting> AppSettings { get; set; }
        public virtual DbSet<UserSetting> UserSettings { get; set; }
        public virtual DbSet<Culture> Cultures { get; set; }
        public virtual DbSet<UserSession> UserSessions { get; set; }
        public virtual DbSet<UserAttachment> UserAttachment { get; set; }
        public virtual DbSet<UserPhoneNumber> UserPhoneNumbers { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        //===========================================
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
                b.HasMany<Case>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
                b.HasOne(b => b.UserProfile).WithOne(i => i.User).HasForeignKey<UserProfile>(b => b.UserId);
                b.HasOne(b => b.UserSetting).WithOne(i => i.User).HasForeignKey<UserSetting>(b => b.UserId);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.IsOnline).HasColumnOrder(2);
                b.Property(x => x.UserName).HasColumnOrder(3);
                b.Property(x => x.NormalizedUserName).HasColumnOrder(45);

                b.Property(x => x.Email).HasColumnOrder(5);
                b.Property(x => x.NormalizedEmail).HasColumnOrder(6);
                b.Property(x => x.EmailConfirmed).HasColumnOrder(7);
                b.Property(x => x.EmailToken).HasColumnOrder(8);
                b.Property(x => x.EmailTokenExpires).HasColumnOrder(9);

                b.Property(x => x.PasswordHash).HasColumnOrder(10);
                b.Property(x => x.PasswordToken).HasColumnOrder(11);
                b.Property(x => x.PasswordTokenExpires).HasColumnOrder(12);
                b.Property(x => x.PasswordResetAt).HasColumnOrder(13);

                b.Property(x => x.PhoneNumber).HasColumnOrder(14);
                b.Property(x => x.PhoneNumberConfirmed).HasColumnOrder(15);
                b.Property(x => x.PhoneNumberToken).HasColumnOrder(16);
                b.Property(x => x.PhoneNumberTokenExpires).HasColumnOrder(17);

                b.Property(x => x.TwoFactorEnabled).HasColumnOrder(18);
                b.Property(x => x.IsActive).HasColumnOrder(19);
                b.Property(x => x.LockoutEnabled).HasColumnOrder(20);
                b.Property(x => x.LockoutEnd).HasColumnOrder(21);
                b.Property(x => x.AccessFailedCount).HasColumnOrder(22);
                b.Property(x => x.SecurityStamp).HasColumnOrder(23);
                b.Property(x => x.ConcurrencyStamp).HasColumnOrder(24);


                #endregion

            });
            builder.Entity<UserSetting>(b =>
            {
                b.HasData(userSettings);
                b.HasQueryFilter(x => x.IsDeleted == false);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.UserId).HasColumnOrder(2);
                b.Property(x => x.Theme).HasColumnOrder(3);
                b.Property(x => x.DarkMode).HasColumnOrder(4);
                b.Property(x => x.Culture).HasColumnOrder(5);
                b.Property(x => x.RightToLeft).HasColumnOrder(6);

                #endregion

            });
            builder.Entity<UserProfile>(b =>
            {
                b.HasData(userProfile);
                b.HasQueryFilter(x => x.IsDeleted == false);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.UserId).HasColumnOrder(2);
                b.Property(x => x.BirthDate).HasColumnOrder(3);
                b.Property(x => x.Description).HasColumnOrder(4);
                b.Property(x => x.EmergencyName).HasColumnOrder(5);
                b.Property(x => x.EmergencyPhone).HasColumnOrder(6);
                b.Property(x => x.FirstName).HasColumnOrder(7);
                b.Property(x => x.Gender).HasColumnOrder(8);
                b.Property(x => x.Height).HasColumnOrder(9);
                b.Property(x => x.IdNumber).HasColumnOrder(10);
                b.Property(x => x.IntroMethodDescription).HasColumnOrder(11);
                b.Property(x => x.IntroMethodId).HasColumnOrder(12);
                b.Property(x => x.IsVolunteer).HasColumnOrder(13);
                b.Property(x => x.LastName).HasColumnOrder(14);
                b.Property(x => x.MiddleName).HasColumnOrder(15);
                b.Property(x => x.ProfileImage).HasColumnOrder(16);
                b.Property(x => x.RaceNationality).HasColumnOrder(17);
                b.Property(x => x.Weight).HasColumnOrder(18);

                #endregion
            });
            builder.Entity<AppSetting>(b =>
            {
                b.HasData(new AppSetting
                {
                    Id = Guid.NewGuid(),
                    Key = AppConstants.DefaultConnectionString,
                    Value = "Server=.;Database={0};Integrated Security = True;",
                });

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.Key).HasColumnOrder(2);
                b.Property(x => x.Value).HasColumnOrder(3);
                b.Property(x => x.Description).HasColumnOrder(4);
                b.Property(x => x.IsReadOnly).HasColumnOrder(5);

                #endregion        
            });
            builder.Entity<Culture>(b =>
            {
                b.HasData(Seed.Cultures);
                b.HasQueryFilter(x => x.IsDeleted == false);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.CultureName).HasColumnOrder(2);
                b.Property(x => x.DateSeparator).HasColumnOrder(3);
                b.Property(x => x.DisplayName).HasColumnOrder(4);
                b.Property(x => x.FirstDayOfWeek).HasColumnOrder(5);
                b.Property(x => x.FullDateTimePattern).HasColumnOrder(6);
                b.Property(x => x.Image).HasColumnOrder(7);
                b.Property(x => x.IsDefault).HasColumnOrder(8);
                b.Property(x => x.LongDatePattern).HasColumnOrder(9);
                b.Property(x => x.LongTimePattern).HasColumnOrder(10);
                b.Property(x => x.MonthDayPattern).HasColumnOrder(11);
                b.Property(x => x.RightToLeft).HasColumnOrder(12);
                b.Property(x => x.ShortDatePattern).HasColumnOrder(13);
                b.Property(x => x.ShortTimePattern).HasColumnOrder(14);
                b.Property(x => x.TimeSeparator).HasColumnOrder(15);
                b.Property(x => x.YearMonthPattern).HasColumnOrder(16);
                #endregion
            });
            builder.Entity<UserClaim>(b =>
            {
                b.HasQueryFilter(x => x.IsDeleted == false);
                b.ToTable("UserClaims");
                b.HasOne(e => e.User).WithMany(e => e.UserClaims).HasForeignKey(e => e.UserId);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.UserId).HasColumnOrder(2);
                b.Property(x => x.ClaimType).HasColumnOrder(3);
                b.Property(x => x.ClaimValue).HasColumnOrder(4);

                #endregion

            });
            builder.Entity<UserLogin>(b =>
            {
                b.HasKey(x => x.Id);

                b.HasQueryFilter(x => x.IsDeleted == false);
                b.ToTable("UserLogins");
                b.HasOne(e => e.User).WithMany(e => e.UserLogins).HasForeignKey(e => e.UserId);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.UserId).HasColumnOrder(2);
                b.Property(x => x.LoginProvider).HasColumnOrder(3);
                b.Property(x => x.ProviderKey).HasColumnOrder(4);
                b.Property(x => x.ProviderDisplayName).HasColumnOrder(5);

                #endregion

            });
            builder.Entity<UserSession>(b =>
            {
                b.HasQueryFilter(x => x.IsDeleted == false);
                b.ToTable("UserSessions");
                b.HasOne(e => e.User).WithMany(e => e.UserSessions).HasForeignKey(e => e.UserId);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.UserId).HasColumnOrder(2);
                b.Property(x => x.StartDate).HasColumnOrder(3);
                b.Property(x => x.Name).HasColumnOrder(4);
                b.Property(x => x.AccessToken).HasColumnOrder(5);
                b.Property(x => x.RefreshToken).HasColumnOrder(6);
                b.Property(x => x.RefreshTokenExpires).HasColumnOrder(7);
                b.Property(x => x.BuildVersion).HasColumnOrder(8);
                b.Property(x => x.ConnectionID).HasColumnOrder(9);
                b.Property(x => x.LoginProvider).HasColumnOrder(10);
                b.Property(x => x.SessionIpAddress).HasColumnOrder(11);

                #endregion
            });
            builder.Entity<UserToken>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasQueryFilter(x => x.IsDeleted == false);
                b.ToTable("UserTokens");
                b.HasOne(e => e.User).WithMany(e => e.UserTokens).HasForeignKey(e => e.UserId);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.UserId).HasColumnOrder(2);
                b.Property(x => x.LoginProvider).HasColumnOrder(3);
                b.Property(x => x.Name).HasColumnOrder(4);
                b.Property(x => x.Value).HasColumnOrder(5);

                #endregion


            });
            builder.Entity<UserAttachment>(b =>
            {
                b.HasQueryFilter(x => x.IsDeleted == false);
                b.HasOne(e => e.User).WithMany(e => e.UserImages).HasForeignKey(e => e.UserId);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.UserId).HasColumnOrder(2);
                b.Property(x => x.Type).HasColumnOrder(3);
                b.Property(x => x.URL).HasColumnOrder(4);
                b.Property(x => x.Description).HasColumnOrder(5);
                b.Property(x => x.Order).HasColumnOrder(6);
                b.Property(x => x.IsDefault).HasColumnOrder(7);

                #endregion

            });
            builder.Entity<UserPhoneNumber>(b =>
            {
                b.HasData(Seed.UserPhoneNumbers);
                b.HasQueryFilter(x => x.IsDeleted == false);
                b.HasOne(e => e.User).WithMany(e => e.UserPhoneNumbers).HasForeignKey(e => e.UserId);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.UserId).HasColumnOrder(2);
                b.Property(x => x.Type).HasColumnOrder(3);
                b.Property(x => x.PhoneNumber).HasColumnOrder(4);
                b.Property(x => x.Description).HasColumnOrder(5);
                b.Property(x => x.Order).HasColumnOrder(6);
                b.Property(x => x.IsDefault).HasColumnOrder(7);

                #endregion
            });
            builder.Entity<UserAddress>(b =>
            {
                b.HasData(Seed.UserAddress);
                b.HasQueryFilter(x => x.IsDeleted == false);
                b.HasOne(e => e.User).WithMany(e => e.UserAddresses).HasForeignKey(e => e.UserId);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.UserId).HasColumnOrder(2);
                b.Property(x => x.Type).HasColumnOrder(3);
                b.Property(x => x.Address).HasColumnOrder(4);
                b.Property(x => x.RegionId).HasColumnOrder(5);
                b.Property(x => x.ZipCode).HasColumnOrder(6);
                b.Property(x => x.Description).HasColumnOrder(7);
                b.Property(x => x.Order).HasColumnOrder(8);
                b.Property(x => x.IsDefault).HasColumnOrder(9);

                #endregion
            });
            builder.Entity<Role>(b =>
            {
                b.HasData(Seed.Roles);
                b.HasQueryFilter(x => x.IsDeleted == false);
                b.ToTable("Roles");
                b.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
                b.HasMany<RoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.Name).HasColumnOrder(2);
                b.Property(x => x.NormalizedName).HasColumnOrder(3);
                b.Property(x => x.ConcurrencyStamp).HasColumnOrder(4);

                #endregion
            });
            builder.Entity<RoleClaim>(b =>
            {

                b.HasQueryFilter(x => x.IsDeleted == false);
                b.ToTable("RoleClaims");
                b.HasOne(e => e.Role).WithMany(e => e.RoleClaims).HasForeignKey(e => e.RoleId);
                var i = 1;
                foreach (var item in AppPermissions.GetPermissions())
                {
                    builder.Entity<RoleClaim>().HasData(new RoleClaim
                    {
                        Id = i,
                        RoleId = Seed.Roles.FirstOrDefault(x => x.Name == AppRoles.Administrator)!.Id,
                        ClaimType = AppClaimTypes.Permission,
                        ClaimValue = item,
                    }); ;
                    i++;
                }

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.RoleId).HasColumnOrder(2);
                b.Property(x => x.ClaimType).HasColumnOrder(3);
                b.Property(x => x.ClaimValue).HasColumnOrder(4);

                #endregion
            });
            builder.Entity<UserRole>(b =>
            {
                b.HasQueryFilter(x => x.IsDeleted == false);

                b.HasKey(x => x.Id);
                b.HasData(new UserRole { Id = Guid.NewGuid(), UserId = user.Id, RoleId = Seed.Roles.FirstOrDefault(x => x.Name == AppRoles.Administrator)!.Id });
                b.ToTable("UserRoles");
                b.HasOne(e => e.User).WithMany(e => e.UserRoles).HasForeignKey(e => e.UserId);
                b.HasOne(e => e.Role).WithMany(e => e.UserRoles).HasForeignKey(e => e.RoleId);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.UserId).HasColumnOrder(2);
                b.Property(x => x.RoleId).HasColumnOrder(3);

                #endregion
            });
            builder.Entity<Region>(b =>
            {
                b.HasData(Seed.Countries);
                b.HasData(Seed.States);
                //b.HasData(Seed.Cities);
                b.HasQueryFilter(x => x.IsDeleted == false);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.ParentId).HasColumnOrder(2);
                b.Property(x => x.RegionType).HasColumnOrder(3);
                b.Property(x => x.Name).HasColumnOrder(4);
                b.Property(x => x.OfficialName).HasColumnOrder(5);
                b.Property(x => x.Iso2).HasColumnOrder(6);
                b.Property(x => x.Iso3).HasColumnOrder(7);
                b.Property(x => x.Numeric).HasColumnOrder(8);
                b.Property(x => x.Flag).HasColumnOrder(9);

                #endregion
            });
            //=============================================
            builder.Entity<MedicalIntake>(b =>
            {
                b.HasQueryFilter(x => x.IsDeleted == false);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.VisitId).HasColumnOrder(2);
                b.Property(x => x.TaskId).HasColumnOrder(3);
                b.Property(x => x.IsComplete).HasColumnOrder(4);
                b.Property(x => x.IsPeriodRemember).HasColumnOrder(5);
                b.Property(x => x.LastPeriodDate).HasColumnOrder(6);
                b.Property(x => x.HaveNormalPeriod).HasColumnOrder(7);
                b.Property(x => x.NormalPeriodNote).HasColumnOrder(8);
                b.Property(x => x.FirstMenstrualAge).HasColumnOrder(9);
                b.Property(x => x.LastSexIntercourse).HasColumnOrder(10);
                b.Property(x => x.Symptoms).HasColumnOrder(11);
                b.Property(x => x.OtherSymptoms).HasColumnOrder(12);
                b.Property(x => x.MedicalConditions).HasColumnOrder(13);
                b.Property(x => x.MedicalConditionsNote).HasColumnOrder(14);
                b.Property(x => x.DoctorCare).HasColumnOrder(15);
                b.Property(x => x.Medication).HasColumnOrder(16);
                b.Property(x => x.MedicationType).HasColumnOrder(17);
                b.Property(x => x.BlackboxMedication).HasColumnOrder(18);
                b.Property(x => x.HavePapSmear).HasColumnOrder(19);
                b.Property(x => x.LastExaminationDate).HasColumnOrder(20);
                b.Property(x => x.UseAlcohol).HasColumnOrder(21);
                b.Property(x => x.AlcoholQuitDate).HasColumnOrder(22);
                b.Property(x => x.AlcoholFrequency).HasColumnOrder(23);
                b.Property(x => x.AlcoholPriorFreq).HasColumnOrder(24);
                b.Property(x => x.AlcoholTotalYears).HasColumnOrder(25);
                b.Property(x => x.UseTobacco).HasColumnOrder(26);
                b.Property(x => x.TobaccoQuitDate).HasColumnOrder(27);
                b.Property(x => x.TobaccoFrequency).HasColumnOrder(28);
                b.Property(x => x.TobaccoPriorFreq).HasColumnOrder(29);
                b.Property(x => x.TobaccoTotalYears).HasColumnOrder(30);
                b.Property(x => x.UseDrugs).HasColumnOrder(31);
                b.Property(x => x.DrugsQuitDate).HasColumnOrder(31);
                b.Property(x => x.DrugFrequency).HasColumnOrder(32);
                b.Property(x => x.DrugsTotalYears).HasColumnOrder(33);
                b.Property(x => x.BirthsQty).HasColumnOrder(34);
                b.Property(x => x.MiscarriageQty).HasColumnOrder(35);
                b.Property(x => x.AbortionQty).HasColumnOrder(36);
                b.Property(x => x.AbortionType).HasColumnOrder(37);
                b.Property(x => x.AbortionDate).HasColumnOrder(38);
                b.Property(x => x.AbortionIssues).HasColumnOrder(39);
                b.Property(x => x.HavePlanB).HasColumnOrder(40);
                b.Property(x => x.PlanBQty).HasColumnOrder(41);
                b.Property(x => x.LastPlanBDate).HasColumnOrder(42);
                b.Property(x => x.HaveBirthControl).HasColumnOrder(43);
                b.Property(x => x.BirthControlEnd).HasColumnOrder(44);
                b.Property(x => x.BirthControlType).HasColumnOrder(45);
                b.Property(x => x.OtherBirthControlType).HasColumnOrder(46);
                b.Property(x => x.BirthControlLong).HasColumnOrder(47);
                b.Property(x => x.SexualActive).HasColumnOrder(48);
                b.Property(x => x.SexualPartners).HasColumnOrder(49);
                b.Property(x => x.HaveStdTest).HasColumnOrder(50);
                b.Property(x => x.StdTypes).HasColumnOrder(51);
                b.Property(x => x.StdTestDate).HasColumnOrder(52);
                b.Property(x => x.StdTestResult).HasColumnOrder(53);
                b.Property(x => x.HaveTreatment).HasColumnOrder(54);
                b.Property(x => x.PartnerNotified).HasColumnOrder(55);
                b.Property(x => x.AdversePrenatal).HasColumnOrder(56);
                b.Property(x => x.HaveRapeAbuse).HasColumnOrder(57);
                b.Property(x => x.RapeAbuseNotes).HasColumnOrder(58);
                b.Property(x => x.Intentions).HasColumnOrder(59);
                b.Property(x => x.AdoptionOption).HasColumnOrder(60);
                b.Property(x => x.AbortionRisk).HasColumnOrder(61);

                #endregion
            });
            builder.Entity<DemographicIntake>(b =>
            {
                b.HasQueryFilter(x => x.IsDeleted == false);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.VisitId).HasColumnOrder(2);
                b.Property(x => x.TaskId).HasColumnOrder(3);
                b.Property(x => x.IsComplete).HasColumnOrder(4);
                b.Property(x => x.RegionId).HasColumnOrder(5);
                b.Property(x => x.InSchool).HasColumnOrder(6);
                b.Property(x => x.LastGrade).HasColumnOrder(7);
                b.Property(x => x.SchoolName).HasColumnOrder(8);
                b.Property(x => x.MaritalStatus).HasColumnOrder(9);
                b.Property(x => x.IsUSCitizen).HasColumnOrder(10);
                b.Property(x => x.ImmigrationStatus).HasColumnOrder(11);
                b.Property(x => x.LivingArrangement).HasColumnOrder(12);
                b.Property(x => x.Employment).HasColumnOrder(13);
                b.Property(x => x.Employer).HasColumnOrder(14);
                b.Property(x => x.Occupation).HasColumnOrder(15);
                b.Property(x => x.Income).HasColumnOrder(16);
                b.Property(x => x.CombinedIncome).HasColumnOrder(17);
                b.Property(x => x.HaveInsurance).HasColumnOrder(18);
                b.Property(x => x.InsuranceName).HasColumnOrder(19);
                b.Property(x => x.MedicaidNo).HasColumnOrder(20);
                b.Property(x => x.NeedInsurance).HasColumnOrder(21);
                b.Property(x => x.NumberOfTaxReturn).HasColumnOrder(22);
                b.Property(x => x.NumberOfHousehold).HasColumnOrder(23);
                b.Property(x => x.Disabled).HasColumnOrder(24);
                b.Property(x => x.FinancialSupport).HasColumnOrder(25);
                b.Property(x => x.AffordPrenatal).HasColumnOrder(26);
                b.Property(x => x.UndueBurden).HasColumnOrder(27);
                b.Property(x => x.ConduciveRaising).HasColumnOrder(28);
                b.Property(x => x.HidePregnancy).HasColumnOrder(29);

                #endregion

            });
            builder.Entity<IntroMethod>(b =>
            {
                b.HasData(Seed.IntroMethods);

                b.HasQueryFilter(x => x.IsDeleted == false);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.ParentId).HasColumnOrder(2);
                b.Property(x => x.Type).HasColumnOrder(3);
                b.Property(x => x.Order).HasColumnOrder(4);
                b.Property(x => x.Name).HasColumnOrder(5);
                b.Property(x => x.DisplayTitle).HasColumnOrder(6);
                b.Property(x => x.Description).HasColumnOrder(7);
                b.Property(x => x.AdditionalInfoRequired).HasColumnOrder(8);
                b.Property(x => x.AdditionalInfoLabel).HasColumnOrder(9);
         
                #endregion
            });
            builder.Entity<Visit>(b =>
            {
                b.HasQueryFilter(x => x.IsDeleted == false);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.CaseId).HasColumnOrder(2);
                b.Property(x => x.Status).HasColumnOrder(3);
                b.Property(x => x.StartDate).HasColumnOrder(4);
                b.Property(x => x.EndDate).HasColumnOrder(5);
                b.Property(x => x.Name).HasColumnOrder(6);
                b.Property(x => x.Comment).HasColumnOrder(7);
                b.Property(x => x.Description).HasColumnOrder(8);

                #endregion
            });
            builder.Entity<Case>(b =>
            {
                b.HasQueryFilter(x => x.IsDeleted == false);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.UserId).HasColumnOrder(2);
                b.Property(x => x.CaseNo).HasColumnOrder(3);
                b.Property(x => x.Status).HasColumnOrder(4);
                b.Property(x => x.StartDate).HasColumnOrder(5);
                b.Property(x => x.EndDate).HasColumnOrder(6);
                b.Property(x => x.Description).HasColumnOrder(7);

                #endregion

            });
            builder.Entity<Tasks>(b =>
            {
                b.HasOne(e => e.Visit).WithMany(e => e.Tasks).HasForeignKey(e => e.VisitId);
                b.HasOne(e => e.Section).WithMany(e => e.VisitSections).HasForeignKey(e => e.SectionId);

                b.HasQueryFilter(x => x.IsDeleted == false);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.VisitId).HasColumnOrder(2);
                b.Property(x => x.UserId).HasColumnOrder(3);
                b.Property(x => x.SectionId).HasColumnOrder(4);
                b.Property(x => x.StartDate).HasColumnOrder(5);
                b.Property(x => x.EndDate).HasColumnOrder(6);
                b.Property(x => x.Status).HasColumnOrder(7);

                #endregion
            });
            builder.Entity<Section>(b =>
            {
                b.HasData(Seed.Sections);
                b.HasQueryFilter(x => x.IsDeleted == false);
                b.HasOne(x => x.Parent).WithMany(x => x.Sections).HasForeignKey(x => x.ParentId).IsRequired(false);

                #region Column Order

                b.Property(x => x.Id).HasColumnOrder(1);
                b.Property(x => x.ParentId).HasColumnOrder(2);
                b.Property(x => x.Name).HasColumnOrder(3);
                b.Property(x => x.DisplayTitle).HasColumnOrder(4);
                b.Property(x => x.SectionGroup).HasColumnOrder(5);
                b.Property(x => x.SectionType).HasColumnOrder(6);
                b.Property(x => x.Visibility).HasColumnOrder(7);
                b.Property(x => x.Gender).HasColumnOrder(8);
                b.Property(x => x.Order).HasColumnOrder(9);
                b.Property(x => x.IsRequired).HasColumnOrder(10);
                b.Property(x => x.Help).HasColumnOrder(11);
                b.Property(x => x.URI).HasColumnOrder(12);
                b.Property(x => x.Command).HasColumnOrder(13);
                b.Property(x => x.Image).HasColumnOrder(14);
                b.Property(x => x.RequiredPolicy).HasColumnOrder(15);

                #endregion
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(x => x.Type == AppClaimTypes.UserId)?.Value;
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

