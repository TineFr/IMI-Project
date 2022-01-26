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
                    ScientificName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
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
                    { new Guid("00000000-0000-0000-0000-000000000002"), "f79bea30-71fe-4e42-8a56-072c690f2960", "BaseUser", "BASEUSER" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), "5bdf6847-332a-43fd-b3a6-3e3c17bff7e2", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000010"), 0, "8a9b22c4-8a4d-40b5-ba88-a81800f4881b", new DateTime(2010, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "janne.vhl@gmail.com", false, "Janne", false, null, "Van Horelbeke", "JANNE.VHL@GMAIL.COM", "JANNE.VHL@GMAIL.COM", "AQAAAAEAACcQAAAAEDDM1Dt2QkBiwE149kbYRw3hCNlzci4pt7DYbOR0HkOsH/Zd+tj9hYfzToFqQKRNtA==", null, false, "9ca06be8-39eb-4c18-bd18-25af18c87906", false, "janne.vhl@gmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), 0, "91039f1e-9a82-49ec-bef4-1c7f1d66b459", new DateTime(1972, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "lotens.jurgen@hotmail.com", false, "Jurgen", false, null, "Lotens", "LOTENS.JURGEN@HOTMAIL.COM", "LOTENS.JURGEN@HOTMAIL.COM", "AQAAAAEAACcQAAAAEDK3Hnw3OPJ7tBcXbPzm9UkVS4J2vfgBIYrCDe1RsOV/u75oJgu2XUZIWaSr5zNq8A==", null, false, "47731cc8-9f1b-447f-bc09-2422307b78e2", false, "lotens.jurgen@hotmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), 0, "30a6745f-0f08-4b30-833f-5dbb2d045e63", new DateTime(1970, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "ann.meerpoel@skynet.be", false, "Ann", false, null, "Meerpoel", "ANN.MEERPOEL@SKYNET.BE", "ANN.MEERPOEL@SKYNET.BE", "AQAAAAEAACcQAAAAEMGk7OkQcZdWLNZInjK5hUMCgJdizAsXYTsrDlICGqpH/cSYGXcum1guI21do7hrfQ==", null, false, "61390396-fbd4-437e-9906-2416518de827", false, "ann.meerpoel@skynet.be" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), 0, "146f1dc6-34ee-4002-95bc-ba2159615614", new DateTime(1997, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "niels.verbeke@hotmail.com", false, "Niels", false, null, "Verbeke", "NIELS.VERBEKE@HOTMAIL.COM", "NIELS.VERBEKE@HOTMAIL.COM", "AQAAAAEAACcQAAAAELd6fb6BM+ypaEa1KITPf+FagjXbVB/Q3TDzNCXN9C7fFKQcww47mQ5/LZ8iPjTHZg==", null, false, "d1b82c5f-d420-45a4-8a48-a52ea4e74f7b", false, "niels.verbeke@hotmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), 0, "c3dafb14-6b30-40a1-ae3d-1dfcc09eabee", new DateTime(1997, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tine.franchois@gmail.com", false, "Tine", false, null, "Franchois", "TINE.FRANCHOIS@GMAIL.COM", "TINE.FRANCHOIS@GMAIL.COM", "AQAAAAEAACcQAAAAELcXju2aLt1fen1vi38Iiva0vmDug+z9uZ1mY7cMk9CVGMsEPUV84OeUkrCkBwb65A==", null, false, "cddcb7e8-e685-4645-abef-b780adf8bad7", false, "tine.franchois@gmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), 0, "95a3c57e-f58e-4fc0-8637-ee153785b041", new DateTime(1996, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "jochem.dewandel@gmail.com", false, "Jochem", false, null, "Dewandel", "JOCHEM.DEWANDEL@GMAIL.COM", "JOCHEM.DEWANDEL@GMAIL.COM", "AQAAAAEAACcQAAAAEJOxG2gDML2UbkUZN60m4p71Yf16hsiwWkemIYUKlRQFwz9Mn0Om5v0saJfv8q30vQ==", null, false, "b68ec9d2-4dcf-48ec-b2f1-a1ff6c1d62dd", false, "jochem.dewandel@gmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 0, "d5fd89de-90d0-4190-8a35-c4441cba3853", new DateTime(1997, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "haenebalcke.niels@gmail.com", false, "Niels", false, null, "Haenebalcke", "HAENEBALCKE.NIELS@GMAIL.COM", "HAENEBALCKE.NIELS@GMAIL.COM", "AQAAAAEAACcQAAAAEK+XQV832Md+gcQGqSMJ35Upx1bdzFWWmFkzwS6OCq/s3FHCo790q988K3baauHUlw==", null, false, "211a2185-02db-4389-a808-c0326aea080e", false, "haenebalcke.niels@gmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 0, "4c28a912-d0e5-436c-8002-d85b08e81b37", new DateTime(1995, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "depotter.sander@gmail.com", false, "Sander", false, null, "Depotter", "DEPOTTER.SANDER@GMAIL.COM", "DEPOTTER.SANDER@GMAIL.COM", "AQAAAAEAACcQAAAAEIphHw20TU8FBVTo723P/xyvIkQYJQ05plvfQ8iBI7yD42VhxV0KN0KmE1tKSeKvIw==", null, false, "1d4facd7-8500-4337-9615-131379633891", false, "depotter.sander@gmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 0, "eced8917-ec07-4d80-9c78-a0fe9e63bdf6", new DateTime(1997, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "deq.claire@gmail.com", false, "Claire", false, null, "Dequinnemaere", "DEQ.CLAIRE@GMAIL.COM", "DEQ.CLAIRE@GMAIL.COM", "AQAAAAEAACcQAAAAEJxvwHgbLPN6oswLBgLJtv/SYnnKtcuodu6Yk4dgHugFlFmPcbnIcEPbu8F30D/vQA==", null, false, "dcd045b9-f2fb-4d00-8aaf-222807cc704b", false, "deq.claire@gmail.com" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), 0, "3a09e811-ac3c-40f3-9702-1b5832b4bde8", new DateTime(1997, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jonas.desmet@telenet.be", false, "Jonas", false, null, "DeSmet", "JONAS.DESMET@TELENET.BE", "JONAS.DESMET@TELENET.BE", "AQAAAAEAACcQAAAAEA6Op5iku5SyibNYsqp7hgpdPypsJ162brWeQm7FYLIidVjaQSQZcmkzYR/RlV6REQ==", null, false, "0d82b083-c575-45c3-a972-a98ae7dcb56e", false, "jonas.desmet@telenet.be" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Description", "Image", "Name", "ScientificName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000002"), "The budgerigar , also known as the common parakeet or shell parakeet, is a small, long-tailed, seed-eating parrot usually nicknamed the budgie, or in American English, the parakeet.Budgies are the only species in the genus Melopsittacus. Naturally, the species is green and yellow with black, scalloped markings on the nape, back, and wings. Budgies are bred in captivity with colouring of blues, whites, yellows, greys, and even with small crests. Source:The Spruce Pets", "images/species/budgie.jpg", "Budgerigar", "Melopsittacus undulatus" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Perhaps the most popular finch due to its availability and price, the zebra finch has been kept in captivity for more than a 100 years.Zebra finches breed readily, and are a good beginner’s bird, easy to care for and requiring a minimal time commitment. Source:The Spruce Pets", "images/species/zebrafinch.jpg", "Zebra Finch", "Taeniopygia guttata" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "A canary is an undemanding little charmer that is usually a beginner's cana bird. This small finch has the power to turn most people into lifelong canary enthusiasts. It is a pleasant companion bird with a cheerful disposition. It communicates its content with a melodious song that is soft and pleasant. The canary has been carefully bred to be available in a variety of colors, sizes, and singing varieties. Source:The Spruce Pets", "images/species/canary.png", "Canary", "Serinus canaria forma domestica" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Colorful, charming, and intelligent, Pacific parrotlets are the smallest members of the parrot family. Nicknamed pocket parrots for one of their favorite hiding spots, they have become increasingly popular pets. Their small size and quiet nature make them an ideal choice for people who live in apartments or condos or those who do not have the space to house a larger bird. Some can learn to talk quite well, although it is not known for being a big talker. They make perfectly affectionate and adorable pets. Source:The Spruce Pets", "images/species/pacificparrotlet.jpg", "Pacific Parrotlet", "Forpus coelestis" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Bourke's parakeets are an excellent introductory bird for those new to hookbills or parrots; they have a calm demeanor and can entertain themselves. They are quiet birds that are ideal apartment dwellers and are equally suited for individual cages or small aviaries, where they are excellent partners for finches and cockatiels as well as other Bourke's parakeets. Keep gentle Bourke's parakeets away from larger, aggressive birds. Source:The Spruce Pets", "images/species/bourkesparakeet.jpg", "Bourke’s Parrot", "Neopsephotus bourkii" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Lovebirds are so named because of their strong pair bonds. Lovebirds range in size from just over 5 inches to just over 6½ inches, which makes them among the smaller parrot species. Lovebirds have short, blunt tail feathers, unlike budgies (“parakeets”), which have long pointed tails, and lovebirds are also stockier. Source:The Spruce Pets", "images/species/lovebird.jpg", "Rosy-faced Lovebird", "Agapornis roseicollis" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Popular as pets due to their small size, beauty, and intelligence, green-cheeked conures have stolen many bird lover's hearts. Their curiosity, spunk, and playful nature are great characteristics in a pet bird. Mischievous and engaging, green-cheeked conures pack a lot of personality into a small package. The fact that they are less noisy than most other parrots—and more affordable—adds to their appeal. Source:The Spruce Pets", "images/species/greencheekedconure.jpg", "Green-Cheeked Conure", "Pyrrhura molinae" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "The Gouldian finch is one of the most beautiful of all pet bird species. It is a brilliant, multicolored bird with vibrant plumage. Its shyness with humans makes it a favorite bird for those who enjoy looking at birds but do not want to handle them. This finch is very social with birds of its kind. A small group of these diminutive birds makes for an excellent display in a large enclosure. Source:The Spruce Pets", "images/species/gouldianfinch.jpg", "Gouldian Finch", "Chloebia gouldiae" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Society finches are not the kind of bird that one would choose if they want an avian friend that talks and plays with them, but they do make wonderful pets for those that prefer to be spectators. Society finches are not birds that are easily handled, but that is because of their small size and not because they are aggressive. Society finches may be easily startled and fly around their enclosures when they aren't nesting or eating, but they are typically peaceful.", "images/species/societyfinch.jpg", "Society Finch", "Lonchura striata domestica" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), "The cockatiel (Nymphicus hollandicus), also known as weiro bird, or quarrion, is a medium sized parrot that is a member of its own branch of the cockatoo family endemic to Australia. They are prized as household pets and companion parrots throughout the world and are relatively easy to breed. As a caged bird, cockatiels are second in popularity only to the budgerigar. Source:The Spruce Pets", "images/species/cockatiel.jpg", "Cockatiel", "Nymphicus hollandicuss" }
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
                    { new Guid("00000000-0000-0000-0000-000000000004"), "images/cage/cage4.jpg", "Study room", "Desk Cage", new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "images/cage/cage11.jpg", "Living room", "Little Home", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "images/cage/cage9.jpg", "Living room", "Gold Cage", new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "images/cage/cage2.png", "Outside", "Outside Cage 2", new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "images/cage/cage3.jpg", "Living room", "White Cage", new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "images/cage/cage6.jpg", "Kitchen", "House-shaped Cage", new Guid("00000000-0000-0000-0000-000000000006") }
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
                    { new Guid("00000000-0000-0000-0000-000000000011"), "Colloidal Silver", "15ml per liter of drinking water", new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Dextrotonic", "15ml per liter of drinking water", new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "Enrofloxacin 10%", "Mix 1 tsp. per 1 Gallon of water", new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Calciboost", "In water (10-20 mls per liter) or on soft-food 0.1-0.2 mls per 100g bodyweight. ", new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "Acox", "6ml per liter of drinking water", new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "Dextrotonic", "15ml per liter of drinking water", new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "Endocox Powder", "1 teaspoon (5 grams) per 1 gallon of drinking water", new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "CocciPlus", "use 1/2 teaspoon to 1 gallon of water.", new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Acox", "6ml per liter of drinking water", new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "Acox", "6ml per liter of drinking water", new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "Doxyvet Liquid", "Use at the rate of 1ml (20 drops) in 100ml of drinking water", new Guid("00000000-0000-0000-0000-000000000007") }
                });

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "CageId", "Food", "Gender", "HatchDate", "Image", "Name", "SpeciesId", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001"), "Parakeet mix", 0, new DateTime(2012, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/cockatiel1.jpg", "Steven", new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000006"), "Parakeet mix", 1, new DateTime(2012, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/bourkesparakeet1.jpg", "Bourkie", new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000004"), "Canary Seed", 1, new DateTime(2015, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/canary1.png", "Connie", new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000007"), "Parrot food", 1, new DateTime(2011, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/lovebird1.jpg", "Rosie", new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000007"), "Parrot food", 0, new DateTime(2011, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/lovebird2.jpg", "Birdo", new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000003"), "Birdseed", 1, new DateTime(2018, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/zebrafinch2.jpg", "Keira", new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000003"), "Birdseed", 0, new DateTime(2019, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/zebrafinch1.jpg", "Flynn", new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000008"), "Classic Avi-Cakes for Small Birds", 0, new DateTime(2012, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/greencheekedconure1.jpg", "Cheeky", new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000009"), "Birdseed", 1, new DateTime(2021, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/goldianfinch1.jpg", "Goldie", new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002"), null, 1, new DateTime(2017, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/budgie2.jpg", "Holly", new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002"), "Parakeet mix", 0, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/budgie1.jpg", "Jake", new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000005"), "Parrot Food", 0, new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/pacificparrotlet1.jpg", "Parro", new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001"), "Parakeet mix", 1, new DateTime(2014, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/cockatiel2.jpg", "July", new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-000000000011"), "Parakeet mix", 0, new DateTime(2015, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/budgie4.jpg", "Loki", new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-000000000011"), "Parakeet mix", 0, new DateTime(2017, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/budgie7.jpg", "Joey", new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000011"), "Parakeet mix", 1, new DateTime(2016, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/budgie6.jpg", "Blue", new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000010"), "Birdseed", 1, new DateTime(2020, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/societyfinch1.jpg", "Lily", new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001"), "Parakeet mix", 1, new DateTime(2014, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/cockatiel3.jpg", "June", new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001"), "Parakeet mix", 0, new DateTime(2014, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/cockatiel4.jpg", "Jupiter", new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "DailyTasks",
                columns: new[] { "Id", "CageId", "Description", "IsDone" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-000000000009"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000006"), "Clean branches", true },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000006"), "Add food", true },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000006"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000007"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000021"), new Guid("00000000-0000-0000-0000-000000000009"), "Add food", true },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000007"), "Clean branches", true },
                    { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-000000000008"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000005"), "Clean branches", true },
                    { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-000000000009"), "Clean branches", true },
                    { new Guid("00000000-0000-0000-0000-000000000023"), new Guid("00000000-0000-0000-0000-000000000010"), "Add food", true },
                    { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-000000000008"), "Clean branches", true },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000004"), "Clean branches", true },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000003"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), "Clean branches", true },
                    { new Guid("00000000-0000-0000-0000-000000000024"), new Guid("00000000-0000-0000-0000-000000000010"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000004"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000004"), "Add food", true },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000002"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000002"), "Clean branches", true },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000003"), "Clean branches", true },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000005"), "Refill water", false },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000002"), "Add food", true }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "EndDate", "MedicineId", "StartDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2022, 2, 2, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6118), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2022, 1, 26, 20, 17, 21, 321, DateTimeKind.Local).AddTicks(8706), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2022, 1, 30, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6498), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2022, 1, 26, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6485), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2022, 2, 2, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6514), new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2022, 1, 26, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6511), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2022, 2, 6, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6562), new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2022, 1, 26, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6559), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new DateTime(2022, 1, 30, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6608), new Guid("00000000-0000-0000-0000-000000000013"), new DateTime(2022, 1, 26, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6605), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2022, 2, 1, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6533), new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2022, 1, 26, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6530), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2022, 1, 30, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6545), new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2022, 1, 26, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6542), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2022, 1, 30, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6591), new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2022, 1, 26, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6588), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2022, 1, 28, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6553), new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2022, 1, 26, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6551), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2022, 1, 30, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6580), new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2022, 1, 26, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6577), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2022, 1, 31, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6571), new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2022, 1, 26, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6568), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2022, 1, 30, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6524), new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2022, 1, 26, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6521), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new DateTime(2022, 2, 2, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6599), new Guid("00000000-0000-0000-0000-000000000012"), new DateTime(2022, 1, 26, 20, 17, 21, 324, DateTimeKind.Local).AddTicks(6597), new Guid("00000000-0000-0000-0000-000000000010") }
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
