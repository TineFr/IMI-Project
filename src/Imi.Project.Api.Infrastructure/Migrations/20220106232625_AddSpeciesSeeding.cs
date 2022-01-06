using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class AddSpeciesSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "ConcurrencyStamp",
                value: "7c8e110a-2b33-41b9-83a0-b2450dabdabe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "ConcurrencyStamp",
                value: "3f496e18-ea14-423b-b4cc-38da5721dded");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7153f222-58c9-49fa-994c-8c824e3d2958", "AQAAAAEAACcQAAAAEAOaXdiP6v+EKaXeZhYilq0v78PncSXJ+ORJfOdy65A5ouy+3v4qDzPyneUimWX8BA==", "02f1c0a3-f9aa-4d4d-8ad3-f3ff0c7d0a2b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b006016-3496-4be5-80ed-4a42f60be957", "AQAAAAEAACcQAAAAELqVNYtpSgR/QSdd//05hZeAUcUGgv7G0PJQbHKKNHyNr5VS1oHe3qjhI9gY6uxxvQ==", "14afa922-3777-4872-90bc-6674258bd807" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b768c267-1eba-4356-8c8a-61876c99b1d2", "AQAAAAEAACcQAAAAEOZYbtxJ2Zr5p00Jo1HgitBNogW7aAk5n2HK7PRi4vrphgJBK49GIHisatw+fwS/sQ==", "573672a7-6498-479d-89d1-481f01c89661" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31913528-6351-4fb5-ab50-bac22e2c2aad", "AQAAAAEAACcQAAAAECKxN3yig16BqCRYhwTzgzkDSNau3nOpX8+BQXm+cbIPeuJEQ9mqTfNh5wt97uu2+g==", "39979abf-c144-4050-8f64-bb419a9705c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e83ebba-115e-48c6-ab39-1766359d7794", "AQAAAAEAACcQAAAAEBy6ZtOVx/YBpV0RltGKS68VpB7h7i8PI8LfEZs47GKZKG10qtPzxTZmSB3Np6In8g==", "51524ace-5c1b-421e-915e-328010e2714b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "127498c4-7fdf-45c3-ad2a-9e0c1976c7c3", "AQAAAAEAACcQAAAAEEztoq0ybPolDeUnOnbj088MJ119ZbkdpBrmT7Lx+BaVpiNvUiIcDkJUzeb7q1fzkg==", "3c7815fd-ffdc-4587-9caa-03ed9706ab73" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ca7ccba-a568-41d1-8067-fed5e2cd6043", "AQAAAAEAACcQAAAAEIQbUAh+XL3dTYhGITchBKQviMqIoZSMOy666kGNP5IiUcd845lGoTW4jzXVh0hh4w==", "b0e38ef4-fcff-4f2d-9c7a-b9b2383da764" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1838d1f7-b280-4280-8d68-ce5dde4117ab", "AQAAAAEAACcQAAAAEBi2xI6KwqifJS6RHgCfaofJ+kBgjcRZTwJxb2q6mDweb2da/zKl0DN91PJ7F0UTSA==", "a362abd6-efa5-4201-b443-f0e31edcdfd5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b441f845-daa9-441b-82fa-0dbec56397f6", "AQAAAAEAACcQAAAAEE7SFw7142fvEQwKy1+qetBAJN+NYbrUkDNhidMcitXW5BfegnJGj8xHEooQ1HfWVg==", "7610cbdc-d6ad-4e48-a915-c16f9415c18c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34c09c27-ea0d-4d17-a5cd-1581a880584a", "AQAAAAEAACcQAAAAEMrDQIdykY5cy7gUk0F8vG46O6S3Z2kyQI4/7A5Okf79+74jxrBX74tmWXh5pb1kSQ==", "c1cdb347-20ee-492f-a75d-c6c2ca786823" });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 14, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3413), new DateTime(2022, 1, 7, 0, 26, 25, 296, DateTimeKind.Local).AddTicks(3819) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 11, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3718), new DateTime(2022, 1, 7, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3704) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 14, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3737), new DateTime(2022, 1, 7, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3734) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 11, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3748), new DateTime(2022, 1, 7, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3745) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 13, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3757), new DateTime(2022, 1, 7, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3754) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 11, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3766), new DateTime(2022, 1, 7, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3763) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 9, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3774), new DateTime(2022, 1, 7, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3771) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 18, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3783), new DateTime(2022, 1, 7, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3780) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 12, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3792), new DateTime(2022, 1, 7, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3789) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 11, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3801), new DateTime(2022, 1, 7, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3799) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 11, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3812), new DateTime(2022, 1, 7, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3809) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 14, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3820), new DateTime(2022, 1, 7, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 11, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3829), new DateTime(2022, 1, 7, 0, 26, 25, 299, DateTimeKind.Local).AddTicks(3826) });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Description", "Image" },
                values: new object[] { "The cockatiel (Nymphicus hollandicus), also known as weiro bird, or quarrion, is a medium sized parrot that is a member of its own branch of the cockatoo family endemic to Australia. They are prized as household pets and companion parrots throughout the world and are relatively easy to breed. As a caged bird, cockatiels are second in popularity only to the budgerigar.", "images/species/cockatiel.jpg" });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "Description", "Image" },
                values: new object[] { "The budgerigar , also known as the common parakeet or shell parakeet, is a small, long-tailed, seed-eating parrot usually nicknamed the budgie, or in American English, the parakeet. Budgies are the only species in the genus Melopsittacus. Naturally, the species is green and yellow with black, scalloped markings on the nape, back, and wings. Budgies are bred in captivity with colouring of blues, whites, yellows, greys, and even with small crests.", "images/species/budgie.jpg" });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "Image",
                value: "images/species/zebrafinch.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Description", "Image" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "Description", "Image" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "Image",
                value: null);
        }
    }
}
