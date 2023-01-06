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
                    table.PrimaryKey("PK_AppSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cultures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CultureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDatePattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongDatePattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongTimePattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortTimePattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullDateTimePattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSeparator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeSeparator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearMonthPattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthDayPattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstDayOfWeek = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    RightToLeft = table.Column<bool>(type: "bit", nullable: false),
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
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Issuer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DBProvider = table.Column<int>(type: "int", nullable: true),
                    ConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Tenant", x => x.Id);
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
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    AddressType = table.Column<short>(type: "smallint", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: true),
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
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: true),
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
                    PhoneNumberType = table.Column<short>(type: "smallint", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: true),
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
                    IntroMethodId = table.Column<int>(type: "int", nullable: true),
                    IsNoticeAccepted = table.Column<bool>(type: "bit", nullable: true),
                    IsVolunteer = table.Column<bool>(type: "bit", nullable: true),
                    Gender = table.Column<short>(type: "smallint", nullable: true),
                    RaceNationality = table.Column<short>(type: "smallint", nullable: true),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Height = table.Column<short>(type: "smallint", nullable: true),
                    Weight = table.Column<short>(type: "smallint", nullable: true),
                    EmergencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroMethodDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    ConnectionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SessionIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    DefaultTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RightToLeft = table.Column<bool>(type: "bit", nullable: false),
                    DarkMode = table.Column<bool>(type: "bit", nullable: false),
                    Culture = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_Tenant_DefaultTenantId",
                        column: x => x.DefaultTenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id");
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
                values: new object[] { new Guid("50dbfe5a-7435-4487-9c7d-8aa806f32206"), new DateTime(2023, 1, 6, 8, 21, 26, 65, DateTimeKind.Utc).AddTicks(4440), null, null, null, null, null, null, false, null, "DefaultConnectionString", null, null, null, "Server=.;Database={0};Integrated Security = True;" });

            migrationBuilder.InsertData(
                table: "Cultures",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "CultureName", "DateSeparator", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "DisplayName", "FirstDayOfWeek", "FullDateTimePattern", "Image", "IsDefault", "IsDeleted", "LongDatePattern", "LongTimePattern", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "MonthDayPattern", "RightToLeft", "ShortDatePattern", "ShortTimePattern", "TimeSeparator", "YearMonthPattern" },
                values: new object[,]
                {
                    { new Guid("ac539c51-f048-4f99-8b3a-41d384cf6c05"), new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(6745), null, null, "fa-IR", "/", null, null, null, "فارسی", 6, "dddd, MMMM dd, yyyy h:mm:ss tt", "_content/wrmc.RootComponents/assets/media/flags/iran.svg", false, false, "dddd, MMMM dd, yyyy ", "HH:mm:ss", null, null, null, "MMMM dd", true, "yyyy/MM/dd", "HH:mm", ":", "MMMM, yyyy" },
                    { new Guid("e3662a12-4f21-4e38-93e9-5d70abcdc844"), new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(3452), null, null, "en-US", "/", null, null, null, "English", 1, "dddd, MMMM dd, yyyy h:mm:ss tt", "_content/wrmc.RootComponents/assets/media/flags/usa.svg", true, false, "dddd, MMMM dd, yyyy", "HH:mm:ss", null, null, null, "MMMM dd", false, "yyyy/MM/dd", "HH:mm", ":", "MMMM, yyyy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Flag", "IsDeleted", "Iso2", "Iso3", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "Numeric", "OfficialName", "ParentId", "RegionType" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(79), null, null, null, null, null, null, false, "af", "AFG", null, null, null, "Afghanistan", null, "the Islamic Republic of Afghanistan", null, (short)1 },
                    { 2, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1818), null, null, null, null, null, null, false, "al", "ALB", null, null, null, "Albania", null, "the Republic of Albania", null, (short)1 },
                    { 3, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1835), null, null, null, null, null, null, false, "dz", "DZA", null, null, null, "Algeria", null, "the People's Democratic Republic of Algeria", null, (short)1 },
                    { 4, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1837), null, null, null, null, null, null, false, "ad", "AND", null, null, null, "Andorra", null, "the Principality of Andorra", null, (short)1 },
                    { 5, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1838), null, null, null, null, null, null, false, "ao", "AGO", null, null, null, "Angola", null, "the Republic of Angola", null, (short)1 },
                    { 6, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1846), null, null, null, null, null, null, false, "ag", "ATG", null, null, null, "Antigua and Barbuda", null, "Antigua and Barbuda", null, (short)1 },
                    { 7, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1847), null, null, null, null, null, null, false, "ar", "ARG", null, null, null, "Argentina", null, "the Argentine Republic", null, (short)1 },
                    { 8, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1849), null, null, null, null, null, null, false, "am", "ARM", null, null, null, "Armenia", null, "the Republic of Armenia", null, (short)1 },
                    { 9, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1853), null, null, null, null, null, null, false, "au", "AUS", null, null, null, "Australia", null, "Australia", null, (short)1 },
                    { 10, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1855), null, null, null, null, null, null, false, "at", "AUT", null, null, null, "Austria", null, "the Republic of Austria", null, (short)1 },
                    { 11, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1856), null, null, null, null, null, null, false, "az", "AZE", null, null, null, "Azerbaijan", null, "the Republic of Azerbaijan", null, (short)1 },
                    { 12, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1857), null, null, null, null, null, null, false, "bs", "BHS", null, null, null, "Bahamas", null, "the Commonwealth of the Bahamas", null, (short)1 },
                    { 13, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1858), null, null, null, null, null, null, false, "bh", "BHR", null, null, null, "Bahrain", null, "the Kingdom of Bahrain", null, (short)1 },
                    { 14, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1860), null, null, null, null, null, null, false, "bd", "BGD", null, null, null, "Bangladesh", null, "the People's Republic of Bangladesh", null, (short)1 },
                    { 15, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1861), null, null, null, null, null, null, false, "bb", "BRB", null, null, null, "Barbados", null, "Barbados", null, (short)1 },
                    { 16, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1862), null, null, null, null, null, null, false, "by", "BLR", null, null, null, "Belarus", null, "the Republic of Belarus", null, (short)1 },
                    { 17, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1863), null, null, null, null, null, null, false, "be", "BEL", null, null, null, "Belgium", null, "the Kingdom of Belgium", null, (short)1 },
                    { 18, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1865), null, null, null, null, null, null, false, "bz", "BLZ", null, null, null, "Belize", null, "Belize", null, (short)1 },
                    { 19, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1866), null, null, null, null, null, null, false, "bj", "BEN", null, null, null, "Benin", null, "the Republic of Benin", null, (short)1 },
                    { 20, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1868), null, null, null, null, null, null, false, "bt", "BTN", null, null, null, "Bhutan", null, "the Kingdom of Bhutan", null, (short)1 },
                    { 21, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1875), null, null, null, null, null, null, false, "bo", "BOL", null, null, null, "Bolivia (Plurinational State of)", null, "the Plurinational State of Bolivia", null, (short)1 },
                    { 22, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1908), null, null, null, null, null, null, false, "ba", "BIH", null, null, null, "Bosnia and Herzegovina", null, "Bosnia and Herzegovina", null, (short)1 },
                    { 23, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1910), null, null, null, null, null, null, false, "bw", "BWA", null, null, null, "Botswana", null, "the Republic of Botswana", null, (short)1 },
                    { 24, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1911), null, null, null, null, null, null, false, "br", "BRA", null, null, null, "Brazil", null, "the Federative Republic of Brazil", null, (short)1 },
                    { 25, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1913), null, null, null, null, null, null, false, "bn", "BRN", null, null, null, "Brunei Darussalam", null, "Brunei Darussalam", null, (short)1 },
                    { 26, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1914), null, null, null, null, null, null, false, "bg", "BGR", null, null, null, "Bulgaria", null, "the Republic of Bulgaria", null, (short)1 },
                    { 27, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1915), null, null, null, null, null, null, false, "bf", "BFA", null, null, null, "Burkina Faso", null, "Burkina Faso", null, (short)1 },
                    { 28, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1916), null, null, null, null, null, null, false, "bi", "BDI", null, null, null, "Burundi", null, "the Republic of Burundi", null, (short)1 },
                    { 29, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1917), null, null, null, null, null, null, false, "cv", "CPV", null, null, null, "Cabo Verde", null, "Republic of Cabo Verde", null, (short)1 },
                    { 30, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1919), null, null, null, null, null, null, false, "kh", "KHM", null, null, null, "Cambodia", null, "the Kingdom of Cambodia", null, (short)1 },
                    { 31, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1920), null, null, null, null, null, null, false, "cm", "CMR", null, null, null, "Cameroon", null, "the Republic of Cameroon", null, (short)1 },
                    { 32, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1921), null, null, null, null, null, null, false, "ca", "CAN", null, null, null, "Canada", null, "Canada", null, (short)1 },
                    { 33, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1922), null, null, null, null, null, null, false, "cf", "CAF", null, null, null, "Central African Republic", null, "the Central African Republic", null, (short)1 },
                    { 34, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1924), null, null, null, null, null, null, false, "td", "TCD", null, null, null, "Chad", null, "the Republic of Chad", null, (short)1 },
                    { 35, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1926), null, null, null, null, null, null, false, "cl", "CHL", null, null, null, "Chile", null, "the Republic of Chile", null, (short)1 },
                    { 36, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1927), null, null, null, null, null, null, false, "cn", "CHN", null, null, null, "China", null, "the People's Republic of China", null, (short)1 },
                    { 37, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1934), null, null, null, null, null, null, false, "co", "COL", null, null, null, "Colombia", null, "the Republic of Colombia", null, (short)1 },
                    { 38, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1935), null, null, null, null, null, null, false, "km", "COM", null, null, null, "Comoros", null, "the Union of the Comoros", null, (short)1 },
                    { 39, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1937), null, null, null, null, null, null, false, "cg", "COG", null, null, null, "Congo", null, "the Republic of the Congo", null, (short)1 },
                    { 40, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1938), null, null, null, null, null, null, false, "ck", "COK", null, null, null, "Cook Islands", null, "the Cook Islands", null, (short)1 },
                    { 41, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1940), null, null, null, null, null, null, false, "cr", "CRI", null, null, null, "Costa Rica", null, "the Republic of Costa Rica", null, (short)1 },
                    { 42, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1941), null, null, null, null, null, null, false, "hr", "HRV", null, null, null, "Croatia", null, "the Republic of Croatia", null, (short)1 },
                    { 43, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1942), null, null, null, null, null, null, false, "cu", "CUB", null, null, null, "Cuba", null, "the Republic of Cuba", null, (short)1 },
                    { 44, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1943), null, null, null, null, null, null, false, "cy", "CYP", null, null, null, "Cyprus", null, "the Republic of Cyprus", null, (short)1 },
                    { 45, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1945), null, null, null, null, null, null, false, "cz", "CZE", null, null, null, "Czechia", null, "the Czech Republic", null, (short)1 },
                    { 46, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1946), null, null, null, null, null, null, false, "ci", "CIV", null, null, null, "CÃ´te d'Ivoire", null, "the Republic of CÃ´te d'Ivoire", null, (short)1 },
                    { 47, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1947), null, null, null, null, null, null, false, "kp", "PRK", null, null, null, "Democratic People's Republic of Korea", null, "the Democratic People's Republic of Korea", null, (short)1 },
                    { 48, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1948), null, null, null, null, null, null, false, "cd", "COD", null, null, null, "Democratic Republic of the Congo", null, "the Democratic Republic of the Congo", null, (short)1 },
                    { 49, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1950), null, null, null, null, null, null, false, "dk", "DNK", null, null, null, "Denmark", null, "the Kingdom of Denmark", null, (short)1 },
                    { 50, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1951), null, null, null, null, null, null, false, "dj", "DJI", null, null, null, "Djibouti", null, "the Republic of Djibouti", null, (short)1 },
                    { 51, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1974), null, null, null, null, null, null, false, "dm", "DMA", null, null, null, "Dominica", null, "the Commonwealth of Dominica", null, (short)1 },
                    { 52, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1976), null, null, null, null, null, null, false, "do", "DOM", null, null, null, "Dominican Republic", null, "the Dominican Republic", null, (short)1 },
                    { 53, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1977), null, null, null, null, null, null, false, "ec", "ECU", null, null, null, "Ecuador", null, "the Republic of Ecuador", null, (short)1 },
                    { 54, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1984), null, null, null, null, null, null, false, "eg", "EGY", null, null, null, "Egypt", null, "the Arab Republic of Egypt", null, (short)1 },
                    { 55, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1985), null, null, null, null, null, null, false, "sv", "SLV", null, null, null, "El Salvador", null, "the Republic of El Salvador", null, (short)1 },
                    { 56, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1987), null, null, null, null, null, null, false, "gq", "GNQ", null, null, null, "Equatorial Guinea", null, "the Republic of Equatorial Guinea", null, (short)1 },
                    { 57, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1988), null, null, null, null, null, null, false, "er", "ERI", null, null, null, "Eritrea", null, "the State of Eritrea", null, (short)1 },
                    { 58, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1989), null, null, null, null, null, null, false, "ce", "EST", null, null, null, "Estonia", null, "the Republic of Estonia", null, (short)1 },
                    { 59, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1990), null, null, null, null, null, null, false, "sz", "SWZ", null, null, null, "Eswatini", null, "the Kingdom of Eswatini", null, (short)1 },
                    { 60, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1992), null, null, null, null, null, null, false, "et", "ETH", null, null, null, "Ethiopia", null, "the Federal Democratic Republic of Ethiopia", null, (short)1 },
                    { 61, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1993), null, null, null, null, null, null, false, "fo", "FRO", null, null, null, "Faroe Islands", null, "Faroe Islands", null, (short)1 },
                    { 62, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1994), null, null, null, null, null, null, false, "fj", "FJI", null, null, null, "Fiji", null, "the Republic of Fiji", null, (short)1 },
                    { 63, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1995), null, null, null, null, null, null, false, "fi", "FIN", null, null, null, "Finland", null, "the Republic of Finland", null, (short)1 },
                    { 64, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1996), null, null, null, null, null, null, false, "fr", "FRA", null, null, null, "France", null, "the French Republic", null, (short)1 },
                    { 65, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1998), null, null, null, null, null, null, false, "ga", "GAB", null, null, null, "Gabon", null, "the Gabonese Republic", null, (short)1 },
                    { 66, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(1999), null, null, null, null, null, null, false, "gm", "GMB", null, null, null, "Gambia", null, "the Republic of the Gambia", null, (short)1 },
                    { 67, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2001), null, null, null, null, null, null, false, "ge", "GEO", null, null, null, "Georgia", null, "Georgia", null, (short)1 },
                    { 68, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2002), null, null, null, null, null, null, false, "de", "DEU", null, null, null, "Germany", null, "the Federal Republic of Germany", null, (short)1 },
                    { 69, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2003), null, null, null, null, null, null, false, "gh", "GHA", null, null, null, "Ghana", null, "the Republic of Ghana", null, (short)1 },
                    { 70, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2015), null, null, null, null, null, null, false, "gr", "GRC", null, null, null, "Greece", null, "the Hellenic Republic", null, (short)1 },
                    { 71, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2018), null, null, null, null, null, null, false, "gd", "GRD", null, null, null, "Grenada", null, "Grenada", null, (short)1 },
                    { 72, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2019), null, null, null, null, null, null, false, "gt", "GTM", null, null, null, "Guatemala", null, "the Republic of Guatemala", null, (short)1 },
                    { 73, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2020), null, null, null, null, null, null, false, "gn", "GIN", null, null, null, "Guinea", null, "the Republic of Guinea", null, (short)1 },
                    { 74, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2022), null, null, null, null, null, null, false, "gw", "GNB", null, null, null, "Guinea-Bissau", null, "the Republic of Guinea-Bissau", null, (short)1 },
                    { 75, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2023), null, null, null, null, null, null, false, "gy", "GUY", null, null, null, "Guyana", null, "the Co-operative Republic of Guyana", null, (short)1 },
                    { 76, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2024), null, null, null, null, null, null, false, "ht", "HTI", null, null, null, "Haiti", null, "the Republic of Haiti", null, (short)1 },
                    { 77, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2025), null, null, null, null, null, null, false, "hn", "HND", null, null, null, "Honduras", null, "the Republic of Honduras", null, (short)1 },
                    { 78, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2045), null, null, null, null, null, null, false, "hu", "HUN", null, null, null, "Hungary", null, "Hungary", null, (short)1 },
                    { 79, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2046), null, null, null, null, null, null, false, "is", "ISL", null, null, null, "Iceland", null, "the Republic of Iceland", null, (short)1 },
                    { 80, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2049), null, null, null, null, null, null, false, "in", "IND", null, null, null, "India", null, "the Republic of India", null, (short)1 },
                    { 81, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2050), null, null, null, null, null, null, false, "id", "IDN", null, null, null, "Indonesia", null, "the Republic of Indonesia", null, (short)1 },
                    { 82, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2051), null, null, null, null, null, null, false, "ir", "IRN", null, null, null, "Iran (Islamic Republic of)", null, "the Islamic Republic of Iran", null, (short)1 },
                    { 83, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2052), null, null, null, null, null, null, false, "iq", "IRQ", null, null, null, "Iraq", null, "the Republic of Iraq", null, (short)1 },
                    { 84, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2054), null, null, null, null, null, null, false, "ie", "IRL", null, null, null, "Ireland", null, "Ireland", null, (short)1 },
                    { 85, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2055), null, null, null, null, null, null, false, "il", "ISR", null, null, null, "Israel", null, "the State of Israel", null, (short)1 },
                    { 86, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2056), null, null, null, null, null, null, false, "it", "ITA", null, null, null, "Italy", null, "the Republic of Italy", null, (short)1 },
                    { 87, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2063), null, null, null, null, null, null, false, "jm", "JAM", null, null, null, "Jamaica", null, "Jamaica", null, (short)1 },
                    { 88, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2065), null, null, null, null, null, null, false, "jp", "JPN", null, null, null, "Japan", null, "Japan", null, (short)1 },
                    { 89, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2066), null, null, null, null, null, null, false, "jo", "JOR", null, null, null, "Jordan", null, "the Hashemite Kingdom of Jordan", null, (short)1 },
                    { 90, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2067), null, null, null, null, null, null, false, "kz", "KAZ", null, null, null, "Kazakhstan", null, "the Republic of Kazakhstan", null, (short)1 },
                    { 91, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2068), null, null, null, null, null, null, false, "kn", "KEN", null, null, null, "Kenya", null, "the Republic of Kenya", null, (short)1 },
                    { 92, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2070), null, null, null, null, null, null, false, "ki", "KIR", null, null, null, "Kiribati", null, "the Republic of Kiribati", null, (short)1 },
                    { 93, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2071), null, null, null, null, null, null, false, "kw", "KWT", null, null, null, "Kuwait", null, "the State of Kuwait", null, (short)1 },
                    { 94, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2072), null, null, null, null, null, null, false, "kg", "KGZ", null, null, null, "Kyrgyzstan", null, "the Kyrgyz Republic", null, (short)1 },
                    { 95, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2073), null, null, null, null, null, null, false, "la", "LAO", null, null, null, "Lao People's Democratic Republic", null, "the Lao People's Democratic Republic", null, (short)1 },
                    { 96, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2074), null, null, null, null, null, null, false, "lv", "LVA", null, null, null, "Latvia", null, "the Republic of Latvia", null, (short)1 },
                    { 97, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2076), null, null, null, null, null, null, false, "lb", "LBN", null, null, null, "Lebanon", null, "the Lebanese Republic", null, (short)1 },
                    { 98, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2077), null, null, null, null, null, null, false, "ls", "LSO", null, null, null, "Lesotho", null, "the Kingdom of Lesotho", null, (short)1 },
                    { 99, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2078), null, null, null, null, null, null, false, "lr", "LBR", null, null, null, "Liberia", null, "the Republic of Liberia", null, (short)1 },
                    { 100, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2079), null, null, null, null, null, null, false, "ly", "LBY", null, null, null, "Libya", null, "State of Libya", null, (short)1 },
                    { 101, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2080), null, null, null, null, null, null, false, "lt", "LTU", null, null, null, "Lithuania", null, "the Republic of Lithuania", null, (short)1 },
                    { 102, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2082), null, null, null, null, null, null, false, "lu", "LUX", null, null, null, "Luxembourg", null, "the Grand Duchy of Luxembourg", null, (short)1 },
                    { 103, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2089), null, null, null, null, null, null, false, "mg", "MDG", null, null, null, "Madagascar", null, "the Republic of Madagascar", null, (short)1 },
                    { 104, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2090), null, null, null, null, null, null, false, "mw", "MWI", null, null, null, "Malawi", null, "the Republic of Malawi", null, (short)1 },
                    { 105, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2091), null, null, null, null, null, null, false, "my", "MYS", null, null, null, "Malaysia", null, "Malaysia", null, (short)1 },
                    { 106, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2092), null, null, null, null, null, null, false, "mv", "MDV", null, null, null, "Maldives", null, "the Republic of Maldives", null, (short)1 },
                    { 107, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2093), null, null, null, null, null, null, false, "ml", "MLI", null, null, null, "Mali", null, "the Republic of Mali", null, (short)1 },
                    { 108, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2095), null, null, null, null, null, null, false, "mt", "MLT", null, null, null, "Malta", null, "the Republic of Malta", null, (short)1 },
                    { 109, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2115), null, null, null, null, null, null, false, "mh", "MHL", null, null, null, "Marshall Islands", null, "the Republic of the Marshall Islands", null, (short)1 },
                    { 110, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2117), null, null, null, null, null, null, false, "mr", "MRT", null, null, null, "Mauritania", null, "the Islamic Republic of Mauritania", null, (short)1 },
                    { 111, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2118), null, null, null, null, null, null, false, "mu", "MUS", null, null, null, "Mauritius", null, "the Republic of Mauritius", null, (short)1 },
                    { 112, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2119), null, null, null, null, null, null, false, "mx", "MEX", null, null, null, "Mexico", null, "the United Mexican States", null, (short)1 },
                    { 113, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2120), null, null, null, null, null, null, false, "fm", "FSM", null, null, null, "Micronesia (Federated States of)", null, "the Federated States of Micronesia", null, (short)1 },
                    { 114, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2121), null, null, null, null, null, null, false, "mc", "MCO", null, null, null, "Monaco", null, "the Principality of Monaco", null, (short)1 },
                    { 115, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2123), null, null, null, null, null, null, false, "mn", "MNG", null, null, null, "Mongolia", null, "Mongolia", null, (short)1 },
                    { 116, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2124), null, null, null, null, null, null, false, "me", "MNE", null, null, null, "Montenegro", null, "Montenegro", null, (short)1 },
                    { 117, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2125), null, null, null, null, null, null, false, "ma", "MAR", null, null, null, "Morocco", null, "the Kingdom of Morocco", null, (short)1 },
                    { 118, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2126), null, null, null, null, null, null, false, "mz", "MOZ", null, null, null, "Mozambique", null, "the Republic of Mozambique", null, (short)1 },
                    { 119, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2128), null, null, null, null, null, null, false, "mm", "MMR", null, null, null, "Myanmar", null, "the Republic of the Union of Myanmar", null, (short)1 },
                    { 120, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2135), null, null, null, null, null, null, false, "na", "NAM", null, null, null, "Namibia", null, "the Republic of Namibia", null, (short)1 },
                    { 121, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2136), null, null, null, null, null, null, false, "nr", "NRU", null, null, null, "Nauru", null, "the Republic of Nauru", null, (short)1 },
                    { 122, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2137), null, null, null, null, null, null, false, "np", "NPL", null, null, null, "Nepal", null, "the Federal Democratic Republic of Nepal", null, (short)1 },
                    { 123, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2139), null, null, null, null, null, null, false, "nl", "NLD", null, null, null, "Netherlands", null, "the Kingdom of the Netherlands", null, (short)1 },
                    { 124, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2140), null, null, null, null, null, null, false, "nz", "NZL", null, null, null, "New Zealand", null, "New Zealand", null, (short)1 },
                    { 125, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2141), null, null, null, null, null, null, false, "ni", "NIC", null, null, null, "Nicaragua", null, "the Republic of Nicaragua", null, (short)1 },
                    { 126, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2142), null, null, null, null, null, null, false, "ne", "NER", null, null, null, "Niger", null, "the Republic of the Niger", null, (short)1 },
                    { 127, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2144), null, null, null, null, null, null, false, "ng", "NGA", null, null, null, "Nigeria", null, "the Federal Republic of Nigeria", null, (short)1 },
                    { 128, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2145), null, null, null, null, null, null, false, "nu", "NIU", null, null, null, "Niue", null, "Niue", null, (short)1 },
                    { 129, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2146), null, null, null, null, null, null, false, "mk", "MKD", null, null, null, "North Macedonia", null, "the Republic of North Macedonia", null, (short)1 },
                    { 130, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2217), null, null, null, null, null, null, false, "no", "NOR", null, null, null, "Norway", null, "the Kingdom of Norway", null, (short)1 },
                    { 131, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2218), null, null, null, null, null, null, false, "om", "OMN", null, null, null, "Oman", null, "the Sultanate of Oman", null, (short)1 },
                    { 132, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2242), null, null, null, null, null, null, false, "pk", "PAK", null, null, null, "Pakistan", null, "the Islamic Republic of Pakistan", null, (short)1 },
                    { 133, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2244), null, null, null, null, null, null, false, "pw", "PLW", null, null, null, "Palau", null, "the Republic of Palau", null, (short)1 },
                    { 134, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2245), null, null, null, null, null, null, false, "pa", "PAN", null, null, null, "Panama", null, "the Republic of Panama", null, (short)1 },
                    { 135, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2246), null, null, null, null, null, null, false, "pg", "PNG", null, null, null, "Papua New Guinea", null, "Independent State of Papua New Guinea", null, (short)1 },
                    { 136, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2254), null, null, null, null, null, null, false, "py", "PRY", null, null, null, "Paraguay", null, "the Republic of Paraguay", null, (short)1 },
                    { 137, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2255), null, null, null, null, null, null, false, "pe", "PER", null, null, null, "Peru", null, "the Republic of Peru", null, (short)1 },
                    { 138, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2257), null, null, null, null, null, null, false, "ph", "PHL", null, null, null, "Philippines", null, "the Republic of the Philippines", null, (short)1 },
                    { 139, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2258), null, null, null, null, null, null, false, "pl", "POL", null, null, null, "Poland", null, "the Republic of Poland", null, (short)1 },
                    { 140, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2259), null, null, null, null, null, null, false, "pt", "PRT", null, null, null, "Portugal", null, "the Portuguese Republic", null, (short)1 },
                    { 141, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2260), null, null, null, null, null, null, false, "qa", "QAT", null, null, null, "Qatar", null, "the State of Qatar", null, (short)1 },
                    { 142, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2261), null, null, null, null, null, null, false, "kr", "KOR", null, null, null, "Republic of Korea", null, "the Republic of Korea", null, (short)1 },
                    { 143, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2263), null, null, null, null, null, null, false, "md", "MDA", null, null, null, "Republic of Moldova", null, "the Republic of Moldova", null, (short)1 },
                    { 144, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2264), null, null, null, null, null, null, false, "ro", "ROU", null, null, null, "Romania", null, "Romania", null, (short)1 },
                    { 145, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2265), null, null, null, null, null, null, false, "ru", "RUS", null, null, null, "Russian Federation", null, "the Russian Federation", null, (short)1 },
                    { 146, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2266), null, null, null, null, null, null, false, "rw", "RWA", null, null, null, "Rwanda", null, "the Republic of Rwanda", null, (short)1 },
                    { 147, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2267), null, null, null, null, null, null, false, "kn", "KNA", null, null, null, "Saint Kitts and Nevis", null, "Saint Kitts and Nevis", null, (short)1 },
                    { 148, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2269), null, null, null, null, null, null, false, "lc", "LCA", null, null, null, "Saint Lucia", null, "Saint Lucia", null, (short)1 },
                    { 149, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2270), null, null, null, null, null, null, false, "vc", "VCT", null, null, null, "Saint Vincent and the Grenadines", null, "Saint Vincent and the Grenadines", null, (short)1 },
                    { 150, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2271), null, null, null, null, null, null, false, "ws", "WSM", null, null, null, "Samoa", null, "the Independent State of Samoa", null, (short)1 },
                    { 151, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2272), null, null, null, null, null, null, false, "sm", "SMR", null, null, null, "San Marino", null, "the Republic of San Marino", null, (short)1 },
                    { 152, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2273), null, null, null, null, null, null, false, "st", "STP", null, null, null, "Sao Tome and Principe", null, "the Democratic Republic of Sao Tome and Principe", null, (short)1 },
                    { 153, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2280), null, null, null, null, null, null, false, "sa", "SAU", null, null, null, "Saudi Arabia", null, "the Kingdom of Saudi Arabia", null, (short)1 },
                    { 154, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2282), null, null, null, null, null, null, false, "sn", "SEN", null, null, null, "Senegal", null, "the Republic of Senegal", null, (short)1 },
                    { 155, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2283), null, null, null, null, null, null, false, "rs", "SRB", null, null, null, "Serbia", null, "the Republic of Serbia", null, (short)1 },
                    { 156, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2284), null, null, null, null, null, null, false, "sc", "SYC", null, null, null, "Seychelles", null, "the Republic of Seychelles", null, (short)1 },
                    { 157, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2285), null, null, null, null, null, null, false, "sl", "SLE", null, null, null, "Sierra Leone", null, "the Republic of Sierra Leone", null, (short)1 },
                    { 158, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2286), null, null, null, null, null, null, false, "sg", "SGP", null, null, null, "Singapore", null, "the Republic of Singapore", null, (short)1 },
                    { 159, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2288), null, null, null, null, null, null, false, "sk", "SVK", null, null, null, "Slovakia", null, "the Slovak Republic", null, (short)1 },
                    { 160, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2289), null, null, null, null, null, null, false, "si", "SVN", null, null, null, "Slovenia", null, "the Republic of Slovenia", null, (short)1 },
                    { 161, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2290), null, null, null, null, null, null, false, "sb", "SLB", null, null, null, "Solomon Islands", null, "Solomon Islands", null, (short)1 },
                    { 162, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2291), null, null, null, null, null, null, false, "so", "SOM", null, null, null, "Somalia", null, "the Federal Republic of Somalia", null, (short)1 },
                    { 163, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2335), null, null, null, null, null, null, false, "za", "ZAF", null, null, null, "South Africa", null, "the Republic of South Africa", null, (short)1 },
                    { 164, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2336), null, null, null, null, null, null, false, "ss", "SSD", null, null, null, "South Sudan", null, "the Republic of South Sudan", null, (short)1 },
                    { 165, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2337), null, null, null, null, null, null, false, "es", "ESP", null, null, null, "Spain", null, "the Kingdom of Spain", null, (short)1 },
                    { 166, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2339), null, null, null, null, null, null, false, "lk", "LKA", null, null, null, "Sri Lanka", null, "the Democratic Socialist Republic of Sri Lanka", null, (short)1 },
                    { 167, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2340), null, null, null, null, null, null, false, "sd", "SDN", null, null, null, "Sudan", null, "the Republic of the Sudan", null, (short)1 },
                    { 168, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2341), null, null, null, null, null, null, false, "sr", "SUR", null, null, null, "Suriname", null, "the Republic of Suriname", null, (short)1 },
                    { 169, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2351), null, null, null, null, null, null, false, "se", "SWE", null, null, null, "Sweden", null, "the Kingdom of Sweden", null, (short)1 },
                    { 170, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2352), null, null, null, null, null, null, false, "ch", "CHE", null, null, null, "Switzerland", null, "the Swiss Confederation", null, (short)1 },
                    { 171, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2353), null, null, null, null, null, null, false, "sy", "SYR", null, null, null, "Syrian Arab Republic", null, "the Syrian Arab Republic", null, (short)1 },
                    { 172, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2355), null, null, null, null, null, null, false, "tj", "TJK", null, null, null, "Tajikistan", null, "the Republic of Tajikistan", null, (short)1 },
                    { 173, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2356), null, null, null, null, null, null, false, "th", "THA", null, null, null, "Thailand", null, "the Kingdom of Thailand", null, (short)1 },
                    { 174, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2357), null, null, null, null, null, null, false, "tl", "TLS", null, null, null, "Timor-Leste", null, "the Democratic Republic of Timor-Leste", null, (short)1 },
                    { 175, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2358), null, null, null, null, null, null, false, "tg", "TGO", null, null, null, "Togo", null, "the Togolese Republic", null, (short)1 },
                    { 176, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2359), null, null, null, null, null, null, false, "tk", "TKL", null, null, null, "Tokelau", null, "Tokelau", null, (short)1 },
                    { 177, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2361), null, null, null, null, null, null, false, "to", "TON", null, null, null, "Tonga", null, "the Kingdom of Tonga", null, (short)1 },
                    { 178, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2362), null, null, null, null, null, null, false, "tt", "TTO", null, null, null, "Trinidad and Tobago", null, "the Republic of Trinidad and Tobago", null, (short)1 },
                    { 179, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2363), null, null, null, null, null, null, false, "tn", "TUN", null, null, null, "Tunisia", null, "the Republic of Tunisia", null, (short)1 },
                    { 180, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2364), null, null, null, null, null, null, false, "tr", "TUR", null, null, null, "Turkey", null, "the Republic of Turkey", null, (short)1 },
                    { 181, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2365), null, null, null, null, null, null, false, "tm", "TKM", null, null, null, "Turkmenistan", null, "Turkmenistan", null, (short)1 },
                    { 182, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2367), null, null, null, null, null, null, false, "tv", "TUV", null, null, null, "Tuvalu", null, "Tuvalu", null, (short)1 },
                    { 183, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2368), null, null, null, null, null, null, false, "ug", "UGA", null, null, null, "Uganda", null, "the Republic of Uganda", null, (short)1 },
                    { 184, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2369), null, null, null, null, null, null, false, "ua", "UKR", null, null, null, "Ukraine", null, "Ukraine", null, (short)1 },
                    { 185, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2370), null, null, null, null, null, null, false, "ae", "ARE", null, null, null, "United Arab Emirates", null, "the United Arab Emirates", null, (short)1 },
                    { 186, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2377), null, null, null, null, null, null, false, "gb", "GBR", null, null, null, "United Kingdom of Great Britain and Northern Ireland", null, "the United Kingdom of Great Britain and Northern Ireland", null, (short)1 },
                    { 187, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2378), null, null, null, null, null, null, false, "tz", "TZA", null, null, null, "United Republic of Tanzania", null, "the United Republic of Tanzania", null, (short)1 },
                    { 188, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2380), null, null, null, null, null, null, false, "us", "USA", null, null, null, "United States of America", null, "the United States of America", null, (short)1 },
                    { 189, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2381), null, null, null, null, null, null, false, "uy", "URY", null, null, null, "Uruguay", null, "the Eastern Republic of Uruguay", null, (short)1 },
                    { 190, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2382), null, null, null, null, null, null, false, "uz", "UZB", null, null, null, "Uzbekistan", null, "the Republic of Uzbekistan", null, (short)1 },
                    { 191, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2383), null, null, null, null, null, null, false, "vu", "VUT", null, null, null, "Vanuatu", null, "the Republic of Vanuatu", null, (short)1 },
                    { 192, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2384), null, null, null, null, null, null, false, "ve", "VEN", null, null, null, "Venezuela (Bolivarian Republic of)", null, "the Bolivarian Republic of Venezuela", null, (short)1 },
                    { 193, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2385), null, null, null, null, null, null, false, "vn", "VNM", null, null, null, "Viet Nam", null, "the Socialist Republic of Viet Nam", null, (short)1 },
                    { 194, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2406), null, null, null, null, null, null, false, "ye", "YEM", null, null, null, "Yemen", null, "the Republic of Yemen", null, (short)1 },
                    { 195, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2408), null, null, null, null, null, null, false, "zm", "ZMB", null, null, null, "Zambia", null, "the Republic of Zambia", null, (short)1 },
                    { 196, new DateTime(2023, 1, 6, 8, 21, 25, 160, DateTimeKind.Utc).AddTicks(2409), null, null, null, null, null, null, false, "zw", "ZWE", null, null, null, "Zimbabwe", null, "the Republic of Zimbabwe", null, (short)1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("52d72a3a-4e78-4948-8070-bcb08d8d5bb7"), null, new DateTime(2023, 1, 6, 8, 21, 25, 169, DateTimeKind.Utc).AddTicks(9762), null, null, null, null, null, false, null, null, null, "client", "CLIENT" },
                    { new Guid("fce4ad58-d747-49d8-9706-b93502d122f5"), null, new DateTime(2023, 1, 6, 8, 21, 25, 161, DateTimeKind.Utc).AddTicks(772), null, null, null, null, null, false, null, null, null, "administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Email", "EmailConfirmed", "EmailToken", "EmailTokenExpires", "IsActive", "IsDeleted", "IsOnline", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordResetAt", "PasswordToken", "PasswordTokenExpires", "PhoneNumber", "PhoneNumberConfirmed", "PhoneNumberToken", "PhoneNumberTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("20b3829e-cce0-43d2-9365-36d3b4563861"), 0, "17d6a617-0b09-4628-95cb-c3a571bdee52", new DateTime(2023, 1, 6, 8, 21, 25, 999, DateTimeKind.Utc).AddTicks(2078), null, null, null, null, null, "admin@wrmc.com", true, null, null, true, false, true, false, null, null, null, null, "ADMIN@WRMC.COM", "ADMIN", "AQAAAAIAAYagAAAAEPHeZ8efNEktN+/CMIo6Axahe5F22gzlBhZLlkRPFLaYGRy2WhNH8Tmu+Esn93C2eA==", null, null, null, null, false, null, null, "b4631992-d70b-47d5-a08e-d08e26e05e41", false, "admin" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Flag", "IsDeleted", "Iso2", "Iso3", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "Numeric", "OfficialName", "ParentId", "RegionType" },
                values: new object[,]
                {
                    { 197, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4737), null, null, null, null, null, null, false, null, "PR", null, null, null, "Puerto Rico", null, null, 188, (short)2 },
                    { 198, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4743), null, null, null, null, null, null, false, null, "MA", null, null, null, "Massachusetts", null, null, 188, (short)2 },
                    { 199, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4744), null, null, null, null, null, null, false, null, "RI", null, null, null, "Rhode Island", null, null, 188, (short)2 },
                    { 200, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4746), null, null, null, null, null, null, false, null, "NH", null, null, null, "New Hampshire", null, null, 188, (short)2 },
                    { 201, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4747), null, null, null, null, null, null, false, null, "ME", null, null, null, "Maine", null, null, 188, (short)2 },
                    { 202, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4749), null, null, null, null, null, null, false, null, "VT", null, null, null, "Vermont", null, null, 188, (short)2 },
                    { 203, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4757), null, null, null, null, null, null, false, null, "CT", null, null, null, "Connecticut", null, null, 188, (short)2 },
                    { 204, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4759), null, null, null, null, null, null, false, null, "NY", null, null, null, "New York", null, null, 188, (short)2 },
                    { 205, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4760), null, null, null, null, null, null, false, null, "NJ", null, null, null, "New Jersey", null, null, 188, (short)2 },
                    { 206, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4763), null, null, null, null, null, null, false, null, "PA", null, null, null, "Pennsylvania", null, null, 188, (short)2 },
                    { 207, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4765), null, null, null, null, null, null, false, null, "DE", null, null, null, "Delaware", null, null, 188, (short)2 },
                    { 208, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4786), null, null, null, null, null, null, false, null, "DC", null, null, null, "District of Columbia", null, null, 188, (short)2 },
                    { 209, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4787), null, null, null, null, null, null, false, null, "VA", null, null, null, "Virginia", null, null, 188, (short)2 },
                    { 210, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4789), null, null, null, null, null, null, false, null, "MD", null, null, null, "Maryland", null, null, 188, (short)2 },
                    { 211, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4790), null, null, null, null, null, null, false, null, "WV", null, null, null, "West Virginia", null, null, 188, (short)2 },
                    { 212, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4791), null, null, null, null, null, null, false, null, "NC", null, null, null, "North Carolina", null, null, 188, (short)2 },
                    { 213, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4792), null, null, null, null, null, null, false, null, "SC", null, null, null, "South Carolina", null, null, 188, (short)2 },
                    { 214, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4794), null, null, null, null, null, null, false, null, "GA", null, null, null, "Georgia", null, null, 188, (short)2 },
                    { 215, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4796), null, null, null, null, null, null, false, null, "FL", null, null, null, "Florida", null, null, 188, (short)2 },
                    { 216, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4797), null, null, null, null, null, null, false, null, "AL", null, null, null, "Alabama", null, null, 188, (short)2 },
                    { 217, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4798), null, null, null, null, null, null, false, null, "TN", null, null, null, "Tennessee", null, null, 188, (short)2 },
                    { 218, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4800), null, null, null, null, null, null, false, null, "MS", null, null, null, "Mississippi", null, null, 188, (short)2 },
                    { 219, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4802), null, null, null, null, null, null, false, null, "KY", null, null, null, "Kentucky", null, null, 188, (short)2 },
                    { 220, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4809), null, null, null, null, null, null, false, null, "OH", null, null, null, "Ohio", null, null, 188, (short)2 },
                    { 221, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4811), null, null, null, null, null, null, false, null, "IN", null, null, null, "Indiana", null, null, 188, (short)2 },
                    { 222, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4812), null, null, null, null, null, null, false, null, "MI", null, null, null, "Michigan", null, null, 188, (short)2 },
                    { 223, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4813), null, null, null, null, null, null, false, null, "IA", null, null, null, "Iowa", null, null, 188, (short)2 },
                    { 224, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4814), null, null, null, null, null, null, false, null, "WI", null, null, null, "Wisconsin", null, null, 188, (short)2 },
                    { 225, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4816), null, null, null, null, null, null, false, null, "MN", null, null, null, "Minnesota", null, null, 188, (short)2 },
                    { 226, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4817), null, null, null, null, null, null, false, null, "SD", null, null, null, "South Dakota", null, null, 188, (short)2 },
                    { 227, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4818), null, null, null, null, null, null, false, null, "ND", null, null, null, "North Dakota", null, null, 188, (short)2 },
                    { 228, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4819), null, null, null, null, null, null, false, null, "MT", null, null, null, "Montana", null, null, 188, (short)2 },
                    { 229, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4821), null, null, null, null, null, null, false, null, "IL", null, null, null, "Illinois", null, null, 188, (short)2 },
                    { 230, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4822), null, null, null, null, null, null, false, null, "MO", null, null, null, "Missouri", null, null, 188, (short)2 },
                    { 231, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4824), null, null, null, null, null, null, false, null, "KS", null, null, null, "Kansas", null, null, 188, (short)2 },
                    { 232, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4825), null, null, null, null, null, null, false, null, "NE", null, null, null, "Nebraska", null, null, 188, (short)2 },
                    { 233, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4826), null, null, null, null, null, null, false, null, "LA", null, null, null, "Louisiana", null, null, 188, (short)2 },
                    { 234, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4827), null, null, null, null, null, null, false, null, "AR", null, null, null, "Arkansas", null, null, 188, (short)2 },
                    { 235, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4880), null, null, null, null, null, null, false, null, "OK", null, null, null, "Oklahoma", null, null, 188, (short)2 },
                    { 236, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4882), null, null, null, null, null, null, false, null, "TX", null, null, null, "Texas", null, null, 188, (short)2 },
                    { 237, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4883), null, null, null, null, null, null, false, null, "CO", null, null, null, "Colorado", null, null, 188, (short)2 },
                    { 238, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4892), null, null, null, null, null, null, false, null, "WY", null, null, null, "Wyoming", null, null, 188, (short)2 },
                    { 239, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4893), null, null, null, null, null, null, false, null, "ID", null, null, null, "Idaho", null, null, 188, (short)2 },
                    { 240, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4894), null, null, null, null, null, null, false, null, "UT", null, null, null, "Utah", null, null, 188, (short)2 },
                    { 241, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4896), null, null, null, null, null, null, false, null, "AZ", null, null, null, "Arizona", null, null, 188, (short)2 },
                    { 242, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4897), null, null, null, null, null, null, false, null, "NM", null, null, null, "New Mexico", null, null, 188, (short)2 },
                    { 243, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4898), null, null, null, null, null, null, false, null, "NV", null, null, null, "Nevada", null, null, 188, (short)2 },
                    { 244, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4899), null, null, null, null, null, null, false, null, "CA", null, null, null, "California", null, null, 188, (short)2 },
                    { 245, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4900), null, null, null, null, null, null, false, null, "HI", null, null, null, "Hawaii", null, null, 188, (short)2 },
                    { 246, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4902), null, null, null, null, null, null, false, null, "OR", null, null, null, "Oregon", null, null, 188, (short)2 },
                    { 247, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4903), null, null, null, null, null, null, false, null, "WA", null, null, null, "Washington", null, null, 188, (short)2 },
                    { 248, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(4904), null, null, null, null, null, null, false, null, "AK", null, null, null, "Alaska", null, null, 188, (short)2 }
                });

            migrationBuilder.InsertData(
                table: "RoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "RoleId" },
                values: new object[,]
                {
                    { 1, "permission", "Global.Availability", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(371), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 2, "permission", "Global.Correction", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(408), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 3, "permission", "Global.Lot", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(418), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 4, "permission", "Global.Notice", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(498), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 5, "permission", "Global.Permission", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(510), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 6, "permission", "Global.Queue", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(543), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 7, "permission", "Global.Role", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(553), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 8, "permission", "Global.Room", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(588), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 9, "permission", "Global.Setting", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(599), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 10, "permission", "Global.Slider", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(609), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 11, "permission", "Global.Staff", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(618), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 12, "permission", "Global.Tasks", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(627), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 13, "permission", "Global.UserRole", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(636), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 14, "permission", "Global.VisitTermination", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(645), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 15, "permission", "Global.AppointmentBehalf", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(654), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 16, "permission", "Global.CheckIn", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(663), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 17, "permission", "Global.Checkout", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(672), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 18, "permission", "Global.Connection", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(682), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 19, "permission", "Global.Explorer", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(691), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 20, "permission", "Global.RegisterBehalf", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(699), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 21, "permission", "Global.Delayed", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(709), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 22, "permission", "Global.CaseReview", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(717), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 23, "permission", "PregnancyTest.Initial", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(745), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 24, "permission", "PregnancyTest.Medical", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(754), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 25, "permission", "PregnancyTest.Demographic", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(782), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 26, "permission", "PregnancyTest.Required", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(793), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 27, "permission", "PregnancyTest.Appointment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(806), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 28, "permission", "PregnancyTest.Social", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(815), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 29, "permission", "PregnancyTest.SocialReview", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(824), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 30, "permission", "PregnancyTest.Decision", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(832), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 31, "permission", "PregnancyTest.ExitSurvey", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(848), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 32, "permission", "PregnancyTest.QaAssignment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(857), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 33, "permission", "PregnancyTest.PaAssignment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(867), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 34, "permission", "PregnancyTest.RequestList", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(876), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 35, "permission", "PregnancyTest.Vulnerability", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(884), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 36, "permission", "PregnancyTest.Spiritual", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(892), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 37, "permission", "PregnancyTest.TestResult", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(901), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 38, "permission", "PregnancyRetest.Medical", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(910), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 39, "permission", "PregnancyRetest.Appointment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(918), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 40, "permission", "PregnancyRetest.Social", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(927), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 41, "permission", "PregnancyRetest.Decision", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(955), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 42, "permission", "PregnancyRetest.Exit", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(965), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 43, "permission", "PregnancyRetest.Assignment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(973), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 44, "permission", "PregnancyRetest.RequestList", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(981), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 45, "permission", "PregnancyRetest.Vulnerability", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(989), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 46, "permission", "PregnancyRetest.Spiritual", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(997), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 47, "permission", "PregnancyRetest.TestResult", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1006), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 48, "permission", "UltrasoundScan.Interview", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1013), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 49, "permission", "UltrasoundScan.Appointment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1021), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 50, "permission", "UltrasoundScan.UExit", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1029), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 51, "permission", "UltrasoundScan.Assignment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1038), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 52, "permission", "UltrasoundScan.RequestList", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1046), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 53, "permission", "UltrasoundScan.UltrasoundReport", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1054), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 54, "permission", "UltrasoundRescan.Interview", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1063), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 55, "permission", "UltrasoundRescan.Appointment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1071), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 56, "permission", "UltrasoundRescan.UExit", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1079), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 57, "permission", "UltrasoundRescan.Assignment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1087), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 58, "permission", "UltrasoundRescan.RequestList", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1095), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 59, "permission", "UltrasoundRescan.UltrasoundReport", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1123), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 60, "permission", "PregnancyOptionsCounseling.Initial", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1133), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 61, "permission", "PregnancyOptionsCounseling.Demographic", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1141), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 62, "permission", "PregnancyOptionsCounseling.medical", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1149), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 63, "permission", "PregnancyOptionsCounseling.Required", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1158), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 64, "permission", "PregnancyOptionsCounseling.appointment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1166), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 65, "permission", "PregnancyOptionsCounseling.exit", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1174), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 66, "permission", "PregnancyOptionsCounseling.assignment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1183), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 67, "permission", "PregnancyOptionsCounseling.information", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1192), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 68, "permission", "PregnancyOptionsCounseling.requestlist", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1200), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 69, "permission", "PostAbortionCounseling.Initial", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1209), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 70, "permission", "PostAbortionCounseling.Demographic", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1217), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 71, "permission", "PostAbortionCounseling.Medical", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1226), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 72, "permission", "PostAbortionCounseling.Required", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1234), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 73, "permission", "PostAbortionCounseling.Appointment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1242), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 74, "permission", "PostAbortionCounseling.Exit", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1287), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 75, "permission", "PostAbortionCounseling.Assignment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1298), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 76, "permission", "PostAbortionCounseling.Information", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1306), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 77, "permission", "PostAbortionCounseling.RequestList", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1315), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 78, "permission", "PregnancyLossCounseling.Initial", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1324), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 79, "permission", "PregnancyLossCounseling.Demographic", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1332), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 80, "permission", "PregnancyLossCounseling.Medical", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1340), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 81, "permission", "PregnancyLossCounseling.Required", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1348), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 82, "permission", "PregnancyLossCounseling.Appointment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1356), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 83, "permission", "PregnancyLossCounseling.Exit", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1364), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 84, "permission", "PregnancyLossCounseling.Assignment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1372), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 85, "permission", "PregnancyLossCounseling.Information", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1381), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 86, "permission", "PregnancyLossCounseling.RequestList", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1389), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 87, "permission", "DiscipleshipCounseling.Initial", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1397), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 88, "permission", "DiscipleshipCounseling.Demographic", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1405), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 89, "permission", "DiscipleshipCounseling.Medical", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1414), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 90, "permission", "DiscipleshipCounseling.Required", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1422), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 91, "permission", "DiscipleshipCounseling.Appointment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1430), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 92, "permission", "DiscipleshipCounseling.Exit", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1459), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 93, "permission", "DiscipleshipCounseling.Assignment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1469), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 94, "permission", "DiscipleshipCounseling.Information", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1477), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 95, "permission", "DiscipleshipCounseling.RequestList", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1486), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 96, "permission", "PrenatalCareInterview.Pregnancy", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1494), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 97, "permission", "PrenatalCareInterview.MedicalHistory", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1502), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 98, "permission", "PrenatalCareInterview.SupportAssessment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1510), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 99, "permission", "clien.prenatalcareinterviewt.Residence", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1519), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 100, "permission", "PrenatalCareInterview.CarrierScreening", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1527), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 101, "permission", "PrenatalCareInterview.Appointment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1536), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 102, "permission", "PrenatalCareInterview.Assignment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1544), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 103, "permission", "PrenatalCareInterview.RequestList", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1553), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 104, "permission", "PrenatalVisits.Appointment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1561), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 105, "permission", "PrenatalVisits.Exit", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1569), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 106, "permission", "PrenatalVisits.Assignment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1577), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 107, "permission", "PrenatalVisits.Prenatal", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1586), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 108, "permission", "PrenatalVisits.RequestList", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1593), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 109, "permission", "PrenatalVisits.Record", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1602), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 110, "permission", "PrenatalVisits.Laboratory", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1640), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 111, "permission", "MaleCounseling.Initial", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1650), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 112, "permission", "MaleCounseling.Demographic", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1658), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 113, "permission", "MaleCounseling.Malemedical", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1666), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 114, "permission", "MaleCounseling.Required", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1675), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 115, "permission", "MaleCounseling.Appointment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1683), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 116, "permission", "MaleCounseling.Exit", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1692), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 117, "permission", "MaleCounseling.MaleAssignment", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1700), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 118, "permission", "MaleCounseling.Medical", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1708), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") },
                    { 119, "permission", "MaleCounseling.MaleInformation", new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(1716), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5") }
                });

            migrationBuilder.InsertData(
                table: "UserAddresses",
                columns: new[] { "Id", "Address", "AddressType", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "IsDefault", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Order", "RegionId", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("115cfbd3-0082-4d44-9eb2-7f1a60998d19"), "Suzy Queue\r\n4455 Landing Lange, APT 4\r\nLouisville, KY 40018-1234", (short)2, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(7085), null, null, null, null, null, null, false, false, null, null, null, 2, null, new Guid("20b3829e-cce0-43d2-9365-36d3b4563861"), "241542123" },
                    { new Guid("38d1a1a0-93a9-4b59-83ee-12e00045f8c0"), "Robert Robertson, 1234 NW Bobcat Lane, St. Robert, MO 65584-5678", (short)1000, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(7092), null, null, null, null, null, null, false, false, null, null, null, 3, null, new Guid("20b3829e-cce0-43d2-9365-36d3b4563861"), "351745121" },
                    { new Guid("73c3996d-8b5e-48bb-8b7a-cdf2285e9710"), "SGT Miranda McAnderson\r\n6543 N 9th Street\r\nAPO, AA 33608-1234", (short)1, new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(5273), null, null, null, null, null, null, true, false, null, null, null, 1, null, new Guid("20b3829e-cce0-43d2-9365-36d3b4563861"), "251742310" }
                });

            migrationBuilder.InsertData(
                table: "UserPhoneNumbers",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "IsDefault", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Order", "PhoneNumber", "PhoneNumberType", "UserId" },
                values: new object[,]
                {
                    { new Guid("286629b8-5c7c-41b9-9721-9635bb27bad3"), new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(8817), null, null, null, null, null, "Bussines Fax", false, false, null, null, null, 2, "5234525867", (short)4, new Guid("20b3829e-cce0-43d2-9365-36d3b4563861") },
                    { new Guid("71b4c392-a045-4407-a41b-37ebf8edcb7e"), new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(7386), null, null, null, null, null, "This is my main mobile", true, false, null, null, null, 1, "2345124454", (short)1, new Guid("20b3829e-cce0-43d2-9365-36d3b4563861") },
                    { new Guid("e75f58df-c765-4f21-8a3f-d1b51de79008"), new DateTime(2023, 1, 6, 8, 21, 25, 170, DateTimeKind.Utc).AddTicks(8828), null, null, null, null, null, "Emergency Contact (my father)", false, false, null, null, null, 3, "8834551820", (short)5, new Guid("20b3829e-cce0-43d2-9365-36d3b4563861") }
                });

            migrationBuilder.InsertData(
                table: "UserProfile",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "EmergencyName", "EmergencyPhone", "FirstName", "Gender", "Height", "IdNumber", "IntroMethodDescription", "IntroMethodId", "IsDeleted", "IsNoticeAccepted", "IsVolunteer", "LastName", "MiddleName", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "ProfileImage", "RaceNationality", "UserId", "Weight" },
                values: new object[] { new Guid("d372a5e8-172e-440d-a3b9-1fae83308d1a"), null, new DateTime(2023, 1, 6, 8, 21, 26, 56, DateTimeKind.Utc).AddTicks(997), null, null, null, null, null, null, null, null, "Test name", (short)1, null, null, null, null, false, null, null, "Test family", null, null, null, null, null, null, new Guid("20b3829e-cce0-43d2-9365-36d3b4563861"), null });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "RoleId", "UserId" },
                values: new object[] { new Guid("70126341-ec06-498d-ab1d-4c7279f4198b"), new DateTime(2023, 1, 6, 8, 21, 26, 73, DateTimeKind.Utc).AddTicks(3630), null, null, null, null, null, false, null, null, null, new Guid("fce4ad58-d747-49d8-9706-b93502d122f5"), new Guid("20b3829e-cce0-43d2-9365-36d3b4563861") });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "Culture", "DarkMode", "DefaultTenantId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "RightToLeft", "Theme", "UserId" },
                values: new object[] { new Guid("67ce4419-2d61-4be9-a333-ef48481af900"), new DateTime(2023, 1, 6, 8, 21, 26, 56, DateTimeKind.Utc).AddTicks(1034), null, null, "en-US", false, null, null, null, null, false, null, null, null, false, "", new Guid("20b3829e-cce0-43d2-9365-36d3b4563861") });

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
                name: "IX_UserSettings_DefaultTenantId",
                table: "UserSettings",
                column: "DefaultTenantId");

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
                name: "Tenant");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
