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
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    Help = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Command = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiredPolicy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectionGroup = table.Column<short>(type: "smallint", nullable: false),
                    SectionType = table.Column<short>(type: "smallint", nullable: false),
                    Visibility = table.Column<short>(type: "smallint", nullable: false),
                    Sex = table.Column<short>(type: "smallint", nullable: false),
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
                name: "SectionClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_SectionClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionClaims_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
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

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
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
                    StdType = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                values: new object[] { new Guid("279edb14-33ff-4b03-9e91-4b0c00c41cd6"), new DateTime(2022, 12, 26, 13, 19, 13, 1, DateTimeKind.Utc).AddTicks(6901), null, null, null, null, null, null, false, null, "DefaultConnectionString", null, null, null, "Server=.;Database={0};Integrated Security = True;" });

            migrationBuilder.InsertData(
                table: "Cultures",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "CultureName", "DateSeparator", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "DisplayName", "FirstDayOfWeek", "FullDateTimePattern", "Image", "IsDefault", "IsDeleted", "LongDatePattern", "LongTimePattern", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "MonthDayPattern", "RightToLeft", "ShortDatePattern", "ShortTimePattern", "TimeSeparator", "YearMonthPattern" },
                values: new object[,]
                {
                    { new Guid("3c73fe4d-33bb-4d70-bfbd-c126b86aa963"), new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(7115), null, null, "fa-IR", "/", null, null, null, "فارسی", 6, "dddd, MMMM dd, yyyy h:mm:ss tt", "_content/wrmc.RootComponents/assets/media/flags/iran.svg", false, false, "dddd, MMMM dd, yyyy ", "HH:mm:ss", null, null, null, "MMMM dd", true, "yyyy/MM/dd", "HH:mm", ":", "MMMM, yyyy" },
                    { new Guid("deb3db60-1032-4b9d-b5f3-dd0503b3ea17"), new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(3765), null, null, "en-US", "/", null, null, null, "English", 1, "dddd, MMMM dd, yyyy h:mm:ss tt", "_content/wrmc.RootComponents/assets/media/flags/usa.svg", true, false, "dddd, MMMM dd, yyyy", "HH:mm:ss", null, null, null, "MMMM dd", false, "yyyy/MM/dd", "HH:mm", ":", "MMMM, yyyy" }
                });

            migrationBuilder.InsertData(
                table: "IntroMethods",
                columns: new[] { "Id", "AdditionalInfoLabel", "AdditionalInfoRequired", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "DisplayTitle", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "Order", "ParentId", "Type" },
                values: new object[,]
                {
                    { 1, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(7649), null, null, null, null, null, "Advertisement", "Advertisement", false, null, null, null, "Advertisement", (short)1, null, (short)0 },
                    { 2, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9174), null, null, null, null, null, "Friends/Relatives/Partner", "Friends/Relatives/Partner", false, null, null, null, "FriendsRelativesPartner", (short)8, null, (short)2 },
                    { 3, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9201), null, null, null, null, null, "Repeat Client", "Repeat Client", false, null, null, null, "RepeatClient", (short)9, null, (short)2 },
                    { 4, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9203), null, null, null, null, null, "Walk-in/Passer By", "Walk-in/Passer By", false, null, null, null, "WalkInPasserBy", (short)10, null, (short)2 },
                    { 5, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9205), null, null, null, null, null, "Crisis Pregnancy Centers", "Crisis Pregnancy Centers", false, null, null, null, "CrisisPregnancyCenters", (short)11, null, (short)2 },
                    { 6, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9206), null, null, null, null, null, "Option United", "Option United", false, null, null, null, "OptionUnited", (short)12, null, (short)2 },
                    { 7, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9207), null, null, null, null, null, "Community Event", "Community Event", false, null, null, null, "CommunityEvent", (short)13, null, (short)2 },
                    { 8, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9209), null, null, null, null, null, "Church Event", "Church Event", false, null, null, null, "ChurchEvent", (short)14, null, (short)2 },
                    { 9, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9210), null, null, null, null, null, "Baby First Services", "Baby First Services", false, null, null, null, "BabyFirstServices", (short)15, null, (short)2 },
                    { 10, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9162), null, null, null, null, null, "Medical Referrals", "Medical Referrals", false, null, null, null, "MedicalReferrals", (short)2, null, (short)0 },
                    { 11, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9165), null, null, null, null, null, "Government Agencies", "Government Agencies", false, null, null, null, "GovernmentAgencies", (short)3, null, (short)0 },
                    { 12, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9167), null, null, null, null, null, "Alcohol/Drug Rehabs", "Alcohol/Drug Rehabs", false, null, null, null, "AlcoholDrugRehabs", (short)4, null, (short)0 },
                    { 13, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9168), null, null, null, null, null, "Shelters", "Shelters", false, null, null, null, "Shelters", (short)5, null, (short)0 },
                    { 14, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9171), null, null, null, null, null, "Church Referral", "Church Referral", false, null, null, null, "ChurchReferral", (short)6, null, (short)0 },
                    { 15, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9173), null, null, null, null, null, "Abortion Clinic", "Abortion Clinic", false, null, null, null, "AbortionClinic", (short)7, null, (short)0 },
                    { 16, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9220), null, null, null, null, null, "Help of Southern Nevada", "Help of Southern Nevada", false, null, null, null, "HelpOfSouthernNevada", (short)16, null, (short)2 }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Flag", "IsDeleted", "Iso2", "Iso3", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "Numeric", "OfficialName", "ParentId", "RegionType" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(448), null, null, null, null, null, null, false, "af", "AFG", null, null, null, "Afghanistan", null, "the Islamic Republic of Afghanistan", null, (short)1 },
                    { 2, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2361), null, null, null, null, null, null, false, "al", "ALB", null, null, null, "Albania", null, "the Republic of Albania", null, (short)1 },
                    { 3, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2364), null, null, null, null, null, null, false, "dz", "DZA", null, null, null, "Algeria", null, "the People's Democratic Republic of Algeria", null, (short)1 },
                    { 4, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2399), null, null, null, null, null, null, false, "ad", "AND", null, null, null, "Andorra", null, "the Principality of Andorra", null, (short)1 },
                    { 5, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2401), null, null, null, null, null, null, false, "ao", "AGO", null, null, null, "Angola", null, "the Republic of Angola", null, (short)1 },
                    { 6, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2412), null, null, null, null, null, null, false, "ag", "ATG", null, null, null, "Antigua and Barbuda", null, "Antigua and Barbuda", null, (short)1 },
                    { 7, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2414), null, null, null, null, null, null, false, "ar", "ARG", null, null, null, "Argentina", null, "the Argentine Republic", null, (short)1 },
                    { 8, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2415), null, null, null, null, null, null, false, "am", "ARM", null, null, null, "Armenia", null, "the Republic of Armenia", null, (short)1 },
                    { 9, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2416), null, null, null, null, null, null, false, "au", "AUS", null, null, null, "Australia", null, "Australia", null, (short)1 },
                    { 10, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2419), null, null, null, null, null, null, false, "at", "AUT", null, null, null, "Austria", null, "the Republic of Austria", null, (short)1 },
                    { 11, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2420), null, null, null, null, null, null, false, "az", "AZE", null, null, null, "Azerbaijan", null, "the Republic of Azerbaijan", null, (short)1 },
                    { 12, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2422), null, null, null, null, null, null, false, "bs", "BHS", null, null, null, "Bahamas", null, "the Commonwealth of the Bahamas", null, (short)1 },
                    { 13, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2423), null, null, null, null, null, null, false, "bh", "BHR", null, null, null, "Bahrain", null, "the Kingdom of Bahrain", null, (short)1 },
                    { 14, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2425), null, null, null, null, null, null, false, "bd", "BGD", null, null, null, "Bangladesh", null, "the People's Republic of Bangladesh", null, (short)1 },
                    { 15, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2426), null, null, null, null, null, null, false, "bb", "BRB", null, null, null, "Barbados", null, "Barbados", null, (short)1 },
                    { 16, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2427), null, null, null, null, null, null, false, "by", "BLR", null, null, null, "Belarus", null, "the Republic of Belarus", null, (short)1 },
                    { 17, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2429), null, null, null, null, null, null, false, "be", "BEL", null, null, null, "Belgium", null, "the Kingdom of Belgium", null, (short)1 },
                    { 18, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2431), null, null, null, null, null, null, false, "bz", "BLZ", null, null, null, "Belize", null, "Belize", null, (short)1 },
                    { 19, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2441), null, null, null, null, null, null, false, "bj", "BEN", null, null, null, "Benin", null, "the Republic of Benin", null, (short)1 },
                    { 20, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2443), null, null, null, null, null, null, false, "bt", "BTN", null, null, null, "Bhutan", null, "the Kingdom of Bhutan", null, (short)1 },
                    { 21, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2444), null, null, null, null, null, null, false, "bo", "BOL", null, null, null, "Bolivia (Plurinational State of)", null, "the Plurinational State of Bolivia", null, (short)1 },
                    { 22, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2445), null, null, null, null, null, null, false, "ba", "BIH", null, null, null, "Bosnia and Herzegovina", null, "Bosnia and Herzegovina", null, (short)1 },
                    { 23, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2447), null, null, null, null, null, null, false, "bw", "BWA", null, null, null, "Botswana", null, "the Republic of Botswana", null, (short)1 },
                    { 24, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2448), null, null, null, null, null, null, false, "br", "BRA", null, null, null, "Brazil", null, "the Federative Republic of Brazil", null, (short)1 },
                    { 25, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2449), null, null, null, null, null, null, false, "bn", "BRN", null, null, null, "Brunei Darussalam", null, "Brunei Darussalam", null, (short)1 },
                    { 26, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2451), null, null, null, null, null, null, false, "bg", "BGR", null, null, null, "Bulgaria", null, "the Republic of Bulgaria", null, (short)1 },
                    { 27, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2452), null, null, null, null, null, null, false, "bf", "BFA", null, null, null, "Burkina Faso", null, "Burkina Faso", null, (short)1 },
                    { 28, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2454), null, null, null, null, null, null, false, "bi", "BDI", null, null, null, "Burundi", null, "the Republic of Burundi", null, (short)1 },
                    { 29, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2475), null, null, null, null, null, null, false, "cv", "CPV", null, null, null, "Cabo Verde", null, "Republic of Cabo Verde", null, (short)1 },
                    { 30, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2477), null, null, null, null, null, null, false, "kh", "KHM", null, null, null, "Cambodia", null, "the Kingdom of Cambodia", null, (short)1 },
                    { 31, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2478), null, null, null, null, null, null, false, "cm", "CMR", null, null, null, "Cameroon", null, "the Republic of Cameroon", null, (short)1 },
                    { 32, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2480), null, null, null, null, null, null, false, "ca", "CAN", null, null, null, "Canada", null, "Canada", null, (short)1 },
                    { 33, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2481), null, null, null, null, null, null, false, "cf", "CAF", null, null, null, "Central African Republic", null, "the Central African Republic", null, (short)1 },
                    { 34, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2483), null, null, null, null, null, null, false, "td", "TCD", null, null, null, "Chad", null, "the Republic of Chad", null, (short)1 },
                    { 35, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2491), null, null, null, null, null, null, false, "cl", "CHL", null, null, null, "Chile", null, "the Republic of Chile", null, (short)1 },
                    { 36, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2492), null, null, null, null, null, null, false, "cn", "CHN", null, null, null, "China", null, "the People's Republic of China", null, (short)1 },
                    { 37, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2494), null, null, null, null, null, null, false, "co", "COL", null, null, null, "Colombia", null, "the Republic of Colombia", null, (short)1 },
                    { 38, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2495), null, null, null, null, null, null, false, "km", "COM", null, null, null, "Comoros", null, "the Union of the Comoros", null, (short)1 },
                    { 39, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2497), null, null, null, null, null, null, false, "cg", "COG", null, null, null, "Congo", null, "the Republic of the Congo", null, (short)1 },
                    { 40, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2498), null, null, null, null, null, null, false, "ck", "COK", null, null, null, "Cook Islands", null, "the Cook Islands", null, (short)1 },
                    { 41, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2499), null, null, null, null, null, null, false, "cr", "CRI", null, null, null, "Costa Rica", null, "the Republic of Costa Rica", null, (short)1 },
                    { 42, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2501), null, null, null, null, null, null, false, "hr", "HRV", null, null, null, "Croatia", null, "the Republic of Croatia", null, (short)1 },
                    { 43, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2502), null, null, null, null, null, null, false, "cu", "CUB", null, null, null, "Cuba", null, "the Republic of Cuba", null, (short)1 },
                    { 44, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2503), null, null, null, null, null, null, false, "cy", "CYP", null, null, null, "Cyprus", null, "the Republic of Cyprus", null, (short)1 },
                    { 45, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2505), null, null, null, null, null, null, false, "cz", "CZE", null, null, null, "Czechia", null, "the Czech Republic", null, (short)1 },
                    { 46, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2506), null, null, null, null, null, null, false, "ci", "CIV", null, null, null, "CÃ´te d'Ivoire", null, "the Republic of CÃ´te d'Ivoire", null, (short)1 },
                    { 47, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2507), null, null, null, null, null, null, false, "kp", "PRK", null, null, null, "Democratic People's Republic of Korea", null, "the Democratic People's Republic of Korea", null, (short)1 },
                    { 48, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2509), null, null, null, null, null, null, false, "cd", "COD", null, null, null, "Democratic Republic of the Congo", null, "the Democratic Republic of the Congo", null, (short)1 },
                    { 49, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2510), null, null, null, null, null, null, false, "dk", "DNK", null, null, null, "Denmark", null, "the Kingdom of Denmark", null, (short)1 },
                    { 50, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2512), null, null, null, null, null, null, false, "dj", "DJI", null, null, null, "Djibouti", null, "the Republic of Djibouti", null, (short)1 },
                    { 51, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2513), null, null, null, null, null, null, false, "dm", "DMA", null, null, null, "Dominica", null, "the Commonwealth of Dominica", null, (short)1 },
                    { 52, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2520), null, null, null, null, null, null, false, "do", "DOM", null, null, null, "Dominican Republic", null, "the Dominican Republic", null, (short)1 },
                    { 53, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2522), null, null, null, null, null, null, false, "ec", "ECU", null, null, null, "Ecuador", null, "the Republic of Ecuador", null, (short)1 },
                    { 54, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2540), null, null, null, null, null, null, false, "eg", "EGY", null, null, null, "Egypt", null, "the Arab Republic of Egypt", null, (short)1 },
                    { 55, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2542), null, null, null, null, null, null, false, "sv", "SLV", null, null, null, "El Salvador", null, "the Republic of El Salvador", null, (short)1 },
                    { 56, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2543), null, null, null, null, null, null, false, "gq", "GNQ", null, null, null, "Equatorial Guinea", null, "the Republic of Equatorial Guinea", null, (short)1 },
                    { 57, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2544), null, null, null, null, null, null, false, "er", "ERI", null, null, null, "Eritrea", null, "the State of Eritrea", null, (short)1 },
                    { 58, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2546), null, null, null, null, null, null, false, "ce", "EST", null, null, null, "Estonia", null, "the Republic of Estonia", null, (short)1 },
                    { 59, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2547), null, null, null, null, null, null, false, "sz", "SWZ", null, null, null, "Eswatini", null, "the Kingdom of Eswatini", null, (short)1 },
                    { 60, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2549), null, null, null, null, null, null, false, "et", "ETH", null, null, null, "Ethiopia", null, "the Federal Democratic Republic of Ethiopia", null, (short)1 },
                    { 61, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2550), null, null, null, null, null, null, false, "fo", "FRO", null, null, null, "Faroe Islands", null, "Faroe Islands", null, (short)1 },
                    { 62, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2551), null, null, null, null, null, null, false, "fj", "FJI", null, null, null, "Fiji", null, "the Republic of Fiji", null, (short)1 },
                    { 63, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2553), null, null, null, null, null, null, false, "fi", "FIN", null, null, null, "Finland", null, "the Republic of Finland", null, (short)1 },
                    { 64, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2554), null, null, null, null, null, null, false, "fr", "FRA", null, null, null, "France", null, "the French Republic", null, (short)1 },
                    { 65, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2555), null, null, null, null, null, null, false, "ga", "GAB", null, null, null, "Gabon", null, "the Gabonese Republic", null, (short)1 },
                    { 66, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2557), null, null, null, null, null, null, false, "gm", "GMB", null, null, null, "Gambia", null, "the Republic of the Gambia", null, (short)1 },
                    { 67, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2559), null, null, null, null, null, null, false, "ge", "GEO", null, null, null, "Georgia", null, "Georgia", null, (short)1 },
                    { 68, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2566), null, null, null, null, null, null, false, "de", "DEU", null, null, null, "Germany", null, "the Federal Republic of Germany", null, (short)1 },
                    { 69, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2568), null, null, null, null, null, null, false, "gh", "GHA", null, null, null, "Ghana", null, "the Republic of Ghana", null, (short)1 },
                    { 70, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2570), null, null, null, null, null, null, false, "gr", "GRC", null, null, null, "Greece", null, "the Hellenic Republic", null, (short)1 },
                    { 71, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2571), null, null, null, null, null, null, false, "gd", "GRD", null, null, null, "Grenada", null, "Grenada", null, (short)1 },
                    { 72, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2574), null, null, null, null, null, null, false, "gt", "GTM", null, null, null, "Guatemala", null, "the Republic of Guatemala", null, (short)1 },
                    { 73, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2575), null, null, null, null, null, null, false, "gn", "GIN", null, null, null, "Guinea", null, "the Republic of Guinea", null, (short)1 },
                    { 74, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2577), null, null, null, null, null, null, false, "gw", "GNB", null, null, null, "Guinea-Bissau", null, "the Republic of Guinea-Bissau", null, (short)1 },
                    { 75, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2578), null, null, null, null, null, null, false, "gy", "GUY", null, null, null, "Guyana", null, "the Co-operative Republic of Guyana", null, (short)1 },
                    { 76, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2580), null, null, null, null, null, null, false, "ht", "HTI", null, null, null, "Haiti", null, "the Republic of Haiti", null, (short)1 },
                    { 77, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2581), null, null, null, null, null, null, false, "hn", "HND", null, null, null, "Honduras", null, "the Republic of Honduras", null, (short)1 },
                    { 78, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2620), null, null, null, null, null, null, false, "hu", "HUN", null, null, null, "Hungary", null, "Hungary", null, (short)1 },
                    { 79, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2623), null, null, null, null, null, null, false, "is", "ISL", null, null, null, "Iceland", null, "the Republic of Iceland", null, (short)1 },
                    { 80, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2626), null, null, null, null, null, null, false, "in", "IND", null, null, null, "India", null, "the Republic of India", null, (short)1 },
                    { 81, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2627), null, null, null, null, null, null, false, "id", "IDN", null, null, null, "Indonesia", null, "the Republic of Indonesia", null, (short)1 },
                    { 82, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2628), null, null, null, null, null, null, false, "ir", "IRN", null, null, null, "Iran (Islamic Republic of)", null, "the Islamic Republic of Iran", null, (short)1 },
                    { 83, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2630), null, null, null, null, null, null, false, "iq", "IRQ", null, null, null, "Iraq", null, "the Republic of Iraq", null, (short)1 },
                    { 84, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2631), null, null, null, null, null, null, false, "ie", "IRL", null, null, null, "Ireland", null, "Ireland", null, (short)1 },
                    { 85, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2640), null, null, null, null, null, null, false, "il", "ISR", null, null, null, "Israel", null, "the State of Israel", null, (short)1 },
                    { 86, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2642), null, null, null, null, null, null, false, "it", "ITA", null, null, null, "Italy", null, "the Republic of Italy", null, (short)1 },
                    { 87, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2644), null, null, null, null, null, null, false, "jm", "JAM", null, null, null, "Jamaica", null, "Jamaica", null, (short)1 },
                    { 88, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2645), null, null, null, null, null, null, false, "jp", "JPN", null, null, null, "Japan", null, "Japan", null, (short)1 },
                    { 89, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2646), null, null, null, null, null, null, false, "jo", "JOR", null, null, null, "Jordan", null, "the Hashemite Kingdom of Jordan", null, (short)1 },
                    { 90, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2648), null, null, null, null, null, null, false, "kz", "KAZ", null, null, null, "Kazakhstan", null, "the Republic of Kazakhstan", null, (short)1 },
                    { 91, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2649), null, null, null, null, null, null, false, "kn", "KEN", null, null, null, "Kenya", null, "the Republic of Kenya", null, (short)1 },
                    { 92, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2650), null, null, null, null, null, null, false, "ki", "KIR", null, null, null, "Kiribati", null, "the Republic of Kiribati", null, (short)1 },
                    { 93, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2652), null, null, null, null, null, null, false, "kw", "KWT", null, null, null, "Kuwait", null, "the State of Kuwait", null, (short)1 },
                    { 94, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2653), null, null, null, null, null, null, false, "kg", "KGZ", null, null, null, "Kyrgyzstan", null, "the Kyrgyz Republic", null, (short)1 },
                    { 95, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2654), null, null, null, null, null, null, false, "la", "LAO", null, null, null, "Lao People's Democratic Republic", null, "the Lao People's Democratic Republic", null, (short)1 },
                    { 96, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2656), null, null, null, null, null, null, false, "lv", "LVA", null, null, null, "Latvia", null, "the Republic of Latvia", null, (short)1 },
                    { 97, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2657), null, null, null, null, null, null, false, "lb", "LBN", null, null, null, "Lebanon", null, "the Lebanese Republic", null, (short)1 },
                    { 98, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2658), null, null, null, null, null, null, false, "ls", "LSO", null, null, null, "Lesotho", null, "the Kingdom of Lesotho", null, (short)1 },
                    { 99, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2659), null, null, null, null, null, null, false, "lr", "LBR", null, null, null, "Liberia", null, "the Republic of Liberia", null, (short)1 },
                    { 100, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2661), null, null, null, null, null, null, false, "ly", "LBY", null, null, null, "Libya", null, "State of Libya", null, (short)1 },
                    { 101, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2668), null, null, null, null, null, null, false, "lt", "LTU", null, null, null, "Lithuania", null, "the Republic of Lithuania", null, (short)1 },
                    { 102, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2670), null, null, null, null, null, null, false, "lu", "LUX", null, null, null, "Luxembourg", null, "the Grand Duchy of Luxembourg", null, (short)1 },
                    { 103, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2671), null, null, null, null, null, null, false, "mg", "MDG", null, null, null, "Madagascar", null, "the Republic of Madagascar", null, (short)1 },
                    { 104, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2708), null, null, null, null, null, null, false, "mw", "MWI", null, null, null, "Malawi", null, "the Republic of Malawi", null, (short)1 },
                    { 105, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2710), null, null, null, null, null, null, false, "my", "MYS", null, null, null, "Malaysia", null, "Malaysia", null, (short)1 },
                    { 106, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2711), null, null, null, null, null, null, false, "mv", "MDV", null, null, null, "Maldives", null, "the Republic of Maldives", null, (short)1 },
                    { 107, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2712), null, null, null, null, null, null, false, "ml", "MLI", null, null, null, "Mali", null, "the Republic of Mali", null, (short)1 },
                    { 108, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2714), null, null, null, null, null, null, false, "mt", "MLT", null, null, null, "Malta", null, "the Republic of Malta", null, (short)1 },
                    { 109, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2715), null, null, null, null, null, null, false, "mh", "MHL", null, null, null, "Marshall Islands", null, "the Republic of the Marshall Islands", null, (short)1 },
                    { 110, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2716), null, null, null, null, null, null, false, "mr", "MRT", null, null, null, "Mauritania", null, "the Islamic Republic of Mauritania", null, (short)1 },
                    { 111, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2718), null, null, null, null, null, null, false, "mu", "MUS", null, null, null, "Mauritius", null, "the Republic of Mauritius", null, (short)1 },
                    { 112, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2719), null, null, null, null, null, null, false, "mx", "MEX", null, null, null, "Mexico", null, "the United Mexican States", null, (short)1 },
                    { 113, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2720), null, null, null, null, null, null, false, "fm", "FSM", null, null, null, "Micronesia (Federated States of)", null, "the Federated States of Micronesia", null, (short)1 },
                    { 114, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2722), null, null, null, null, null, null, false, "mc", "MCO", null, null, null, "Monaco", null, "the Principality of Monaco", null, (short)1 },
                    { 115, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2723), null, null, null, null, null, null, false, "mn", "MNG", null, null, null, "Mongolia", null, "Mongolia", null, (short)1 },
                    { 116, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2724), null, null, null, null, null, null, false, "me", "MNE", null, null, null, "Montenegro", null, "Montenegro", null, (short)1 },
                    { 117, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2726), null, null, null, null, null, null, false, "ma", "MAR", null, null, null, "Morocco", null, "the Kingdom of Morocco", null, (short)1 },
                    { 118, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2733), null, null, null, null, null, null, false, "mz", "MOZ", null, null, null, "Mozambique", null, "the Republic of Mozambique", null, (short)1 },
                    { 119, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2735), null, null, null, null, null, null, false, "mm", "MMR", null, null, null, "Myanmar", null, "the Republic of the Union of Myanmar", null, (short)1 },
                    { 120, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2736), null, null, null, null, null, null, false, "na", "NAM", null, null, null, "Namibia", null, "the Republic of Namibia", null, (short)1 },
                    { 121, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2737), null, null, null, null, null, null, false, "nr", "NRU", null, null, null, "Nauru", null, "the Republic of Nauru", null, (short)1 },
                    { 122, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2739), null, null, null, null, null, null, false, "np", "NPL", null, null, null, "Nepal", null, "the Federal Democratic Republic of Nepal", null, (short)1 },
                    { 123, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2740), null, null, null, null, null, null, false, "nl", "NLD", null, null, null, "Netherlands", null, "the Kingdom of the Netherlands", null, (short)1 },
                    { 124, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2741), null, null, null, null, null, null, false, "nz", "NZL", null, null, null, "New Zealand", null, "New Zealand", null, (short)1 },
                    { 125, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2743), null, null, null, null, null, null, false, "ni", "NIC", null, null, null, "Nicaragua", null, "the Republic of Nicaragua", null, (short)1 },
                    { 126, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2744), null, null, null, null, null, null, false, "ne", "NER", null, null, null, "Niger", null, "the Republic of the Niger", null, (short)1 },
                    { 127, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2745), null, null, null, null, null, null, false, "ng", "NGA", null, null, null, "Nigeria", null, "the Federal Republic of Nigeria", null, (short)1 },
                    { 128, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2747), null, null, null, null, null, null, false, "nu", "NIU", null, null, null, "Niue", null, "Niue", null, (short)1 },
                    { 129, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2748), null, null, null, null, null, null, false, "mk", "MKD", null, null, null, "North Macedonia", null, "the Republic of North Macedonia", null, (short)1 },
                    { 130, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2769), null, null, null, null, null, null, false, "no", "NOR", null, null, null, "Norway", null, "the Kingdom of Norway", null, (short)1 },
                    { 131, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2770), null, null, null, null, null, null, false, "om", "OMN", null, null, null, "Oman", null, "the Sultanate of Oman", null, (short)1 },
                    { 132, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2772), null, null, null, null, null, null, false, "pk", "PAK", null, null, null, "Pakistan", null, "the Islamic Republic of Pakistan", null, (short)1 },
                    { 133, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2773), null, null, null, null, null, null, false, "pw", "PLW", null, null, null, "Palau", null, "the Republic of Palau", null, (short)1 },
                    { 134, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2780), null, null, null, null, null, null, false, "pa", "PAN", null, null, null, "Panama", null, "the Republic of Panama", null, (short)1 },
                    { 135, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2782), null, null, null, null, null, null, false, "pg", "PNG", null, null, null, "Papua New Guinea", null, "Independent State of Papua New Guinea", null, (short)1 },
                    { 136, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2783), null, null, null, null, null, null, false, "py", "PRY", null, null, null, "Paraguay", null, "the Republic of Paraguay", null, (short)1 },
                    { 137, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2785), null, null, null, null, null, null, false, "pe", "PER", null, null, null, "Peru", null, "the Republic of Peru", null, (short)1 },
                    { 138, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2786), null, null, null, null, null, null, false, "ph", "PHL", null, null, null, "Philippines", null, "the Republic of the Philippines", null, (short)1 },
                    { 139, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2787), null, null, null, null, null, null, false, "pl", "POL", null, null, null, "Poland", null, "the Republic of Poland", null, (short)1 },
                    { 140, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2789), null, null, null, null, null, null, false, "pt", "PRT", null, null, null, "Portugal", null, "the Portuguese Republic", null, (short)1 },
                    { 141, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2790), null, null, null, null, null, null, false, "qa", "QAT", null, null, null, "Qatar", null, "the State of Qatar", null, (short)1 },
                    { 142, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2791), null, null, null, null, null, null, false, "kr", "KOR", null, null, null, "Republic of Korea", null, "the Republic of Korea", null, (short)1 },
                    { 143, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2793), null, null, null, null, null, null, false, "md", "MDA", null, null, null, "Republic of Moldova", null, "the Republic of Moldova", null, (short)1 },
                    { 144, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2794), null, null, null, null, null, null, false, "ro", "ROU", null, null, null, "Romania", null, "Romania", null, (short)1 },
                    { 145, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2795), null, null, null, null, null, null, false, "ru", "RUS", null, null, null, "Russian Federation", null, "the Russian Federation", null, (short)1 },
                    { 146, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2797), null, null, null, null, null, null, false, "rw", "RWA", null, null, null, "Rwanda", null, "the Republic of Rwanda", null, (short)1 },
                    { 147, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2798), null, null, null, null, null, null, false, "kn", "KNA", null, null, null, "Saint Kitts and Nevis", null, "Saint Kitts and Nevis", null, (short)1 },
                    { 148, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2799), null, null, null, null, null, null, false, "lc", "LCA", null, null, null, "Saint Lucia", null, "Saint Lucia", null, (short)1 },
                    { 149, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2801), null, null, null, null, null, null, false, "vc", "VCT", null, null, null, "Saint Vincent and the Grenadines", null, "Saint Vincent and the Grenadines", null, (short)1 },
                    { 150, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2802), null, null, null, null, null, null, false, "ws", "WSM", null, null, null, "Samoa", null, "the Independent State of Samoa", null, (short)1 },
                    { 151, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2826), null, null, null, null, null, null, false, "sm", "SMR", null, null, null, "San Marino", null, "the Republic of San Marino", null, (short)1 },
                    { 152, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2828), null, null, null, null, null, null, false, "st", "STP", null, null, null, "Sao Tome and Principe", null, "the Democratic Republic of Sao Tome and Principe", null, (short)1 },
                    { 153, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2829), null, null, null, null, null, null, false, "sa", "SAU", null, null, null, "Saudi Arabia", null, "the Kingdom of Saudi Arabia", null, (short)1 },
                    { 154, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2830), null, null, null, null, null, null, false, "sn", "SEN", null, null, null, "Senegal", null, "the Republic of Senegal", null, (short)1 },
                    { 155, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2832), null, null, null, null, null, null, false, "rs", "SRB", null, null, null, "Serbia", null, "the Republic of Serbia", null, (short)1 },
                    { 156, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2833), null, null, null, null, null, null, false, "sc", "SYC", null, null, null, "Seychelles", null, "the Republic of Seychelles", null, (short)1 },
                    { 157, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2834), null, null, null, null, null, null, false, "sl", "SLE", null, null, null, "Sierra Leone", null, "the Republic of Sierra Leone", null, (short)1 },
                    { 158, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2836), null, null, null, null, null, null, false, "sg", "SGP", null, null, null, "Singapore", null, "the Republic of Singapore", null, (short)1 },
                    { 159, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2837), null, null, null, null, null, null, false, "sk", "SVK", null, null, null, "Slovakia", null, "the Slovak Republic", null, (short)1 },
                    { 160, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2838), null, null, null, null, null, null, false, "si", "SVN", null, null, null, "Slovenia", null, "the Republic of Slovenia", null, (short)1 },
                    { 161, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2840), null, null, null, null, null, null, false, "sb", "SLB", null, null, null, "Solomon Islands", null, "Solomon Islands", null, (short)1 },
                    { 162, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2841), null, null, null, null, null, null, false, "so", "SOM", null, null, null, "Somalia", null, "the Federal Republic of Somalia", null, (short)1 },
                    { 163, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2843), null, null, null, null, null, null, false, "za", "ZAF", null, null, null, "South Africa", null, "the Republic of South Africa", null, (short)1 },
                    { 164, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2844), null, null, null, null, null, null, false, "ss", "SSD", null, null, null, "South Sudan", null, "the Republic of South Sudan", null, (short)1 },
                    { 165, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2845), null, null, null, null, null, null, false, "es", "ESP", null, null, null, "Spain", null, "the Kingdom of Spain", null, (short)1 },
                    { 166, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2847), null, null, null, null, null, null, false, "lk", "LKA", null, null, null, "Sri Lanka", null, "the Democratic Socialist Republic of Sri Lanka", null, (short)1 },
                    { 167, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2854), null, null, null, null, null, null, false, "sd", "SDN", null, null, null, "Sudan", null, "the Republic of the Sudan", null, (short)1 },
                    { 168, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2855), null, null, null, null, null, null, false, "sr", "SUR", null, null, null, "Suriname", null, "the Republic of Suriname", null, (short)1 },
                    { 169, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2857), null, null, null, null, null, null, false, "se", "SWE", null, null, null, "Sweden", null, "the Kingdom of Sweden", null, (short)1 },
                    { 170, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2858), null, null, null, null, null, null, false, "ch", "CHE", null, null, null, "Switzerland", null, "the Swiss Confederation", null, (short)1 },
                    { 171, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2859), null, null, null, null, null, null, false, "sy", "SYR", null, null, null, "Syrian Arab Republic", null, "the Syrian Arab Republic", null, (short)1 },
                    { 172, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2861), null, null, null, null, null, null, false, "tj", "TJK", null, null, null, "Tajikistan", null, "the Republic of Tajikistan", null, (short)1 },
                    { 173, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2862), null, null, null, null, null, null, false, "th", "THA", null, null, null, "Thailand", null, "the Kingdom of Thailand", null, (short)1 },
                    { 174, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2863), null, null, null, null, null, null, false, "tl", "TLS", null, null, null, "Timor-Leste", null, "the Democratic Republic of Timor-Leste", null, (short)1 },
                    { 175, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2865), null, null, null, null, null, null, false, "tg", "TGO", null, null, null, "Togo", null, "the Togolese Republic", null, (short)1 },
                    { 176, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2866), null, null, null, null, null, null, false, "tk", "TKL", null, null, null, "Tokelau", null, "Tokelau", null, (short)1 },
                    { 177, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2868), null, null, null, null, null, null, false, "to", "TON", null, null, null, "Tonga", null, "the Kingdom of Tonga", null, (short)1 },
                    { 178, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2886), null, null, null, null, null, null, false, "tt", "TTO", null, null, null, "Trinidad and Tobago", null, "the Republic of Trinidad and Tobago", null, (short)1 },
                    { 179, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2887), null, null, null, null, null, null, false, "tn", "TUN", null, null, null, "Tunisia", null, "the Republic of Tunisia", null, (short)1 },
                    { 180, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2888), null, null, null, null, null, null, false, "tr", "TUR", null, null, null, "Turkey", null, "the Republic of Turkey", null, (short)1 },
                    { 181, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2890), null, null, null, null, null, null, false, "tm", "TKM", null, null, null, "Turkmenistan", null, "Turkmenistan", null, (short)1 },
                    { 182, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2891), null, null, null, null, null, null, false, "tv", "TUV", null, null, null, "Tuvalu", null, "Tuvalu", null, (short)1 },
                    { 183, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2893), null, null, null, null, null, null, false, "ug", "UGA", null, null, null, "Uganda", null, "the Republic of Uganda", null, (short)1 },
                    { 184, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2900), null, null, null, null, null, null, false, "ua", "UKR", null, null, null, "Ukraine", null, "Ukraine", null, (short)1 },
                    { 185, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2901), null, null, null, null, null, null, false, "ae", "ARE", null, null, null, "United Arab Emirates", null, "the United Arab Emirates", null, (short)1 },
                    { 186, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2903), null, null, null, null, null, null, false, "gb", "GBR", null, null, null, "United Kingdom of Great Britain and Northern Ireland", null, "the United Kingdom of Great Britain and Northern Ireland", null, (short)1 },
                    { 187, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2904), null, null, null, null, null, null, false, "tz", "TZA", null, null, null, "United Republic of Tanzania", null, "the United Republic of Tanzania", null, (short)1 },
                    { 188, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2905), null, null, null, null, null, null, false, "us", "USA", null, null, null, "United States of America", null, "the United States of America", null, (short)1 },
                    { 189, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2907), null, null, null, null, null, null, false, "uy", "URY", null, null, null, "Uruguay", null, "the Eastern Republic of Uruguay", null, (short)1 },
                    { 190, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2908), null, null, null, null, null, null, false, "uz", "UZB", null, null, null, "Uzbekistan", null, "the Republic of Uzbekistan", null, (short)1 },
                    { 191, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2909), null, null, null, null, null, null, false, "vu", "VUT", null, null, null, "Vanuatu", null, "the Republic of Vanuatu", null, (short)1 },
                    { 192, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2911), null, null, null, null, null, null, false, "ve", "VEN", null, null, null, "Venezuela (Bolivarian Republic of)", null, "the Bolivarian Republic of Venezuela", null, (short)1 },
                    { 193, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2912), null, null, null, null, null, null, false, "vn", "VNM", null, null, null, "Viet Nam", null, "the Socialist Republic of Viet Nam", null, (short)1 },
                    { 194, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2913), null, null, null, null, null, null, false, "ye", "YEM", null, null, null, "Yemen", null, "the Republic of Yemen", null, (short)1 },
                    { 195, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2915), null, null, null, null, null, null, false, "zm", "ZMB", null, null, null, "Zambia", null, "the Republic of Zambia", null, (short)1 },
                    { 196, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(2916), null, null, null, null, null, null, false, "zw", "ZWE", null, null, null, "Zimbabwe", null, "the Republic of Zimbabwe", null, (short)1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1f53b465-cef8-467f-a163-758fe2bed342"), null, new DateTime(2022, 12, 26, 13, 19, 11, 678, DateTimeKind.Utc).AddTicks(947), null, null, null, null, null, false, null, null, null, "administrator", "ADMINISTRATOR" },
                    { new Guid("8086256c-013a-4b62-bdd1-b5531cfbd8fb"), null, new DateTime(2022, 12, 26, 13, 19, 11, 686, DateTimeKind.Utc).AddTicks(9873), null, null, null, null, null, false, null, null, null, "client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Command", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "DisplayTitle", "Help", "Image", "IsDeleted", "IsRequired", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "Order", "ParentId", "RequiredPolicy", "SectionGroup", "SectionType", "Sex", "URI", "Visibility" },
                values: new object[] { new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(929), null, null, null, null, null, "Pregnancy Test", "Pregnancy Test and Care Plan", null, false, false, null, null, null, "PregnancyTest", 1, null, "-", (short)0, (short)0, (short)0, "PregnancyTest", (short)2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Email", "EmailConfirmed", "EmailToken", "EmailTokenExpires", "IsActive", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordResetAt", "PasswordToken", "PasswordTokenExpires", "PhoneNumber", "PhoneNumberConfirmed", "PhoneNumberToken", "PhoneNumberTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("ff1e1f19-02b0-460b-9807-d4af12121e82"), 0, "bdc96185-dbb3-4b07-8a71-4507102652d0", new DateTime(2022, 12, 26, 13, 19, 12, 937, DateTimeKind.Utc).AddTicks(38), null, null, null, null, null, "admin@wrmc.com", true, null, null, true, false, false, null, null, null, null, "ADMIN@WRMC.COM", "ADMIN", "AQAAAAIAAYagAAAAECAurTJPd87UzsNTx2XkaF1fJh6v27urFjYpHar0dGnLDh+nqrtxlVa9BmkH5mt2yw==", null, null, null, null, false, null, null, "42dfe908-d624-4a4b-b46f-73c2fc5a53da", false, "admin" });

            migrationBuilder.InsertData(
                table: "IntroMethods",
                columns: new[] { "Id", "AdditionalInfoLabel", "AdditionalInfoRequired", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "DisplayTitle", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "Order", "ParentId", "Type" },
                values: new object[,]
                {
                    { 17, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9457), null, null, null, null, null, "Billboards", "Billboards", false, null, null, null, "Billboards", (short)4, 1, (short)2 },
                    { 18, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9458), null, null, null, null, null, "Bus Stop Fillers", "Bus Stop Fillers", false, null, null, null, "BusStopFillers", (short)5, 1, (short)2 },
                    { 19, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9460), null, null, null, null, null, "Phone book/Directories", "Phone book/Directories", false, null, null, null, "PhoneBookDirectories", (short)6, 1, (short)2 },
                    { 20, "TV Station", true, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9221), null, null, null, null, null, "TV Commercial", "TV Commercial", false, null, null, null, "TVCommercial", (short)1, 1, (short)2 },
                    { 21, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9452), null, null, null, null, null, "Radio Advertisement", "Radio Advertisement", false, null, null, null, "RadioAdvertisement", (short)2, 1, (short)1 },
                    { 22, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9461), null, null, null, null, null, "Flyers", "Flyers", false, null, null, null, "Flyers", (short)7, 1, (short)2 },
                    { 23, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9462), null, null, null, null, null, "Newspaper", "Newspaper", false, null, null, null, "Newspaper", (short)8, 1, (short)2 },
                    { 24, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9456), null, null, null, null, null, "Social Media", "Social Media", false, null, null, null, "SocialMedia", (short)3, 1, (short)1 },
                    { 36, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9490), null, null, null, null, null, "Dr. Sauter", "Dr. Sauter", false, null, null, null, "DrSauter", (short)1, 10, (short)2 },
                    { 37, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9491), null, null, null, null, null, "Dr. Herrero", "Dr. Herrero", false, null, null, null, "DrHerrero", (short)2, 10, (short)2 },
                    { 38, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9493), null, null, null, null, null, "Dr. Strebel", "Dr. Strebel", false, null, null, null, "DrStrebel", (short)3, 10, (short)2 },
                    { 39, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9494), null, null, null, null, null, "UNLV Medicine", "UNLV Medicine", false, null, null, null, "UNLVMedicine", (short)4, 10, (short)2 },
                    { 40, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9495), null, null, null, null, null, "Baby Steps UMC", "Baby Steps UMC", false, null, null, null, "BabyStepsUMC", (short)5, 10, (short)2 },
                    { 41, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9497), null, null, null, null, null, "Sunny Babies", "Sunny Babies", false, null, null, null, "SunnyBabies", (short)6, 10, (short)2 },
                    { 42, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9522), null, null, null, null, null, "Mountain View Hospital", "Mountain View Hospital", false, null, null, null, "MountainViewHospital", (short)7, 10, (short)2 },
                    { 43, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9523), null, null, null, null, null, "Health Department", "Health Department", false, null, null, null, "HealthDepartment", (short)8, 10, (short)2 },
                    { 44, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9531), null, null, null, null, null, "Welfare", "Welfare", false, null, null, null, "Welfare", (short)1, 11, (short)2 },
                    { 45, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9532), null, null, null, null, null, "Medicaid", "Medicaid", false, null, null, null, "Medicaid", (short)2, 11, (short)2 },
                    { 46, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9533), null, null, null, null, null, "WIC", "WIC", false, null, null, null, "WIC", (short)3, 11, (short)2 },
                    { 47, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9535), null, null, null, null, null, "Department of Child and Family Services", "Department of Child and Family Services", false, null, null, null, "ChildFamilyServices", (short)4, 11, (short)2 },
                    { 48, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9536), null, null, null, null, null, "Nevada 211", "Nevada 211", false, null, null, null, "Nevada211", (short)5, 11, (short)2 },
                    { 49, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9537), null, null, null, null, null, "West Care Rehab", "West Care Rehab", false, null, null, null, "WestCareRehab", (short)1, 12, (short)2 },
                    { 50, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9538), null, null, null, null, null, "Center for Behavioral Health", "Center for Behavioral Health", false, null, null, null, "CenterForBehavioralHealth", (short)2, 12, (short)2 },
                    { 51, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9540), null, null, null, null, null, "Other", "Other", false, null, null, null, "OtherAlcoholDrugRehabs", (short)3, 12, (short)2 },
                    { 52, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9541), null, null, null, null, null, "Las Vegas Rescue Mission", "Las Vegas Rescue Mission", false, null, null, null, "LasVegasRescueMission", (short)1, 13, (short)2 },
                    { 53, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9542), null, null, null, null, null, "Shade Tree", "Shade Tree", false, null, null, null, "ShadeTree", (short)2, 13, (short)2 },
                    { 54, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9543), null, null, null, null, null, "SafeNest", "SafeNest", false, null, null, null, "SafeNest", (short)3, 13, (short)2 },
                    { 55, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9545), null, null, null, null, null, "Nevada Youth Partnership", "Nevada Youth Partnership", false, null, null, null, "NevadaYouthPartnership", (short)4, 13, (short)2 },
                    { 56, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9546), null, null, null, null, null, "Other", "Other", false, null, null, null, "Other", (short)5, 13, (short)2 },
                    { 57, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9547), null, null, null, null, null, "Grace Point Church", "Grace Point Church", false, null, null, null, "Grace Point Church", (short)1, 14, (short)2 },
                    { 58, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9555), null, null, null, null, null, "Green Valley Baptist", "Green Valley Baptist", false, null, null, null, "Green Valley Baptist", (short)2, 14, (short)2 },
                    { 59, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9556), null, null, null, null, null, "Green Valley Christian Center", "Green Valley Christian Center", false, null, null, null, "Green Valley Christian Center", (short)3, 14, (short)2 },
                    { 60, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9557), null, null, null, null, null, "Harvest Life Christian Fellowship", "Harvest Life Christian Fellowship", false, null, null, null, "Harvest Life Christian Fellowship", (short)4, 14, (short)2 },
                    { 61, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9559), null, null, null, null, null, "Highland Hills Baptist", "Highland Hills Baptist", false, null, null, null, "Highland Hills Baptist", (short)5, 14, (short)2 },
                    { 62, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9560), null, null, null, null, null, "Hope Church", "Hope Church", false, null, null, null, "Hope Church", (short)6, 14, (short)2 },
                    { 63, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9561), null, null, null, null, null, "Iglesia Agua Viva", "Iglesia Agua Viva", false, null, null, null, "Iglesia Agua Viva", (short)7, 14, (short)2 },
                    { 64, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9562), null, null, null, null, null, "Iglesia Bautista Pan De Vida", "Iglesia Bautista Pan De Vida", false, null, null, null, "Iglesia Bautista Pan De Vida", (short)8, 14, (short)2 },
                    { 65, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9564), null, null, null, null, null, "International Church of Las Vegas", "International Church of Las Vegas", false, null, null, null, "International Church of Las Vegas", (short)9, 14, (short)2 },
                    { 66, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9566), null, null, null, null, null, "Jesus the Good Shepard Church", "Jesus the Good Shepard Church", false, null, null, null, "Jesus the Good Shepard Church", (short)10, 14, (short)2 },
                    { 67, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9567), null, null, null, null, null, "Lake Mead Church", "Lake Mead Church", false, null, null, null, "Lake Mead Church", (short)11, 14, (short)2 },
                    { 68, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9569), null, null, null, null, null, "Las Vegas Bible Church", "Las Vegas Bible Church", false, null, null, null, "Las Vegas Bible Church", (short)12, 14, (short)2 },
                    { 69, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9570), null, null, null, null, null, "Las Vegas Church of the Nazarene", "Las Vegas Church of the Nazarene", false, null, null, null, "Las Vegas Church of the Nazarene", (short)13, 14, (short)2 },
                    { 70, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9571), null, null, null, null, null, "Life Baptist Church", "Life Baptist Church", false, null, null, null, "Life Baptist Church", (short)14, 14, (short)2 },
                    { 71, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9572), null, null, null, null, null, "Life Springs Christian Church", "Life Springs Christian Church", false, null, null, null, "Life Springs Christian Church", (short)15, 14, (short)2 },
                    { 72, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9574), null, null, null, null, null, "Living Grace Foursquare Church", "Living Grace Foursquare Church", false, null, null, null, "Living Grace Foursquare Church", (short)16, 14, (short)2 },
                    { 73, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9581), null, null, null, null, null, "Meadows Fellowship Christian Church", "Meadows Fellowship Christian Church", false, null, null, null, "Meadows Fellowship Christian Church", (short)17, 14, (short)2 },
                    { 74, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9582), null, null, null, null, null, "Messiah's Christian Fellowship", "Messiah's Christian Fellowship", false, null, null, null, "Messiah's Christian Fellowship", (short)18, 14, (short)2 },
                    { 75, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9601), null, null, null, null, null, "Moapa Christian Church", "Moapa Christian Church", false, null, null, null, "Moapa Christian Church", (short)19, 14, (short)2 },
                    { 76, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9602), null, null, null, null, null, "Mountain View Lutheran Church", "Mountain View Lutheran Church", false, null, null, null, "Mountain View Lutheran Church", (short)20, 14, (short)2 },
                    { 77, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9604), null, null, null, null, null, "Mountaintop Faith Ministries", "Mountaintop Faith Ministries", false, null, null, null, "Mountaintop Faith Ministries", (short)21, 14, (short)2 },
                    { 78, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9605), null, null, null, null, null, "Mt. Charleston Baptist Church", "Mt. Charleston Baptist Church", false, null, null, null, "Mt. Charleston Baptist Church", (short)22, 14, (short)2 },
                    { 79, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9606), null, null, null, null, null, "Neighborhood Church", "Neighborhood Church", false, null, null, null, "Neighborhood Church", (short)23, 14, (short)2 },
                    { 80, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9607), null, null, null, null, null, "Nellis Baptist Church", "Nellis Baptist Church", false, null, null, null, "Nellis Baptist Church", (short)24, 14, (short)2 },
                    { 81, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9609), null, null, null, null, null, "New Day Christian Church", "New Day Christian Church", false, null, null, null, "New Day Christian Church", (short)25, 14, (short)2 },
                    { 82, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9679), null, null, null, null, null, "No church stated", "No church stated", false, null, null, null, "No church stated", (short)26, 14, (short)2 },
                    { 83, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9680), null, null, null, null, null, "North Las Vegas Baptist Church", "North Las Vegas Baptist Church", false, null, null, null, "North Las Vegas Baptist Church", (short)27, 14, (short)2 },
                    { 84, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9681), null, null, null, null, null, "Northstar Baptist Church", "Northstar Baptist Church", false, null, null, null, "Northstar Baptist Church", (short)28, 14, (short)2 },
                    { 85, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9683), null, null, null, null, null, "Oasis Baptist Church", "Oasis Baptist Church", false, null, null, null, "Oasis Baptist Church", (short)29, 14, (short)2 },
                    { 86, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9684), null, null, null, null, null, "Oasis Christian Church", "Oasis Christian Church", false, null, null, null, "Oasis Christian Church", (short)30, 14, (short)2 },
                    { 87, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9692), null, null, null, null, null, "Our Lady of Las Vegas Catholic Church", "Our Lady of Las Vegas Catholic Church", false, null, null, null, "Our Lady of Las Vegas Catholic Church", (short)31, 14, (short)2 },
                    { 88, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9693), null, null, null, null, null, "Our Savior's Lutheran Church", "Our Savior's Lutheran Church", false, null, null, null, "Our Savior's Lutheran Church", (short)32, 14, (short)2 },
                    { 89, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9695), null, null, null, null, null, "Paradise Church", "Paradise Church", false, null, null, null, "Paradise Church", (short)33, 14, (short)2 },
                    { 90, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9696), null, null, null, null, null, "Prince of Peace", "Prince of Peace", false, null, null, null, "Prince of Peace", (short)34, 14, (short)2 },
                    { 91, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9697), null, null, null, null, null, "Providence Reformed Church", "Providence Reformed Church", false, null, null, null, "Providence Reformed Church", (short)35, 14, (short)2 },
                    { 92, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9699), null, null, null, null, null, "Remnant Ministries", "Remnant Ministries", false, null, null, null, "Remnant Ministries", (short)36, 14, (short)2 },
                    { 93, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9700), null, null, null, null, null, "Shadow Hills Church", "Shadow Hills Church", false, null, null, null, "Shadow Hills Church", (short)37, 14, (short)2 },
                    { 94, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9701), null, null, null, null, null, "South Hills Church Community", "South Hills Church Community", false, null, null, null, "South Hills Church Community", (short)38, 14, (short)2 },
                    { 95, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9703), null, null, null, null, null, "Southern Hills Baptist Church", "Southern Hills Baptist Church", false, null, null, null, "Southern Hills Baptist Church", (short)39, 14, (short)2 },
                    { 96, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9704), null, null, null, null, null, "Spring Valley Baptist Church", "Spring Valley Baptist Church", false, null, null, null, "Spring Valley Baptist Church", (short)40, 14, (short)2 },
                    { 97, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9705), null, null, null, null, null, "St. Anthony of Padua Catholic Church", "St. Anthony of Padua Catholic Church", false, null, null, null, "St. Anthony of Padua Catholic Church", (short)41, 14, (short)2 },
                    { 98, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9706), null, null, null, null, null, "St. Bridget Catholic Church", "St. Bridget Catholic Church", false, null, null, null, "St. Bridget Catholic Church", (short)42, 14, (short)2 },
                    { 99, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9708), null, null, null, null, null, "St. Francis of Assisi Catholic Church", "St. Francis of Assisi Catholic Church", false, null, null, null, "St. Francis of Assisi Catholic Church", (short)43, 14, (short)2 },
                    { 100, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9709), null, null, null, null, null, "St. John Neumann Roman Catholic Church", "St. John Neumann Roman Catholic Church", false, null, null, null, "St. John Neumann Roman Catholic Church", (short)44, 14, (short)2 },
                    { 101, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9710), null, null, null, null, null, "St. Joseph Husband of Mary Catholic Church", "St. Joseph Husband of Mary Catholic Church", false, null, null, null, "St. Joseph Husband of Mary Catholic Church", (short)45, 14, (short)2 },
                    { 102, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9717), null, null, null, null, null, "St. Thomas Moore Catholic Church", "St. Thomas Moore Catholic Church", false, null, null, null, "St. Thomas Moore Catholic Church", (short)46, 14, (short)2 },
                    { 103, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9718), null, null, null, null, null, "St. Viator's", "St. Viator's", false, null, null, null, "St. Viator's", (short)47, 14, (short)2 },
                    { 104, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9720), null, null, null, null, null, "Summerlin Community Church", "Summerlin Community Church", false, null, null, null, "Summerlin Community Church", (short)48, 14, (short)2 },
                    { 105, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9721), null, null, null, null, null, "The Church @ Lake Mead", "The Church @ Lake Mead", false, null, null, null, "The Church @ Lake Mead", (short)49, 14, (short)2 },
                    { 106, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9722), null, null, null, null, null, "The Church Las Vegas", "The Church Las Vegas", false, null, null, null, "The Church Las Vegas", (short)50, 14, (short)2 },
                    { 107, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9724), null, null, null, null, null, "The Crossing Church", "The Crossing Church", false, null, null, null, "The Crossing Church", (short)51, 14, (short)2 },
                    { 108, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9725), null, null, null, null, null, "The River A Christian Church", "The River A Christian Church", false, null, null, null, "The River A Christian Church", (short)52, 14, (short)2 },
                    { 109, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9726), null, null, null, null, null, "Trinity Life", "Trinity Life", false, null, null, null, "Trinity Life", (short)53, 14, (short)2 },
                    { 110, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9727), null, null, null, null, null, "Trinity Life", "Trinity Life", false, null, null, null, "Trinity Life", (short)54, 14, (short)2 },
                    { 111, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9729), null, null, null, null, null, "Twin Lakes Baptist Church", "Twin Lakes Baptist Church", false, null, null, null, "Twin Lakes Baptist Church", (short)55, 14, (short)2 },
                    { 112, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9730), null, null, null, null, null, "Valley Vegas Church", "Valley Vegas Church", false, null, null, null, "Valley Vegas Church", (short)56, 14, (short)2 },
                    { 113, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9765), null, null, null, null, null, "Wagon Wheel Missionary Baptist", "Wagon Wheel Missionary Baptist", false, null, null, null, "Wagon Wheel Missionary Baptist", (short)57, 14, (short)2 },
                    { 114, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9767), null, null, null, null, null, "Word of Life", "Word of Life", false, null, null, null, "Word of Life", (short)58, 14, (short)2 },
                    { 115, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9769), null, null, null, null, null, "Calvary Chapel Las Vegas", "Calvary Chapel Las Vegas", false, null, null, null, "Calvary Chapel Las Vegas", (short)59, 14, (short)2 },
                    { 116, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9777), null, null, null, null, null, "Calvary Chapel Lone Mountain", "Calvary Chapel Lone Mountain", false, null, null, null, "Calvary Chapel Lone Mountain", (short)60, 14, (short)2 },
                    { 117, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9779), null, null, null, null, null, "Calvary Chapel Henderson", "Calvary Chapel Henderson", false, null, null, null, "Calvary Chapel Henderson", (short)61, 14, (short)2 },
                    { 118, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9780), null, null, null, null, null, "Calvary Chapel Boulder City", "Calvary Chapel Boulder City", false, null, null, null, "Calvary Chapel Boulder City", (short)62, 14, (short)2 },
                    { 119, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9781), null, null, null, null, null, "Cornerstone Church", "Cornerstone Church", false, null, null, null, "Cornerstone Church", (short)63, 14, (short)2 },
                    { 120, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9783), null, null, null, null, null, "Canyon Ridge Church", "Canyon Ridge Church", false, null, null, null, "Canyon Ridge Church", (short)64, 14, (short)2 },
                    { 121, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9784), null, null, null, null, null, "Oasis Church", "Oasis Church", false, null, null, null, "Oasis Church", (short)65, 14, (short)2 },
                    { 122, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9785), null, null, null, null, null, "Life Church", "Life Church", false, null, null, null, "Life Church", (short)66, 14, (short)2 },
                    { 123, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9787), null, null, null, null, null, "Hope Church", "Hope Church", false, null, null, null, "Hope Church", (short)67, 14, (short)2 },
                    { 124, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9788), null, null, null, null, null, "Meadow Mesa", "Meadow Mesa", false, null, null, null, "Meadow Mesa", (short)68, 14, (short)2 },
                    { 125, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9789), null, null, null, null, null, "Walk Church", "Walk Church", false, null, null, null, "Walk Church", (short)69, 14, (short)2 },
                    { 126, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9790), null, null, null, null, null, "The Crossing", "The Crossing", false, null, null, null, "The Crossing", (short)70, 14, (short)2 },
                    { 127, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9792), null, null, null, null, null, "Bethany Baptist", "Bethany Baptist", false, null, null, null, "Bethany Baptist", (short)71, 14, (short)2 },
                    { 128, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9793), null, null, null, null, null, "Faith Lutheran", "Faith Lutheran", false, null, null, null, "Faith Lutheran", (short)72, 14, (short)2 },
                    { 129, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9794), null, null, null, null, null, "St. Joseph Husband of Mary", "St. Joseph Husband of Mary", false, null, null, null, "St. Joseph Husband of Mary", (short)73, 14, (short)2 },
                    { 130, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9804), null, null, null, null, null, "St Thomas Moore", "St Thomas Moore", false, null, null, null, "St Thomas Moore", (short)74, 14, (short)2 },
                    { 131, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9805), null, null, null, null, null, "St. Frances Assisi", "St. Frances Assisi", false, null, null, null, "St. Frances Assisi", (short)75, 14, (short)2 },
                    { 132, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9807), null, null, null, null, null, "Grace Point", "Grace Point", false, null, null, null, "Grace Point", (short)76, 14, (short)2 },
                    { 133, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9808), null, null, null, null, null, "Grace Bible Fellowship", "Grace Bible Fellowship", false, null, null, null, "Grace Bible Fellowship", (short)77, 14, (short)2 },
                    { 134, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9809), null, null, null, null, null, "Anthem Church", "Anthem Church", false, null, null, null, "Anthem Church", (short)78, 14, (short)2 },
                    { 135, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9811), null, null, null, null, null, "Green Valley Baptist", "Green Valley Baptist", false, null, null, null, "Green Valley Baptist", (short)79, 14, (short)2 },
                    { 136, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9812), null, null, null, null, null, "Other", "Other", false, null, null, null, "Other", (short)80, 14, (short)2 },
                    { 137, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9813), null, null, null, null, null, "Planned Parenthood", "Planned Parenthood", false, null, null, null, "Planned Parenthood", (short)1, 15, (short)2 },
                    { 138, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9814), null, null, null, null, null, "Birth Control Center", "Birth Control Center", false, null, null, null, "Birth Control Center", (short)2, 15, (short)2 },
                    { 139, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9816), null, null, null, null, null, "Other", "Other", false, null, null, null, "Other", (short)3, 15, (short)2 }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Flag", "IsDeleted", "Iso2", "Iso3", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "Numeric", "OfficialName", "ParentId", "RegionType" },
                values: new object[,]
                {
                    { 197, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4595), null, null, null, null, null, null, false, null, "PR", null, null, null, "Puerto Rico", null, null, 188, (short)2 },
                    { 198, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4601), null, null, null, null, null, null, false, null, "MA", null, null, null, "Massachusetts", null, null, 188, (short)2 },
                    { 199, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4602), null, null, null, null, null, null, false, null, "RI", null, null, null, "Rhode Island", null, null, 188, (short)2 },
                    { 200, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4604), null, null, null, null, null, null, false, null, "NH", null, null, null, "New Hampshire", null, null, 188, (short)2 },
                    { 201, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4612), null, null, null, null, null, null, false, null, "ME", null, null, null, "Maine", null, null, 188, (short)2 },
                    { 202, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4614), null, null, null, null, null, null, false, null, "VT", null, null, null, "Vermont", null, null, 188, (short)2 },
                    { 203, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4616), null, null, null, null, null, null, false, null, "CT", null, null, null, "Connecticut", null, null, 188, (short)2 },
                    { 204, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4617), null, null, null, null, null, null, false, null, "NY", null, null, null, "New York", null, null, 188, (short)2 },
                    { 205, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4619), null, null, null, null, null, null, false, null, "NJ", null, null, null, "New Jersey", null, null, 188, (short)2 },
                    { 206, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4621), null, null, null, null, null, null, false, null, "PA", null, null, null, "Pennsylvania", null, null, 188, (short)2 },
                    { 207, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4622), null, null, null, null, null, null, false, null, "DE", null, null, null, "Delaware", null, null, 188, (short)2 },
                    { 208, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4623), null, null, null, null, null, null, false, null, "DC", null, null, null, "District of Columbia", null, null, 188, (short)2 },
                    { 209, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4625), null, null, null, null, null, null, false, null, "VA", null, null, null, "Virginia", null, null, 188, (short)2 },
                    { 210, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4626), null, null, null, null, null, null, false, null, "MD", null, null, null, "Maryland", null, null, 188, (short)2 },
                    { 211, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4627), null, null, null, null, null, null, false, null, "WV", null, null, null, "West Virginia", null, null, 188, (short)2 },
                    { 212, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4629), null, null, null, null, null, null, false, null, "NC", null, null, null, "North Carolina", null, null, 188, (short)2 },
                    { 213, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4630), null, null, null, null, null, null, false, null, "SC", null, null, null, "South Carolina", null, null, 188, (short)2 },
                    { 214, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4632), null, null, null, null, null, null, false, null, "GA", null, null, null, "Georgia", null, null, 188, (short)2 },
                    { 215, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4634), null, null, null, null, null, null, false, null, "FL", null, null, null, "Florida", null, null, 188, (short)2 },
                    { 216, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4655), null, null, null, null, null, null, false, null, "AL", null, null, null, "Alabama", null, null, 188, (short)2 },
                    { 217, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4656), null, null, null, null, null, null, false, null, "TN", null, null, null, "Tennessee", null, null, 188, (short)2 },
                    { 218, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4664), null, null, null, null, null, null, false, null, "MS", null, null, null, "Mississippi", null, null, 188, (short)2 },
                    { 219, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4666), null, null, null, null, null, null, false, null, "KY", null, null, null, "Kentucky", null, null, 188, (short)2 },
                    { 220, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4667), null, null, null, null, null, null, false, null, "OH", null, null, null, "Ohio", null, null, 188, (short)2 },
                    { 221, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4668), null, null, null, null, null, null, false, null, "IN", null, null, null, "Indiana", null, null, 188, (short)2 },
                    { 222, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4670), null, null, null, null, null, null, false, null, "MI", null, null, null, "Michigan", null, null, 188, (short)2 },
                    { 223, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4671), null, null, null, null, null, null, false, null, "IA", null, null, null, "Iowa", null, null, 188, (short)2 },
                    { 224, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4672), null, null, null, null, null, null, false, null, "WI", null, null, null, "Wisconsin", null, null, 188, (short)2 },
                    { 225, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4674), null, null, null, null, null, null, false, null, "MN", null, null, null, "Minnesota", null, null, 188, (short)2 },
                    { 226, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4675), null, null, null, null, null, null, false, null, "SD", null, null, null, "South Dakota", null, null, 188, (short)2 },
                    { 227, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4676), null, null, null, null, null, null, false, null, "ND", null, null, null, "North Dakota", null, null, 188, (short)2 },
                    { 228, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4678), null, null, null, null, null, null, false, null, "MT", null, null, null, "Montana", null, null, 188, (short)2 },
                    { 229, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4679), null, null, null, null, null, null, false, null, "IL", null, null, null, "Illinois", null, null, 188, (short)2 },
                    { 230, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4681), null, null, null, null, null, null, false, null, "MO", null, null, null, "Missouri", null, null, 188, (short)2 },
                    { 231, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4682), null, null, null, null, null, null, false, null, "KS", null, null, null, "Kansas", null, null, 188, (short)2 },
                    { 232, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4684), null, null, null, null, null, null, false, null, "NE", null, null, null, "Nebraska", null, null, 188, (short)2 },
                    { 233, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4685), null, null, null, null, null, null, false, null, "LA", null, null, null, "Louisiana", null, null, 188, (short)2 },
                    { 234, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4686), null, null, null, null, null, null, false, null, "AR", null, null, null, "Arkansas", null, null, 188, (short)2 },
                    { 235, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4688), null, null, null, null, null, null, false, null, "OK", null, null, null, "Oklahoma", null, null, 188, (short)2 },
                    { 236, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4696), null, null, null, null, null, null, false, null, "TX", null, null, null, "Texas", null, null, 188, (short)2 },
                    { 237, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4697), null, null, null, null, null, null, false, null, "CO", null, null, null, "Colorado", null, null, 188, (short)2 },
                    { 238, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4698), null, null, null, null, null, null, false, null, "WY", null, null, null, "Wyoming", null, null, 188, (short)2 },
                    { 239, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4700), null, null, null, null, null, null, false, null, "ID", null, null, null, "Idaho", null, null, 188, (short)2 },
                    { 240, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4701), null, null, null, null, null, null, false, null, "UT", null, null, null, "Utah", null, null, 188, (short)2 },
                    { 241, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4721), null, null, null, null, null, null, false, null, "AZ", null, null, null, "Arizona", null, null, 188, (short)2 },
                    { 242, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4723), null, null, null, null, null, null, false, null, "NM", null, null, null, "New Mexico", null, null, 188, (short)2 },
                    { 243, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4724), null, null, null, null, null, null, false, null, "NV", null, null, null, "Nevada", null, null, 188, (short)2 },
                    { 244, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4726), null, null, null, null, null, null, false, null, "CA", null, null, null, "California", null, null, 188, (short)2 },
                    { 245, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4727), null, null, null, null, null, null, false, null, "HI", null, null, null, "Hawaii", null, null, 188, (short)2 },
                    { 246, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4728), null, null, null, null, null, null, false, null, "OR", null, null, null, "Oregon", null, null, 188, (short)2 },
                    { 247, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4730), null, null, null, null, null, null, false, null, "WA", null, null, null, "Washington", null, null, 188, (short)2 },
                    { 248, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4731), null, null, null, null, null, null, false, null, "AK", null, null, null, "Alaska", null, null, 188, (short)2 }
                });

            migrationBuilder.InsertData(
                table: "RoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "RoleId" },
                values: new object[,]
                {
                    { 1, "permission", "Global.Availability", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(4935), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 2, "permission", "Global.Correction", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(4967), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 3, "permission", "Global.Lot", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(4976), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 4, "permission", "Global.Notice", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(4984), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 5, "permission", "Global.Permission", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(4991), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 6, "permission", "Global.Queue", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5003), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 7, "permission", "Global.Role", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5011), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 8, "permission", "Global.Room", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5018), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 9, "permission", "Global.Setting", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5026), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 10, "permission", "Global.Slider", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5034), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 11, "permission", "Global.Staff", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5042), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 12, "permission", "Global.Tasks", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5049), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 13, "permission", "Global.UserRole", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5094), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 14, "permission", "Global.VisitTermination", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5103), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 15, "permission", "Global.AppointmentBehalf", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5110), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 16, "permission", "Global.CheckIn", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5118), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 17, "permission", "Global.Checkout", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5125), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 18, "permission", "Global.Connection", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5133), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 19, "permission", "Global.Explorer", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5140), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 20, "permission", "Global.RegisterBehalf", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5148), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 21, "permission", "Global.Delayed", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5174), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 22, "permission", "Global.CaseReview", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5182), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 23, "permission", "PregnancyTest.Initial", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5193), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 24, "permission", "PregnancyTest.Medical", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5201), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 25, "permission", "PregnancyTest.Demographic", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5209), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 26, "permission", "PregnancyTest.Required", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5216), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 27, "permission", "PregnancyTest.Appointment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5231), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 28, "permission", "PregnancyTest.Social", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5239), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 29, "permission", "PregnancyTest.SocialReview", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5247), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 30, "permission", "PregnancyTest.Decision", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5272), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 31, "permission", "PregnancyTest.ExitSurvey", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5287), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 32, "permission", "PregnancyTest.QaAssignment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5295), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 33, "permission", "PregnancyTest.PaAssignment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5303), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 34, "permission", "PregnancyTest.RequestList", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5311), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 35, "permission", "PregnancyTest.Vulnerability", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5318), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 36, "permission", "PregnancyTest.Spiritual", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5326), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 37, "permission", "PregnancyTest.TestResult", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5333), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 38, "permission", "PregnancyRetest.Medical", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5341), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 39, "permission", "PregnancyRetest.Appointment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5348), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 40, "permission", "PregnancyRetest.Social", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5356), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 41, "permission", "PregnancyRetest.Decision", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5363), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 42, "permission", "PregnancyRetest.Exit", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5371), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 43, "permission", "PregnancyRetest.Assignment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5379), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 44, "permission", "PregnancyRetest.RequestList", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5386), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 45, "permission", "PregnancyRetest.Vulnerability", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5394), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 46, "permission", "PregnancyRetest.Spiritual", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5420), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 47, "permission", "PregnancyRetest.TestResult", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5428), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 48, "permission", "UltrasoundScan.Interview", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5436), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 49, "permission", "UltrasoundScan.Appointment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5443), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 50, "permission", "UltrasoundScan.UExit", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5451), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 51, "permission", "UltrasoundScan.Assignment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5459), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 52, "permission", "UltrasoundScan.RequestList", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5466), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 53, "permission", "UltrasoundScan.UltrasoundReport", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5473), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 54, "permission", "UltrasoundRescan.Interview", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5481), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 55, "permission", "UltrasoundRescan.Appointment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5489), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 56, "permission", "UltrasoundRescan.UExit", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5496), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 57, "permission", "UltrasoundRescan.Assignment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5503), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 58, "permission", "UltrasoundRescan.RequestList", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5510), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 59, "permission", "UltrasoundRescan.UltrasoundReport", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5518), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 60, "permission", "PregnancyOptionsCounseling.Initial", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5525), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 61, "permission", "PregnancyOptionsCounseling.Demographic", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5533), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 62, "permission", "PregnancyOptionsCounseling.medical", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5540), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 63, "permission", "PregnancyOptionsCounseling.Required", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5548), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 64, "permission", "PregnancyOptionsCounseling.appointment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5574), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 65, "permission", "PregnancyOptionsCounseling.exit", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5582), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 66, "permission", "PregnancyOptionsCounseling.assignment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5590), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 67, "permission", "PregnancyOptionsCounseling.information", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5598), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 68, "permission", "PregnancyOptionsCounseling.requestlist", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5606), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 69, "permission", "PostAbortionCounseling.Initial", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5613), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 70, "permission", "PostAbortionCounseling.Demographic", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5621), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 71, "permission", "PostAbortionCounseling.Medical", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5628), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 72, "permission", "PostAbortionCounseling.Required", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5635), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 73, "permission", "PostAbortionCounseling.Appointment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5643), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 74, "permission", "PostAbortionCounseling.Exit", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5650), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 75, "permission", "PostAbortionCounseling.Assignment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5657), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 76, "permission", "PostAbortionCounseling.Information", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5665), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 77, "permission", "PostAbortionCounseling.RequestList", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5672), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 78, "permission", "PregnancyLossCounseling.Initial", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5680), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 79, "permission", "PregnancyLossCounseling.Demographic", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5704), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 80, "permission", "PregnancyLossCounseling.Medical", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5713), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 81, "permission", "PregnancyLossCounseling.Required", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5721), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 82, "permission", "PregnancyLossCounseling.Appointment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5728), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 83, "permission", "PregnancyLossCounseling.Exit", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5735), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 84, "permission", "PregnancyLossCounseling.Assignment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5743), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 85, "permission", "PregnancyLossCounseling.Information", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5750), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 86, "permission", "PregnancyLossCounseling.RequestList", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5758), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 87, "permission", "DiscipleshipCounseling.Initial", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5765), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 88, "permission", "DiscipleshipCounseling.Demographic", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5772), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 89, "permission", "DiscipleshipCounseling.Medical", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5780), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 90, "permission", "DiscipleshipCounseling.Required", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5787), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 91, "permission", "DiscipleshipCounseling.Appointment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5795), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 92, "permission", "DiscipleshipCounseling.Exit", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5802), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 93, "permission", "DiscipleshipCounseling.Assignment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5810), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 94, "permission", "DiscipleshipCounseling.Information", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5817), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 95, "permission", "DiscipleshipCounseling.RequestList", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5825), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 96, "permission", "PrenatalCareInterview.Pregnancy", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5832), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 97, "permission", "PrenatalCareInterview.MedicalHistory", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5858), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 98, "permission", "PrenatalCareInterview.SupportAssessment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5866), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 99, "permission", "clien.prenatalcareinterviewt.Residence", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5873), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 100, "permission", "PrenatalCareInterview.CarrierScreening", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5881), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 101, "permission", "PrenatalCareInterview.Appointment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5888), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 102, "permission", "PrenatalCareInterview.Assignment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5896), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 103, "permission", "PrenatalCareInterview.RequestList", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5903), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 104, "permission", "PrenatalVisits.Appointment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5910), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 105, "permission", "PrenatalVisits.Exit", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5918), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 106, "permission", "PrenatalVisits.Assignment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5925), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 107, "permission", "PrenatalVisits.Prenatal", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5933), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 108, "permission", "PrenatalVisits.RequestList", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5940), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 109, "permission", "PrenatalVisits.Record", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5948), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 110, "permission", "PrenatalVisits.Laboratory", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5955), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 111, "permission", "MaleCounseling.Initial", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5963), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 112, "permission", "MaleCounseling.Demographic", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5970), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 113, "permission", "MaleCounseling.Malemedical", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(5977), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 114, "permission", "MaleCounseling.Required", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(6009), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 115, "permission", "MaleCounseling.Appointment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(6018), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 116, "permission", "MaleCounseling.Exit", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(6026), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 117, "permission", "MaleCounseling.MaleAssignment", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(6033), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 118, "permission", "MaleCounseling.Medical", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(6041), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") },
                    { 119, "permission", "MaleCounseling.MaleInformation", new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(6049), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342") }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Command", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "DisplayTitle", "Help", "Image", "IsDeleted", "IsRequired", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "Order", "ParentId", "RequiredPolicy", "SectionGroup", "SectionType", "Sex", "URI", "Visibility" },
                values: new object[,]
                {
                    { new Guid("00000001-6df9-4ecb-86c8-000000000001"), "-", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(3978), null, null, null, null, null, "Step 1", "this is step 1", null, false, true, null, null, null, "Step1", 1, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, (short)0, "-", (short)2 },
                    { new Guid("00000002-6df9-4ecb-86c8-000000000002"), "-", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4416), null, null, null, null, null, "Step 2", "this is step 2", null, false, true, null, null, null, "Step2", 2, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, (short)0, "-", (short)2 },
                    { new Guid("00000003-6df9-4ecb-86c8-000000000003"), "-", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4424), null, null, null, null, null, "Step 3", "this is step 3", null, false, true, null, null, null, "Step3", 3, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, (short)0, "-", (short)2 },
                    { new Guid("00000004-6df9-4ecb-86c8-000000000004"), "-", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4427), null, null, null, null, null, "Step 4", "this is step 4", null, false, true, null, null, null, "Step4", 4, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, (short)0, "-", (short)2 },
                    { new Guid("00000005-6df9-4ecb-86c8-000000000005"), "-", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4439), null, null, null, null, null, "Step 5", "this is step 5", null, false, true, null, null, null, "Step5", 5, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, (short)0, "-", (short)2 },
                    { new Guid("00000006-6df9-4ecb-86c8-000000000006"), "-", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4443), null, null, null, null, null, "Step 6", "this is step 6", null, false, true, null, null, null, "Step6", 6, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, (short)0, "-", (short)2 },
                    { new Guid("00000007-6df9-4ecb-86c8-000000000007"), "-", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4447), null, null, null, null, null, "Step 7", "this is step 7", null, false, true, null, null, null, "Step7", 7, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, (short)0, "-", (short)2 },
                    { new Guid("00000008-6df9-4ecb-86c8-000000000008"), "-", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4463), null, null, null, null, null, "Step 8", "this is step 8", null, false, true, null, null, null, "Step8", 8, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, (short)0, "-", (short)2 },
                    { new Guid("00000009-6df9-4ecb-86c8-000000000009"), "-", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4469), null, null, null, null, null, "Step 9", "this is step 9", null, false, true, null, null, null, "Step9", 9, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, (short)0, "-", (short)2 },
                    { new Guid("00000010-6df9-4ecb-86c8-000000000010"), "-", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4483), null, null, null, null, null, "Step 10", "this is step 10", null, false, true, null, null, null, "Step10", 10, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, (short)0, "-", (short)2 },
                    { new Guid("00000011-6df9-4ecb-86c8-000000000011"), "-", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4488), null, null, null, null, null, "Step 11", "this is step 11", null, false, true, null, null, null, "Step11", 11, new Guid("c3c1384e-9822-49f1-97c5-0d065426329b"), "-", (short)1, (short)0, (short)0, "-", (short)2 }
                });

            migrationBuilder.InsertData(
                table: "UserAddresses",
                columns: new[] { "Id", "Address", "AddressType", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "IsDefault", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Order", "RegionId", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("4ac82356-c883-48f0-8f62-7fdf9b468d34"), "SGT Miranda McAnderson\r\n6543 N 9th Street\r\nAPO, AA 33608-1234", (short)1, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(5093), null, null, null, null, null, null, true, false, null, null, null, 1, null, new Guid("ff1e1f19-02b0-460b-9807-d4af12121e82"), "251742310" },
                    { new Guid("c5a31e13-9a80-4904-8f8a-91b7599655f1"), "Robert Robertson, 1234 NW Bobcat Lane, St. Robert, MO 65584-5678", (short)1000, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(6681), null, null, null, null, null, null, false, false, null, null, null, 3, null, new Guid("ff1e1f19-02b0-460b-9807-d4af12121e82"), "351745121" },
                    { new Guid("f16e59bd-c443-4449-822b-4ed7b772360d"), "Suzy Queue\r\n4455 Landing Lange, APT 4\r\nLouisville, KY 40018-1234", (short)2, new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(6675), null, null, null, null, null, null, false, false, null, null, null, 2, null, new Guid("ff1e1f19-02b0-460b-9807-d4af12121e82"), "241542123" }
                });

            migrationBuilder.InsertData(
                table: "UserPhoneNumbers",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "IsDefault", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Order", "PhoneNumber", "PhoneNumberType", "UserId" },
                values: new object[,]
                {
                    { new Guid("0b0cd364-60c4-4806-a1f3-9adaad0359c3"), new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(7047), null, null, null, null, null, "This is my main mobile", true, false, null, null, null, 1, "2345124454", (short)1, new Guid("ff1e1f19-02b0-460b-9807-d4af12121e82") },
                    { new Guid("3f8b1635-3c32-4d89-8f86-0cf6dba90195"), new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(8502), null, null, null, null, null, "Emergency Contact (my father)", false, false, null, null, null, 3, "8834551820", (short)5, new Guid("ff1e1f19-02b0-460b-9807-d4af12121e82") },
                    { new Guid("a3191ebf-3526-4ea6-be51-528275479d36"), new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(8495), null, null, null, null, null, "Bussines Fax", false, false, null, null, null, 2, "5234525867", (short)4, new Guid("ff1e1f19-02b0-460b-9807-d4af12121e82") }
                });

            migrationBuilder.InsertData(
                table: "UserProfile",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "EmergencyName", "EmergencyPhone", "FirstName", "Gender", "Height", "IdNumber", "IntroMethodDescription", "IntroMethodId", "IsDeleted", "IsNoticeAccepted", "IsVolunteer", "LastName", "MiddleName", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "ProfileImage", "RaceNationality", "UserId", "Weight" },
                values: new object[] { new Guid("0900a4df-dd2b-471e-baaf-edbfeb78eed8"), null, new DateTime(2022, 12, 26, 13, 19, 12, 994, DateTimeKind.Utc).AddTicks(1998), null, null, null, null, null, null, null, null, "Test name", (short)1, null, null, null, null, false, null, null, "Test family", null, null, null, null, null, null, new Guid("ff1e1f19-02b0-460b-9807-d4af12121e82"), null });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "RoleId", "UserId" },
                values: new object[] { new Guid("ef83f644-04da-4d90-beaa-9ca9ffc5e011"), new DateTime(2022, 12, 26, 13, 19, 13, 8, DateTimeKind.Utc).AddTicks(7401), null, null, null, null, null, false, null, null, null, new Guid("1f53b465-cef8-467f-a163-758fe2bed342"), new Guid("ff1e1f19-02b0-460b-9807-d4af12121e82") });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "Culture", "DarkMode", "DefaultTenantId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "RightToLeft", "Theme", "UserId" },
                values: new object[] { new Guid("05dc8b10-81df-47f1-94fd-c5c396ad3348"), new DateTime(2022, 12, 26, 13, 19, 12, 994, DateTimeKind.Utc).AddTicks(2034), null, null, "en-US", false, null, null, null, null, false, null, null, null, false, "", new Guid("ff1e1f19-02b0-460b-9807-d4af12121e82") });

            migrationBuilder.InsertData(
                table: "IntroMethods",
                columns: new[] { "Id", "AdditionalInfoLabel", "AdditionalInfoRequired", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "Description", "DisplayTitle", "IsDeleted", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "Order", "ParentId", "Type" },
                values: new object[,]
                {
                    { 25, "Radio Station", true, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9464), null, null, null, null, null, "Secular", "Secular Radio", false, null, null, null, "SecularRadio", (short)1, 21, (short)2 },
                    { 26, "Radio Station", true, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9465), null, null, null, null, null, "Christian", "Christian Radio", false, null, null, null, "ChristianRadio", (short)2, 21, (short)2 },
                    { 27, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9467), null, null, null, null, null, "Google Ads", "Google Ads", false, null, null, null, "GoogleAds", (short)1, 24, (short)2 },
                    { 28, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9468), null, null, null, null, null, "Facebook", "Facebook", false, null, null, null, "Facebook", (short)2, 24, (short)2 },
                    { 29, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9469), null, null, null, null, null, "Yelp", "Yelp", false, null, null, null, "Yelp", (short)3, 24, (short)2 },
                    { 30, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9481), null, null, null, null, null, "Instagram", "Instagram", false, null, null, null, "Instagram", (short)4, 24, (short)2 },
                    { 31, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9483), null, null, null, null, null, "Twitter", "Twitter", false, null, null, null, "Twitter", (short)5, 24, (short)2 },
                    { 32, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9484), null, null, null, null, null, "Game Apps", "Game Apps", false, null, null, null, "GameApps", (short)6, 24, (short)2 },
                    { 33, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9485), null, null, null, null, null, "Tinder", "Tinder", false, null, null, null, "Tinder", (short)7, 24, (short)2 },
                    { 34, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9488), null, null, null, null, null, "Signage", "Signage", false, null, null, null, "Signage", (short)8, 24, (short)2 },
                    { 35, null, false, new DateTime(2022, 12, 26, 13, 19, 11, 677, DateTimeKind.Utc).AddTicks(9489), null, null, null, null, null, "Medical Mobile Unit Sign", "Medical Mobile Unit Sign", false, null, null, null, "MedicalMobileUnitSign", (short)9, 24, (short)2 }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Command", "CreatedDate", "CreatedIpAddress", "CreatedUserId", "DeletedDate", "DeletedIpAddress", "DeletedUserId", "DisplayTitle", "Help", "Image", "IsDeleted", "IsRequired", "ModifiedDate", "ModifiedIpAddress", "ModifiedUserId", "Name", "Order", "ParentId", "RequiredPolicy", "SectionGroup", "SectionType", "Sex", "URI", "Visibility" },
                values: new object[,]
                {
                    { new Guid("04a1f6c7-bc25-44c5-a03c-89cdae176b95"), "CheckIn", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4503), null, null, null, null, null, "Check-In", "In this section,the check-in will be done by the institution.", null, false, true, null, null, null, "CheckIn", 1, new Guid("00000002-6df9-4ecb-86c8-000000000002"), "Global.CheckIn", (short)2, (short)1, (short)0, "CheckIn", (short)2 },
                    { new Guid("07d2d70e-04bd-47a9-be75-07ac79ba5559"), "Fill Medical Info", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4500), null, null, null, null, null, "Medical Info", "In this section, the corresponding form is filled by the client.", null, false, true, null, null, null, "MedicalInfo", 2, new Guid("00000001-6df9-4ecb-86c8-000000000001"), "PregnancyTest.Medical", (short)2, (short)3, (short)0, "-", (short)2 },
                    { new Guid("15a7a441-3fda-45af-b55d-207c8048fc24"), "Check-out", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4586), null, null, null, null, null, "Check-out", "In this section,the check-out will be done by the institution.", null, false, false, null, null, null, "Checkout", 2, new Guid("00000011-6df9-4ecb-86c8-000000000011"), "Global.Checkout", (short)2, (short)2, (short)0, "Checkout", (short)2 },
                    { new Guid("25ccff72-d895-4589-ae4f-d0920ba498d9"), "Review", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4530), null, null, null, null, null, "Social Review", "In this section, the social form filled by the client is approved by the institution.", null, false, true, null, null, null, "SocialReview", 1, new Guid("00000006-6df9-4ecb-86c8-000000000006"), "PregnancyTest.SocialReview", (short)2, (short)8, (short)0, "Social", (short)2 },
                    { new Guid("388eb72c-1cf5-420a-b429-e4ca18354448"), "Fill Vulnerability", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4574), null, null, null, null, null, "Vulnerability", "In this section, the vulnerability form filled by the institution.", null, false, true, null, null, null, "vulnerability", 1, new Guid("00000009-6df9-4ecb-86c8-000000000009"), "PregnancyTest.Vulnerability", (short)2, (short)11, (short)0, "vulnerability", (short)2 },
                    { new Guid("46cfc37a-798c-43a4-bbd0-5c4461eae8d0"), "Fill Survey", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4577), null, null, null, null, null, "Exit Survey", "In this section, the exit survey form filled by the institution.", null, false, true, null, null, null, "ExitSurvey", 1, new Guid("00000010-6df9-4ecb-86c8-000000000010"), "PregnancyTest.ExitSurvey", (short)2, (short)12, (short)0, "ExitSurvey", (short)2 },
                    { new Guid("63467563-34b8-4e3f-85dd-3d82f5d9cd22"), "Take Client", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4523), null, null, null, null, null, "Pro Advocate Assignment", "In this section, one of the institution's employees will be responsible for continuing the work.", null, false, true, null, null, null, "PaAssignment", 1, new Guid("00000005-6df9-4ecb-86c8-000000000005"), "PregnancyTest.PaAssignment", (short)2, (short)7, (short)0, "PaAssignment", (short)2 },
                    { new Guid("70c45833-c7f0-49cc-affd-19e7a0e00ed0"), "Fill Decision", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4534), null, null, null, null, null, "Decision", "In this section, the corresponding form is filled by the client.", null, false, true, null, null, null, "Decision", 1, new Guid("00000007-6df9-4ecb-86c8-000000000007"), "PregnancyTest.Decision", (short)2, (short)9, (short)0, "Decision", (short)2 },
                    { new Guid("78f0e8fd-dc08-4aab-b81a-079400c15c33"), "ARL", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4580), null, null, null, null, null, "ARL", "In this section, the ARL form filled by the institution.", null, false, true, null, null, null, "ARL", 2, new Guid("00000010-6df9-4ecb-86c8-000000000010"), "PregnancyTest.RequestList", (short)2, (short)13, (short)0, "ARL", (short)2 },
                    { new Guid("7918950a-f58e-447b-b3cc-a3a946b363cd"), "Review", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4563), null, null, null, null, null, "Decision Review", "In this section, the decision form filled by the client is approved by the institution.", null, false, true, null, null, null, "DecisionReview", 1, new Guid("00000008-6df9-4ecb-86c8-000000000008"), "PregnancyTest.Decision", (short)2, (short)10, (short)0, "Decision", (short)2 },
                    { new Guid("8b113113-29c5-467f-896b-763fedbedd43"), "Fill Demographic Intake", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4492), null, null, null, null, null, "Demographic Intake", "In this section, the corresponding form is filled by the client.", null, false, true, null, null, null, "DemographicIntake", 1, new Guid("00000001-6df9-4ecb-86c8-000000000001"), "PregnancyTest.Demographic", (short)2, (short)2, (short)0, "DemographicIntake", (short)2 },
                    { new Guid("958f234b-c49e-4402-8525-70c01f3b7330"), "Take Client", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4513), null, null, null, null, null, "Qualified Advocate Assignment", "In this section, one of the institution's employees will be responsible for continuing the work.", null, false, true, null, null, null, "QaAssignment", 1, new Guid("00000003-6df9-4ecb-86c8-000000000003"), "PregnancyTest.QaAssignment", (short)2, (short)4, (short)0, "QaAssignment", (short)2 },
                    { new Guid("cdeec4ee-6cb2-49e5-85cf-d3098efeaf10"), "Fill Test Result", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4520), null, null, null, null, null, "Test Result", "In this section,the test result will be done by the institution.", null, false, true, null, null, null, "TestResult", 2, new Guid("00000004-6df9-4ecb-86c8-000000000004"), "PregnancyTest.TestResult", (short)2, (short)6, (short)0, "TestResult", (short)2 },
                    { new Guid("d05912f3-4c37-46d0-aca9-53a7b9913972"), "Fill Spiritual", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4583), null, null, null, null, null, "Spiritual Form", "In this section, the ARL form filled by the institution.", null, false, false, null, null, null, "Spiritual", 1, new Guid("00000011-6df9-4ecb-86c8-000000000011"), "PregnancyTest.Spiritual", (short)2, (short)14, (short)0, "Spiritual", (short)2 },
                    { new Guid("e0698701-fcef-483f-8c7f-211f5ca01a43"), "Fill Social", new DateTime(2022, 12, 26, 13, 19, 11, 687, DateTimeKind.Utc).AddTicks(4516), null, null, null, null, null, "Social Form", "In this section, the corresponding form is filled by the client.", null, false, true, null, null, null, "Social", 1, new Guid("00000004-6df9-4ecb-86c8-000000000004"), "PregnancyTest.Social", (short)2, (short)5, (short)0, "Social", (short)2 }
                });

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
                name: "IX_SectionClaims_SectionId",
                table: "SectionClaims",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ParentId",
                table: "Sections",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_SectionId",
                table: "Tasks",
                column: "SectionId");

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
                name: "SectionClaims");

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
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "IntroMethods");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Cases");
        }
    }
}
