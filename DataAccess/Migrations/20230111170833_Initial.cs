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
                name: "IntroMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: false),
                    Order = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInfoRequired = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalInfoLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_IntroMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntroMethods_IntroMethods_ParentId",
                        column: x => x.ParentId,
                        principalTable: "IntroMethods",
                        principalColumn: "Id");
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
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectionGroup = table.Column<short>(type: "smallint", nullable: false),
                    SectionType = table.Column<short>(type: "smallint", nullable: false),
                    Visibility = table.Column<short>(type: "smallint", nullable: false),
                    Gender = table.Column<short>(type: "smallint", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    Help = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Command = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiredPolicy = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Sections_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Sections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DefaultTenantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaseNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Order = table.Column<int>(type: "int", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
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
                    Type = table.Column<short>(type: "smallint", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
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
                        name: "FK_UserProfile_IntroMethods_IntroMethodId",
                        column: x => x.IntroMethodId,
                        principalTable: "IntroMethods",
                        principalColumn: "Id");
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
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DarkMode = table.Column<bool>(type: "bit", nullable: false),
                    Culture = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_Users_UserId",
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

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
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
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DemographicIntakes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    InSchool = table.Column<bool>(type: "bit", nullable: true),
                    LastGrade = table.Column<short>(type: "smallint", nullable: true),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<short>(type: "smallint", nullable: true),
                    IsUSCitizen = table.Column<bool>(type: "bit", nullable: true),
                    ImmigrationStatus = table.Column<short>(type: "smallint", nullable: true),
                    LivingArrangement = table.Column<short>(type: "smallint", nullable: true),
                    Employment = table.Column<short>(type: "smallint", nullable: true),
                    Employer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Income = table.Column<short>(type: "smallint", nullable: true),
                    CombinedIncome = table.Column<bool>(type: "bit", nullable: true),
                    HaveInsurance = table.Column<bool>(type: "bit", nullable: true),
                    InsuranceName = table.Column<short>(type: "smallint", nullable: true),
                    MedicaidNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeedInsurance = table.Column<bool>(type: "bit", nullable: true),
                    NumberOfTaxReturn = table.Column<short>(type: "smallint", nullable: true),
                    NumberOfHousehold = table.Column<short>(type: "smallint", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: true),
                    FinancialSupport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AffordPrenatal = table.Column<bool>(type: "bit", nullable: true),
                    UndueBurden = table.Column<bool>(type: "bit", nullable: true),
                    ConduciveRaising = table.Column<bool>(type: "bit", nullable: true),
                    HidePregnancy = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_DemographicIntakes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemographicIntakes_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DemographicIntakes_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DemographicIntakes_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalIntakes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    IsPeriodRemember = table.Column<bool>(type: "bit", nullable: true),
                    LastPeriodDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HaveNormalPeriod = table.Column<bool>(type: "bit", nullable: true),
                    NormalPeriodNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstMenstrualAge = table.Column<short>(type: "smallint", nullable: true),
                    LastSexIntercourse = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherSymptoms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalConditions = table.Column<bool>(type: "bit", nullable: true),
                    MedicalConditionsNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorCare = table.Column<bool>(type: "bit", nullable: true),
                    Medication = table.Column<bool>(type: "bit", nullable: true),
                    MedicationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlackboxMedication = table.Column<bool>(type: "bit", nullable: true),
                    HavePapSmear = table.Column<bool>(type: "bit", nullable: true),
                    LastExaminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UseAlcohol = table.Column<bool>(type: "bit", nullable: true),
                    AlcoholQuitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlcoholFrequency = table.Column<short>(type: "smallint", nullable: true),
                    AlcoholPriorFreq = table.Column<short>(type: "smallint", nullable: true),
                    AlcoholTotalYears = table.Column<short>(type: "smallint", nullable: true),
                    UseTobacco = table.Column<bool>(type: "bit", nullable: true),
                    TobaccoQuitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TobaccoFrequency = table.Column<short>(type: "smallint", nullable: true),
                    TobaccoPriorFreq = table.Column<short>(type: "smallint", nullable: true),
                    TobaccoTotalYears = table.Column<short>(type: "smallint", nullable: true),
                    UseDrugs = table.Column<bool>(type: "bit", nullable: true),
                    DrugsQuitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DrugFrequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugsTotalYears = table.Column<short>(type: "smallint", nullable: true),
                    BirthsQty = table.Column<short>(type: "smallint", nullable: true),
                    MiscarriageQty = table.Column<short>(type: "smallint", nullable: true),
                    AbortionQty = table.Column<short>(type: "smallint", nullable: true),
                    AbortionType = table.Column<short>(type: "smallint", nullable: true),
                    AbortionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AbortionIssues = table.Column<bool>(type: "bit", nullable: true),
                    HavePlanB = table.Column<bool>(type: "bit", nullable: true),
                    PlanBQty = table.Column<short>(type: "smallint", nullable: true),
                    LastPlanBDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HaveBirthControl = table.Column<bool>(type: "bit", nullable: true),
                    BirthControlEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BirthControlType = table.Column<short>(type: "smallint", nullable: true),
                    OtherBirthControlType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthControlLong = table.Column<short>(type: "smallint", nullable: true),
                    SexualActive = table.Column<short>(type: "smallint", nullable: true),
                    SexualPartners = table.Column<short>(type: "smallint", nullable: true),
                    HaveStdTest = table.Column<bool>(type: "bit", nullable: true),
                    StdTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StdTestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StdTestResult = table.Column<bool>(type: "bit", nullable: true),
                    HaveTreatment = table.Column<bool>(type: "bit", nullable: true),
                    PartnerNotified = table.Column<bool>(type: "bit", nullable: true),
                    AdversePrenatal = table.Column<bool>(type: "bit", nullable: true),
                    HaveRapeAbuse = table.Column<bool>(type: "bit", nullable: true),
                    RapeAbuseNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Intentions = table.Column<short>(type: "smallint", nullable: true),
                    AdoptionOption = table.Column<bool>(type: "bit", nullable: true),
                    AbortionRisk = table.Column<short>(type: "smallint", nullable: true),
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
                    table.PrimaryKey("PK_MedicalIntakes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalIntakes_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicalIntakes_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "IsDeleted", "IsReadOnly", "Key", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Value" },
                values: new object[] { new Guid("9cf65d6c-5411-4d44-a846-b1f61bc4e972"), null, null, null, null, null, null, null, false, null, "DefaultConnectionString", null, null, null, "Server=.;Database={0};Integrated Security = True;" });

            migrationBuilder.InsertData(
                table: "Cultures",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "CultureName", "DateSeparator", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "DisplayName", "FirstDayOfWeek", "FullDateTimePattern", "Image", "IsDefault", "IsDeleted", "LongDatePattern", "LongTimePattern", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "MonthDayPattern", "RightToLeft", "ShortDatePattern", "ShortTimePattern", "TimeSeparator", "YearMonthPattern" },
                values: new object[,]
                {
                    { new Guid("6db2b218-567e-4266-8782-78be093250b4"), null, null, null, "en-US", "/", null, null, null, "English", 1, "dddd, MMMM dd, yyyy h:mm:ss tt", "_content/wrmc.RootComponents/assets/media/flags/usa.svg", true, false, "dddd, MMMM dd, yyyy", "HH:mm:ss", null, null, null, "MMMM dd", false, "yyyy/MM/dd", "HH:mm", ":", "MMMM, yyyy" },
                    { new Guid("a7db5686-c621-413c-8fba-496652f07b20"), null, null, null, "fa-IR", "/", null, null, null, "فارسی", 6, "dddd, MMMM dd, yyyy h:mm:ss tt", "_content/wrmc.RootComponents/assets/media/flags/iran.svg", false, false, "dddd, MMMM dd, yyyy ", "HH:mm:ss", null, null, null, "MMMM dd", true, "yyyy/MM/dd", "HH:mm", ":", "MMMM, yyyy" }
                });

            migrationBuilder.InsertData(
                table: "IntroMethods",
                columns: new[] { "Id", "AdditionalInfoLabel", "AdditionalInfoRequired", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "DisplayTitle", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "Order", "ParentId", "Type" },
                values: new object[,]
                {
                    { 1, null, false, null, null, null, null, null, null, "Advertisement", "Advertisement", false, null, null, null, "Advertisement", (short)1, null, (short)0 },
                    { 2, null, false, null, null, null, null, null, null, "Friends/Relatives/Partner", "Friends/Relatives/Partner", false, null, null, null, "FriendsRelativesPartner", (short)8, null, (short)2 },
                    { 3, null, false, null, null, null, null, null, null, "Repeat Client", "Repeat Client", false, null, null, null, "RepeatClient", (short)9, null, (short)2 },
                    { 4, null, false, null, null, null, null, null, null, "Walk-in/Passer By", "Walk-in/Passer By", false, null, null, null, "WalkInPasserBy", (short)10, null, (short)2 },
                    { 5, null, false, null, null, null, null, null, null, "Crisis Pregnancy Centers", "Crisis Pregnancy Centers", false, null, null, null, "CrisisPregnancyCenters", (short)11, null, (short)2 },
                    { 6, null, false, null, null, null, null, null, null, "Option United", "Option United", false, null, null, null, "OptionUnited", (short)12, null, (short)2 },
                    { 7, null, false, null, null, null, null, null, null, "Community Event", "Community Event", false, null, null, null, "CommunityEvent", (short)13, null, (short)2 },
                    { 8, null, false, null, null, null, null, null, null, "Church Event", "Church Event", false, null, null, null, "ChurchEvent", (short)14, null, (short)2 },
                    { 9, null, false, null, null, null, null, null, null, "Baby First Services", "Baby First Services", false, null, null, null, "BabyFirstServices", (short)15, null, (short)2 },
                    { 10, null, false, null, null, null, null, null, null, "Medical Referrals", "Medical Referrals", false, null, null, null, "MedicalReferrals", (short)2, null, (short)0 },
                    { 11, null, false, null, null, null, null, null, null, "Government Agencies", "Government Agencies", false, null, null, null, "GovernmentAgencies", (short)3, null, (short)0 },
                    { 12, null, false, null, null, null, null, null, null, "Alcohol/Drug Rehabs", "Alcohol/Drug Rehabs", false, null, null, null, "AlcoholDrugRehabs", (short)4, null, (short)0 },
                    { 13, null, false, null, null, null, null, null, null, "Shelters", "Shelters", false, null, null, null, "Shelters", (short)5, null, (short)0 },
                    { 14, null, false, null, null, null, null, null, null, "Church Referral", "Church Referral", false, null, null, null, "ChurchReferral", (short)6, null, (short)0 },
                    { 15, null, false, null, null, null, null, null, null, "Abortion Clinic", "Abortion Clinic", false, null, null, null, "AbortionClinic", (short)7, null, (short)0 },
                    { 16, null, false, null, null, null, null, null, null, "Help of Southern Nevada", "Help of Southern Nevada", false, null, null, null, "HelpOfSouthernNevada", (short)16, null, (short)2 }
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
                    { new Guid("65794e9f-091f-4362-b16c-76bb21000d9f"), null, new DateTime(2023, 1, 11, 17, 8, 31, 940, DateTimeKind.Utc).AddTicks(9086), null, null, null, null, null, false, null, null, null, "administrator", "ADMINISTRATOR" },
                    { new Guid("680b73b2-7ec4-4160-8d5f-6d228182c445"), null, new DateTime(2023, 1, 11, 17, 8, 31, 949, DateTimeKind.Utc).AddTicks(9051), null, null, null, null, null, false, null, null, null, "client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Command", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "DisplayTitle", "Gender", "Help", "Image", "IsDeleted", "IsRequired", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "Order", "ParentId", "RequiredPolicy", "SectionGroup", "SectionType", "URI", "Visibility" },
                values: new object[] { new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", null, null, null, null, null, null, "Pregnancy Test", (short)0, "Pregnancy Test and Care Plan", null, false, false, null, null, null, "PregnancyTest", 1, null, "-", (short)0, (short)0, "PregnancyTest", (short)2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DefaultTenantId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Email", "EmailConfirmed", "EmailToken", "EmailTokenExpires", "IsActive", "IsDeleted", "IsOnline", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordResetAt", "PasswordToken", "PasswordTokenExpires", "PhoneNumber", "PhoneNumberConfirmed", "PhoneNumberToken", "PhoneNumberTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("c84184d2-f664-43c0-9f3d-faa10fdf72ac"), 0, "5f6db1aa-d8f3-47a5-8c83-53947aae0f22", new DateTime(2023, 1, 11, 17, 8, 33, 158, DateTimeKind.Utc).AddTicks(4704), null, null, null, null, null, null, "admin@wrmc.com", true, null, null, true, false, true, false, null, null, null, null, "ADMIN@WRMC.COM", "ADMIN", "AQAAAAIAAYagAAAAEMMRxlgq/CMG0nmpqAf4rx7GJ9/8jH7T35FPxY+8JAGB2HjtE4AZ3piUOjYpLJf/Sw==", null, null, null, null, false, null, null, "af21cc70-87e2-4ca5-ace5-575e6a58ed71", false, "admin" });

            migrationBuilder.InsertData(
                table: "IntroMethods",
                columns: new[] { "Id", "AdditionalInfoLabel", "AdditionalInfoRequired", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "DisplayTitle", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "Order", "ParentId", "Type" },
                values: new object[,]
                {
                    { 17, null, false, null, null, null, null, null, null, "Billboards", "Billboards", false, null, null, null, "Billboards", (short)4, 1, (short)2 },
                    { 18, null, false, null, null, null, null, null, null, "Bus Stop Fillers", "Bus Stop Fillers", false, null, null, null, "BusStopFillers", (short)5, 1, (short)2 },
                    { 19, null, false, null, null, null, null, null, null, "Phone book/Directories", "Phone book/Directories", false, null, null, null, "PhoneBookDirectories", (short)6, 1, (short)2 },
                    { 20, "TV Station", true, null, null, null, null, null, null, "TV Commercial", "TV Commercial", false, null, null, null, "TVCommercial", (short)1, 1, (short)2 },
                    { 21, null, false, null, null, null, null, null, null, "Radio Advertisement", "Radio Advertisement", false, null, null, null, "RadioAdvertisement", (short)2, 1, (short)1 },
                    { 22, null, false, null, null, null, null, null, null, "Flyers", "Flyers", false, null, null, null, "Flyers", (short)7, 1, (short)2 },
                    { 23, null, false, null, null, null, null, null, null, "Newspaper", "Newspaper", false, null, null, null, "Newspaper", (short)8, 1, (short)2 },
                    { 24, null, false, null, null, null, null, null, null, "Social Media", "Social Media", false, null, null, null, "SocialMedia", (short)3, 1, (short)1 },
                    { 36, null, false, null, null, null, null, null, null, "Dr. Sauter", "Dr. Sauter", false, null, null, null, "DrSauter", (short)1, 10, (short)2 },
                    { 37, null, false, null, null, null, null, null, null, "Dr. Herrero", "Dr. Herrero", false, null, null, null, "DrHerrero", (short)2, 10, (short)2 },
                    { 38, null, false, null, null, null, null, null, null, "Dr. Strebel", "Dr. Strebel", false, null, null, null, "DrStrebel", (short)3, 10, (short)2 },
                    { 39, null, false, null, null, null, null, null, null, "UNLV Medicine", "UNLV Medicine", false, null, null, null, "UNLVMedicine", (short)4, 10, (short)2 },
                    { 40, null, false, null, null, null, null, null, null, "Baby Steps UMC", "Baby Steps UMC", false, null, null, null, "BabyStepsUMC", (short)5, 10, (short)2 },
                    { 41, null, false, null, null, null, null, null, null, "Sunny Babies", "Sunny Babies", false, null, null, null, "SunnyBabies", (short)6, 10, (short)2 },
                    { 42, null, false, null, null, null, null, null, null, "Mountain View Hospital", "Mountain View Hospital", false, null, null, null, "MountainViewHospital", (short)7, 10, (short)2 },
                    { 43, null, false, null, null, null, null, null, null, "Health Department", "Health Department", false, null, null, null, "HealthDepartment", (short)8, 10, (short)2 },
                    { 44, null, false, null, null, null, null, null, null, "Welfare", "Welfare", false, null, null, null, "Welfare", (short)1, 11, (short)2 },
                    { 45, null, false, null, null, null, null, null, null, "Medicaid", "Medicaid", false, null, null, null, "Medicaid", (short)2, 11, (short)2 },
                    { 46, null, false, null, null, null, null, null, null, "WIC", "WIC", false, null, null, null, "WIC", (short)3, 11, (short)2 },
                    { 47, null, false, null, null, null, null, null, null, "Department of Child and Family Services", "Department of Child and Family Services", false, null, null, null, "ChildFamilyServices", (short)4, 11, (short)2 },
                    { 48, null, false, null, null, null, null, null, null, "Nevada 211", "Nevada 211", false, null, null, null, "Nevada211", (short)5, 11, (short)2 },
                    { 49, null, false, null, null, null, null, null, null, "West Care Rehab", "West Care Rehab", false, null, null, null, "WestCareRehab", (short)1, 12, (short)2 },
                    { 50, null, false, null, null, null, null, null, null, "Center for Behavioral Health", "Center for Behavioral Health", false, null, null, null, "CenterForBehavioralHealth", (short)2, 12, (short)2 },
                    { 51, null, false, null, null, null, null, null, null, "Other", "Other", false, null, null, null, "OtherAlcoholDrugRehabs", (short)3, 12, (short)2 },
                    { 52, null, false, null, null, null, null, null, null, "Las Vegas Rescue Mission", "Las Vegas Rescue Mission", false, null, null, null, "LasVegasRescueMission", (short)1, 13, (short)2 },
                    { 53, null, false, null, null, null, null, null, null, "Shade Tree", "Shade Tree", false, null, null, null, "ShadeTree", (short)2, 13, (short)2 },
                    { 54, null, false, null, null, null, null, null, null, "SafeNest", "SafeNest", false, null, null, null, "SafeNest", (short)3, 13, (short)2 },
                    { 55, null, false, null, null, null, null, null, null, "Nevada Youth Partnership", "Nevada Youth Partnership", false, null, null, null, "NevadaYouthPartnership", (short)4, 13, (short)2 },
                    { 56, null, false, null, null, null, null, null, null, "Other", "Other", false, null, null, null, "Other", (short)5, 13, (short)2 },
                    { 57, null, false, null, null, null, null, null, null, "Grace Point Church", "Grace Point Church", false, null, null, null, "Grace Point Church", (short)1, 14, (short)2 },
                    { 58, null, false, null, null, null, null, null, null, "Green Valley Baptist", "Green Valley Baptist", false, null, null, null, "Green Valley Baptist", (short)2, 14, (short)2 },
                    { 59, null, false, null, null, null, null, null, null, "Green Valley Christian Center", "Green Valley Christian Center", false, null, null, null, "Green Valley Christian Center", (short)3, 14, (short)2 },
                    { 60, null, false, null, null, null, null, null, null, "Harvest Life Christian Fellowship", "Harvest Life Christian Fellowship", false, null, null, null, "Harvest Life Christian Fellowship", (short)4, 14, (short)2 },
                    { 61, null, false, null, null, null, null, null, null, "Highland Hills Baptist", "Highland Hills Baptist", false, null, null, null, "Highland Hills Baptist", (short)5, 14, (short)2 },
                    { 62, null, false, null, null, null, null, null, null, "Hope Church", "Hope Church", false, null, null, null, "Hope Church", (short)6, 14, (short)2 },
                    { 63, null, false, null, null, null, null, null, null, "Iglesia Agua Viva", "Iglesia Agua Viva", false, null, null, null, "Iglesia Agua Viva", (short)7, 14, (short)2 },
                    { 64, null, false, null, null, null, null, null, null, "Iglesia Bautista Pan De Vida", "Iglesia Bautista Pan De Vida", false, null, null, null, "Iglesia Bautista Pan De Vida", (short)8, 14, (short)2 },
                    { 65, null, false, null, null, null, null, null, null, "International Church of Las Vegas", "International Church of Las Vegas", false, null, null, null, "International Church of Las Vegas", (short)9, 14, (short)2 },
                    { 66, null, false, null, null, null, null, null, null, "Jesus the Good Shepard Church", "Jesus the Good Shepard Church", false, null, null, null, "Jesus the Good Shepard Church", (short)10, 14, (short)2 },
                    { 67, null, false, null, null, null, null, null, null, "Lake Mead Church", "Lake Mead Church", false, null, null, null, "Lake Mead Church", (short)11, 14, (short)2 },
                    { 68, null, false, null, null, null, null, null, null, "Las Vegas Bible Church", "Las Vegas Bible Church", false, null, null, null, "Las Vegas Bible Church", (short)12, 14, (short)2 },
                    { 69, null, false, null, null, null, null, null, null, "Las Vegas Church of the Nazarene", "Las Vegas Church of the Nazarene", false, null, null, null, "Las Vegas Church of the Nazarene", (short)13, 14, (short)2 },
                    { 70, null, false, null, null, null, null, null, null, "Life Baptist Church", "Life Baptist Church", false, null, null, null, "Life Baptist Church", (short)14, 14, (short)2 },
                    { 71, null, false, null, null, null, null, null, null, "Life Springs Christian Church", "Life Springs Christian Church", false, null, null, null, "Life Springs Christian Church", (short)15, 14, (short)2 },
                    { 72, null, false, null, null, null, null, null, null, "Living Grace Foursquare Church", "Living Grace Foursquare Church", false, null, null, null, "Living Grace Foursquare Church", (short)16, 14, (short)2 },
                    { 73, null, false, null, null, null, null, null, null, "Meadows Fellowship Christian Church", "Meadows Fellowship Christian Church", false, null, null, null, "Meadows Fellowship Christian Church", (short)17, 14, (short)2 },
                    { 74, null, false, null, null, null, null, null, null, "Messiah's Christian Fellowship", "Messiah's Christian Fellowship", false, null, null, null, "Messiah's Christian Fellowship", (short)18, 14, (short)2 },
                    { 75, null, false, null, null, null, null, null, null, "Moapa Christian Church", "Moapa Christian Church", false, null, null, null, "Moapa Christian Church", (short)19, 14, (short)2 },
                    { 76, null, false, null, null, null, null, null, null, "Mountain View Lutheran Church", "Mountain View Lutheran Church", false, null, null, null, "Mountain View Lutheran Church", (short)20, 14, (short)2 },
                    { 77, null, false, null, null, null, null, null, null, "Mountaintop Faith Ministries", "Mountaintop Faith Ministries", false, null, null, null, "Mountaintop Faith Ministries", (short)21, 14, (short)2 },
                    { 78, null, false, null, null, null, null, null, null, "Mt. Charleston Baptist Church", "Mt. Charleston Baptist Church", false, null, null, null, "Mt. Charleston Baptist Church", (short)22, 14, (short)2 },
                    { 79, null, false, null, null, null, null, null, null, "Neighborhood Church", "Neighborhood Church", false, null, null, null, "Neighborhood Church", (short)23, 14, (short)2 },
                    { 80, null, false, null, null, null, null, null, null, "Nellis Baptist Church", "Nellis Baptist Church", false, null, null, null, "Nellis Baptist Church", (short)24, 14, (short)2 },
                    { 81, null, false, null, null, null, null, null, null, "New Day Christian Church", "New Day Christian Church", false, null, null, null, "New Day Christian Church", (short)25, 14, (short)2 },
                    { 82, null, false, null, null, null, null, null, null, "No church stated", "No church stated", false, null, null, null, "No church stated", (short)26, 14, (short)2 },
                    { 83, null, false, null, null, null, null, null, null, "North Las Vegas Baptist Church", "North Las Vegas Baptist Church", false, null, null, null, "North Las Vegas Baptist Church", (short)27, 14, (short)2 },
                    { 84, null, false, null, null, null, null, null, null, "Northstar Baptist Church", "Northstar Baptist Church", false, null, null, null, "Northstar Baptist Church", (short)28, 14, (short)2 },
                    { 85, null, false, null, null, null, null, null, null, "Oasis Baptist Church", "Oasis Baptist Church", false, null, null, null, "Oasis Baptist Church", (short)29, 14, (short)2 },
                    { 86, null, false, null, null, null, null, null, null, "Oasis Christian Church", "Oasis Christian Church", false, null, null, null, "Oasis Christian Church", (short)30, 14, (short)2 },
                    { 87, null, false, null, null, null, null, null, null, "Our Lady of Las Vegas Catholic Church", "Our Lady of Las Vegas Catholic Church", false, null, null, null, "Our Lady of Las Vegas Catholic Church", (short)31, 14, (short)2 },
                    { 88, null, false, null, null, null, null, null, null, "Our Savior's Lutheran Church", "Our Savior's Lutheran Church", false, null, null, null, "Our Savior's Lutheran Church", (short)32, 14, (short)2 },
                    { 89, null, false, null, null, null, null, null, null, "Paradise Church", "Paradise Church", false, null, null, null, "Paradise Church", (short)33, 14, (short)2 },
                    { 90, null, false, null, null, null, null, null, null, "Prince of Peace", "Prince of Peace", false, null, null, null, "Prince of Peace", (short)34, 14, (short)2 },
                    { 91, null, false, null, null, null, null, null, null, "Providence Reformed Church", "Providence Reformed Church", false, null, null, null, "Providence Reformed Church", (short)35, 14, (short)2 },
                    { 92, null, false, null, null, null, null, null, null, "Remnant Ministries", "Remnant Ministries", false, null, null, null, "Remnant Ministries", (short)36, 14, (short)2 },
                    { 93, null, false, null, null, null, null, null, null, "Shadow Hills Church", "Shadow Hills Church", false, null, null, null, "Shadow Hills Church", (short)37, 14, (short)2 },
                    { 94, null, false, null, null, null, null, null, null, "South Hills Church Community", "South Hills Church Community", false, null, null, null, "South Hills Church Community", (short)38, 14, (short)2 },
                    { 95, null, false, null, null, null, null, null, null, "Southern Hills Baptist Church", "Southern Hills Baptist Church", false, null, null, null, "Southern Hills Baptist Church", (short)39, 14, (short)2 },
                    { 96, null, false, null, null, null, null, null, null, "Spring Valley Baptist Church", "Spring Valley Baptist Church", false, null, null, null, "Spring Valley Baptist Church", (short)40, 14, (short)2 },
                    { 97, null, false, null, null, null, null, null, null, "St. Anthony of Padua Catholic Church", "St. Anthony of Padua Catholic Church", false, null, null, null, "St. Anthony of Padua Catholic Church", (short)41, 14, (short)2 },
                    { 98, null, false, null, null, null, null, null, null, "St. Bridget Catholic Church", "St. Bridget Catholic Church", false, null, null, null, "St. Bridget Catholic Church", (short)42, 14, (short)2 },
                    { 99, null, false, null, null, null, null, null, null, "St. Francis of Assisi Catholic Church", "St. Francis of Assisi Catholic Church", false, null, null, null, "St. Francis of Assisi Catholic Church", (short)43, 14, (short)2 },
                    { 100, null, false, null, null, null, null, null, null, "St. John Neumann Roman Catholic Church", "St. John Neumann Roman Catholic Church", false, null, null, null, "St. John Neumann Roman Catholic Church", (short)44, 14, (short)2 },
                    { 101, null, false, null, null, null, null, null, null, "St. Joseph Husband of Mary Catholic Church", "St. Joseph Husband of Mary Catholic Church", false, null, null, null, "St. Joseph Husband of Mary Catholic Church", (short)45, 14, (short)2 },
                    { 102, null, false, null, null, null, null, null, null, "St. Thomas Moore Catholic Church", "St. Thomas Moore Catholic Church", false, null, null, null, "St. Thomas Moore Catholic Church", (short)46, 14, (short)2 },
                    { 103, null, false, null, null, null, null, null, null, "St. Viator's", "St. Viator's", false, null, null, null, "St. Viator's", (short)47, 14, (short)2 },
                    { 104, null, false, null, null, null, null, null, null, "Summerlin Community Church", "Summerlin Community Church", false, null, null, null, "Summerlin Community Church", (short)48, 14, (short)2 },
                    { 105, null, false, null, null, null, null, null, null, "The Church @ Lake Mead", "The Church @ Lake Mead", false, null, null, null, "The Church @ Lake Mead", (short)49, 14, (short)2 },
                    { 106, null, false, null, null, null, null, null, null, "The Church Las Vegas", "The Church Las Vegas", false, null, null, null, "The Church Las Vegas", (short)50, 14, (short)2 },
                    { 107, null, false, null, null, null, null, null, null, "The Crossing Church", "The Crossing Church", false, null, null, null, "The Crossing Church", (short)51, 14, (short)2 },
                    { 108, null, false, null, null, null, null, null, null, "The River A Christian Church", "The River A Christian Church", false, null, null, null, "The River A Christian Church", (short)52, 14, (short)2 },
                    { 109, null, false, null, null, null, null, null, null, "Trinity Life", "Trinity Life", false, null, null, null, "Trinity Life", (short)53, 14, (short)2 },
                    { 110, null, false, null, null, null, null, null, null, "Trinity Life", "Trinity Life", false, null, null, null, "Trinity Life", (short)54, 14, (short)2 },
                    { 111, null, false, null, null, null, null, null, null, "Twin Lakes Baptist Church", "Twin Lakes Baptist Church", false, null, null, null, "Twin Lakes Baptist Church", (short)55, 14, (short)2 },
                    { 112, null, false, null, null, null, null, null, null, "Valley Vegas Church", "Valley Vegas Church", false, null, null, null, "Valley Vegas Church", (short)56, 14, (short)2 },
                    { 113, null, false, null, null, null, null, null, null, "Wagon Wheel Missionary Baptist", "Wagon Wheel Missionary Baptist", false, null, null, null, "Wagon Wheel Missionary Baptist", (short)57, 14, (short)2 },
                    { 114, null, false, null, null, null, null, null, null, "Word of Life", "Word of Life", false, null, null, null, "Word of Life", (short)58, 14, (short)2 },
                    { 115, null, false, null, null, null, null, null, null, "Calvary Chapel Las Vegas", "Calvary Chapel Las Vegas", false, null, null, null, "Calvary Chapel Las Vegas", (short)59, 14, (short)2 },
                    { 116, null, false, null, null, null, null, null, null, "Calvary Chapel Lone Mountain", "Calvary Chapel Lone Mountain", false, null, null, null, "Calvary Chapel Lone Mountain", (short)60, 14, (short)2 },
                    { 117, null, false, null, null, null, null, null, null, "Calvary Chapel Henderson", "Calvary Chapel Henderson", false, null, null, null, "Calvary Chapel Henderson", (short)61, 14, (short)2 },
                    { 118, null, false, null, null, null, null, null, null, "Calvary Chapel Boulder City", "Calvary Chapel Boulder City", false, null, null, null, "Calvary Chapel Boulder City", (short)62, 14, (short)2 },
                    { 119, null, false, null, null, null, null, null, null, "Cornerstone Church", "Cornerstone Church", false, null, null, null, "Cornerstone Church", (short)63, 14, (short)2 },
                    { 120, null, false, null, null, null, null, null, null, "Canyon Ridge Church", "Canyon Ridge Church", false, null, null, null, "Canyon Ridge Church", (short)64, 14, (short)2 },
                    { 121, null, false, null, null, null, null, null, null, "Oasis Church", "Oasis Church", false, null, null, null, "Oasis Church", (short)65, 14, (short)2 },
                    { 122, null, false, null, null, null, null, null, null, "Life Church", "Life Church", false, null, null, null, "Life Church", (short)66, 14, (short)2 },
                    { 123, null, false, null, null, null, null, null, null, "Hope Church", "Hope Church", false, null, null, null, "Hope Church", (short)67, 14, (short)2 },
                    { 124, null, false, null, null, null, null, null, null, "Meadow Mesa", "Meadow Mesa", false, null, null, null, "Meadow Mesa", (short)68, 14, (short)2 },
                    { 125, null, false, null, null, null, null, null, null, "Walk Church", "Walk Church", false, null, null, null, "Walk Church", (short)69, 14, (short)2 },
                    { 126, null, false, null, null, null, null, null, null, "The Crossing", "The Crossing", false, null, null, null, "The Crossing", (short)70, 14, (short)2 },
                    { 127, null, false, null, null, null, null, null, null, "Bethany Baptist", "Bethany Baptist", false, null, null, null, "Bethany Baptist", (short)71, 14, (short)2 },
                    { 128, null, false, null, null, null, null, null, null, "Faith Lutheran", "Faith Lutheran", false, null, null, null, "Faith Lutheran", (short)72, 14, (short)2 },
                    { 129, null, false, null, null, null, null, null, null, "St. Joseph Husband of Mary", "St. Joseph Husband of Mary", false, null, null, null, "St. Joseph Husband of Mary", (short)73, 14, (short)2 },
                    { 130, null, false, null, null, null, null, null, null, "St Thomas Moore", "St Thomas Moore", false, null, null, null, "St Thomas Moore", (short)74, 14, (short)2 },
                    { 131, null, false, null, null, null, null, null, null, "St. Frances Assisi", "St. Frances Assisi", false, null, null, null, "St. Frances Assisi", (short)75, 14, (short)2 },
                    { 132, null, false, null, null, null, null, null, null, "Grace Point", "Grace Point", false, null, null, null, "Grace Point", (short)76, 14, (short)2 },
                    { 133, null, false, null, null, null, null, null, null, "Grace Bible Fellowship", "Grace Bible Fellowship", false, null, null, null, "Grace Bible Fellowship", (short)77, 14, (short)2 },
                    { 134, null, false, null, null, null, null, null, null, "Anthem Church", "Anthem Church", false, null, null, null, "Anthem Church", (short)78, 14, (short)2 },
                    { 135, null, false, null, null, null, null, null, null, "Green Valley Baptist", "Green Valley Baptist", false, null, null, null, "Green Valley Baptist", (short)79, 14, (short)2 },
                    { 136, null, false, null, null, null, null, null, null, "Other", "Other", false, null, null, null, "Other", (short)80, 14, (short)2 },
                    { 137, null, false, null, null, null, null, null, null, "Planned Parenthood", "Planned Parenthood", false, null, null, null, "Planned Parenthood", (short)1, 15, (short)2 },
                    { 138, null, false, null, null, null, null, null, null, "Birth Control Center", "Birth Control Center", false, null, null, null, "Birth Control Center", (short)2, 15, (short)2 },
                    { 139, null, false, null, null, null, null, null, null, "Other", "Other", false, null, null, null, "Other", (short)3, 15, (short)2 }
                });

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
                    { 1, "permission", "Global.Availability", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(203), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 2, "permission", "Global.Correction", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(238), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 3, "permission", "Global.Lot", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(247), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 4, "permission", "Global.Notice", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(254), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 5, "permission", "Global.Permission", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(282), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 6, "permission", "Global.Queue", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(292), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 7, "permission", "Global.Role", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(300), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 8, "permission", "Global.Room", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(356), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 9, "permission", "Global.Setting", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(365), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 10, "permission", "Global.Slider", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(373), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 11, "permission", "Global.Staff", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(380), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 12, "permission", "Global.Tasks", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(387), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 13, "permission", "Global.UserRole", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(394), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 14, "permission", "Global.VisitTermination", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(400), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 15, "permission", "Global.AppointmentBehalf", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(407), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 16, "permission", "Global.CheckIn", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(414), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 17, "permission", "Global.Checkout", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(421), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 18, "permission", "Global.Connection", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(428), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 19, "permission", "Global.Explorer", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(435), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 20, "permission", "Global.RegisterBehalf", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(442), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 21, "permission", "Global.Delayed", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(449), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 22, "permission", "Global.CaseReview", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(477), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 23, "permission", "PregnancyTest.Initial", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(503), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 24, "permission", "PregnancyTest.Medical", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(510), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 25, "permission", "PregnancyTest.Demographic", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(517), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 26, "permission", "PregnancyTest.Required", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(527), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 27, "permission", "PregnancyTest.Appointment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(536), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 28, "permission", "PregnancyTest.Social", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(543), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 29, "permission", "PregnancyTest.SocialReview", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(551), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 30, "permission", "PregnancyTest.Decision", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(559), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 31, "permission", "PregnancyTest.ExitSurvey", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(575), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 32, "permission", "PregnancyTest.QaAssignment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(582), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 33, "permission", "PregnancyTest.PaAssignment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(589), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 34, "permission", "PregnancyTest.RequestList", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(596), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 35, "permission", "PregnancyTest.Vulnerability", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(603), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 36, "permission", "PregnancyTest.Spiritual", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(610), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 37, "permission", "PregnancyTest.TestResult", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(617), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 38, "permission", "PregnancyRetest.Medical", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(643), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 39, "permission", "PregnancyRetest.Appointment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(652), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 40, "permission", "PregnancyRetest.Social", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(660), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 41, "permission", "PregnancyRetest.Decision", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(666), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 42, "permission", "PregnancyRetest.Exit", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(673), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 43, "permission", "PregnancyRetest.Assignment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(680), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 44, "permission", "PregnancyRetest.RequestList", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(687), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 45, "permission", "PregnancyRetest.Vulnerability", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(694), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 46, "permission", "PregnancyRetest.Spiritual", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(702), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 47, "permission", "PregnancyRetest.TestResult", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(709), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 48, "permission", "UltrasoundScan.Interview", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(715), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 49, "permission", "UltrasoundScan.Appointment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(722), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 50, "permission", "UltrasoundScan.UExit", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(729), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 51, "permission", "UltrasoundScan.Assignment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(736), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 52, "permission", "UltrasoundScan.RequestList", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(743), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 53, "permission", "UltrasoundScan.UltrasoundReport", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(750), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 54, "permission", "UltrasoundRescan.Interview", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(757), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 55, "permission", "UltrasoundRescan.Appointment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(765), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 56, "permission", "UltrasoundRescan.UExit", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(792), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 57, "permission", "UltrasoundRescan.Assignment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(799), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 58, "permission", "UltrasoundRescan.RequestList", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(806), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 59, "permission", "UltrasoundRescan.UltrasoundReport", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(813), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 60, "permission", "PregnancyOptionsCounseling.Initial", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(820), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 61, "permission", "PregnancyOptionsCounseling.Demographic", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(826), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 62, "permission", "PregnancyOptionsCounseling.medical", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(833), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 63, "permission", "PregnancyOptionsCounseling.Required", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(840), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 64, "permission", "PregnancyOptionsCounseling.appointment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(847), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 65, "permission", "PregnancyOptionsCounseling.exit", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(854), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 66, "permission", "PregnancyOptionsCounseling.assignment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(861), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 67, "permission", "PregnancyOptionsCounseling.information", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(868), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 68, "permission", "PregnancyOptionsCounseling.requestlist", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(875), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 69, "permission", "PostAbortionCounseling.Initial", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(881), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 70, "permission", "PostAbortionCounseling.Demographic", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(888), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 71, "permission", "PostAbortionCounseling.Medical", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(914), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 72, "permission", "PostAbortionCounseling.Required", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(924), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 73, "permission", "PostAbortionCounseling.Appointment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(931), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 74, "permission", "PostAbortionCounseling.Exit", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(938), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 75, "permission", "PostAbortionCounseling.Assignment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(944), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 76, "permission", "PostAbortionCounseling.Information", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(951), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 77, "permission", "PostAbortionCounseling.RequestList", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(959), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 78, "permission", "PregnancyLossCounseling.Initial", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(965), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 79, "permission", "PregnancyLossCounseling.Demographic", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(972), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 80, "permission", "PregnancyLossCounseling.Medical", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(979), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 81, "permission", "PregnancyLossCounseling.Required", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(986), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 82, "permission", "PregnancyLossCounseling.Appointment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(993), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 83, "permission", "PregnancyLossCounseling.Exit", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1000), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 84, "permission", "PregnancyLossCounseling.Assignment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1006), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 85, "permission", "PregnancyLossCounseling.Information", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1013), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 86, "permission", "PregnancyLossCounseling.RequestList", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1020), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 87, "permission", "DiscipleshipCounseling.Initial", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1027), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 88, "permission", "DiscipleshipCounseling.Demographic", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1034), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 89, "permission", "DiscipleshipCounseling.Medical", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1061), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 90, "permission", "DiscipleshipCounseling.Required", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1069), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 91, "permission", "DiscipleshipCounseling.Appointment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1076), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 92, "permission", "DiscipleshipCounseling.Exit", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1083), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 93, "permission", "DiscipleshipCounseling.Assignment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1090), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 94, "permission", "DiscipleshipCounseling.Information", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1097), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 95, "permission", "DiscipleshipCounseling.RequestList", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1104), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 96, "permission", "PrenatalCareInterview.Pregnancy", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1110), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 97, "permission", "PrenatalCareInterview.MedicalHistory", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1118), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 98, "permission", "PrenatalCareInterview.SupportAssessment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1125), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 99, "permission", "clien.prenatalcareinterviewt.Residence", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1131), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 100, "permission", "PrenatalCareInterview.CarrierScreening", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1138), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 101, "permission", "PrenatalCareInterview.Appointment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1145), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 102, "permission", "PrenatalCareInterview.Assignment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1152), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 103, "permission", "PrenatalCareInterview.RequestList", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1159), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 104, "permission", "PrenatalVisits.Appointment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1165), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 105, "permission", "PrenatalVisits.Exit", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1172), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 106, "permission", "PrenatalVisits.Assignment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1198), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 107, "permission", "PrenatalVisits.Prenatal", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1206), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 108, "permission", "PrenatalVisits.RequestList", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1213), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 109, "permission", "PrenatalVisits.Record", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1220), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 110, "permission", "PrenatalVisits.Laboratory", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1227), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 111, "permission", "MaleCounseling.Initial", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1234), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 112, "permission", "MaleCounseling.Demographic", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1241), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 113, "permission", "MaleCounseling.Malemedical", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1248), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 114, "permission", "MaleCounseling.Required", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1254), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 115, "permission", "MaleCounseling.Appointment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1261), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 116, "permission", "MaleCounseling.Exit", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1268), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 117, "permission", "MaleCounseling.MaleAssignment", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1275), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 118, "permission", "MaleCounseling.Medical", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1281), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") },
                    { 119, "permission", "MaleCounseling.MaleInformation", new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(1288), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f") }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Command", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "DisplayTitle", "Gender", "Help", "Image", "IsDeleted", "IsRequired", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "Order", "ParentId", "RequiredPolicy", "SectionGroup", "SectionType", "URI", "Visibility" },
                values: new object[,]
                {
                    { new Guid("00000001-6df9-4ecb-86c8-000000000001"), "-", null, null, null, null, null, null, "Step 1", (short)0, "this is step 1", null, false, true, null, null, null, "Step1", 1, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, "-", (short)2 },
                    { new Guid("00000002-6df9-4ecb-86c8-000000000002"), "-", null, null, null, null, null, null, "Step 2", (short)0, "this is step 2", null, false, true, null, null, null, "Step2", 2, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, "-", (short)2 },
                    { new Guid("00000003-6df9-4ecb-86c8-000000000003"), "-", null, null, null, null, null, null, "Step 3", (short)0, "this is step 3", null, false, true, null, null, null, "Step3", 3, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, "-", (short)2 },
                    { new Guid("00000004-6df9-4ecb-86c8-000000000004"), "-", null, null, null, null, null, null, "Step 4", (short)0, "this is step 4", null, false, true, null, null, null, "Step4", 4, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, "-", (short)2 },
                    { new Guid("00000005-6df9-4ecb-86c8-000000000005"), "-", null, null, null, null, null, null, "Step 5", (short)0, "this is step 5", null, false, true, null, null, null, "Step5", 5, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, "-", (short)2 },
                    { new Guid("00000006-6df9-4ecb-86c8-000000000006"), "-", null, null, null, null, null, null, "Step 6", (short)0, "this is step 6", null, false, true, null, null, null, "Step6", 6, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, "-", (short)2 },
                    { new Guid("00000007-6df9-4ecb-86c8-000000000007"), "-", null, null, null, null, null, null, "Step 7", (short)0, "this is step 7", null, false, true, null, null, null, "Step7", 7, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, "-", (short)2 },
                    { new Guid("00000008-6df9-4ecb-86c8-000000000008"), "-", null, null, null, null, null, null, "Step 8", (short)0, "this is step 8", null, false, true, null, null, null, "Step8", 8, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, "-", (short)2 },
                    { new Guid("00000009-6df9-4ecb-86c8-000000000009"), "-", null, null, null, null, null, null, "Step 9", (short)0, "this is step 9", null, false, true, null, null, null, "Step9", 9, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, "-", (short)2 },
                    { new Guid("00000010-6df9-4ecb-86c8-000000000010"), "-", null, null, null, null, null, null, "Step 10", (short)0, "this is step 10", null, false, true, null, null, null, "Step10", 10, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, "-", (short)2 },
                    { new Guid("00000011-6df9-4ecb-86c8-000000000011"), "-", null, null, null, null, null, null, "Step 11", (short)0, "this is step 11", null, false, true, null, null, null, "Step11", 11, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, "-", (short)2 }
                });

            migrationBuilder.InsertData(
                table: "UserAddresses",
                columns: new[] { "Id", "Address", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "IsDefault", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Order", "RegionId", "Type", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("a116a72a-8967-4bf3-9492-9fcf942cf594"), "SGT Miranda McAnderson\r\n6543 N 9th Street\r\nAPO, AA 33608-1234", null, null, null, null, null, null, null, true, false, null, null, null, 1, null, (short)1, new Guid("c84184d2-f664-43c0-9f3d-faa10fdf72ac"), "251742310" },
                    { new Guid("adb7513e-19c6-4717-9fa2-737342cb41f7"), "Robert Robertson, 1234 NW Bobcat Lane, St. Robert, MO 65584-5678", null, null, null, null, null, null, null, false, false, null, null, null, 3, null, (short)1000, new Guid("c84184d2-f664-43c0-9f3d-faa10fdf72ac"), "351745121" },
                    { new Guid("c2c2cbb8-cfba-427e-b6f2-65e0e924a6e2"), "Suzy Queue\r\n4455 Landing Lange, APT 4\r\nLouisville, KY 40018-1234", null, null, null, null, null, null, null, false, false, null, null, null, 2, null, (short)2, new Guid("c84184d2-f664-43c0-9f3d-faa10fdf72ac"), "241542123" }
                });

            migrationBuilder.InsertData(
                table: "UserPhoneNumbers",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "IsDefault", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Order", "PhoneNumber", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("022879c0-a1e0-41ad-b7a3-e755eefd2fbe"), null, null, null, null, null, null, "Bussines Fax", false, false, null, null, null, 2, "5234525867", (short)4, new Guid("c84184d2-f664-43c0-9f3d-faa10fdf72ac") },
                    { new Guid("9ae54f4b-6e01-4ab5-adf9-af795d107790"), null, null, null, null, null, null, "This is my main mobile", true, false, null, null, null, 1, "2345124454", (short)1, new Guid("c84184d2-f664-43c0-9f3d-faa10fdf72ac") },
                    { new Guid("c748b13e-33c0-449f-8c25-12866f664450"), null, null, null, null, null, null, "Emergency Contact (my father)", false, false, null, null, null, 3, "8834551820", (short)5, new Guid("c84184d2-f664-43c0-9f3d-faa10fdf72ac") }
                });

            migrationBuilder.InsertData(
                table: "UserProfile",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "EmergencyName", "EmergencyPhone", "FirstName", "Gender", "Height", "IdNumber", "IntroMethodDescription", "IntroMethodId", "IsDeleted", "IsNoticeAccepted", "IsVolunteer", "LastName", "MiddleName", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "ProfileImage", "RaceNationality", "UserId", "Weight" },
                values: new object[] { new Guid("6b091a7b-ded8-47a3-baf9-5d5904a8baf0"), null, null, null, null, null, null, null, null, null, null, "Test name", (short)1, null, null, null, null, false, null, null, "Test family", null, null, null, null, null, null, new Guid("c84184d2-f664-43c0-9f3d-faa10fdf72ac"), null });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "RoleId", "UserId" },
                values: new object[] { new Guid("92aaaf8e-77ac-4412-bdfe-3a6e51794523"), new DateTime(2023, 1, 11, 17, 8, 33, 231, DateTimeKind.Utc).AddTicks(3098), null, null, null, null, null, false, null, null, null, new Guid("65794e9f-091f-4362-b16c-76bb21000d9f"), new Guid("c84184d2-f664-43c0-9f3d-faa10fdf72ac") });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "Culture", "DarkMode", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "RightToLeft", "Theme", "UserId" },
                values: new object[] { new Guid("ff21ef9d-abbf-4dbe-abfd-4ad86c6c87d7"), null, null, null, "en-US", false, null, null, null, false, null, null, null, false, "", new Guid("c84184d2-f664-43c0-9f3d-faa10fdf72ac") });

            migrationBuilder.InsertData(
                table: "IntroMethods",
                columns: new[] { "Id", "AdditionalInfoLabel", "AdditionalInfoRequired", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "DisplayTitle", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "Order", "ParentId", "Type" },
                values: new object[,]
                {
                    { 25, "Radio Station", true, null, null, null, null, null, null, "Secular", "Secular Radio", false, null, null, null, "SecularRadio", (short)1, 21, (short)2 },
                    { 26, "Radio Station", true, null, null, null, null, null, null, "Christian", "Christian Radio", false, null, null, null, "ChristianRadio", (short)2, 21, (short)2 },
                    { 27, null, false, null, null, null, null, null, null, "Google Ads", "Google Ads", false, null, null, null, "GoogleAds", (short)1, 24, (short)2 },
                    { 28, null, false, null, null, null, null, null, null, "Facebook", "Facebook", false, null, null, null, "Facebook", (short)2, 24, (short)2 },
                    { 29, null, false, null, null, null, null, null, null, "Yelp", "Yelp", false, null, null, null, "Yelp", (short)3, 24, (short)2 },
                    { 30, null, false, null, null, null, null, null, null, "Instagram", "Instagram", false, null, null, null, "Instagram", (short)4, 24, (short)2 },
                    { 31, null, false, null, null, null, null, null, null, "Twitter", "Twitter", false, null, null, null, "Twitter", (short)5, 24, (short)2 },
                    { 32, null, false, null, null, null, null, null, null, "Game Apps", "Game Apps", false, null, null, null, "GameApps", (short)6, 24, (short)2 },
                    { 33, null, false, null, null, null, null, null, null, "Tinder", "Tinder", false, null, null, null, "Tinder", (short)7, 24, (short)2 },
                    { 34, null, false, null, null, null, null, null, null, "Signage", "Signage", false, null, null, null, "Signage", (short)8, 24, (short)2 },
                    { 35, null, false, null, null, null, null, null, null, "Medical Mobile Unit Sign", "Medical Mobile Unit Sign", false, null, null, null, "MedicalMobileUnitSign", (short)9, 24, (short)2 }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Command", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "DisplayTitle", "Gender", "Help", "Image", "IsDeleted", "IsRequired", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "Order", "ParentId", "RequiredPolicy", "SectionGroup", "SectionType", "URI", "Visibility" },
                values: new object[,]
                {
                    { new Guid("07bf50e0-0d9c-409f-b5ef-0d6196a12c0b"), "Take Client", null, null, null, null, null, null, "Pro Advocate Assignment", (short)0, "In this section, one of the institution's employees will be responsible for continuing the work.", null, false, true, null, null, null, "PaAssignment", 1, new Guid("00000005-6df9-4ecb-86c8-000000000005"), "PregnancyTest.PaAssignment", (short)2, (short)7, "PaAssignment", (short)2 },
                    { new Guid("4105e988-33fc-4dc3-afd9-f4c04ffc547c"), "Fill Decision", null, null, null, null, null, null, "Decision", (short)0, "In this section, the corresponding form is filled by the client.", null, false, true, null, null, null, "Decision", 1, new Guid("00000007-6df9-4ecb-86c8-000000000007"), "PregnancyTest.Decision", (short)2, (short)9, "Decision", (short)2 },
                    { new Guid("53ff9112-3b15-479d-bf08-f32d2b30ae0f"), "Review", null, null, null, null, null, null, "Social Review", (short)0, "In this section, the social form filled by the client is approved by the institution.", null, false, true, null, null, null, "SocialReview", 1, new Guid("00000006-6df9-4ecb-86c8-000000000006"), "PregnancyTest.SocialReview", (short)2, (short)8, "Social", (short)2 },
                    { new Guid("546437d7-212c-48c4-99e6-effa0a60223a"), "Fill Survey", null, null, null, null, null, null, "Exit Survey", (short)0, "In this section, the exit survey form filled by the institution.", null, false, true, null, null, null, "ExitSurvey", 1, new Guid("00000010-6df9-4ecb-86c8-000000000010"), "PregnancyTest.ExitSurvey", (short)2, (short)12, "ExitSurvey", (short)2 },
                    { new Guid("71583efc-3a4e-4207-886c-c9d2b0312204"), "Take Client", null, null, null, null, null, null, "Qualified Advocate Assignment", (short)0, "In this section, one of the institution's employees will be responsible for continuing the work.", null, false, true, null, null, null, "QaAssignment", 1, new Guid("00000003-6df9-4ecb-86c8-000000000003"), "PregnancyTest.QaAssignment", (short)2, (short)4, "QaAssignment", (short)2 },
                    { new Guid("7815a693-ae0f-4f49-9777-b8d7eb5b4c1e"), "Fill Spiritual", null, null, null, null, null, null, "Spiritual Form", (short)0, "In this section, the ARL form filled by the institution.", null, false, false, null, null, null, "Spiritual", 1, new Guid("00000011-6df9-4ecb-86c8-000000000011"), "PregnancyTest.Spiritual", (short)2, (short)14, "Spiritual", (short)2 },
                    { new Guid("833f07ef-045a-41db-a1d9-e1f4c4c9d343"), "Review", null, null, null, null, null, null, "Decision Review", (short)0, "In this section, the decision form filled by the client is approved by the institution.", null, false, true, null, null, null, "DecisionReview", 1, new Guid("00000008-6df9-4ecb-86c8-000000000008"), "PregnancyTest.Decision", (short)2, (short)10, "Decision", (short)2 },
                    { new Guid("900bad1f-876c-4a56-a8e5-7ac77a8a2e01"), "Fill Demographic Intake", null, null, null, null, null, null, "Demographic Intake", (short)0, "In this section, the corresponding form is filled by the client.", null, false, true, null, null, null, "DemographicIntake", 1, new Guid("00000001-6df9-4ecb-86c8-000000000001"), "PregnancyTest.Demographic", (short)2, (short)2, "DemographicIntake", (short)2 },
                    { new Guid("94ce2417-aaa3-4277-99d8-0c355da36546"), "Fill Social", null, null, null, null, null, null, "Social Form", (short)0, "In this section, the corresponding form is filled by the client.", null, false, true, null, null, null, "Social", 1, new Guid("00000004-6df9-4ecb-86c8-000000000004"), "PregnancyTest.Social", (short)2, (short)5, "Social", (short)2 },
                    { new Guid("98412242-1b4d-45c1-89f1-c1f9a198fc5e"), "Fill Vulnerability", null, null, null, null, null, null, "Vulnerability", (short)0, "In this section, the vulnerability form filled by the institution.", null, false, true, null, null, null, "vulnerability", 1, new Guid("00000009-6df9-4ecb-86c8-000000000009"), "PregnancyTest.Vulnerability", (short)2, (short)11, "vulnerability", (short)2 },
                    { new Guid("ac2fd8fe-818d-48bb-a90e-81e87f26a272"), "Fill Medical Info", null, null, null, null, null, null, "Medical Info", (short)0, "In this section, the corresponding form is filled by the client.", null, false, true, null, null, null, "MedicalInfo", 2, new Guid("00000001-6df9-4ecb-86c8-000000000001"), "PregnancyTest.Medical", (short)2, (short)3, "-", (short)2 },
                    { new Guid("c47128ca-3fe7-42c9-bb85-2141ace9c22b"), "Fill Test Result", null, null, null, null, null, null, "Test Result", (short)0, "In this section,the test result will be done by the institution.", null, false, true, null, null, null, "TestResult", 2, new Guid("00000004-6df9-4ecb-86c8-000000000004"), "PregnancyTest.TestResult", (short)2, (short)6, "TestResult", (short)2 },
                    { new Guid("c52aa6e5-5e9b-415e-870a-6eaf4aef7dcf"), "ARL", null, null, null, null, null, null, "ARL", (short)0, "In this section, the ARL form filled by the institution.", null, false, true, null, null, null, "ARL", 2, new Guid("00000010-6df9-4ecb-86c8-000000000010"), "PregnancyTest.RequestList", (short)2, (short)13, "ARL", (short)2 },
                    { new Guid("e6f733bc-bf93-4b83-a028-e55bf46790c8"), "Check-out", null, null, null, null, null, null, "Check-out", (short)0, "In this section,the check-out will be done by the institution.", null, false, false, null, null, null, "Checkout", 2, new Guid("00000011-6df9-4ecb-86c8-000000000011"), "Global.Checkout", (short)2, (short)2, "Checkout", (short)2 },
                    { new Guid("eb461078-02b4-4695-a910-16469834c16a"), "CheckIn", null, null, null, null, null, null, "Check-In", (short)0, "In this section,the check-in will be done by the institution.", null, false, true, null, null, null, "CheckIn", 1, new Guid("00000002-6df9-4ecb-86c8-000000000002"), "Global.CheckIn", (short)2, (short)1, "CheckIn", (short)2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_UserId",
                table: "Cases",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DemographicIntakes_RegionId",
                table: "DemographicIntakes",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_DemographicIntakes_TaskId",
                table: "DemographicIntakes",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_DemographicIntakes_VisitId",
                table: "DemographicIntakes",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_IntroMethods_ParentId",
                table: "IntroMethods",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalIntakes_TaskId",
                table: "MedicalIntakes",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalIntakes_VisitId",
                table: "MedicalIntakes",
                column: "VisitId");

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
                name: "IX_Sections_ParentId",
                table: "Sections",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_SectionId",
                table: "Tasks",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_VisitId",
                table: "Tasks",
                column: "VisitId");

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
                name: "IX_UserProfile_IntroMethodId",
                table: "UserProfile",
                column: "IntroMethodId");

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
                name: "IX_UserSettings_UserId",
                table: "UserSettings",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_CaseId",
                table: "Visits",
                column: "CaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSettings");

            migrationBuilder.DropTable(
                name: "Cultures");

            migrationBuilder.DropTable(
                name: "DemographicIntakes");

            migrationBuilder.DropTable(
                name: "MedicalIntakes");

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
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "IntroMethods");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
