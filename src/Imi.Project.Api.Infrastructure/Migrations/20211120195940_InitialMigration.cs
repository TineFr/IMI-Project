using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ScientificName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    Usage = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicine_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Birds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    HatchDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Food = table.Column<string>(nullable: true),
                    CageId = table.Column<Guid>(nullable: true),
                    SpeciesId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Birds_Cages_CageId",
                        column: x => x.CageId,
                        principalTable: "Cages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Birds_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Birds_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DailyTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CageId = table.Column<Guid>(nullable: false),
                    IsDone = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyTasks_Cages_CageId",
                        column: x => x.CageId,
                        principalTable: "Cages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MedicineId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BirdPrescriptions",
                columns: table => new
                {
                    BirdId = table.Column<Guid>(nullable: false),
                    PrescriptionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdPrescriptions", x => new { x.BirdId, x.PrescriptionId });
                    table.ForeignKey(
                        name: "FK_BirdPrescriptions_Birds_BirdId",
                        column: x => x.BirdId,
                        principalTable: "Birds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BirdPrescriptions_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000002"), "990cd681-f206-494a-ab38-f537b17da54c", "BaseUser", "BASEUSER" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), "ff162166-cf75-4152-bd10-e520c4965c54", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000010"), 0, "a2bc2cff-08f3-4893-b12f-1bb725a3f1a4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "janne.jannes@gmail.com", true, null, false, null, null, "JANNE.JANNES@GMAIL.COM", "JANNE.JANNES@GMAIL.COM", "AQAAAAEAACcQAAAAEIqVJe0NmGIWuuMeqcV57hJCC1IdeqwghwwabotewshE9/PYcyNdCdgtVQK3hRo2nA==", null, false, "dfaaa082-aef4-4a11-91f1-fc17f0ac1ac4", false, "janne.jannes@gmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), 0, "39a5eb3e-2b77-4c46-804d-7ec70bf7160f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lotens.jurgen@hotmail.com", true, null, false, null, null, "LOTENS.JURGEN@HOTMAIL.COM", "LOTENS.JURGEN@HOTMAIL.COM", "AQAAAAEAACcQAAAAEEy+/RYSKcRoXzboioL4IiKztocSzY76NVS3Lx4vKcIjnXiHX8vACc+4V1OzuGO+3g==", null, false, "888c0d7d-7b1c-4f56-8248-c34db821276e", false, "lotens.jurgen@hotmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), 0, "1dc8fc6d-16b3-4d91-8348-2f40329a700e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ann.meerpoel@skynet.be", true, null, false, null, null, "ANN.MEERPOEL@SKYNET.BE", "ANN.MEERPOEL@SKYNET.BE", "AQAAAAEAACcQAAAAEDMNorjzeF6Cr5DBnmsBk+eVQEx6U59HL1hpGOMyO3unSiHQ15popDRgYViYSEjbjQ==", null, false, "58bbd765-2b38-41a0-ae0a-3f07b43da725", false, "ann.meerpoel@skynet.be" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), 0, "7d1180be-ae37-4c81-842e-4d0a185e5faf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "niels.verbeke@hotmail.com", true, null, false, null, null, "NIELS.VERBEKE@HOTMAIL.COM", "NIELS.VERBEKE@HOTMAIL.COM", "AQAAAAEAACcQAAAAEIUOm7PBsVmNxN1RmL2MJc3laNfdmGaOIMGnKck4M1bm8zZCUlagQfLGC52DmYBUbg==", null, false, "9f65e2c9-324a-40f3-b7d9-f15f3fa380bc", false, "niels.verbeke@hotmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), 0, "ad4e6e17-b62b-4555-8cca-c3917bebb182", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tine.franchois@gmail.com", false, null, false, null, null, "TINE.FRANCHOIS@GMAIL.COM", "TINE.FRANCHOIS@GMAIL.COM", "AQAAAAEAACcQAAAAEHnAG/2obGR7BnD41IwRLZmzXp9pP1okIV6Tyi4uAfy2nrX2rQCBAfLCXf874A+jtw==", null, false, "15f13435-10e0-4222-ad87-ab2f3993c2a5", false, "tine.franchois@gmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), 0, "ba6956be-9043-4b46-9f69-33653566a2f0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jochem.dewandel@gmail.com", true, null, false, null, null, "JOCHEM.DEWANDEL@GMAIL.COM", "JOCHEM.DEWANDEL@GMAIL.COM", "AQAAAAEAACcQAAAAEBb0Y1jnucsQb35p/MFV6Xq8r2B5W2j+R7WUmKkY3r/OaHaaEaWXeDjUnbGDepb/cQ==", null, false, "581a6d62-fd07-4c56-8e30-9b2dabbe04ec", false, "jochem.dewandel@gmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 0, "69715a6c-8fe6-42d2-b780-b62e2bb8ae55", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "haenebalcke.niels@gmail.com", true, null, false, null, null, "HAENEBALCKE.NIELS@GMAIL.COM", "HAENEBALCKE.NIELS@GMAIL.COM", "AQAAAAEAACcQAAAAEKiWxDWa72WZJRGku8qPB7duexf+NuSjyVf2W8QgeEtDxBxo5V5x3qX6uaaawvLv8A==", null, false, "cafdc2f7-852e-4715-ad2f-5cd591e7fa83", false, "haenebalcke.niels@gmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 0, "776c8aa1-2f45-4668-8261-f42877450d32", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "depotter.sander@gmail.com", true, null, false, null, null, "DEPOTTER.SANDER@GMAIL.COM", "DEPOTTER.SANDER@GMAIL.COM", "AQAAAAEAACcQAAAAEBuYLpJTJ1ilIt2RGyqk+hM8t2iFsnEWezo8IaTnYy70MfYL960eRyVQN4KbpmSGrg==", null, false, "5408698d-3fb8-41e4-9175-851afdef69a6", false, "depotter.sander@gmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 0, "f710fdc3-6f19-4666-8234-f1030dc0d2c5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "deq.claire@gmail.com", false, null, false, null, null, "DEQ.CLAIRE@GMAIL.COM", "DEQ.CLAIRE@GMAIL.COM", "AQAAAAEAACcQAAAAECSQjYvC4eOG44zkQ21YwS/rzksVuD9sH+RUTCWQWt7zLYy5A8ILgc0yMRnYhVTaVQ==", null, false, "99b15552-fd2d-4e02-bcc9-50465ccd3b5c", false, "deq.claire@gmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), 0, "5f2a8b52-419f-4537-ad50-cf21b7eed03c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jonas.desmet@telenet.be", true, null, false, null, null, "JONAS.DESMET@TELENET.BE", "JONAS.DESMET@TELENET.BE", "AQAAAAEAACcQAAAAEGlSf8OJtWldZMKNUBhuE+UBX+aomdDHYmF/Lit6LtpdD5P3mmLF901Dq3SNzE5vBw==", null, false, "6d449862-3252-4502-9d75-32225c5b1634", false, "jonas.desmet@telenet.be" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Name", "ScientificName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Budgerigar", "Melopsittacus undulatus" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Zebra finch", "Taeniopygia guttata" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Canary", "Serinus canaria forma domestica" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Pacific parrotlet", "Forpus coelestis" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Bourke’s parrot", "Neopsephotus bourkii" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Rosy-faced lovebrid", "Agapornis roseicollis" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Green-Cheeked Conure", "Pyrrhura molinae" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Gouldian finch", "Chloebia gouldiae" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Society finch", "Lonchura striata domestica" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Cockatiel", "Nymphicus hollandicuss" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.InsertData(
                table: "Cages",
                columns: new[] { "Id", "Image", "Location", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000010"), "images/cage/cage10.png", "Outside", "Vintage Cage", new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "images/cage/cage5.jpg", "Outside", "Pink Cage", new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "images/cage/cage8.jpg", "Dining room", "Mansion Cage", new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "images/cage/cage7.jpg", "Dining room", "Small Black Cage", new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), "images/cage/cage1.png", "Outside", "Outside Cage 1", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "images/cage/cage6.jpg", "Kitchen", "House-shaped Cage", new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "images/cage/cage2.png", "Outside", "Outside Cage 2", new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "images/cage/cage9.jpg", "Living room", "Gold Cage", new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "images/cage/cage3.jpg", "Living room", "White Cage", new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "images/cage/cage4.jpg", "Study room", "Desk Cage", new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.InsertData(
                table: "Medicine",
                columns: new[] { "Id", "Name", "Usage", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Dextrotonic", "15ml per liter of drinking water", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Acox", "6ml per liter of drinking water", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Amoxicillin 10% ", "administer 1 teaspoon per 1 gallon of drinking water", new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Amtyl", "Mix 3g into 2 teaspoons of water and give 1ml of solution per 100grams of body weight.", new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Aureomycin", "1/4 teaspoon to 1 quart of water", new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Penicillin", "Mix 1/4 teaspoon to 1 gallon of water", new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Dextrotonic", "15ml per liter of drinking water", new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "Acox", "6ml per liter of drinking water", new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Calciboost", "In water (10-20 mls per liter) or on soft-food 0.1-0.2 mls per 100g bodyweight. ", new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "Enrofloxacin 10%", "Mix 1 tsp. per 1 Gallon of water", new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "Acox", "6ml per liter of drinking water", new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "Dextrotonic", "15ml per liter of drinking water", new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "CocciPlus", "use 1/2 teaspoon to 1 gallon of water.", new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Acox", "6ml per liter of drinking water", new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "Doxyvet Liquid", "Use at the rate of 1ml (20 drops) in 100ml of drinking water", new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "Colloidal Silver", "15ml per liter of drinking water", new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "Endocox Powder", "1 teaspoon (5 grams) per 1 gallon of drinking water", new Guid("00000000-0000-0000-0000-000000000007") }
                });

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "CageId", "Food", "Gender", "HatchDate", "Image", "Name", "SpeciesId", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001"), "Parakeet mix", 0, new DateTime(2012, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/cockatiel1.jpg", "Steven", new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000007"), "Parrot food", 0, new DateTime(2011, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/lovebird2.jpg", "Birdo", new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000007"), "Parrot food", 1, new DateTime(2011, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/lovebird1.jpg", "Rosie", new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000006"), "Parakeet mix", 1, new DateTime(2012, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/bourkesparakeet1.jpg", "Bourkie", new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000008"), "Classic Avi-Cakes for Small Birds", 0, new DateTime(2012, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/greencheekedconure1.jpg", "Cheeky", new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000005"), "Parrot Food", 0, new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/pacificparrotlet1.jpg", "Parro", new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000004"), "Canary Seed", 1, new DateTime(2015, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/canary1.jpg", "Connie", new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000003"), "Birdseed", 1, new DateTime(2018, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/zebrafinch2.jpg", "Keira", new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000003"), "Birdseed", 0, new DateTime(2019, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/zebrafinch1.jpg", "Flynn", new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000009"), "Birdseed", 1, new DateTime(2021, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/goldianfinch1.jpg", "Goldie", new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001"), "Parakeet mix", 1, new DateTime(2014, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/cockatiel2.jpg", "July", new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001"), "Parakeet mix", 1, new DateTime(2014, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/cockatiel3.jpg", "June", new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002"), "Parakeet mix", 0, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/budgie1.jpg", "Jake", new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000010"), "Birdseed", 1, new DateTime(2020, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/societyfinch1.jpg", "Lily", new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001"), "Parakeet mix", 0, new DateTime(2014, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/cockatiel4.jpg", "Jupiter", new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002"), null, 1, new DateTime(2017, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/budgie2.jpg", "Holly", new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.InsertData(
                table: "DailyTasks",
                columns: new[] { "Id", "CageId", "Description", "IsDone" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000002"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000006"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000006"), "Add food", true },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000006"), "Clean branches", true },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-000000000008"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000005"), "Clean branches", true },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000005"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), "Clean branches", true },
                    { new Guid("00000000-0000-0000-0000-000000000024"), new Guid("00000000-0000-0000-0000-000000000010"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-000000000008"), "Clean branches", true },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000004"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000004"), "Add food", true },
                    { new Guid("00000000-0000-0000-0000-000000000023"), new Guid("00000000-0000-0000-0000-000000000010"), "Add food", true },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000007"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-000000000009"), "Clean branches", true },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000003"), "Clean branches", true },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000003"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000021"), new Guid("00000000-0000-0000-0000-000000000009"), "Add food", true },
                    { new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-000000000009"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000002"), "Add food", true },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000002"), "Clean branches", true },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000004"), "Clean branches", true },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000007"), "Clean branches", true }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "EndDate", "MedicineId", "StartDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000013"), new DateTime(2021, 11, 24, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(606), new Guid("00000000-0000-0000-0000-000000000013"), new DateTime(2021, 11, 20, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(603), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2021, 12, 1, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(561), new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2021, 11, 20, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(558), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2021, 11, 24, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(578), new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2021, 11, 20, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(576), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2021, 11, 25, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(570), new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2021, 11, 20, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(567), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2021, 11, 22, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(552), new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2021, 11, 20, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(550), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2021, 11, 24, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(544), new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2021, 11, 20, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(541), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2021, 11, 26, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(535), new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2021, 11, 20, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(532), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2021, 11, 24, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(526), new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2021, 11, 20, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(524), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2021, 11, 27, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(516), new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2021, 11, 20, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(512), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2021, 11, 24, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(497), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2021, 11, 20, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(482), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2021, 11, 27, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(183), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2021, 11, 20, 20, 59, 39, 874, DateTimeKind.Local).AddTicks(397), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2021, 11, 24, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(588), new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2021, 11, 20, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(585), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new DateTime(2021, 11, 27, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(597), new Guid("00000000-0000-0000-0000-000000000012"), new DateTime(2021, 11, 20, 20, 59, 39, 877, DateTimeKind.Local).AddTicks(594), new Guid("00000000-0000-0000-0000-000000000010") }
                });

            migrationBuilder.InsertData(
                table: "BirdPrescriptions",
                columns: new[] { "BirdId", "PrescriptionId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000011") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000013") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000013") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000012") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BirdPrescriptions_PrescriptionId",
                table: "BirdPrescriptions",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Birds_CageId",
                table: "Birds",
                column: "CageId");

            migrationBuilder.CreateIndex(
                name: "IX_Birds_SpeciesId",
                table: "Birds",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Birds_UserId",
                table: "Birds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cages_UserId",
                table: "Cages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyTasks_CageId",
                table: "DailyTasks",
                column: "CageId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_UserId",
                table: "Medicine",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_MedicineId",
                table: "Prescriptions",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_UserId",
                table: "Prescriptions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BirdPrescriptions");

            migrationBuilder.DropTable(
                name: "DailyTasks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Birds");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Cages");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
