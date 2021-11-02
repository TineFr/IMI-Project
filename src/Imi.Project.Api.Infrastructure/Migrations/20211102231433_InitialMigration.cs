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
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
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
                        name: "FK_Prescriptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                table: "Species",
                columns: new[] { "Id", "Name", "ScientificName" },
                values: new object[,]
                {
                    { new Guid("5894d41b-e7c2-4125-8a66-92c802bf8ed2"), "Cockatiel", "Nymphicus hollandicuss" },
                    { new Guid("77c58c3a-4d83-4aeb-9f52-3f6dcd220991"), "Gouldian finch", "Chloebia gouldiae" },
                    { new Guid("9dd9092f-3ee6-4912-a30e-5d6fa5a3cbbf"), "Green-Cheeked Conure", "Pyrrhura molinae" },
                    { new Guid("76f07ff5-9f33-457d-9670-def36354afc4"), "Rosy-faced lovebrid", "Agapornis roseicollis" },
                    { new Guid("26825fce-1d1a-48ef-b41f-a65b099d7469"), "Bourke’s parrot", "Neopsephotus bourkii" },
                    { new Guid("d2100a88-4892-4727-bbb5-f2ab846a5568"), "Society finch", "Lonchura striata domestica" },
                    { new Guid("024ff36d-ab70-4e63-80b4-6732179f1dc7"), "Canary", "Serinus canaria forma domestica" },
                    { new Guid("ea4b7aa4-9855-487d-ab36-d361a7bf0dfd"), "Zebra finch", "Taeniopygia guttata" },
                    { new Guid("dbcebceb-24ee-4477-8a09-7042512f1f6d"), "Budgerigar", "Melopsittacus undulatus" },
                    { new Guid("ec476ed6-7c6c-4550-abb7-01c088bebb98"), "Pacific parrotlet", "Forpus coelestis" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5fe16af9-4ef4-4150-a117-7101fc54f5e7"), "Lootens" },
                    { new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591"), "Franchois" },
                    { new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b"), "Dequinnemaere" },
                    { new Guid("530eb08b-f676-480b-969f-8968efdbc1bf"), "Depotter" },
                    { new Guid("4e0f6789-5dc7-44e7-8158-40fb528cf3ed"), "Haenebalcke" },
                    { new Guid("933d1a9f-7bbb-43e2-b450-22ea20a2b252"), "De Wandel" },
                    { new Guid("f5366b81-e363-40c8-a090-76ce62c2aec2"), "De Smet" },
                    { new Guid("c896a1b4-aa50-4f24-ac69-022dbde764c4"), "Verbeke" },
                    { new Guid("c2f73340-7b1e-46fa-99de-f751716b8cb4"), "Meerpoel" },
                    { new Guid("512dcc41-cc66-4ce7-98af-608784f78f72"), "Van De Sompel" }
                });

            migrationBuilder.InsertData(
                table: "Cages",
                columns: new[] { "Id", "Image", "Location", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("2fb04232-9775-4ef8-bb2d-cc1c0296e84c"), "images/cage/cage1.png", "Outside", "Outside Cage 1", new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591") },
                    { new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"), "images/cage/cage2.png", "Outside", "Outside Cage 2", new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b") },
                    { new Guid("f1a017b4-a9ee-44d0-96f6-ceef146399d5"), "images/cage/cage3.jpg", "Living room", "White Cage", new Guid("530eb08b-f676-480b-969f-8968efdbc1bf") },
                    { new Guid("9e192a55-6ba4-4551-a266-7e0ac50b600f"), "images/cage/cage4.jpg", "Study room", "Desk Cage", new Guid("4e0f6789-5dc7-44e7-8158-40fb528cf3ed") },
                    { new Guid("882960e6-4aa7-4db2-bebb-2085fca6e6ec"), "images/cage/cage9.jpg", "Living room", "Gold Cage", new Guid("933d1a9f-7bbb-43e2-b450-22ea20a2b252") },
                    { new Guid("dec5e6f3-aec0-4a64-ade1-1d27ee2551ed"), "images/cage/cage6.jpg", "Kitchen", "House-shaped Cage", new Guid("f5366b81-e363-40c8-a090-76ce62c2aec2") },
                    { new Guid("e4cf0b3d-0f7c-47d0-a3f4-61d6ebf5fdbb"), "images/cage/cage7.jpg", "Dining room", "Small Black Cage", new Guid("c896a1b4-aa50-4f24-ac69-022dbde764c4") },
                    { new Guid("796ea575-67b8-492d-9dc9-9b146ddd46a7"), "images/cage/cage8.jpg", "Dining room", "Mansion Cage", new Guid("c2f73340-7b1e-46fa-99de-f751716b8cb4") },
                    { new Guid("475f3d68-64c5-442c-9f9b-d78077bf86ce"), "images/cage/cage5.jpg", "Outside", "Pink Cage", new Guid("5fe16af9-4ef4-4150-a117-7101fc54f5e7") },
                    { new Guid("d3a15731-39c1-4d8b-8d92-f8b75a06de91"), "images/cage/cage10.png", "Outside", "Vintage Cage", new Guid("512dcc41-cc66-4ce7-98af-608784f78f72") }
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
                    { new Guid("4ab6a030-6f8b-47dc-abe5-e73a720825cb"), new Guid("796ea575-67b8-492d-9dc9-9b146ddd46a7"), "Classic Avi-Cakes for Small Birds", 0, new DateTime(2012, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/greencheekedconure1.jpg", "Cheeky", new Guid("9dd9092f-3ee6-4912-a30e-5d6fa5a3cbbf"), new Guid("c2f73340-7b1e-46fa-99de-f751716b8cb4") },
                    { new Guid("9d4fa8c1-8393-4f7d-9d69-8de0a0e6af25"), new Guid("e4cf0b3d-0f7c-47d0-a3f4-61d6ebf5fdbb"), "Parrot food", 0, new DateTime(2011, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/lovebird2.jpg", "Birdo", new Guid("76f07ff5-9f33-457d-9670-def36354afc4"), new Guid("c896a1b4-aa50-4f24-ac69-022dbde764c4") },
                    { new Guid("e40bc83b-cefa-4df1-bfbe-6ef74fc1fea9"), new Guid("e4cf0b3d-0f7c-47d0-a3f4-61d6ebf5fdbb"), "Parrot food", 1, new DateTime(2011, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/lovebird1.jpg", "Rosie", new Guid("76f07ff5-9f33-457d-9670-def36354afc4"), new Guid("c896a1b4-aa50-4f24-ac69-022dbde764c4") },
                    { new Guid("eb74bb0d-aa4e-4a08-8c51-a345a2364487"), new Guid("dec5e6f3-aec0-4a64-ade1-1d27ee2551ed"), "Parakeet mix", 1, new DateTime(2012, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/bourkesparakeet1.jpg", "Bourkie", new Guid("26825fce-1d1a-48ef-b41f-a65b099d7469"), new Guid("f5366b81-e363-40c8-a090-76ce62c2aec2") },
                    { new Guid("f3aecf28-88f9-45ea-87bd-2cb490e8f95c"), new Guid("882960e6-4aa7-4db2-bebb-2085fca6e6ec"), "Parrot Food", 0, new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/pacificparrotlet1.jpg", "Parro", new Guid("ec476ed6-7c6c-4550-abb7-01c088bebb98"), new Guid("933d1a9f-7bbb-43e2-b450-22ea20a2b252") },
                    { new Guid("257df2fc-fa69-41fb-9dcb-fb21555972c4"), new Guid("9e192a55-6ba4-4551-a266-7e0ac50b600f"), "Canary Seed", 1, new DateTime(2015, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/canary1.jpg", "Connie", new Guid("024ff36d-ab70-4e63-80b4-6732179f1dc7"), new Guid("4e0f6789-5dc7-44e7-8158-40fb528cf3ed") },
                    { new Guid("2518b942-e928-43ab-981c-2cdc2e6705b3"), new Guid("f1a017b4-a9ee-44d0-96f6-ceef146399d5"), "Birdseed", 1, new DateTime(2018, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/zebrafinch2.jpg", "Keira", new Guid("ea4b7aa4-9855-487d-ab36-d361a7bf0dfd"), new Guid("530eb08b-f676-480b-969f-8968efdbc1bf") },
                    { new Guid("d2a75360-d1a3-4d44-a8a2-5342cde36dd5"), new Guid("f1a017b4-a9ee-44d0-96f6-ceef146399d5"), "Birdseed", 0, new DateTime(2019, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/zebrafinch1.jpg", "Flynn", new Guid("ea4b7aa4-9855-487d-ab36-d361a7bf0dfd"), new Guid("530eb08b-f676-480b-969f-8968efdbc1bf") },
                    { new Guid("4a90f4c5-87e9-497b-a53d-7dba2e135a3d"), new Guid("d3a15731-39c1-4d8b-8d92-f8b75a06de91"), "Birdseed", 1, new DateTime(2020, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/societyfinch1.jpg", "Lily", new Guid("d2100a88-4892-4727-bbb5-f2ab846a5568"), new Guid("512dcc41-cc66-4ce7-98af-608784f78f72") },
                    { new Guid("0b862c07-6d07-4aee-a1a6-fc28740c4c97"), new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"), "Parakeet mix", 0, new DateTime(2014, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/cockatiel4.jpg", "Jupiter", new Guid("5894d41b-e7c2-4125-8a66-92c802bf8ed2"), new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b") },
                    { new Guid("6c46edba-c183-41bc-b1b8-f9b89e9d5c4d"), new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"), "Parakeet mix", 1, new DateTime(2014, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/cockatiel3.jpg", "June", new Guid("5894d41b-e7c2-4125-8a66-92c802bf8ed2"), new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b") },
                    { new Guid("8470bc8b-28ac-4e51-9faf-4fcf4c5f0d14"), new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"), "Parakeet mix", 1, new DateTime(2014, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/cockatiel2.jpg", "July", new Guid("5894d41b-e7c2-4125-8a66-92c802bf8ed2"), new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b") },
                    { new Guid("8e74a018-6d85-4e2a-bb85-f8da2d58f3bf"), new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"), "Parakeet mix", 0, new DateTime(2012, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/cockatiel1.jpg", "Steven", new Guid("5894d41b-e7c2-4125-8a66-92c802bf8ed2"), new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b") },
                    { new Guid("6668e055-e99c-4b50-ad12-5a28ca2ad422"), new Guid("2fb04232-9775-4ef8-bb2d-cc1c0296e84c"), "Parakeet mix", 1, new DateTime(2017, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/budgie2.jpg", "Holly", new Guid("dbcebceb-24ee-4477-8a09-7042512f1f6d"), new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591") },
                    { new Guid("bbc756d6-106f-4be0-a221-f977f2f11590"), new Guid("475f3d68-64c5-442c-9f9b-d78077bf86ce"), "Birdseed", 1, new DateTime(2021, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/goldianfinch1.jpg", "Goldie", new Guid("77c58c3a-4d83-4aeb-9f52-3f6dcd220991"), new Guid("5fe16af9-4ef4-4150-a117-7101fc54f5e7") }
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
                table: "Prescriptions",
                columns: new[] { "Id", "EndDate", "MedicineId", "Name", "StartDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("f8dc77b5-ef08-4ce6-936c-fc3c44f682a8"), new DateTime(2021, 11, 7, 0, 14, 33, 267, DateTimeKind.Local).AddTicks(7786), new Guid("44411f0e-5e99-49b4-9beb-922d3a97093d"), null, new DateTime(2021, 11, 3, 0, 14, 33, 267, DateTimeKind.Local).AddTicks(7773), null },
                    { new Guid("53d1b65f-4785-4790-8f0f-62378de01f4e"), new DateTime(2021, 11, 10, 0, 14, 33, 267, DateTimeKind.Local).AddTicks(7482), new Guid("eb6e6128-25cf-4b4b-b511-fce4a801d1f0"), null, new DateTime(2021, 11, 3, 0, 14, 33, 263, DateTimeKind.Local).AddTicks(9174), null }
                });

            migrationBuilder.InsertData(
                table: "BirdPrescriptions",
                columns: new[] { "BirdId", "PrescriptionId" },
                values: new object[] { new Guid("6668e055-e99c-4b50-ad12-5a28ca2ad422"), new Guid("53d1b65f-4785-4790-8f0f-62378de01f4e") });

            migrationBuilder.InsertData(
                table: "BirdPrescriptions",
                columns: new[] { "BirdId", "PrescriptionId" },
                values: new object[] { new Guid("6668e055-e99c-4b50-ad12-5a28ca2ad422"), new Guid("f8dc77b5-ef08-4ce6-936c-fc3c44f682a8") });

            migrationBuilder.InsertData(
                table: "BirdPrescriptions",
                columns: new[] { "BirdId", "PrescriptionId" },
                values: new object[] { new Guid("8e74a018-6d85-4e2a-bb85-f8da2d58f3bf"), new Guid("f8dc77b5-ef08-4ce6-936c-fc3c44f682a8") });

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
                name: "BirdPrescriptions");

            migrationBuilder.DropTable(
                name: "DailyTasks");

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
                name: "Users");
        }
    }
}
