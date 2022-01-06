using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class Speciesupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Species",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Species",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "ConcurrencyStamp",
                value: "cd4fcfee-75da-45b7-ae7a-7c5451c5d1fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "ConcurrencyStamp",
                value: "da6dd8f7-9182-4ef9-97c1-117f29411b28");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae3357e6-eb9e-4686-b629-8cdaec2d185f", "AQAAAAEAACcQAAAAEM58YMqMFlvOnvEslY07ZUQ6mBEID9lxStJc7WW6VuuxQQiw4XHi4xyjgxnmGtL6cA==", "97e8bf0f-fc8e-415c-bac2-1ef6a71c32ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53259326-1eff-4497-aca9-c22d424e09e8", "AQAAAAEAACcQAAAAEFlz/5yb8ijvk/fGgw9Ac2SO8x7cnASd0jIB4UprFVtzEMXywmG6DBc6+ewYF+FvPA==", "0e09138f-6249-4e59-8ecd-096e2f28231a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe599ace-203e-41b6-8957-e7dba522d171", "AQAAAAEAACcQAAAAEDn6ma6W6BBcX3B/Sa4NnX4XhkbbI5AyjWV9hD5lJA2VQUsXelYDOwUx6n2j9aBOyg==", "009c16f2-5bb8-4412-b6c1-d5b1a5782f13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b27572b-0071-4a0e-bab6-fa1e73a86afd", "AQAAAAEAACcQAAAAEPh2B0/X4oNnWI9F2CkPmoIMPpDEN8lyx0w4wcIaRLugA2ujXlVhUJ4vM2+GH+dhMA==", "8d1a8fad-45e8-4b94-bb54-c03acdd295dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5eb04500-9cd6-49df-9594-7dd125a92b6f", "AQAAAAEAACcQAAAAEBj8dA+LU3xaYj0NZygij/gjfrli7WAkphRksq4fNTKz9wdzqm2TkOJhbvmPA3j87A==", "bc3e4f9a-82cd-4bfa-8b3f-2cbe99ed5fca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8f234ab-05d2-448f-ae29-7b0b262ff734", "AQAAAAEAACcQAAAAENxYqkX9eghg2VIvOpMnn53OxqEus1rjcLDwO3OGqnNBG17ZwRW2MqUYDa4hRXtQ6g==", "0ffd7149-77a9-449f-88ec-4062297fc11a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90a56022-9aae-4118-9d36-db3d687241ff", "AQAAAAEAACcQAAAAEB/64ku7y1HAv1E0bq+wyuRQJovLOk0etlE5A8Qox0HPB1JRp9BJWehkaqqxB36a0Q==", "e6bde638-e141-41b0-a89b-7812aa00cb98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d7c27ad-e28b-4608-81a9-3ea375dff75d", "AQAAAAEAACcQAAAAEGCwHQbje0n2muDstDycPAHvAmMDYlx2j8ZL2jMofJkthBQ7FTIA6S1IsCCz5Vd0AA==", "8732f126-65d6-4f47-b521-3499b9fed10a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abb70cd7-35a3-4fcd-8b5a-c8c8c7d2c5a1", "AQAAAAEAACcQAAAAEHvKWqoU8W1PYkA0LXYZ5ztqNPx6kI0PL54OI9Wq2vvlWUjnUzQKXYClN3iL+56kog==", "8b4c2a80-7279-43df-9479-0de4724c4757" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6beff47-6880-4ab7-8a05-96841b712399", "AQAAAAEAACcQAAAAEBWpeCVGAP6Nd323TnmNTx74kEJiFdnOPhQL3wc4XipnDvGvpyGC31kBpF1JA6z9Wg==", "1ac6c732-d7a2-42dc-ba1f-4090717122a4" });

            migrationBuilder.InsertData(
                table: "Cages",
                columns: new[] { "Id", "Image", "Location", "Name", "UserId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000011"), "images/cage/cage11.jpg", "Living room", "Little Home", new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 13, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(5531), new DateTime(2022, 1, 6, 23, 40, 27, 580, DateTimeKind.Local).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 10, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(5902), new DateTime(2022, 1, 6, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(5886) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 13, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(5938), new DateTime(2022, 1, 6, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(5935) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 10, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(5947), new DateTime(2022, 1, 6, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(5945) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 12, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(5957), new DateTime(2022, 1, 6, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(5954) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 10, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(5966), new DateTime(2022, 1, 6, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(5963) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 8, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(5976), new DateTime(2022, 1, 6, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(5973) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 17, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(5984), new DateTime(2022, 1, 6, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(5982) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 11, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(5994), new DateTime(2022, 1, 6, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(5991) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 10, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(6004), new DateTime(2022, 1, 6, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(6001) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 10, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(6015), new DateTime(2022, 1, 6, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(6013) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 13, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(6025), new DateTime(2022, 1, 6, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(6022) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 10, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(6034), new DateTime(2022, 1, 6, 23, 40, 27, 583, DateTimeKind.Local).AddTicks(6031) });

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "CageId", "Food", "Gender", "HatchDate", "Image", "Name", "SpeciesId", "UserId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000011"), "Parakeet mix", 1, new DateTime(2016, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/budgie6.jpg", "Blue", new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "CageId", "Food", "Gender", "HatchDate", "Image", "Name", "SpeciesId", "UserId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-000000000011"), "Parakeet mix", 0, new DateTime(2017, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/bird/budgie7.jpg", "Joey", new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Cages",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Species");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "ConcurrencyStamp",
                value: "0b767bd1-c8b3-4174-b040-b64f7161b7e3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "ConcurrencyStamp",
                value: "c04f7a13-64e9-4b24-95e2-5aea9a709c59");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ce3ae53-2557-4d74-beab-2ef1e1e7e68f", "AQAAAAEAACcQAAAAEOEtVkGmvzH1zFZhIi87LTj28nKHAo6ivHwqIxcM7/voub6QQzKph+ScZpvIAeufoQ==", "6b711716-2ea3-4a69-9890-40de1dc95cc2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f60d13ec-93e0-414a-a209-54a44a07f322", "AQAAAAEAACcQAAAAEPbvOTDf7fYhTefa8M4ua59hPyfs8gMd2lEyR7bjZoteCK/TKrlt88CjUUcdouVExw==", "4fb585c5-f972-4e80-9712-d7dcbade4114" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6e38722-399c-4c6c-9174-2e9c4ac80571", "AQAAAAEAACcQAAAAENZ0TMbokjlJe65KHCdDiNjioPrgMi42p8JiVu/sGYy6EAKr2oKzwPJV7v2AfAH8Gw==", "01647cb8-c96f-47c5-8271-17a8d45fb26c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da713a85-ff35-4944-9e67-a18af8f0ecea", "AQAAAAEAACcQAAAAEJSXKs2zzZXjybTtZN7vh3VLNYRwhV3vuFSNxaCY32hc+JmFTJgvyDM/sKBI621hsA==", "95505f4b-30b2-4665-b28d-037165d045cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f872155b-3e36-4ede-b014-0f0a13de6178", "AQAAAAEAACcQAAAAECIyprTooksirX8Bunuov0GZAtOOBN1IRcjFrorzJ5HOWqr7FyeSQQmJSblQk44w6g==", "a350280c-876a-4429-bcf1-dcccd8cdb88c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e6b9518-3b5e-4a2a-963b-253a4e9a7d09", "AQAAAAEAACcQAAAAEAR93hCTZjh5vd/at1bgWFwVvMUoWraVIbVWfCjYK8y5JxjN1MIOqQU5WynXJ4ujNw==", "23a7ec73-8002-4909-be81-3c82a5bda7eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfe74847-3951-43a9-8b5a-b4256ed751eb", "AQAAAAEAACcQAAAAEIvvJ8tRoTQG4r9ZwFVElurXgn9T4YLcuyZiwFyCW/s7yCoYhlLinTpGBdgVh0e7Cw==", "4f11f8c2-787c-417b-bd70-da8b32b28b90" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "917b6b97-3f67-4531-a814-65c476b44f40", "AQAAAAEAACcQAAAAEGgg6d4LzjFQmlQftHPwvvVE0JFoPp9yLam03LjGtsVkg/YgaUu9QpaKcivMMxFj8A==", "a10fc7df-98a2-4612-97b7-887d865db507" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af08deae-83bd-4677-9e99-2221b0e8cbda", "AQAAAAEAACcQAAAAEAJ6cHgybsYYzRftsNJjKhuLoxd+MU1zQK6NIbya2ZsRxe78Fw+2cRohCrknE6ESXw==", "16bf35af-0095-4286-92ee-c4e9cac3bf1a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f96d6f6e-3852-4271-9860-8328e1228769", "AQAAAAEAACcQAAAAEA+bCye6I+Y8RAgkkd4tjf/i41/r+Aq1tDcnTj8fvyGvJdqoJkdDNGVwtEoRweEjFg==", "f42d1cb4-07e4-47d8-9a97-4fdba7b8f32b" });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 30, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(6640), new DateTime(2021, 12, 23, 13, 25, 33, 202, DateTimeKind.Local).AddTicks(6095) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 27, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(6949), new DateTime(2021, 12, 23, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(6934) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 30, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7020), new DateTime(2021, 12, 23, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7017) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 27, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7029), new DateTime(2021, 12, 23, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7026) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 29, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7039), new DateTime(2021, 12, 23, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7036) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 27, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7048), new DateTime(2021, 12, 23, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7045) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 25, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7056), new DateTime(2021, 12, 23, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7054) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 3, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7065), new DateTime(2021, 12, 23, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7062) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 28, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7074), new DateTime(2021, 12, 23, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7071) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 27, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7083), new DateTime(2021, 12, 23, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7080) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 27, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7093), new DateTime(2021, 12, 23, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7090) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 30, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7121), new DateTime(2021, 12, 23, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 27, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7129), new DateTime(2021, 12, 23, 13, 25, 33, 206, DateTimeKind.Local).AddTicks(7127) });
        }
    }
}
