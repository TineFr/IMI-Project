﻿// <auto-generated />
using System;
using Imi.Project.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Imi.Project.Api.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
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

                    b.Property<Guid?>("FoodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<DateTime>("HatchDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PairId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SpeciesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CageId");

                    b.HasIndex("FoodId");

                    b.HasIndex("PairId");

                    b.HasIndex("SpeciesId");

                    b.HasIndex("UserId");

                    b.ToTable("Birds");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8606c209-1d51-4ee3-9f8d-8de3d0f3f24e"),
                            CageId = new Guid("2fb04232-9775-4ef8-bb2d-cc1c0296e84c"),
                            FoodId = new Guid("a1a2af92-244d-4a49-bf3a-e220298f49b3"),
                            Gender = 0,
                            HatchDate = new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/budgie1.jpg",
                            Name = "Jake",
                            PairId = new Guid("49f6a183-df21-47a4-80be-a3ac46714584"),
                            SpeciesId = new Guid("dbcebceb-24ee-4477-8a09-7042512f1f6d"),
                            UserId = new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591")
                        },
                        new
                        {
                            Id = new Guid("6668e055-e99c-4b50-ad12-5a28ca2ad422"),
                            CageId = new Guid("2fb04232-9775-4ef8-bb2d-cc1c0296e84c"),
                            FoodId = new Guid("a1a2af92-244d-4a49-bf3a-e220298f49b3"),
                            Gender = 1,
                            HatchDate = new DateTime(2017, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/budgie2.jpg",
                            Name = "Holly",
                            PairId = new Guid("49f6a183-df21-47a4-80be-a3ac46714584"),
                            SpeciesId = new Guid("dbcebceb-24ee-4477-8a09-7042512f1f6d"),
                            UserId = new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591")
                        },
                        new
                        {
                            Id = new Guid("8e74a018-6d85-4e2a-bb85-f8da2d58f3bf"),
                            CageId = new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"),
                            FoodId = new Guid("a1a2af92-244d-4a49-bf3a-e220298f49b3"),
                            Gender = 0,
                            HatchDate = new DateTime(2012, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/cockatiel1.jpg",
                            Name = "Steven",
                            PairId = new Guid("87ca38ac-99b3-487a-85a4-68053940432a"),
                            SpeciesId = new Guid("5894d41b-e7c2-4125-8a66-92c802bf8ed2"),
                            UserId = new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b")
                        },
                        new
                        {
                            Id = new Guid("8470bc8b-28ac-4e51-9faf-4fcf4c5f0d14"),
                            CageId = new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"),
                            FoodId = new Guid("a1a2af92-244d-4a49-bf3a-e220298f49b3"),
                            Gender = 1,
                            HatchDate = new DateTime(2014, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "images/bird/cockatiel2.jpg",
                            Name = "July",
                            PairId = new Guid("87ca38ac-99b3-487a-85a4-68053940432a"),
                            SpeciesId = new Guid("5894d41b-e7c2-4125-8a66-92c802bf8ed2"),
                            UserId = new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b")
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

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Food", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Food");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2191cbe2-9f0c-4064-94d6-e66834bd9064"),
                            Name = "Parrot mix"
                        },
                        new
                        {
                            Id = new Guid("a1a2af92-244d-4a49-bf3a-e220298f49b3"),
                            Name = "Parakeet mix"
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Nest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOccupied")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PairId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CageId");

                    b.HasIndex("PairId")
                        .IsUnique()
                        .HasFilter("[PairId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("Nests");

                    b.HasData(
                        new
                        {
                            Id = new Guid("666c1fa7-c317-4e84-bba1-3590ba6fa5d9"),
                            CageId = new Guid("2fb04232-9775-4ef8-bb2d-cc1c0296e84c"),
                            Image = "images/nest/nestbox2.jpg",
                            IsOccupied = true,
                            Name = "Nest Box 1",
                            PairId = new Guid("49f6a183-df21-47a4-80be-a3ac46714584"),
                            UserId = new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591")
                        },
                        new
                        {
                            Id = new Guid("c29cf848-cdef-4251-a78b-b76bff142a7c"),
                            CageId = new Guid("aba63d5f-8dd1-42e3-93b8-898c71554e5a"),
                            Image = "images/nest/nestbox1.jpg",
                            IsOccupied = true,
                            Name = "Nest Box 2",
                            PairId = new Guid("87ca38ac-99b3-487a-85a4-68053940432a"),
                            UserId = new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b")
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Pair", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Pairs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("49f6a183-df21-47a4-80be-a3ac46714584"),
                            Name = "Jake X Holly",
                            UserId = new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591")
                        },
                        new
                        {
                            Id = new Guid("87ca38ac-99b3-487a-85a4-68053940432a"),
                            Name = "Steven X July",
                            UserId = new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b")
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
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5e146a05-34ec-4ff0-8dde-6dc6d62c3591"),
                            Email = "tine.franchois@gmail.com",
                            FirstName = "Tine",
                            Name = "Franchois",
                            Password = "15rtfpTN"
                        },
                        new
                        {
                            Id = new Guid("334cd0db-6111-4a42-9f4d-6af33fe6283b"),
                            Email = "claire.dequinnemaere@gmail.com",
                            FirstName = "Claire",
                            Name = "Dequinnemaere",
                            Password = "iej456Pn"
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Bird", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.Cage", "Cage")
                        .WithMany("Birds")
                        .HasForeignKey("CageId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Imi.Project.Api.Core.Entities.Food", "Food")
                        .WithMany("Birds")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Imi.Project.Api.Core.Entities.Pair", "Pair")
                        .WithMany("Birds")
                        .HasForeignKey("PairId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Imi.Project.Api.Core.Entities.Species", "Species")
                        .WithMany("Birds")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Imi.Project.Api.Core.Entities.User", "User")
                        .WithMany("Birds")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Cage", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.User", "User")
                        .WithMany("Cages")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.DailyTask", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.Cage", "Cage")
                        .WithMany("DailyTasks")
                        .HasForeignKey("CageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Nest", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.Cage", "Cage")
                        .WithMany("Nests")
                        .HasForeignKey("CageId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Imi.Project.Api.Core.Entities.Pair", "Pair")
                        .WithOne("Nest")
                        .HasForeignKey("Imi.Project.Api.Core.Entities.Nest", "PairId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Imi.Project.Api.Core.Entities.User", "User")
                        .WithMany("Nests")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Pair", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.User", "User")
                        .WithMany("Pairs")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
