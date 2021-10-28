using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ScientificName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    Usage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicine_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Birds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
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
                        name: "FK_Birds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DailyTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
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
                name: "BirdMedicines",
                columns: table => new
                {
                    BirdId = table.Column<Guid>(nullable: false),
                    MedicineId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdMedicines", x => new { x.BirdId, x.MedicineId });
                    table.ForeignKey(
                        name: "FK_BirdMedicines_Birds_BirdId",
                        column: x => x.BirdId,
                        principalTable: "Birds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BirdMedicines_Medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Name", "ScientificName" },
                values: new object[,]
                {
                    { new Guid("5894d41b-e7c2-4125-8a66-92c802bf8ed2"), "Cockatiel", "Nymphicus hollandicuss" },
                    { new Guid("dbcebceb-24ee-4477-8a09-7042512f1f6d"), "Budgerigar", "Melopsittacus undulatus" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591"), "Franchois" },
                    { new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b"), "Dequinnemaere" }
                });

            migrationBuilder.InsertData(
                table: "Cages",
                columns: new[] { "Id", "Image", "Location", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("2fb04232-9775-4ef8-bb2d-cc1c0296e84c"), "images/cage/cage1.png", "Outside", "Outside Cage 1", new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591") },
                    { new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"), "images/cage/cage2.png", "Outside", "Outside Cage 2", new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b") }
                });

            migrationBuilder.InsertData(
                table: "Medicine",
                columns: new[] { "Id", "Name", "Usage", "UserId" },
                values: new object[,]
                {
                    { new Guid("eb6e6128-25cf-4b4b-b511-fce4a801d1f0"), "Dextrotonic", "15ml per liter of drinking water", new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591") },
                    { new Guid("44411f0e-5e99-49b4-9beb-922d3a97093d"), "Acox", "6ml per liter of drinking water", new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591") }
                });

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "CageId", "Food", "Gender", "HatchDate", "Image", "Name", "SpeciesId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8606c209-1d51-4ee3-9f8d-8de3d0f3f24e"), new Guid("2fb04232-9775-4ef8-bb2d-cc1c0296e84c"), "Parakeet mix", 0, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/budgie1.jpg", "Jake", new Guid("dbcebceb-24ee-4477-8a09-7042512f1f6d"), new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591") },
                    { new Guid("6668e055-e99c-4b50-ad12-5a28ca2ad422"), new Guid("2fb04232-9775-4ef8-bb2d-cc1c0296e84c"), "Parakeet mix", 1, new DateTime(2017, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/budgie2.jpg", "Holly", new Guid("dbcebceb-24ee-4477-8a09-7042512f1f6d"), new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591") },
                    { new Guid("8e74a018-6d85-4e2a-bb85-f8da2d58f3bf"), new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"), "Parakeet mix", 0, new DateTime(2012, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/cockatiel1.jpg", "Steven", new Guid("5894d41b-e7c2-4125-8a66-92c802bf8ed2"), new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b") },
                    { new Guid("8470bc8b-28ac-4e51-9faf-4fcf4c5f0d14"), new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"), "Parakeet mix", 1, new DateTime(2014, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/cockatiel2.jpg", "July", new Guid("5894d41b-e7c2-4125-8a66-92c802bf8ed2"), new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b") }
                });

            migrationBuilder.InsertData(
                table: "DailyTasks",
                columns: new[] { "Id", "CageId", "IsDone", "Name" },
                values: new object[,]
                {
                    { new Guid("dc063e36-6a74-429d-9569-97838a06ede7"), new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"), false, "Refill water" },
                    { new Guid("2fb04232-9775-4ef8-bb2d-cc1c0296e84c"), new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"), true, "Clean branches" }
                });

            migrationBuilder.InsertData(
                table: "BirdMedicines",
                columns: new[] { "BirdId", "MedicineId" },
                values: new object[] { new Guid("6668e055-e99c-4b50-ad12-5a28ca2ad422"), new Guid("44411f0e-5e99-49b4-9beb-922d3a97093d") });

            migrationBuilder.InsertData(
                table: "BirdMedicines",
                columns: new[] { "BirdId", "MedicineId" },
                values: new object[] { new Guid("8e74a018-6d85-4e2a-bb85-f8da2d58f3bf"), new Guid("eb6e6128-25cf-4b4b-b511-fce4a801d1f0") });

            migrationBuilder.CreateIndex(
                name: "IX_BirdMedicines_MedicineId",
                table: "BirdMedicines",
                column: "MedicineId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BirdMedicines");

            migrationBuilder.DropTable(
                name: "DailyTasks");

            migrationBuilder.DropTable(
                name: "Birds");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Cages");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
