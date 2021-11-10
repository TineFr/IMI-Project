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
                    AccessFailedCount = table.Column<int>(nullable: false)
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
                    { new Guid("00000000-0000-0000-0000-000000000002"), "7742d065-8bf2-49b1-aa8e-ffa7c1e0732f", "BaseUser", "BASEUSER" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), "5fa9dcb7-26d2-46c8-866d-78de35763cc2", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000010"), 0, "caa026fa-01a3-4be2-8c54-7a422235a801", "janne.jannes@gmail.com", true, false, null, "JANNE.JANNES@GMAIL.COM", "JANNE.JANNES@GMAIL.COM", "AQAAAAEAACcQAAAAEJ5Ee5ek/4/FJ9+7tpJb8N3LByaxymjeniGHxhpqypvK5XIB2pj2B/pLRIrS+09O5A==", null, false, "92bcaefc-ac0a-4943-bdc2-3a16cd533943", false, "janne.jannes@gmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), 0, "0ae75bd9-05d0-4926-8f36-2dd0defee6b2", "lotens.jurgen@hotmail.com", true, false, null, "LOTENS.JURGEN@HOTMAIL.COM", "LOTENS.JURGEN@HOTMAIL.COM", "AQAAAAEAACcQAAAAENFH2BQDVMbqjHQbyYjxEsD2QiWj/x6tUAEd2IY8xX2B2kAqW7p9LC5VFyFnEz6YSQ==", null, false, "2c3461ad-0fc7-4b8a-99ea-498a9b16b89a", false, "lotens.jurgen@hotmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), 0, "a83e1b2c-a8c8-4706-aecf-5492545cee76", "ann.meerpoel@skynet.be", true, false, null, "ANN.MEERPOEL@SKYNET.BE", "ANN.MEERPOEL@SKYNET.BE", "AQAAAAEAACcQAAAAEP3SSxfmeUzWgaZnCbfMec4Bosc6MRutQoxQmb1PQfh9ke5ojnsiBVgsqfA5hPCpcw==", null, false, "6eaa9264-4a8e-4fb0-83e8-72c987f482f6", false, "ann.meerpoel@skynet.be" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), 0, "69fd3391-6685-40e3-9886-07678daf3c0f", "niels.verbeke@hotmail.com", true, false, null, "NIELS.VERBEKE@HOTMAIL.COM", "NIELS.VERBEKE@HOTMAIL.COM", "AQAAAAEAACcQAAAAEC4zS21Jo3upoXCntRhuhX/XhptZ7uAw85TiTn4Mfm+O0SbSyjWz1esmC6QtQMWuQw==", null, false, "953cfa8a-4a65-414b-9864-33f8fae3c823", false, "niels.verbeke@hotmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), 0, "95ca15a4-628a-4d42-b1cc-8132c7e81b5b", "tine.franchois@gmail.com", false, false, null, "TINE.FRANCHOIS@GMAIL.COM", "TINE.FRANCHOIS@GMAIL.COM", "AQAAAAEAACcQAAAAEM4k05XJneqX7xvjB4mHow5+lrpqP99cBYQsSxmBLrmTJBSdovvnAHyvpwTOMEu0JA==", null, false, "97c48448-7a9e-464c-84a2-66127d9ccd05", false, "tine.franchois@gmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), 0, "435b1a34-2b4f-4398-9f09-60c8e6fba547", "jochem.dewandel@gmail.com", true, false, null, "JOCHEM.DEWANDEL@GMAIL.COM", "JOCHEM.DEWANDEL@GMAIL.COM", "AQAAAAEAACcQAAAAEAslOkPvps3g5BIf5g0yaPsnqX2OCj1f3AK+6YrofxpkIYOz2gy7bZ4ONH+osLeb/A==", null, false, "1989d0f2-7aa4-4a6e-ab6a-4b7e40578d2d", false, "jochem.dewandel@gmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 0, "2a9d7379-b6e3-4a6a-ac94-af6ee298e28f", "haenebalcke.niels@gmail.com", true, false, null, "HAENEBALCKE.NIELS@GMAIL.COM", "HAENEBALCKE.NIELS@GMAIL.COM", "AQAAAAEAACcQAAAAELEiVTTY3ZHGLY161dp20nb6TPYnr+3tiS9iIJM1ImvyGvt0GvfHzdG2Vcf6V7VwUw==", null, false, "3d0eaed6-9411-4eac-aaf8-baeb87c44d5a", false, "haenebalcke.niels@gmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 0, "8f2c0925-fcd5-447c-bbeb-76b3c8d90ccd", "depotter.sander@gmail.com", true, false, null, "DEPOTTER.SANDER@GMAIL.COM", "DEPOTTER.SANDER@GMAIL.COM", "AQAAAAEAACcQAAAAEEmXUyesW+QaCk2CuOG49v+wkR9OhzUZ47lwVD8aVvibNXK2Fp+zUXoOd25lbqWBLg==", null, false, "0908e294-251c-4b0a-a31c-469979076d28", false, "depotter.sander@gmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 0, "ac191c0f-2992-416d-ba14-36a4035067b4", "deq.claire@gmail.com", false, false, null, "DEQ.CLAIRE@GMAIL.COM", "DEQ.CLAIRE@GMAIL.COM", "AQAAAAEAACcQAAAAEHIlnwteI+Z3KJ5CHt8bMhGPuz+hZibCRE9yeRsoEO5yn8D+X1WY7vDxkDD22SIFqQ==", null, false, "038f9e8b-99b7-430b-9179-5c886aa7daba", false, "deq.claire@gmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), 0, "a5a4805d-062c-4296-b33a-252068c0c355", "jonas.desmet@telenet.be", true, false, null, "JONAS.DESMET@TELENET.BE", "JONAS.DESMET@TELENET.BE", "AQAAAAEAACcQAAAAEJVMtWskNBSlE8W00cXwbgvBPYpJ3x7CZXA5gXFzNTp8CZUCK6wWVjBJs1Pnbjo6Bw==", null, false, "8b30c23c-1bec-488c-b8c3-fdd8216e5acd", false, "jonas.desmet@telenet.be" }
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
                    { new Guid("00000000-0000-0000-0000-000000000013"), new DateTime(2021, 11, 14, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5553), new Guid("00000000-0000-0000-0000-000000000013"), new DateTime(2021, 11, 10, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5551), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2021, 11, 21, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5507), new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2021, 11, 10, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5504), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2021, 11, 14, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5526), new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2021, 11, 10, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5523), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2021, 11, 15, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5516), new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2021, 11, 10, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5513), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2021, 11, 12, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5437), new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2021, 11, 10, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5435), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2021, 11, 14, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5429), new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2021, 11, 10, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5426), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2021, 11, 16, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5420), new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2021, 11, 10, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5417), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2021, 11, 14, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5410), new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2021, 11, 10, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5407), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2021, 11, 17, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5397), new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2021, 11, 10, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5394), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2021, 11, 14, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5378), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2021, 11, 10, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5364), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2021, 11, 17, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5075), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2021, 11, 10, 23, 46, 58, 167, DateTimeKind.Local).AddTicks(4437), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2021, 11, 14, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5535), new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2021, 11, 10, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5532), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new DateTime(2021, 11, 17, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5545), new Guid("00000000-0000-0000-0000-000000000012"), new DateTime(2021, 11, 10, 23, 46, 58, 170, DateTimeKind.Local).AddTicks(5542), new Guid("00000000-0000-0000-0000-000000000010") }
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
