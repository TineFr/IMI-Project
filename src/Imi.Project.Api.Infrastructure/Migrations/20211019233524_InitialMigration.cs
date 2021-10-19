using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                });

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
                    Name = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pairs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pairs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Birds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    HatchDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    PairId = table.Column<Guid>(nullable: true),
                    CageId = table.Column<Guid>(nullable: true),
                    SpeciesId = table.Column<Guid>(nullable: true),
                    FoodId = table.Column<Guid>(nullable: true),
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
                        name: "FK_Birds_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Birds_Pairs_PairId",
                        column: x => x.PairId,
                        principalTable: "Pairs",
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PairId = table.Column<Guid>(nullable: true),
                    CageId = table.Column<Guid>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    IsOccupied = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nests_Cages_CageId",
                        column: x => x.CageId,
                        principalTable: "Cages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Nests_Pairs_PairId",
                        column: x => x.PairId,
                        principalTable: "Pairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Nests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2191cbe2-9f0c-4064-94d6-e66834bd9064"), "Parrot mix" },
                    { new Guid("a1a2af92-244d-4a49-bf3a-e220298f49b3"), "Parakeet mix" }
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
                columns: new[] { "Id", "Email", "FirstName", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591"), "tine.franchois@gmail.com", "Tine", "Franchois", "15rtfpTN" },
                    { new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b"), "claire.dequinnemaere@gmail.com", "Claire", "Dequinnemaere", "iej456Pn" }
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
                table: "Pairs",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("49f6a183-df21-47a4-80be-a3ac46714584"), "Jake X Holly", new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591") },
                    { new Guid("87ca38ac-99b3-487a-85a4-68053940432a"), "Steven X July", new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b") }
                });

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "CageId", "FoodId", "Gender", "HatchDate", "Image", "Name", "PairId", "SpeciesId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8606c209-1d51-4ee3-9f8d-8de3d0f3f24e"), new Guid("2fb04232-9775-4ef8-bb2d-cc1c0296e84c"), new Guid("a1a2af92-244d-4a49-bf3a-e220298f49b3"), 0, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/budgie1.jpg", "Jake", new Guid("49f6a183-df21-47a4-80be-a3ac46714584"), new Guid("dbcebceb-24ee-4477-8a09-7042512f1f6d"), new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591") },
                    { new Guid("6668e055-e99c-4b50-ad12-5a28ca2ad422"), new Guid("2fb04232-9775-4ef8-bb2d-cc1c0296e84c"), new Guid("a1a2af92-244d-4a49-bf3a-e220298f49b3"), 1, new DateTime(2017, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/budgie2.jpg", "Holly", new Guid("49f6a183-df21-47a4-80be-a3ac46714584"), new Guid("dbcebceb-24ee-4477-8a09-7042512f1f6d"), new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591") },
                    { new Guid("8e74a018-6d85-4e2a-bb85-f8da2d58f3bf"), new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"), new Guid("a1a2af92-244d-4a49-bf3a-e220298f49b3"), 0, new DateTime(2012, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/cockatiel1.jpg", "Steven", new Guid("87ca38ac-99b3-487a-85a4-68053940432a"), new Guid("5894d41b-e7c2-4125-8a66-92c802bf8ed2"), new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b") },
                    { new Guid("8470bc8b-28ac-4e51-9faf-4fcf4c5f0d14"), new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"), new Guid("a1a2af92-244d-4a49-bf3a-e220298f49b3"), 1, new DateTime(2014, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/cockatiel2.jpg", "July", new Guid("87ca38ac-99b3-487a-85a4-68053940432a"), new Guid("5894d41b-e7c2-4125-8a66-92c802bf8ed2"), new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b") }
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
                table: "Nests",
                columns: new[] { "Id", "CageId", "Image", "IsOccupied", "Name", "PairId", "UserId" },
                values: new object[,]
                {
                    { new Guid("666c1fa7-c317-4e84-bba1-3590ba6fa5d9"), new Guid("2fb04232-9775-4ef8-bb2d-cc1c0296e84c"), "images/nest/nestbox2.jpg", true, "Nest Box 1", new Guid("49f6a183-df21-47a4-80be-a3ac46714584"), new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591") },
                    { new Guid("c29cf848-cdef-4251-a78b-b76bff142a7c"), new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"), "images/nest/nestbox1.jpg", true, "Nest Box 2", new Guid("87ca38ac-99b3-487a-85a4-68053940432a"), new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Birds_CageId",
                table: "Birds",
                column: "CageId");

            migrationBuilder.CreateIndex(
                name: "IX_Birds_FoodId",
                table: "Birds",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Birds_PairId",
                table: "Birds",
                column: "PairId");

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
                name: "IX_Nests_CageId",
                table: "Nests",
                column: "CageId");

            migrationBuilder.CreateIndex(
                name: "IX_Nests_PairId",
                table: "Nests",
                column: "PairId",
                unique: true,
                filter: "[PairId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Nests_UserId",
                table: "Nests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_UserId",
                table: "Pairs",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Birds");

            migrationBuilder.DropTable(
                name: "DailyTasks");

            migrationBuilder.DropTable(
                name: "Nests");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Cages");

            migrationBuilder.DropTable(
                name: "Pairs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
