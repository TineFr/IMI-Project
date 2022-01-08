using Imi.Project.Api.Core.Entities;
using Imi.Project.Common.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Seeding
{
    public class BirdSeeding
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bird>().HasData(
                new Bird[]
                {
                        new Bird
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                            Name = "Jake",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                            Gender = Gender.Male,
                            HatchDate = new DateTime(2015, 12, 25),
                            Image = "images/bird/budgie1.jpg",
                            SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                            Food = "Parakeet mix",
                            UserId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                        },

                        new Bird
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                            Name = "Holly",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                            Gender = Common.Enums.Gender.Female,
                            HatchDate = new DateTime(2017, 07, 13),
                            Image = "images/bird/budgie2.jpg",
                            SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                            Food = null /*"Parakeet mix"*/,
                            UserId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                        },

                        new Bird
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                            Name = "Steven",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                            Gender = Common.Enums.Gender.Male,
                            HatchDate = new DateTime(2012, 09, 03),
                            Image = "images/bird/cockatiel1.jpg",
                            SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                            Food = "Parakeet mix",
                            UserId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                        },

                        new Bird
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                            Name = "July",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                            Gender = Common.Enums.Gender.Female,
                            HatchDate = new DateTime(2014, 11, 14),
                            Image = "images/bird/cockatiel2.jpg",
                            SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                            Food = "Parakeet mix",
                            UserId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                         },

                       new Bird
                        {
                           Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                           Name = "June",
                           CageId=Guid.Parse("00000000-0000-0000-0000-000000000001"),
                           Gender = Common.Enums.Gender.Female,
                           HatchDate = new DateTime(2014, 11, 14),
                           Image = "images/bird/cockatiel3.jpg",
                           SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                           Food = "Parakeet mix",
                           UserId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                        },

                       new Bird
                         {
                           Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                           Name = "Jupiter",
                           CageId=Guid.Parse("00000000-0000-0000-0000-000000000001"),
                           Gender = Common.Enums.Gender.Male,
                           HatchDate = new DateTime(2014, 6, 10),
                           Image = "images/bird/cockatiel4.jpg",
                           SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                           Food = "Parakeet mix",
                           UserId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                          },


                        new Bird
                        {
                           Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                           Name = "Flynn",
                           CageId=Guid.Parse("00000000-0000-0000-0000-000000000003"),
                           Gender = Common.Enums.Gender.Male,
                           HatchDate = new DateTime(2019, 06, 28),
                           Image = "images/bird/zebrafinch1.jpg",
                           SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                           Food = "Birdseed",
                           UserId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                        },


                        new Bird
                        {
                           Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                           Name = "Keira",
                           CageId=Guid.Parse("00000000-0000-0000-0000-000000000003"),
                           Gender = Common.Enums.Gender.Female,
                           HatchDate = new DateTime(2018, 07, 07),
                           Image = "images/bird/zebrafinch2.jpg",
                           SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                           Food = "Birdseed",
                           UserId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                        },


                        new Bird
                        {
                           Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                           Name = "Connie",
                           CageId=Guid.Parse("00000000-0000-0000-0000-000000000004"),
                           Gender = Common.Enums.Gender.Female,
                           HatchDate = new DateTime(2015, 11, 02),
                           Image = "images/bird/canary1.png",
                           SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                           Food = "Canary Seed",
                           UserId = Guid.Parse("00000000-0000-0000-0000-000000000004")
                        },



                        new Bird
                        {
                           Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                           Name = "Parro",
                           CageId=Guid.Parse("00000000-0000-0000-0000-000000000005"),
                           Gender = Common.Enums.Gender.Male,
                           HatchDate = new DateTime(2010, 10, 14),
                           Image = "images/bird/pacificparrotlet1.jpg",
                           SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                           Food = "Parrot Food",
                           UserId = Guid.Parse("00000000-0000-0000-0000-000000000005")
                        },



                        new Bird
                        {
                           Id = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                           Name = "Bourkie",
                           CageId=Guid.Parse("00000000-0000-0000-0000-000000000006"),
                           Gender = Common.Enums.Gender.Female,
                           HatchDate = new DateTime(2012, 11, 04),
                           Image = "images/bird/bourkesparakeet1.jpg",
                           SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                           Food = "Parakeet mix",
                           UserId = Guid.Parse("00000000-0000-0000-0000-000000000006")
                        },



                        new Bird
                        {
                           Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                           Name = "Rosie",
                           CageId=Guid.Parse("00000000-0000-0000-0000-000000000007"),
                           Gender = Gender.Female,
                           HatchDate = new DateTime(2011, 08, 14),
                           Image = "images/bird/lovebird1.jpg",
                           SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                           Food = "Parrot food",
                           UserId = Guid.Parse("00000000-0000-0000-0000-000000000007")
                        },


                        new Bird
                        {
                           Id = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                           Name = "Birdo",
                           CageId=Guid.Parse("00000000-0000-0000-0000-000000000007"),
                           Gender = Gender.Male,
                           HatchDate = new DateTime(2011, 04, 14),
                           Image = "images/bird/lovebird2.jpg",
                           SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                           Food = "Parrot food",
                           UserId = Guid.Parse("00000000-0000-0000-0000-000000000007")
                        },


                        new Bird
                        {
                           Id = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                           Name = "Cheeky",
                           CageId=Guid.Parse("00000000-0000-0000-0000-000000000008"),
                           Gender = Common.Enums.Gender.Male,
                           HatchDate = new DateTime(2012, 08, 19),
                           Image = "images/bird/greencheekedconure1.jpg",
                           SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                           Food = "Classic Avi-Cakes for Small Birds",
                           UserId = Guid.Parse("00000000-0000-0000-0000-000000000008")
                        },



                        new Bird
                        {
                           Id = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                           Name = "Goldie",
                           CageId=Guid.Parse("00000000-0000-0000-0000-000000000009"),
                           Gender = Common.Enums.Gender.Female,
                           HatchDate = new DateTime(2021, 03, 30),
                           Image = "images/bird/goldianfinch1.jpg",
                           SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                           Food = "Birdseed",
                           UserId = Guid.Parse("00000000-0000-0000-0000-000000000009")
                        },

                        new Bird
                        {
                           Id = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                           Name = "Lily",
                           CageId=Guid.Parse("00000000-0000-0000-0000-000000000010"),
                           Gender = Common.Enums.Gender.Female,
                           HatchDate = new DateTime(2020, 08, 20),
                           Image = "images/bird/societyfinch1.jpg",
                           SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                           Food = "Birdseed",
                           UserId = Guid.Parse("00000000-0000-0000-0000-000000000010")
                        },

                        new Bird
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000017"),
                            Name = "Blue",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                            Gender = Common.Enums.Gender.Female,
                            HatchDate = new DateTime(2016, 09, 02),
                            Image = "images/bird/budgie6.jpg",
                            SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                            Food = "Parakeet mix",
                            UserId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                        },

                        new Bird
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000018"),
                            Name = "Joey",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                            Gender = Common.Enums.Gender.Male,
                            HatchDate = new DateTime(2017, 09, 08),
                            Image = "images/bird/budgie7.jpg",
                            SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                            Food = "Parakeet mix",
                            UserId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                        },




                });

        }

    }
}
