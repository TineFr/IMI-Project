﻿// <auto-generated />
using System;
using Imi.Project.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Imi.Project.Api.Infrastructure.Migrations
{
    [DbContext(typeof(MyAviaryDbContext))]
    partial class MyAviaryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Bird", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Food")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<DateTime>("HatchDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SpeciesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CageId");

                    b.HasIndex("SpeciesId");

                    b.HasIndex("UserId");

                    b.ToTable("Birds");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8606c209-1d51-4ee3-9f8d-8de3d0f3f24e"),
                            CageId = new Guid("2fb04232-9775-4ef8-bb2d-cc1c0296e84c"),
                            Food = "Parakeet mix",
                            Gender = 0,
                            HatchDate = new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/budgie1.jpg",
                            Name = "Jake",
                            SpeciesId = new Guid("dbcebceb-24ee-4477-8a09-7042512f1f6d"),
                            UserId = new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591")
                        },
                        new
                        {
                            Id = new Guid("6668e055-e99c-4b50-ad12-5a28ca2ad422"),
                            CageId = new Guid("2fb04232-9775-4ef8-bb2d-cc1c0296e84c"),
                            Food = "Parakeet mix",
                            Gender = 1,
                            HatchDate = new DateTime(2017, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/budgie2.jpg",
                            Name = "Holly",
                            SpeciesId = new Guid("dbcebceb-24ee-4477-8a09-7042512f1f6d"),
                            UserId = new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591")
                        },
                        new
                        {
                            Id = new Guid("8e74a018-6d85-4e2a-bb85-f8da2d58f3bf"),
                            CageId = new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"),
                            Food = "Parakeet mix",
                            Gender = 0,
                            HatchDate = new DateTime(2012, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/cockatiel1.jpg",
                            Name = "Steven",
                            SpeciesId = new Guid("5894d41b-e7c2-4125-8a66-92c802bf8ed2"),
                            UserId = new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b")
                        },
                        new
                        {
                            Id = new Guid("8470bc8b-28ac-4e51-9faf-4fcf4c5f0d14"),
                            CageId = new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"),
                            Food = "Parakeet mix",
                            Gender = 1,
                            HatchDate = new DateTime(2014, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/cockatiel2.jpg",
                            Name = "July",
                            SpeciesId = new Guid("5894d41b-e7c2-4125-8a66-92c802bf8ed2"),
                            UserId = new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b")
                        },
                        new
                        {
                            Id = new Guid("6c46edba-c183-41bc-b1b8-f9b89e9d5c4d"),
                            CageId = new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"),
                            Food = "Parakeet mix",
                            Gender = 1,
                            HatchDate = new DateTime(2014, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/cockatiel3.jpg",
                            Name = "June",
                            SpeciesId = new Guid("5894d41b-e7c2-4125-8a66-92c802bf8ed2"),
                            UserId = new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b")
                        },
                        new
                        {
                            Id = new Guid("0b862c07-6d07-4aee-a1a6-fc28740c4c97"),
                            CageId = new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"),
                            Food = "Parakeet mix",
                            Gender = 0,
                            HatchDate = new DateTime(2014, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/cockatiel4.jpg",
                            Name = "Jupiter",
                            SpeciesId = new Guid("5894d41b-e7c2-4125-8a66-92c802bf8ed2"),
                            UserId = new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b")
                        },
                        new
                        {
                            Id = new Guid("d2a75360-d1a3-4d44-a8a2-5342cde36dd5"),
                            CageId = new Guid("f1a017b4-a9ee-44d0-96f6-ceef146399d5"),
                            Food = "Birdseed",
                            Gender = 0,
                            HatchDate = new DateTime(2019, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/zebrafinch1.jpg",
                            Name = "Flynn",
                            SpeciesId = new Guid("ea4b7aa4-9855-487d-ab36-d361a7bf0dfd"),
                            UserId = new Guid("530eb08b-f676-480b-969f-8968efdbc1bf")
                        },
                        new
                        {
                            Id = new Guid("2518b942-e928-43ab-981c-2cdc2e6705b3"),
                            CageId = new Guid("f1a017b4-a9ee-44d0-96f6-ceef146399d5"),
                            Food = "Birdseed",
                            Gender = 1,
                            HatchDate = new DateTime(2018, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/zebrafinch2.jpg",
                            Name = "Keira",
                            SpeciesId = new Guid("ea4b7aa4-9855-487d-ab36-d361a7bf0dfd"),
                            UserId = new Guid("530eb08b-f676-480b-969f-8968efdbc1bf")
                        },
                        new
                        {
                            Id = new Guid("257df2fc-fa69-41fb-9dcb-fb21555972c4"),
                            CageId = new Guid("9e192a55-6ba4-4551-a266-7e0ac50b600f"),
                            Food = "Canary Seed",
                            Gender = 1,
                            HatchDate = new DateTime(2015, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/canary1.jpg",
                            Name = "Connie",
                            SpeciesId = new Guid("024ff36d-ab70-4e63-80b4-6732179f1dc7"),
                            UserId = new Guid("4e0f6789-5dc7-44e7-8158-40fb528cf3ed")
                        },
                        new
                        {
                            Id = new Guid("f3aecf28-88f9-45ea-87bd-2cb490e8f95c"),
                            CageId = new Guid("882960e6-4aa7-4db2-bebb-2085fca6e6ec"),
                            Food = "Parrot Food",
                            Gender = 0,
                            HatchDate = new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/pacificparrotlet1.jpg",
                            Name = "Parro",
                            SpeciesId = new Guid("ec476ed6-7c6c-4550-abb7-01c088bebb98"),
                            UserId = new Guid("933d1a9f-7bbb-43e2-b450-22ea20a2b252")
                        },
                        new
                        {
                            Id = new Guid("eb74bb0d-aa4e-4a08-8c51-a345a2364487"),
                            CageId = new Guid("dec5e6f3-aec0-4a64-ade1-1d27ee2551ed"),
                            Food = "Parakeet mix",
                            Gender = 1,
                            HatchDate = new DateTime(2012, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/bourkesparakeet1.jpg",
                            Name = "Bourkie",
                            SpeciesId = new Guid("26825fce-1d1a-48ef-b41f-a65b099d7469"),
                            UserId = new Guid("f5366b81-e363-40c8-a090-76ce62c2aec2")
                        },
                        new
                        {
                            Id = new Guid("e40bc83b-cefa-4df1-bfbe-6ef74fc1fea9"),
                            CageId = new Guid("e4cf0b3d-0f7c-47d0-a3f4-61d6ebf5fdbb"),
                            Food = "Parrot food",
                            Gender = 1,
                            HatchDate = new DateTime(2011, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/lovebird1.jpg",
                            Name = "Rosie",
                            SpeciesId = new Guid("76f07ff5-9f33-457d-9670-def36354afc4"),
                            UserId = new Guid("c896a1b4-aa50-4f24-ac69-022dbde764c4")
                        },
                        new
                        {
                            Id = new Guid("9d4fa8c1-8393-4f7d-9d69-8de0a0e6af25"),
                            CageId = new Guid("e4cf0b3d-0f7c-47d0-a3f4-61d6ebf5fdbb"),
                            Food = "Parrot food",
                            Gender = 0,
                            HatchDate = new DateTime(2011, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/lovebird2.jpg",
                            Name = "Birdo",
                            SpeciesId = new Guid("76f07ff5-9f33-457d-9670-def36354afc4"),
                            UserId = new Guid("c896a1b4-aa50-4f24-ac69-022dbde764c4")
                        },
                        new
                        {
                            Id = new Guid("4ab6a030-6f8b-47dc-abe5-e73a720825cb"),
                            CageId = new Guid("796ea575-67b8-492d-9dc9-9b146ddd46a7"),
                            Food = "Classic Avi-Cakes for Small Birds",
                            Gender = 0,
                            HatchDate = new DateTime(2012, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/greencheekedconure1.jpg",
                            Name = "Cheeky",
                            SpeciesId = new Guid("9dd9092f-3ee6-4912-a30e-5d6fa5a3cbbf"),
                            UserId = new Guid("c2f73340-7b1e-46fa-99de-f751716b8cb4")
                        },
                        new
                        {
                            Id = new Guid("bbc756d6-106f-4be0-a221-f977f2f11590"),
                            CageId = new Guid("475f3d68-64c5-442c-9f9b-d78077bf86ce"),
                            Food = "Birdseed",
                            Gender = 1,
                            HatchDate = new DateTime(2021, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/goldianfinch1.jpg",
                            Name = "Goldie",
                            SpeciesId = new Guid("77c58c3a-4d83-4aeb-9f52-3f6dcd220991"),
                            UserId = new Guid("5fe16af9-4ef4-4150-a117-7101fc54f5e7")
                        },
                        new
                        {
                            Id = new Guid("4a90f4c5-87e9-497b-a53d-7dba2e135a3d"),
                            CageId = new Guid("d3a15731-39c1-4d8b-8d92-f8b75a06de91"),
                            Food = "Birdseed",
                            Gender = 1,
                            HatchDate = new DateTime(2020, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/societyfinch1.jpg",
                            Name = "Lily",
                            SpeciesId = new Guid("d2100a88-4892-4727-bbb5-f2ab846a5568"),
                            UserId = new Guid("512dcc41-cc66-4ce7-98af-608784f78f72")
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.BirdPrescription", b =>
                {
                    b.Property<Guid>("BirdId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PrescriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BirdId", "PrescriptionId");

                    b.HasIndex("PrescriptionId");

                    b.ToTable("BirdPrescriptions");

                    b.HasData(
                        new
                        {
                            BirdId = new Guid("6668e055-e99c-4b50-ad12-5a28ca2ad422"),
                            PrescriptionId = new Guid("53d1b65f-4785-4790-8f0f-62378de01f4e")
                        },
                        new
                        {
                            BirdId = new Guid("8e74a018-6d85-4e2a-bb85-f8da2d58f3bf"),
                            PrescriptionId = new Guid("f8dc77b5-ef08-4ce6-936c-fc3c44f682a8")
                        },
                        new
                        {
                            BirdId = new Guid("6668e055-e99c-4b50-ad12-5a28ca2ad422"),
                            PrescriptionId = new Guid("f8dc77b5-ef08-4ce6-936c-fc3c44f682a8")
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Cage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cages");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2fb04232-9775-4ef8-bb2d-cc1c0296e84c"),
                            Image = "images/cage/cage1.png",
                            Location = "Outside",
                            Name = "Outside Cage 1",
                            UserId = new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591")
                        },
                        new
                        {
                            Id = new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"),
                            Image = "images/cage/cage2.png",
                            Location = "Outside",
                            Name = "Outside Cage 2",
                            UserId = new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b")
                        },
                        new
                        {
                            Id = new Guid("f1a017b4-a9ee-44d0-96f6-ceef146399d5"),
                            Image = "images/cage/cage3.jpg",
                            Location = "Living room",
                            Name = "White Cage",
                            UserId = new Guid("530eb08b-f676-480b-969f-8968efdbc1bf")
                        },
                        new
                        {
                            Id = new Guid("9e192a55-6ba4-4551-a266-7e0ac50b600f"),
                            Image = "images/cage/cage4.jpg",
                            Location = "Study room",
                            Name = "Desk Cage",
                            UserId = new Guid("4e0f6789-5dc7-44e7-8158-40fb528cf3ed")
                        },
                        new
                        {
                            Id = new Guid("882960e6-4aa7-4db2-bebb-2085fca6e6ec"),
                            Image = "images/cage/cage9.jpg",
                            Location = "Living room",
                            Name = "Gold Cage",
                            UserId = new Guid("933d1a9f-7bbb-43e2-b450-22ea20a2b252")
                        },
                        new
                        {
                            Id = new Guid("dec5e6f3-aec0-4a64-ade1-1d27ee2551ed"),
                            Image = "images/cage/cage6.jpg",
                            Location = "Kitchen",
                            Name = "House-shaped Cage",
                            UserId = new Guid("f5366b81-e363-40c8-a090-76ce62c2aec2")
                        },
                        new
                        {
                            Id = new Guid("e4cf0b3d-0f7c-47d0-a3f4-61d6ebf5fdbb"),
                            Image = "images/cage/cage7.jpg",
                            Location = "Dining room",
                            Name = "Small Black Cage",
                            UserId = new Guid("c896a1b4-aa50-4f24-ac69-022dbde764c4")
                        },
                        new
                        {
                            Id = new Guid("796ea575-67b8-492d-9dc9-9b146ddd46a7"),
                            Image = "images/cage/cage8.jpg",
                            Location = "Dining room",
                            Name = "Mansion Cage",
                            UserId = new Guid("c2f73340-7b1e-46fa-99de-f751716b8cb4")
                        },
                        new
                        {
                            Id = new Guid("475f3d68-64c5-442c-9f9b-d78077bf86ce"),
                            Image = "images/cage/cage5.jpg",
                            Location = "Outside",
                            Name = "Pink Cage",
                            UserId = new Guid("5fe16af9-4ef4-4150-a117-7101fc54f5e7")
                        },
                        new
                        {
                            Id = new Guid("d3a15731-39c1-4d8b-8d92-f8b75a06de91"),
                            Image = "images/cage/cage10.png",
                            Location = "Outside",
                            Name = "Vintage Cage",
                            UserId = new Guid("512dcc41-cc66-4ce7-98af-608784f78f72")
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.DailyTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CageId");

                    b.ToTable("DailyTasks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dc063e36-6a74-429d-9569-97838a06ede7"),
                            CageId = new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"),
                            IsDone = false,
                            Name = "Refill water"
                        },
                        new
                        {
                            Id = new Guid("2fb04232-9775-4ef8-bb2d-cc1c0296e84c"),
                            CageId = new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"),
                            IsDone = true,
                            Name = "Clean branches"
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Medicine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Medicine");

                    b.HasData(
                        new
                        {
                            Id = new Guid("eb6e6128-25cf-4b4b-b511-fce4a801d1f0"),
                            Name = "Dextrotonic",
                            Usage = "15ml per liter of drinking water",
                            UserId = new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591")
                        },
                        new
                        {
                            Id = new Guid("44411f0e-5e99-49b4-9beb-922d3a97093d"),
                            Name = "Acox",
                            Usage = "6ml per liter of drinking water",
                            UserId = new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591")
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Prescription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MedicineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MedicineId");

                    b.HasIndex("UserId");

                    b.ToTable("Prescriptions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("53d1b65f-4785-4790-8f0f-62378de01f4e"),
                            EndDate = new DateTime(2021, 11, 10, 0, 14, 33, 267, DateTimeKind.Local).AddTicks(7482),
                            MedicineId = new Guid("eb6e6128-25cf-4b4b-b511-fce4a801d1f0"),
                            StartDate = new DateTime(2021, 11, 3, 0, 14, 33, 263, DateTimeKind.Local).AddTicks(9174)
                        },
                        new
                        {
                            Id = new Guid("f8dc77b5-ef08-4ce6-936c-fc3c44f682a8"),
                            EndDate = new DateTime(2021, 11, 7, 0, 14, 33, 267, DateTimeKind.Local).AddTicks(7786),
                            MedicineId = new Guid("44411f0e-5e99-49b4-9beb-922d3a97093d"),
                            StartDate = new DateTime(2021, 11, 3, 0, 14, 33, 267, DateTimeKind.Local).AddTicks(7773)
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Species", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScientificName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Species");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5894d41b-e7c2-4125-8a66-92c802bf8ed2"),
                            Name = "Cockatiel",
                            ScientificName = "Nymphicus hollandicuss"
                        },
                        new
                        {
                            Id = new Guid("dbcebceb-24ee-4477-8a09-7042512f1f6d"),
                            Name = "Budgerigar",
                            ScientificName = "Melopsittacus undulatus"
                        },
                        new
                        {
                            Id = new Guid("ea4b7aa4-9855-487d-ab36-d361a7bf0dfd"),
                            Name = "Zebra finch",
                            ScientificName = "Taeniopygia guttata"
                        },
                        new
                        {
                            Id = new Guid("024ff36d-ab70-4e63-80b4-6732179f1dc7"),
                            Name = "Canary",
                            ScientificName = "Serinus canaria forma domestica"
                        },
                        new
                        {
                            Id = new Guid("ec476ed6-7c6c-4550-abb7-01c088bebb98"),
                            Name = "Pacific parrotlet",
                            ScientificName = "Forpus coelestis"
                        },
                        new
                        {
                            Id = new Guid("26825fce-1d1a-48ef-b41f-a65b099d7469"),
                            Name = "Bourke’s parrot",
                            ScientificName = "Neopsephotus bourkii"
                        },
                        new
                        {
                            Id = new Guid("76f07ff5-9f33-457d-9670-def36354afc4"),
                            Name = "Rosy-faced lovebrid",
                            ScientificName = "Agapornis roseicollis"
                        },
                        new
                        {
                            Id = new Guid("9dd9092f-3ee6-4912-a30e-5d6fa5a3cbbf"),
                            Name = "Green-Cheeked Conure",
                            ScientificName = "Pyrrhura molinae"
                        },
                        new
                        {
                            Id = new Guid("77c58c3a-4d83-4aeb-9f52-3f6dcd220991"),
                            Name = "Gouldian finch",
                            ScientificName = "Chloebia gouldiae"
                        },
                        new
                        {
                            Id = new Guid("d2100a88-4892-4727-bbb5-f2ab846a5568"),
                            Name = "Society finch",
                            ScientificName = "Lonchura striata domestica"
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591"),
                            Name = "Franchois"
                        },
                        new
                        {
                            Id = new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b"),
                            Name = "Dequinnemaere"
                        },
                        new
                        {
                            Id = new Guid("530eb08b-f676-480b-969f-8968efdbc1bf"),
                            Name = "Depotter"
                        },
                        new
                        {
                            Id = new Guid("4e0f6789-5dc7-44e7-8158-40fb528cf3ed"),
                            Name = "Haenebalcke"
                        },
                        new
                        {
                            Id = new Guid("933d1a9f-7bbb-43e2-b450-22ea20a2b252"),
                            Name = "De Wandel"
                        },
                        new
                        {
                            Id = new Guid("f5366b81-e363-40c8-a090-76ce62c2aec2"),
                            Name = "De Smet"
                        },
                        new
                        {
                            Id = new Guid("c896a1b4-aa50-4f24-ac69-022dbde764c4"),
                            Name = "Verbeke"
                        },
                        new
                        {
                            Id = new Guid("c2f73340-7b1e-46fa-99de-f751716b8cb4"),
                            Name = "Meerpoel"
                        },
                        new
                        {
                            Id = new Guid("5fe16af9-4ef4-4150-a117-7101fc54f5e7"),
                            Name = "Lootens"
                        },
                        new
                        {
                            Id = new Guid("512dcc41-cc66-4ce7-98af-608784f78f72"),
                            Name = "Van De Sompel"
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Bird", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.Cage", "Cage")
                        .WithMany("Birds")
                        .HasForeignKey("CageId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Imi.Project.Api.Core.Entities.Species", "Species")
                        .WithMany("Birds")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Imi.Project.Api.Core.Entities.User", "User")
                        .WithMany("Birds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.BirdPrescription", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.Bird", "Bird")
                        .WithMany("BirdPrescriptions")
                        .HasForeignKey("BirdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Imi.Project.Api.Core.Entities.Prescription", "Prescription")
                        .WithMany("BirdPrescriptions")
                        .HasForeignKey("PrescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Cage", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.User", "User")
                        .WithMany("Cages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.DailyTask", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.Cage", "Cage")
                        .WithMany("DailyTasks")
                        .HasForeignKey("CageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Medicine", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.User", "User")
                        .WithMany("Medicines")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Prescription", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.Medicine", "Medicine")
                        .WithMany("Prescriptions")
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Imi.Project.Api.Core.Entities.User", "User")
                        .WithMany("Prescriptions")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
