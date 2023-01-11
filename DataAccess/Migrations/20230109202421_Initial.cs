using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WRMC.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cultures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CultureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSeparator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstDayOfWeek = table.Column<int>(type: "int", nullable: false),
                    FullDateTimePattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    LongDatePattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongTimePattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthDayPattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RightToLeft = table.Column<bool>(type: "bit", nullable: false),
                    ShortDatePattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortTimePattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeSeparator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearMonthPattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    RegionType = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iso2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iso3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numeric = table.Column<short>(type: "smallint", nullable: true),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Regions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DBProvider = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    EmailToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordResetAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumberToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Tenant_DefaultTenantId",
                        column: x => x.DefaultTenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<short>(type: "smallint", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddresses_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAddresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<short>(type: "smallint", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAttachment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<short>(type: "smallint", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPhoneNumbers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<short>(type: "smallint", nullable: true),
                    Height = table.Column<short>(type: "smallint", nullable: true),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroMethodDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroMethodId = table.Column<int>(type: "int", nullable: true),
                    IsVolunteer = table.Column<bool>(type: "bit", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaceNationality = table.Column<short>(type: "smallint", nullable: true),
                    Weight = table.Column<short>(type: "smallint", nullable: true),
                    IsNoticeAccepted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfile_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BuildVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConnectionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DarkMode = table.Column<bool>(type: "bit", nullable: false),
                    Culture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RightToLeft = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTenants_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTenants_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "IsDeleted", "IsReadOnly", "Key", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Value" },
                values: new object[] { new Guid("e2acb5e1-dc2c-41fc-9b54-c4a8e15b083e"), null, null, null, null, null, null, null, false, null, "DefaultConnectionString", null, null, null, "Server=.;Database={0};Integrated Security = True;" });

            migrationBuilder.InsertData(
                table: "Cultures",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "CultureName", "DateSeparator", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "DisplayName", "FirstDayOfWeek", "FullDateTimePattern", "Image", "IsDefault", "IsDeleted", "LongDatePattern", "LongTimePattern", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "MonthDayPattern", "RightToLeft", "ShortDatePattern", "ShortTimePattern", "TimeSeparator", "YearMonthPattern" },
                values: new object[,]
                {
                    { new Guid("7e47fe89-6571-4cbc-b5b7-16614d1dad22"), null, null, null, "en-US", "/", null, null, null, "English", 1, "dddd, MMMM dd, yyyy h:mm:ss tt", "_content/wrmc.RootComponents/assets/media/flags/usa.svg", true, false, "dddd, MMMM dd, yyyy", "HH:mm:ss", null, null, null, "MMMM dd", false, "yyyy/MM/dd", "HH:mm", ":", "MMMM, yyyy" },
                    { new Guid("bfa9f00f-05d8-45fb-86af-b6d84a70d88b"), null, null, null, "fa-IR", "/", null, null, null, "فارسی", 6, "dddd, MMMM dd, yyyy h:mm:ss tt", "_content/wrmc.RootComponents/assets/media/flags/iran.svg", false, false, "dddd, MMMM dd, yyyy ", "HH:mm:ss", null, null, null, "MMMM dd", true, "yyyy/MM/dd", "HH:mm", ":", "MMMM, yyyy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Flag", "IsDeleted", "Iso2", "Iso3", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "Numeric", "OfficialName", "ParentId", "RegionType" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, null, null, false, "af", "AFG", null, null, null, "Afghanistan", null, "the Islamic Republic of Afghanistan", null, (short)1 },
                    { 2, null, null, null, null, null, null, null, false, "al", "ALB", null, null, null, "Albania", null, "the Republic of Albania", null, (short)1 },
                    { 3, null, null, null, null, null, null, null, false, "dz", "DZA", null, null, null, "Algeria", null, "the People's Democratic Republic of Algeria", null, (short)1 },
                    { 4, null, null, null, null, null, null, null, false, "ad", "AND", null, null, null, "Andorra", null, "the Principality of Andorra", null, (short)1 },
                    { 5, null, null, null, null, null, null, null, false, "ao", "AGO", null, null, null, "Angola", null, "the Republic of Angola", null, (short)1 },
                    { 6, null, null, null, null, null, null, null, false, "ag", "ATG", null, null, null, "Antigua and Barbuda", null, "Antigua and Barbuda", null, (short)1 },
                    { 7, null, null, null, null, null, null, null, false, "ar", "ARG", null, null, null, "Argentina", null, "the Argentine Republic", null, (short)1 },
                    { 8, null, null, null, null, null, null, null, false, "am", "ARM", null, null, null, "Armenia", null, "the Republic of Armenia", null, (short)1 },
                    { 9, null, null, null, null, null, null, null, false, "au", "AUS", null, null, null, "Australia", null, "Australia", null, (short)1 },
                    { 10, null, null, null, null, null, null, null, false, "at", "AUT", null, null, null, "Austria", null, "the Republic of Austria", null, (short)1 },
                    { 11, null, null, null, null, null, null, null, false, "az", "AZE", null, null, null, "Azerbaijan", null, "the Republic of Azerbaijan", null, (short)1 },
                    { 12, null, null, null, null, null, null, null, false, "bs", "BHS", null, null, null, "Bahamas", null, "the Commonwealth of the Bahamas", null, (short)1 },
                    { 13, null, null, null, null, null, null, null, false, "bh", "BHR", null, null, null, "Bahrain", null, "the Kingdom of Bahrain", null, (short)1 },
                    { 14, null, null, null, null, null, null, null, false, "bd", "BGD", null, null, null, "Bangladesh", null, "the People's Republic of Bangladesh", null, (short)1 },
                    { 15, null, null, null, null, null, null, null, false, "bb", "BRB", null, null, null, "Barbados", null, "Barbados", null, (short)1 },
                    { 16, null, null, null, null, null, null, null, false, "by", "BLR", null, null, null, "Belarus", null, "the Republic of Belarus", null, (short)1 },
                    { 17, null, null, null, null, null, null, null, false, "be", "BEL", null, null, null, "Belgium", null, "the Kingdom of Belgium", null, (short)1 },
                    { 18, null, null, null, null, null, null, null, false, "bz", "BLZ", null, null, null, "Belize", null, "Belize", null, (short)1 },
                    { 19, null, null, null, null, null, null, null, false, "bj", "BEN", null, null, null, "Benin", null, "the Republic of Benin", null, (short)1 },
                    { 20, null, null, null, null, null, null, null, false, "bt", "BTN", null, null, null, "Bhutan", null, "the Kingdom of Bhutan", null, (short)1 },
                    { 21, null, null, null, null, null, null, null, false, "bo", "BOL", null, null, null, "Bolivia (Plurinational State of)", null, "the Plurinational State of Bolivia", null, (short)1 },
                    { 22, null, null, null, null, null, null, null, false, "ba", "BIH", null, null, null, "Bosnia and Herzegovina", null, "Bosnia and Herzegovina", null, (short)1 },
                    { 23, null, null, null, null, null, null, null, false, "bw", "BWA", null, null, null, "Botswana", null, "the Republic of Botswana", null, (short)1 },
                    { 24, null, null, null, null, null, null, null, false, "br", "BRA", null, null, null, "Brazil", null, "the Federative Republic of Brazil", null, (short)1 },
                    { 25, null, null, null, null, null, null, null, false, "bn", "BRN", null, null, null, "Brunei Darussalam", null, "Brunei Darussalam", null, (short)1 },
                    { 26, null, null, null, null, null, null, null, false, "bg", "BGR", null, null, null, "Bulgaria", null, "the Republic of Bulgaria", null, (short)1 },
                    { 27, null, null, null, null, null, null, null, false, "bf", "BFA", null, null, null, "Burkina Faso", null, "Burkina Faso", null, (short)1 },
                    { 28, null, null, null, null, null, null, null, false, "bi", "BDI", null, null, null, "Burundi", null, "the Republic of Burundi", null, (short)1 },
                    { 29, null, null, null, null, null, null, null, false, "cv", "CPV", null, null, null, "Cabo Verde", null, "Republic of Cabo Verde", null, (short)1 },
                    { 30, null, null, null, null, null, null, null, false, "kh", "KHM", null, null, null, "Cambodia", null, "the Kingdom of Cambodia", null, (short)1 },
                    { 31, null, null, null, null, null, null, null, false, "cm", "CMR", null, null, null, "Cameroon", null, "the Republic of Cameroon", null, (short)1 },
                    { 32, null, null, null, null, null, null, null, false, "ca", "CAN", null, null, null, "Canada", null, "Canada", null, (short)1 },
                    { 33, null, null, null, null, null, null, null, false, "cf", "CAF", null, null, null, "Central African Republic", null, "the Central African Republic", null, (short)1 },
                    { 34, null, null, null, null, null, null, null, false, "td", "TCD", null, null, null, "Chad", null, "the Republic of Chad", null, (short)1 },
                    { 35, null, null, null, null, null, null, null, false, "cl", "CHL", null, null, null, "Chile", null, "the Republic of Chile", null, (short)1 },
                    { 36, null, null, null, null, null, null, null, false, "cn", "CHN", null, null, null, "China", null, "the People's Republic of China", null, (short)1 },
                    { 37, null, null, null, null, null, null, null, false, "co", "COL", null, null, null, "Colombia", null, "the Republic of Colombia", null, (short)1 },
                    { 38, null, null, null, null, null, null, null, false, "km", "COM", null, null, null, "Comoros", null, "the Union of the Comoros", null, (short)1 },
                    { 39, null, null, null, null, null, null, null, false, "cg", "COG", null, null, null, "Congo", null, "the Republic of the Congo", null, (short)1 },
                    { 40, null, null, null, null, null, null, null, false, "ck", "COK", null, null, null, "Cook Islands", null, "the Cook Islands", null, (short)1 },
                    { 41, null, null, null, null, null, null, null, false, "cr", "CRI", null, null, null, "Costa Rica", null, "the Republic of Costa Rica", null, (short)1 },
                    { 42, null, null, null, null, null, null, null, false, "hr", "HRV", null, null, null, "Croatia", null, "the Republic of Croatia", null, (short)1 },
                    { 43, null, null, null, null, null, null, null, false, "cu", "CUB", null, null, null, "Cuba", null, "the Republic of Cuba", null, (short)1 },
                    { 44, null, null, null, null, null, null, null, false, "cy", "CYP", null, null, null, "Cyprus", null, "the Republic of Cyprus", null, (short)1 },
                    { 45, null, null, null, null, null, null, null, false, "cz", "CZE", null, null, null, "Czechia", null, "the Czech Republic", null, (short)1 },
                    { 46, null, null, null, null, null, null, null, false, "ci", "CIV", null, null, null, "CÃ´te d'Ivoire", null, "the Republic of CÃ´te d'Ivoire", null, (short)1 },
                    { 47, null, null, null, null, null, null, null, false, "kp", "PRK", null, null, null, "Democratic People's Republic of Korea", null, "the Democratic People's Republic of Korea", null, (short)1 },
                    { 48, null, null, null, null, null, null, null, false, "cd", "COD", null, null, null, "Democratic Republic of the Congo", null, "the Democratic Republic of the Congo", null, (short)1 },
                    { 49, null, null, null, null, null, null, null, false, "dk", "DNK", null, null, null, "Denmark", null, "the Kingdom of Denmark", null, (short)1 },
                    { 50, null, null, null, null, null, null, null, false, "dj", "DJI", null, null, null, "Djibouti", null, "the Republic of Djibouti", null, (short)1 },
                    { 51, null, null, null, null, null, null, null, false, "dm", "DMA", null, null, null, "Dominica", null, "the Commonwealth of Dominica", null, (short)1 },
                    { 52, null, null, null, null, null, null, null, false, "do", "DOM", null, null, null, "Dominican Republic", null, "the Dominican Republic", null, (short)1 },
                    { 53, null, null, null, null, null, null, null, false, "ec", "ECU", null, null, null, "Ecuador", null, "the Republic of Ecuador", null, (short)1 },
                    { 54, null, null, null, null, null, null, null, false, "eg", "EGY", null, null, null, "Egypt", null, "the Arab Republic of Egypt", null, (short)1 },
                    { 55, null, null, null, null, null, null, null, false, "sv", "SLV", null, null, null, "El Salvador", null, "the Republic of El Salvador", null, (short)1 },
                    { 56, null, null, null, null, null, null, null, false, "gq", "GNQ", null, null, null, "Equatorial Guinea", null, "the Republic of Equatorial Guinea", null, (short)1 },
                    { 57, null, null, null, null, null, null, null, false, "er", "ERI", null, null, null, "Eritrea", null, "the State of Eritrea", null, (short)1 },
                    { 58, null, null, null, null, null, null, null, false, "ce", "EST", null, null, null, "Estonia", null, "the Republic of Estonia", null, (short)1 },
                    { 59, null, null, null, null, null, null, null, false, "sz", "SWZ", null, null, null, "Eswatini", null, "the Kingdom of Eswatini", null, (short)1 },
                    { 60, null, null, null, null, null, null, null, false, "et", "ETH", null, null, null, "Ethiopia", null, "the Federal Democratic Republic of Ethiopia", null, (short)1 },
                    { 61, null, null, null, null, null, null, null, false, "fo", "FRO", null, null, null, "Faroe Islands", null, "Faroe Islands", null, (short)1 },
                    { 62, null, null, null, null, null, null, null, false, "fj", "FJI", null, null, null, "Fiji", null, "the Republic of Fiji", null, (short)1 },
                    { 63, null, null, null, null, null, null, null, false, "fi", "FIN", null, null, null, "Finland", null, "the Republic of Finland", null, (short)1 },
                    { 64, null, null, null, null, null, null, null, false, "fr", "FRA", null, null, null, "France", null, "the French Republic", null, (short)1 },
                    { 65, null, null, null, null, null, null, null, false, "ga", "GAB", null, null, null, "Gabon", null, "the Gabonese Republic", null, (short)1 },
                    { 66, null, null, null, null, null, null, null, false, "gm", "GMB", null, null, null, "Gambia", null, "the Republic of the Gambia", null, (short)1 },
                    { 67, null, null, null, null, null, null, null, false, "ge", "GEO", null, null, null, "Georgia", null, "Georgia", null, (short)1 },
                    { 68, null, null, null, null, null, null, null, false, "de", "DEU", null, null, null, "Germany", null, "the Federal Republic of Germany", null, (short)1 },
                    { 69, null, null, null, null, null, null, null, false, "gh", "GHA", null, null, null, "Ghana", null, "the Republic of Ghana", null, (short)1 },
                    { 70, null, null, null, null, null, null, null, false, "gr", "GRC", null, null, null, "Greece", null, "the Hellenic Republic", null, (short)1 },
                    { 71, null, null, null, null, null, null, null, false, "gd", "GRD", null, null, null, "Grenada", null, "Grenada", null, (short)1 },
                    { 72, null, null, null, null, null, null, null, false, "gt", "GTM", null, null, null, "Guatemala", null, "the Republic of Guatemala", null, (short)1 },
                    { 73, null, null, null, null, null, null, null, false, "gn", "GIN", null, null, null, "Guinea", null, "the Republic of Guinea", null, (short)1 },
                    { 74, null, null, null, null, null, null, null, false, "gw", "GNB", null, null, null, "Guinea-Bissau", null, "the Republic of Guinea-Bissau", null, (short)1 },
                    { 75, null, null, null, null, null, null, null, false, "gy", "GUY", null, null, null, "Guyana", null, "the Co-operative Republic of Guyana", null, (short)1 },
                    { 76, null, null, null, null, null, null, null, false, "ht", "HTI", null, null, null, "Haiti", null, "the Republic of Haiti", null, (short)1 },
                    { 77, null, null, null, null, null, null, null, false, "hn", "HND", null, null, null, "Honduras", null, "the Republic of Honduras", null, (short)1 },
                    { 78, null, null, null, null, null, null, null, false, "hu", "HUN", null, null, null, "Hungary", null, "Hungary", null, (short)1 },
                    { 79, null, null, null, null, null, null, null, false, "is", "ISL", null, null, null, "Iceland", null, "the Republic of Iceland", null, (short)1 },
                    { 80, null, null, null, null, null, null, null, false, "in", "IND", null, null, null, "India", null, "the Republic of India", null, (short)1 },
                    { 81, null, null, null, null, null, null, null, false, "id", "IDN", null, null, null, "Indonesia", null, "the Republic of Indonesia", null, (short)1 },
                    { 82, null, null, null, null, null, null, null, false, "ir", "IRN", null, null, null, "Iran (Islamic Republic of)", null, "the Islamic Republic of Iran", null, (short)1 },
                    { 83, null, null, null, null, null, null, null, false, "iq", "IRQ", null, null, null, "Iraq", null, "the Republic of Iraq", null, (short)1 },
                    { 84, null, null, null, null, null, null, null, false, "ie", "IRL", null, null, null, "Ireland", null, "Ireland", null, (short)1 },
                    { 85, null, null, null, null, null, null, null, false, "il", "ISR", null, null, null, "Israel", null, "the State of Israel", null, (short)1 },
                    { 86, null, null, null, null, null, null, null, false, "it", "ITA", null, null, null, "Italy", null, "the Republic of Italy", null, (short)1 },
                    { 87, null, null, null, null, null, null, null, false, "jm", "JAM", null, null, null, "Jamaica", null, "Jamaica", null, (short)1 },
                    { 88, null, null, null, null, null, null, null, false, "jp", "JPN", null, null, null, "Japan", null, "Japan", null, (short)1 },
                    { 89, null, null, null, null, null, null, null, false, "jo", "JOR", null, null, null, "Jordan", null, "the Hashemite Kingdom of Jordan", null, (short)1 },
                    { 90, null, null, null, null, null, null, null, false, "kz", "KAZ", null, null, null, "Kazakhstan", null, "the Republic of Kazakhstan", null, (short)1 },
                    { 91, null, null, null, null, null, null, null, false, "kn", "KEN", null, null, null, "Kenya", null, "the Republic of Kenya", null, (short)1 },
                    { 92, null, null, null, null, null, null, null, false, "ki", "KIR", null, null, null, "Kiribati", null, "the Republic of Kiribati", null, (short)1 },
                    { 93, null, null, null, null, null, null, null, false, "kw", "KWT", null, null, null, "Kuwait", null, "the State of Kuwait", null, (short)1 },
                    { 94, null, null, null, null, null, null, null, false, "kg", "KGZ", null, null, null, "Kyrgyzstan", null, "the Kyrgyz Republic", null, (short)1 },
                    { 95, null, null, null, null, null, null, null, false, "la", "LAO", null, null, null, "Lao People's Democratic Republic", null, "the Lao People's Democratic Republic", null, (short)1 },
                    { 96, null, null, null, null, null, null, null, false, "lv", "LVA", null, null, null, "Latvia", null, "the Republic of Latvia", null, (short)1 },
                    { 97, null, null, null, null, null, null, null, false, "lb", "LBN", null, null, null, "Lebanon", null, "the Lebanese Republic", null, (short)1 },
                    { 98, null, null, null, null, null, null, null, false, "ls", "LSO", null, null, null, "Lesotho", null, "the Kingdom of Lesotho", null, (short)1 },
                    { 99, null, null, null, null, null, null, null, false, "lr", "LBR", null, null, null, "Liberia", null, "the Republic of Liberia", null, (short)1 },
                    { 100, null, null, null, null, null, null, null, false, "ly", "LBY", null, null, null, "Libya", null, "State of Libya", null, (short)1 },
                    { 101, null, null, null, null, null, null, null, false, "lt", "LTU", null, null, null, "Lithuania", null, "the Republic of Lithuania", null, (short)1 },
                    { 102, null, null, null, null, null, null, null, false, "lu", "LUX", null, null, null, "Luxembourg", null, "the Grand Duchy of Luxembourg", null, (short)1 },
                    { 103, null, null, null, null, null, null, null, false, "mg", "MDG", null, null, null, "Madagascar", null, "the Republic of Madagascar", null, (short)1 },
                    { 104, null, null, null, null, null, null, null, false, "mw", "MWI", null, null, null, "Malawi", null, "the Republic of Malawi", null, (short)1 },
                    { 105, null, null, null, null, null, null, null, false, "my", "MYS", null, null, null, "Malaysia", null, "Malaysia", null, (short)1 },
                    { 106, null, null, null, null, null, null, null, false, "mv", "MDV", null, null, null, "Maldives", null, "the Republic of Maldives", null, (short)1 },
                    { 107, null, null, null, null, null, null, null, false, "ml", "MLI", null, null, null, "Mali", null, "the Republic of Mali", null, (short)1 },
                    { 108, null, null, null, null, null, null, null, false, "mt", "MLT", null, null, null, "Malta", null, "the Republic of Malta", null, (short)1 },
                    { 109, null, null, null, null, null, null, null, false, "mh", "MHL", null, null, null, "Marshall Islands", null, "the Republic of the Marshall Islands", null, (short)1 },
                    { 110, null, null, null, null, null, null, null, false, "mr", "MRT", null, null, null, "Mauritania", null, "the Islamic Republic of Mauritania", null, (short)1 },
                    { 111, null, null, null, null, null, null, null, false, "mu", "MUS", null, null, null, "Mauritius", null, "the Republic of Mauritius", null, (short)1 },
                    { 112, null, null, null, null, null, null, null, false, "mx", "MEX", null, null, null, "Mexico", null, "the United Mexican States", null, (short)1 },
                    { 113, null, null, null, null, null, null, null, false, "fm", "FSM", null, null, null, "Micronesia (Federated States of)", null, "the Federated States of Micronesia", null, (short)1 },
                    { 114, null, null, null, null, null, null, null, false, "mc", "MCO", null, null, null, "Monaco", null, "the Principality of Monaco", null, (short)1 },
                    { 115, null, null, null, null, null, null, null, false, "mn", "MNG", null, null, null, "Mongolia", null, "Mongolia", null, (short)1 },
                    { 116, null, null, null, null, null, null, null, false, "me", "MNE", null, null, null, "Montenegro", null, "Montenegro", null, (short)1 },
                    { 117, null, null, null, null, null, null, null, false, "ma", "MAR", null, null, null, "Morocco", null, "the Kingdom of Morocco", null, (short)1 },
                    { 118, null, null, null, null, null, null, null, false, "mz", "MOZ", null, null, null, "Mozambique", null, "the Republic of Mozambique", null, (short)1 },
                    { 119, null, null, null, null, null, null, null, false, "mm", "MMR", null, null, null, "Myanmar", null, "the Republic of the Union of Myanmar", null, (short)1 },
                    { 120, null, null, null, null, null, null, null, false, "na", "NAM", null, null, null, "Namibia", null, "the Republic of Namibia", null, (short)1 },
                    { 121, null, null, null, null, null, null, null, false, "nr", "NRU", null, null, null, "Nauru", null, "the Republic of Nauru", null, (short)1 },
                    { 122, null, null, null, null, null, null, null, false, "np", "NPL", null, null, null, "Nepal", null, "the Federal Democratic Republic of Nepal", null, (short)1 },
                    { 123, null, null, null, null, null, null, null, false, "nl", "NLD", null, null, null, "Netherlands", null, "the Kingdom of the Netherlands", null, (short)1 },
                    { 124, null, null, null, null, null, null, null, false, "nz", "NZL", null, null, null, "New Zealand", null, "New Zealand", null, (short)1 },
                    { 125, null, null, null, null, null, null, null, false, "ni", "NIC", null, null, null, "Nicaragua", null, "the Republic of Nicaragua", null, (short)1 },
                    { 126, null, null, null, null, null, null, null, false, "ne", "NER", null, null, null, "Niger", null, "the Republic of the Niger", null, (short)1 },
                    { 127, null, null, null, null, null, null, null, false, "ng", "NGA", null, null, null, "Nigeria", null, "the Federal Republic of Nigeria", null, (short)1 },
                    { 128, null, null, null, null, null, null, null, false, "nu", "NIU", null, null, null, "Niue", null, "Niue", null, (short)1 },
                    { 129, null, null, null, null, null, null, null, false, "mk", "MKD", null, null, null, "North Macedonia", null, "the Republic of North Macedonia", null, (short)1 },
                    { 130, null, null, null, null, null, null, null, false, "no", "NOR", null, null, null, "Norway", null, "the Kingdom of Norway", null, (short)1 },
                    { 131, null, null, null, null, null, null, null, false, "om", "OMN", null, null, null, "Oman", null, "the Sultanate of Oman", null, (short)1 },
                    { 132, null, null, null, null, null, null, null, false, "pk", "PAK", null, null, null, "Pakistan", null, "the Islamic Republic of Pakistan", null, (short)1 },
                    { 133, null, null, null, null, null, null, null, false, "pw", "PLW", null, null, null, "Palau", null, "the Republic of Palau", null, (short)1 },
                    { 134, null, null, null, null, null, null, null, false, "pa", "PAN", null, null, null, "Panama", null, "the Republic of Panama", null, (short)1 },
                    { 135, null, null, null, null, null, null, null, false, "pg", "PNG", null, null, null, "Papua New Guinea", null, "Independent State of Papua New Guinea", null, (short)1 },
                    { 136, null, null, null, null, null, null, null, false, "py", "PRY", null, null, null, "Paraguay", null, "the Republic of Paraguay", null, (short)1 },
                    { 137, null, null, null, null, null, null, null, false, "pe", "PER", null, null, null, "Peru", null, "the Republic of Peru", null, (short)1 },
                    { 138, null, null, null, null, null, null, null, false, "ph", "PHL", null, null, null, "Philippines", null, "the Republic of the Philippines", null, (short)1 },
                    { 139, null, null, null, null, null, null, null, false, "pl", "POL", null, null, null, "Poland", null, "the Republic of Poland", null, (short)1 },
                    { 140, null, null, null, null, null, null, null, false, "pt", "PRT", null, null, null, "Portugal", null, "the Portuguese Republic", null, (short)1 },
                    { 141, null, null, null, null, null, null, null, false, "qa", "QAT", null, null, null, "Qatar", null, "the State of Qatar", null, (short)1 },
                    { 142, null, null, null, null, null, null, null, false, "kr", "KOR", null, null, null, "Republic of Korea", null, "the Republic of Korea", null, (short)1 },
                    { 143, null, null, null, null, null, null, null, false, "md", "MDA", null, null, null, "Republic of Moldova", null, "the Republic of Moldova", null, (short)1 },
                    { 144, null, null, null, null, null, null, null, false, "ro", "ROU", null, null, null, "Romania", null, "Romania", null, (short)1 },
                    { 145, null, null, null, null, null, null, null, false, "ru", "RUS", null, null, null, "Russian Federation", null, "the Russian Federation", null, (short)1 },
                    { 146, null, null, null, null, null, null, null, false, "rw", "RWA", null, null, null, "Rwanda", null, "the Republic of Rwanda", null, (short)1 },
                    { 147, null, null, null, null, null, null, null, false, "kn", "KNA", null, null, null, "Saint Kitts and Nevis", null, "Saint Kitts and Nevis", null, (short)1 },
                    { 148, null, null, null, null, null, null, null, false, "lc", "LCA", null, null, null, "Saint Lucia", null, "Saint Lucia", null, (short)1 },
                    { 149, null, null, null, null, null, null, null, false, "vc", "VCT", null, null, null, "Saint Vincent and the Grenadines", null, "Saint Vincent and the Grenadines", null, (short)1 },
                    { 150, null, null, null, null, null, null, null, false, "ws", "WSM", null, null, null, "Samoa", null, "the Independent State of Samoa", null, (short)1 },
                    { 151, null, null, null, null, null, null, null, false, "sm", "SMR", null, null, null, "San Marino", null, "the Republic of San Marino", null, (short)1 },
                    { 152, null, null, null, null, null, null, null, false, "st", "STP", null, null, null, "Sao Tome and Principe", null, "the Democratic Republic of Sao Tome and Principe", null, (short)1 },
                    { 153, null, null, null, null, null, null, null, false, "sa", "SAU", null, null, null, "Saudi Arabia", null, "the Kingdom of Saudi Arabia", null, (short)1 },
                    { 154, null, null, null, null, null, null, null, false, "sn", "SEN", null, null, null, "Senegal", null, "the Republic of Senegal", null, (short)1 },
                    { 155, null, null, null, null, null, null, null, false, "rs", "SRB", null, null, null, "Serbia", null, "the Republic of Serbia", null, (short)1 },
                    { 156, null, null, null, null, null, null, null, false, "sc", "SYC", null, null, null, "Seychelles", null, "the Republic of Seychelles", null, (short)1 },
                    { 157, null, null, null, null, null, null, null, false, "sl", "SLE", null, null, null, "Sierra Leone", null, "the Republic of Sierra Leone", null, (short)1 },
                    { 158, null, null, null, null, null, null, null, false, "sg", "SGP", null, null, null, "Singapore", null, "the Republic of Singapore", null, (short)1 },
                    { 159, null, null, null, null, null, null, null, false, "sk", "SVK", null, null, null, "Slovakia", null, "the Slovak Republic", null, (short)1 },
                    { 160, null, null, null, null, null, null, null, false, "si", "SVN", null, null, null, "Slovenia", null, "the Republic of Slovenia", null, (short)1 },
                    { 161, null, null, null, null, null, null, null, false, "sb", "SLB", null, null, null, "Solomon Islands", null, "Solomon Islands", null, (short)1 },
                    { 162, null, null, null, null, null, null, null, false, "so", "SOM", null, null, null, "Somalia", null, "the Federal Republic of Somalia", null, (short)1 },
                    { 163, null, null, null, null, null, null, null, false, "za", "ZAF", null, null, null, "South Africa", null, "the Republic of South Africa", null, (short)1 },
                    { 164, null, null, null, null, null, null, null, false, "ss", "SSD", null, null, null, "South Sudan", null, "the Republic of South Sudan", null, (short)1 },
                    { 165, null, null, null, null, null, null, null, false, "es", "ESP", null, null, null, "Spain", null, "the Kingdom of Spain", null, (short)1 },
                    { 166, null, null, null, null, null, null, null, false, "lk", "LKA", null, null, null, "Sri Lanka", null, "the Democratic Socialist Republic of Sri Lanka", null, (short)1 },
                    { 167, null, null, null, null, null, null, null, false, "sd", "SDN", null, null, null, "Sudan", null, "the Republic of the Sudan", null, (short)1 },
                    { 168, null, null, null, null, null, null, null, false, "sr", "SUR", null, null, null, "Suriname", null, "the Republic of Suriname", null, (short)1 },
                    { 169, null, null, null, null, null, null, null, false, "se", "SWE", null, null, null, "Sweden", null, "the Kingdom of Sweden", null, (short)1 },
                    { 170, null, null, null, null, null, null, null, false, "ch", "CHE", null, null, null, "Switzerland", null, "the Swiss Confederation", null, (short)1 },
                    { 171, null, null, null, null, null, null, null, false, "sy", "SYR", null, null, null, "Syrian Arab Republic", null, "the Syrian Arab Republic", null, (short)1 },
                    { 172, null, null, null, null, null, null, null, false, "tj", "TJK", null, null, null, "Tajikistan", null, "the Republic of Tajikistan", null, (short)1 },
                    { 173, null, null, null, null, null, null, null, false, "th", "THA", null, null, null, "Thailand", null, "the Kingdom of Thailand", null, (short)1 },
                    { 174, null, null, null, null, null, null, null, false, "tl", "TLS", null, null, null, "Timor-Leste", null, "the Democratic Republic of Timor-Leste", null, (short)1 },
                    { 175, null, null, null, null, null, null, null, false, "tg", "TGO", null, null, null, "Togo", null, "the Togolese Republic", null, (short)1 },
                    { 176, null, null, null, null, null, null, null, false, "tk", "TKL", null, null, null, "Tokelau", null, "Tokelau", null, (short)1 },
                    { 177, null, null, null, null, null, null, null, false, "to", "TON", null, null, null, "Tonga", null, "the Kingdom of Tonga", null, (short)1 },
                    { 178, null, null, null, null, null, null, null, false, "tt", "TTO", null, null, null, "Trinidad and Tobago", null, "the Republic of Trinidad and Tobago", null, (short)1 },
                    { 179, null, null, null, null, null, null, null, false, "tn", "TUN", null, null, null, "Tunisia", null, "the Republic of Tunisia", null, (short)1 },
                    { 180, null, null, null, null, null, null, null, false, "tr", "TUR", null, null, null, "Turkey", null, "the Republic of Turkey", null, (short)1 },
                    { 181, null, null, null, null, null, null, null, false, "tm", "TKM", null, null, null, "Turkmenistan", null, "Turkmenistan", null, (short)1 },
                    { 182, null, null, null, null, null, null, null, false, "tv", "TUV", null, null, null, "Tuvalu", null, "Tuvalu", null, (short)1 },
                    { 183, null, null, null, null, null, null, null, false, "ug", "UGA", null, null, null, "Uganda", null, "the Republic of Uganda", null, (short)1 },
                    { 184, null, null, null, null, null, null, null, false, "ua", "UKR", null, null, null, "Ukraine", null, "Ukraine", null, (short)1 },
                    { 185, null, null, null, null, null, null, null, false, "ae", "ARE", null, null, null, "United Arab Emirates", null, "the United Arab Emirates", null, (short)1 },
                    { 186, null, null, null, null, null, null, null, false, "gb", "GBR", null, null, null, "United Kingdom of Great Britain and Northern Ireland", null, "the United Kingdom of Great Britain and Northern Ireland", null, (short)1 },
                    { 187, null, null, null, null, null, null, null, false, "tz", "TZA", null, null, null, "United Republic of Tanzania", null, "the United Republic of Tanzania", null, (short)1 },
                    { 188, null, null, null, null, null, null, null, false, "us", "USA", null, null, null, "United States of America", null, "the United States of America", null, (short)1 },
                    { 189, null, null, null, null, null, null, null, false, "uy", "URY", null, null, null, "Uruguay", null, "the Eastern Republic of Uruguay", null, (short)1 },
                    { 190, null, null, null, null, null, null, null, false, "uz", "UZB", null, null, null, "Uzbekistan", null, "the Republic of Uzbekistan", null, (short)1 },
                    { 191, null, null, null, null, null, null, null, false, "vu", "VUT", null, null, null, "Vanuatu", null, "the Republic of Vanuatu", null, (short)1 },
                    { 192, null, null, null, null, null, null, null, false, "ve", "VEN", null, null, null, "Venezuela (Bolivarian Republic of)", null, "the Bolivarian Republic of Venezuela", null, (short)1 },
                    { 193, null, null, null, null, null, null, null, false, "vn", "VNM", null, null, null, "Viet Nam", null, "the Socialist Republic of Viet Nam", null, (short)1 },
                    { 194, null, null, null, null, null, null, null, false, "ye", "YEM", null, null, null, "Yemen", null, "the Republic of Yemen", null, (short)1 },
                    { 195, null, null, null, null, null, null, null, false, "zm", "ZMB", null, null, null, "Zambia", null, "the Republic of Zambia", null, (short)1 },
                    { 196, null, null, null, null, null, null, null, false, "zw", "ZWE", null, null, null, "Zimbabwe", null, "the Republic of Zimbabwe", null, (short)1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("7d124c01-cf5e-44e5-9275-9c6ab72fc26e"), null, new DateTime(2023, 1, 9, 20, 24, 19, 631, DateTimeKind.Utc).AddTicks(4198), null, null, null, null, null, false, null, null, null, "client", "CLIENT" },
                    { new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4"), null, new DateTime(2023, 1, 9, 20, 24, 19, 622, DateTimeKind.Utc).AddTicks(6055), null, null, null, null, null, false, null, null, null, "administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DefaultTenantId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Email", "EmailConfirmed", "EmailToken", "EmailTokenExpires", "IsActive", "IsDeleted", "IsOnline", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordResetAt", "PasswordToken", "PasswordTokenExpires", "PhoneNumber", "PhoneNumberConfirmed", "PhoneNumberToken", "PhoneNumberTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("817b6b01-25ab-4cf4-8b7e-157a8f996c48"), 0, "8e1f75d4-fdb0-4e37-aa25-b9760d8313b1", new DateTime(2023, 1, 9, 20, 24, 20, 487, DateTimeKind.Utc).AddTicks(9460), null, null, null, null, null, null, "admin@wrmc.com", true, null, null, true, false, true, false, null, null, null, null, "ADMIN@WRMC.COM", "ADMIN", "AQAAAAIAAYagAAAAEFCf1lLNpcfy0ElsEOEn3JFaKHfCLtcOfOc1hmlZ9nUk6PBJKlsFeIHxMSbr39CJvA==", null, null, null, null, false, null, null, "7e9a15ed-fe94-4200-9e24-b13e6380c2b5", false, "admin" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Flag", "IsDeleted", "Iso2", "Iso3", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "Numeric", "OfficialName", "ParentId", "RegionType" },
                values: new object[,]
                {
                    { 197, null, null, null, null, null, null, null, false, null, "PR", null, null, null, "Puerto Rico", null, null, 188, (short)2 },
                    { 198, null, null, null, null, null, null, null, false, null, "MA", null, null, null, "Massachusetts", null, null, 188, (short)2 },
                    { 199, null, null, null, null, null, null, null, false, null, "RI", null, null, null, "Rhode Island", null, null, 188, (short)2 },
                    { 200, null, null, null, null, null, null, null, false, null, "NH", null, null, null, "New Hampshire", null, null, 188, (short)2 },
                    { 201, null, null, null, null, null, null, null, false, null, "ME", null, null, null, "Maine", null, null, 188, (short)2 },
                    { 202, null, null, null, null, null, null, null, false, null, "VT", null, null, null, "Vermont", null, null, 188, (short)2 },
                    { 203, null, null, null, null, null, null, null, false, null, "CT", null, null, null, "Connecticut", null, null, 188, (short)2 },
                    { 204, null, null, null, null, null, null, null, false, null, "NY", null, null, null, "New York", null, null, 188, (short)2 },
                    { 205, null, null, null, null, null, null, null, false, null, "NJ", null, null, null, "New Jersey", null, null, 188, (short)2 },
                    { 206, null, null, null, null, null, null, null, false, null, "PA", null, null, null, "Pennsylvania", null, null, 188, (short)2 },
                    { 207, null, null, null, null, null, null, null, false, null, "DE", null, null, null, "Delaware", null, null, 188, (short)2 },
                    { 208, null, null, null, null, null, null, null, false, null, "DC", null, null, null, "District of Columbia", null, null, 188, (short)2 },
                    { 209, null, null, null, null, null, null, null, false, null, "VA", null, null, null, "Virginia", null, null, 188, (short)2 },
                    { 210, null, null, null, null, null, null, null, false, null, "MD", null, null, null, "Maryland", null, null, 188, (short)2 },
                    { 211, null, null, null, null, null, null, null, false, null, "WV", null, null, null, "West Virginia", null, null, 188, (short)2 },
                    { 212, null, null, null, null, null, null, null, false, null, "NC", null, null, null, "North Carolina", null, null, 188, (short)2 },
                    { 213, null, null, null, null, null, null, null, false, null, "SC", null, null, null, "South Carolina", null, null, 188, (short)2 },
                    { 214, null, null, null, null, null, null, null, false, null, "GA", null, null, null, "Georgia", null, null, 188, (short)2 },
                    { 215, null, null, null, null, null, null, null, false, null, "FL", null, null, null, "Florida", null, null, 188, (short)2 },
                    { 216, null, null, null, null, null, null, null, false, null, "AL", null, null, null, "Alabama", null, null, 188, (short)2 },
                    { 217, null, null, null, null, null, null, null, false, null, "TN", null, null, null, "Tennessee", null, null, 188, (short)2 },
                    { 218, null, null, null, null, null, null, null, false, null, "MS", null, null, null, "Mississippi", null, null, 188, (short)2 },
                    { 219, null, null, null, null, null, null, null, false, null, "KY", null, null, null, "Kentucky", null, null, 188, (short)2 },
                    { 220, null, null, null, null, null, null, null, false, null, "OH", null, null, null, "Ohio", null, null, 188, (short)2 },
                    { 221, null, null, null, null, null, null, null, false, null, "IN", null, null, null, "Indiana", null, null, 188, (short)2 },
                    { 222, null, null, null, null, null, null, null, false, null, "MI", null, null, null, "Michigan", null, null, 188, (short)2 },
                    { 223, null, null, null, null, null, null, null, false, null, "IA", null, null, null, "Iowa", null, null, 188, (short)2 },
                    { 224, null, null, null, null, null, null, null, false, null, "WI", null, null, null, "Wisconsin", null, null, 188, (short)2 },
                    { 225, null, null, null, null, null, null, null, false, null, "MN", null, null, null, "Minnesota", null, null, 188, (short)2 },
                    { 226, null, null, null, null, null, null, null, false, null, "SD", null, null, null, "South Dakota", null, null, 188, (short)2 },
                    { 227, null, null, null, null, null, null, null, false, null, "ND", null, null, null, "North Dakota", null, null, 188, (short)2 },
                    { 228, null, null, null, null, null, null, null, false, null, "MT", null, null, null, "Montana", null, null, 188, (short)2 },
                    { 229, null, null, null, null, null, null, null, false, null, "IL", null, null, null, "Illinois", null, null, 188, (short)2 },
                    { 230, null, null, null, null, null, null, null, false, null, "MO", null, null, null, "Missouri", null, null, 188, (short)2 },
                    { 231, null, null, null, null, null, null, null, false, null, "KS", null, null, null, "Kansas", null, null, 188, (short)2 },
                    { 232, null, null, null, null, null, null, null, false, null, "NE", null, null, null, "Nebraska", null, null, 188, (short)2 },
                    { 233, null, null, null, null, null, null, null, false, null, "LA", null, null, null, "Louisiana", null, null, 188, (short)2 },
                    { 234, null, null, null, null, null, null, null, false, null, "AR", null, null, null, "Arkansas", null, null, 188, (short)2 },
                    { 235, null, null, null, null, null, null, null, false, null, "OK", null, null, null, "Oklahoma", null, null, 188, (short)2 },
                    { 236, null, null, null, null, null, null, null, false, null, "TX", null, null, null, "Texas", null, null, 188, (short)2 },
                    { 237, null, null, null, null, null, null, null, false, null, "CO", null, null, null, "Colorado", null, null, 188, (short)2 },
                    { 238, null, null, null, null, null, null, null, false, null, "WY", null, null, null, "Wyoming", null, null, 188, (short)2 },
                    { 239, null, null, null, null, null, null, null, false, null, "ID", null, null, null, "Idaho", null, null, 188, (short)2 },
                    { 240, null, null, null, null, null, null, null, false, null, "UT", null, null, null, "Utah", null, null, 188, (short)2 },
                    { 241, null, null, null, null, null, null, null, false, null, "AZ", null, null, null, "Arizona", null, null, 188, (short)2 },
                    { 242, null, null, null, null, null, null, null, false, null, "NM", null, null, null, "New Mexico", null, null, 188, (short)2 },
                    { 243, null, null, null, null, null, null, null, false, null, "NV", null, null, null, "Nevada", null, null, 188, (short)2 },
                    { 244, null, null, null, null, null, null, null, false, null, "CA", null, null, null, "California", null, null, 188, (short)2 },
                    { 245, null, null, null, null, null, null, null, false, null, "HI", null, null, null, "Hawaii", null, null, 188, (short)2 },
                    { 246, null, null, null, null, null, null, null, false, null, "OR", null, null, null, "Oregon", null, null, 188, (short)2 },
                    { 247, null, null, null, null, null, null, null, false, null, "WA", null, null, null, "Washington", null, null, 188, (short)2 },
                    { 248, null, null, null, null, null, null, null, false, null, "AK", null, null, null, "Alaska", null, null, 188, (short)2 }
                });

            migrationBuilder.InsertData(
                table: "RoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "RoleId" },
                values: new object[,]
                {
                    { 1, "permission", "Global.Availability", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2138), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 2, "permission", "Global.Correction", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2167), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 3, "permission", "Global.Lot", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2176), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 4, "permission", "Global.Notice", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2220), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 5, "permission", "Global.Permission", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2230), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 6, "permission", "Global.Queue", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2239), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 7, "permission", "Global.Role", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2247), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 8, "permission", "Global.Room", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2255), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 9, "permission", "Global.Setting", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2263), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 10, "permission", "Global.Slider", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2271), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 11, "permission", "Global.Staff", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2279), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 12, "permission", "Global.Tasks", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2287), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 13, "permission", "Global.UserRole", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2294), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 14, "permission", "Global.VisitTermination", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2302), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 15, "permission", "Global.AppointmentBehalf", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2310), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 16, "permission", "Global.CheckIn", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2318), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 17, "permission", "Global.Checkout", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2326), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 18, "permission", "Global.Connection", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2335), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 19, "permission", "Global.Explorer", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2342), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 20, "permission", "Global.RegisterBehalf", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2372), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 21, "permission", "Global.Delayed", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2382), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 22, "permission", "Global.CaseReview", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2390), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 23, "permission", "PregnancyTest.Initial", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2397), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 24, "permission", "PregnancyTest.Medical", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2404), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 25, "permission", "PregnancyTest.Demographic", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2412), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 26, "permission", "PregnancyTest.Required", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2420), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 27, "permission", "PregnancyTest.Appointment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2427), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 28, "permission", "PregnancyTest.Social", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2435), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 29, "permission", "PregnancyTest.SocialReview", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2442), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 30, "permission", "PregnancyTest.Decision", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2450), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 31, "permission", "PregnancyTest.ExitSurvey", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2458), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 32, "permission", "PregnancyTest.QaAssignment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2465), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 33, "permission", "PregnancyTest.PaAssignment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2473), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 34, "permission", "PregnancyTest.RequestList", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2482), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 35, "permission", "PregnancyTest.Vulnerability", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2489), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 36, "permission", "PregnancyTest.Spiritual", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2498), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 37, "permission", "PregnancyTest.TestResult", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2524), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 38, "permission", "PregnancyRetest.Medical", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2532), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 39, "permission", "PregnancyRetest.Appointment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2540), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 40, "permission", "PregnancyRetest.Social", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2548), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 41, "permission", "PregnancyRetest.Decision", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2555), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 42, "permission", "PregnancyRetest.Exit", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2564), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 43, "permission", "PregnancyRetest.Assignment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2571), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 44, "permission", "PregnancyRetest.RequestList", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2579), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 45, "permission", "PregnancyRetest.Vulnerability", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2586), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 46, "permission", "PregnancyRetest.Spiritual", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2594), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 47, "permission", "PregnancyRetest.TestResult", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2602), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 48, "permission", "UltrasoundScan.Interview", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2609), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 49, "permission", "UltrasoundScan.Appointment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2699), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 50, "permission", "UltrasoundScan.UExit", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2732), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 51, "permission", "UltrasoundScan.Assignment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2740), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 52, "permission", "UltrasoundScan.RequestList", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2748), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 53, "permission", "UltrasoundScan.UltrasoundReport", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2756), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 54, "permission", "UltrasoundRescan.Interview", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2799), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 55, "permission", "UltrasoundRescan.Appointment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2810), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 56, "permission", "UltrasoundRescan.UExit", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2818), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 57, "permission", "UltrasoundRescan.Assignment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2826), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 58, "permission", "UltrasoundRescan.RequestList", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2833), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 59, "permission", "UltrasoundRescan.UltrasoundReport", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2841), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 60, "permission", "PregnancyOptionsCounseling.Initial", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2849), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 61, "permission", "PregnancyOptionsCounseling.Demographic", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2856), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 62, "permission", "PregnancyOptionsCounseling.medical", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2864), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 63, "permission", "PregnancyOptionsCounseling.Required", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2871), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 64, "permission", "PregnancyOptionsCounseling.appointment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2879), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 65, "permission", "PregnancyOptionsCounseling.exit", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2886), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 66, "permission", "PregnancyOptionsCounseling.assignment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2899), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 67, "permission", "PregnancyOptionsCounseling.information", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2906), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 68, "permission", "PregnancyOptionsCounseling.requestlist", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2914), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 69, "permission", "PostAbortionCounseling.Initial", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2921), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 70, "permission", "PostAbortionCounseling.Demographic", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2948), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 71, "permission", "PostAbortionCounseling.Medical", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2956), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 72, "permission", "PostAbortionCounseling.Required", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2964), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 73, "permission", "PostAbortionCounseling.Appointment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2971), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 74, "permission", "PostAbortionCounseling.Exit", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2978), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 75, "permission", "PostAbortionCounseling.Assignment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2986), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 76, "permission", "PostAbortionCounseling.Information", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(2993), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 77, "permission", "PostAbortionCounseling.RequestList", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3001), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 78, "permission", "PregnancyLossCounseling.Initial", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3008), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 79, "permission", "PregnancyLossCounseling.Demographic", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3016), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 80, "permission", "PregnancyLossCounseling.Medical", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3023), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 81, "permission", "PregnancyLossCounseling.Required", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3030), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 82, "permission", "PregnancyLossCounseling.Appointment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3038), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 83, "permission", "PregnancyLossCounseling.Exit", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3045), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 84, "permission", "PregnancyLossCounseling.Assignment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3053), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 85, "permission", "PregnancyLossCounseling.Information", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3061), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 86, "permission", "PregnancyLossCounseling.RequestList", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3068), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 87, "permission", "DiscipleshipCounseling.Initial", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3093), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 88, "permission", "DiscipleshipCounseling.Demographic", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3102), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 89, "permission", "DiscipleshipCounseling.Medical", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3111), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 90, "permission", "DiscipleshipCounseling.Required", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3118), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 91, "permission", "DiscipleshipCounseling.Appointment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3126), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 92, "permission", "DiscipleshipCounseling.Exit", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3134), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 93, "permission", "DiscipleshipCounseling.Assignment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3141), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 94, "permission", "DiscipleshipCounseling.Information", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3149), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 95, "permission", "DiscipleshipCounseling.RequestList", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3157), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 96, "permission", "PrenatalCareInterview.Pregnancy", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3164), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 97, "permission", "PrenatalCareInterview.MedicalHistory", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3172), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 98, "permission", "PrenatalCareInterview.SupportAssessment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3180), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 99, "permission", "clien.prenatalcareinterviewt.Residence", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3187), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 100, "permission", "PrenatalCareInterview.CarrierScreening", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3195), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 101, "permission", "PrenatalCareInterview.Appointment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3202), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 102, "permission", "PrenatalCareInterview.Assignment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3210), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 103, "permission", "PrenatalCareInterview.RequestList", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3217), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 104, "permission", "PrenatalVisits.Appointment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3224), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 105, "permission", "PrenatalVisits.Exit", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3250), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 106, "permission", "PrenatalVisits.Assignment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3258), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 107, "permission", "PrenatalVisits.Prenatal", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3266), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 108, "permission", "PrenatalVisits.RequestList", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3273), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 109, "permission", "PrenatalVisits.Record", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3280), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 110, "permission", "PrenatalVisits.Laboratory", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3288), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 111, "permission", "MaleCounseling.Initial", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3296), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 112, "permission", "MaleCounseling.Demographic", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3303), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 113, "permission", "MaleCounseling.Malemedical", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3311), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 114, "permission", "MaleCounseling.Required", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3318), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 115, "permission", "MaleCounseling.Appointment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3325), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 116, "permission", "MaleCounseling.Exit", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3333), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 117, "permission", "MaleCounseling.MaleAssignment", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3341), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 118, "permission", "MaleCounseling.Medical", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3349), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") },
                    { 119, "permission", "MaleCounseling.MaleInformation", new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(3356), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4") }
                });

            migrationBuilder.InsertData(
                table: "UserAddresses",
                columns: new[] { "Id", "Address", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "IsDefault", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Order", "RegionId", "Type", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("b5106f12-4501-4da5-aa7d-5efb567eb61d"), "Robert Robertson, 1234 NW Bobcat Lane, St. Robert, MO 65584-5678", null, null, null, null, null, null, null, false, false, null, null, null, 3, null, (short)1000, new Guid("817b6b01-25ab-4cf4-8b7e-157a8f996c48"), "351745121" },
                    { new Guid("b80dde41-d26b-4f11-976e-66f102568f76"), "Suzy Queue\r\n4455 Landing Lange, APT 4\r\nLouisville, KY 40018-1234", null, null, null, null, null, null, null, false, false, null, null, null, 2, null, (short)2, new Guid("817b6b01-25ab-4cf4-8b7e-157a8f996c48"), "241542123" },
                    { new Guid("ef55f690-5fc3-4d0f-9f7b-c5fcaca0ecb9"), "SGT Miranda McAnderson\r\n6543 N 9th Street\r\nAPO, AA 33608-1234", null, null, null, null, null, null, null, true, false, null, null, null, 1, null, (short)1, new Guid("817b6b01-25ab-4cf4-8b7e-157a8f996c48"), "251742310" }
                });

            migrationBuilder.InsertData(
                table: "UserPhoneNumbers",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "IsDefault", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Order", "PhoneNumber", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("4c5b3ca2-2b71-45ed-9adb-bf10c5b5b9fa"), null, null, null, null, null, null, "Bussines Fax", false, false, null, null, null, 2, "5234525867", (short)4, new Guid("817b6b01-25ab-4cf4-8b7e-157a8f996c48") },
                    { new Guid("da714479-17aa-4a4a-975c-0bbb30042ef9"), null, null, null, null, null, null, "Emergency Contact (my father)", false, false, null, null, null, 3, "8834551820", (short)5, new Guid("817b6b01-25ab-4cf4-8b7e-157a8f996c48") },
                    { new Guid("e15bb5ae-762f-4d8b-9182-8bf89f6959f4"), null, null, null, null, null, null, "This is my main mobile", true, false, null, null, null, 1, "2345124454", (short)1, new Guid("817b6b01-25ab-4cf4-8b7e-157a8f996c48") }
                });

            migrationBuilder.InsertData(
                table: "UserProfile",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "EmergencyName", "EmergencyPhone", "FirstName", "Gender", "Height", "IdNumber", "IntroMethodDescription", "IntroMethodId", "IsDeleted", "IsNoticeAccepted", "IsVolunteer", "LastName", "MiddleName", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "ProfileImage", "RaceNationality", "UserId", "Weight" },
                values: new object[] { new Guid("18b01083-7fa8-40dc-9be0-b91a35ff98b8"), null, null, null, null, null, null, null, null, null, null, "Test name", (short)1, null, null, null, null, false, null, null, "Test family", null, null, null, null, null, null, new Guid("817b6b01-25ab-4cf4-8b7e-157a8f996c48"), null });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "RoleId", "UserId" },
                values: new object[] { new Guid("2c96c3b3-3e11-4c6e-bb6a-671a9a82964f"), new DateTime(2023, 1, 9, 20, 24, 20, 561, DateTimeKind.Utc).AddTicks(5180), null, null, null, null, null, false, null, null, null, new Guid("ba5a97f6-d3f2-4b73-8af0-3803e218c8c4"), new Guid("817b6b01-25ab-4cf4-8b7e-157a8f996c48") });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "Culture", "DarkMode", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "RightToLeft", "Theme", "UserId" },
                values: new object[] { new Guid("52333795-8095-4af2-b0fe-6713c1ee8c44"), null, null, null, "en-US", false, null, null, null, false, null, null, null, false, "", new Guid("817b6b01-25ab-4cf4-8b7e-157a8f996c48") });

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ParentId",
                table: "Regions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_RegionId",
                table: "UserAddresses",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAttachment_UserId",
                table: "UserAttachment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPhoneNumbers_UserId",
                table: "UserPhoneNumbers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_UserId",
                table: "UserProfile",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DefaultTenantId",
                table: "Users",
                column: "DefaultTenantId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_UserId",
                table: "UserSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTenants_TenantId",
                table: "UserTenants",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTenants_UserId",
                table: "UserTenants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSettings");

            migrationBuilder.DropTable(
                name: "Cultures");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "UserAttachment");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserPhoneNumbers");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserSessions");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "UserTenants");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
