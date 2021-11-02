using Imi.Project.Api.Core.Entities;
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
                            Id = Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E"),
                            Name = "Jake",
                            CageId = Guid.Parse("2FB04232-9775-4EF8-BB2D-CC1C0296E84C"),
                            Gender = Core.Enums.Gender.Male,
                            HatchDate = new DateTime(2015, 12, 25),
                            Image = "images/bird/budgie1.jpg",
                            SpeciesId = Guid.Parse("DBCEBCEB-24EE-4477-8A09-7042512F1F6D"),
                            Food = "Parakeet mix",
                            UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")
                        },

                        new Bird
                        {
                            Id = Guid.Parse("6668E055-E99C-4B50-AD12-5A28CA2AD422"),
                            Name = "Holly",
                            CageId = Guid.Parse("2FB04232-9775-4EF8-BB2D-CC1C0296E84C"),
                            Gender = Core.Enums.Gender.Female,
                            HatchDate = new DateTime(2017, 07, 13),
                            Image = "images/bird/budgie2.jpg",
                            SpeciesId = Guid.Parse("DBCEBCEB-24EE-4477-8A09-7042512F1F6D"),
                            Food = "Parakeet mix",
                            UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")
                        },

                        new Bird
                        {
                            Id = Guid.Parse("8E74A018-6D85-4E2A-BB85-F8DA2D58F3BF"),
                            Name = "Steven",
                            CageId = Guid.Parse("ABA63D5F-8DD1-42E3-93B8-898C71554E5A"),
                            Gender = Core.Enums.Gender.Male,
                            HatchDate = new DateTime(2012, 09, 03),
                            Image = "images/bird/cockatiel1.jpg",
                            SpeciesId = Guid.Parse("5894D41B-E7C2-4125-8A66-92C802BF8ED2"),
                            Food = "Parakeet mix",
                            UserId = Guid.Parse("334CD0DB-6111-4A42-9F4D-6AF33FE6283B")
                        },

                        new Bird
                        {
                            Id = Guid.Parse("8470BC8B-28AC-4E51-9FAF-4FCF4C5F0D14"),
                            Name = "July",
                            CageId = Guid.Parse("ABA63D5F-8DD1-42E3-93B8-898C71554E5A"),
                            Gender = Core.Enums.Gender.Female,
                            HatchDate = new DateTime(2014, 11, 14),
                            Image = "images/bird/cockatiel2.jpg",
                            SpeciesId = Guid.Parse("5894D41B-E7C2-4125-8A66-92C802BF8ED2"),
                            Food = "Parakeet mix",
                            UserId = Guid.Parse("334CD0DB-6111-4A42-9F4D-6AF33FE6283B")
                         },

                       new Bird
                        {
                           Id = Guid.Parse("6c46edba-c183-41bc-b1b8-f9b89e9d5c4d"),
                           Name = "June",
                           CageId=Guid.Parse("ABA63D5F-8DD1-42E3-93B8-898C71554E5A"),
                           Gender = Core.Enums.Gender.Female,
                           HatchDate = new DateTime(2014, 11, 14),
                           Image = "images/bird/cockatiel3.jpg",
                           SpeciesId = Guid.Parse("5894D41B-E7C2-4125-8A66-92C802BF8ED2"),
                           Food = "Parakeet mix",
                           UserId = Guid.Parse("334CD0DB-6111-4A42-9F4D-6AF33FE6283B")
                        },

                       new Bird
                         {
                           Id = Guid.Parse("0b862c07-6d07-4aee-a1a6-fc28740c4c97"),
                           Name = "Jupiter",
                           CageId=Guid.Parse("ABA63D5F-8DD1-42E3-93B8-898C71554E5A"),
                           Gender = Core.Enums.Gender.Male,
                           HatchDate = new DateTime(2014, 6, 10),
                           Image = "images/bird/cockatiel4.jpg",
                           SpeciesId = Guid.Parse("5894D41B-E7C2-4125-8A66-92C802BF8ED2"),
                           Food = "Parakeet mix",
                           UserId = Guid.Parse("334CD0DB-6111-4A42-9F4D-6AF33FE6283B")
                          },


                        new Bird
                        {
                           Id = Guid.Parse("d2a75360-d1a3-4d44-a8a2-5342cde36dd5"),
                           Name = "Flynn",
                           CageId=Guid.Parse("f1a017b4-a9ee-44d0-96f6-ceef146399d5"),
                           Gender = Core.Enums.Gender.Male,
                           HatchDate = new DateTime(2019, 06, 28),
                           Image = "images/bird/zebrafinch1.jpg",
                           SpeciesId = Guid.Parse("ea4b7aa4-9855-487d-ab36-d361a7bf0dfd"),
                           Food = "Birdseed",
                           UserId = Guid.Parse("530eb08b-f676-480b-969f-8968efdbc1bf")
                        },


                        new Bird
                        {
                           Id = Guid.Parse("2518b942-e928-43ab-981c-2cdc2e6705b3"),
                           Name = "Keira",
                           CageId=Guid.Parse("f1a017b4-a9ee-44d0-96f6-ceef146399d5"),
                           Gender = Core.Enums.Gender.Female,
                           HatchDate = new DateTime(2018, 07, 07),
                           Image = "images/bird/zebrafinch2.jpg",
                           SpeciesId = Guid.Parse("ea4b7aa4-9855-487d-ab36-d361a7bf0dfd"),
                           Food = "Birdseed",
                           UserId = Guid.Parse("530eb08b-f676-480b-969f-8968efdbc1bf")
                        },


                        new Bird
                        {
                           Id = Guid.Parse("257df2fc-fa69-41fb-9dcb-fb21555972c4"),
                           Name = "Connie",
                           CageId=Guid.Parse("9e192a55-6ba4-4551-a266-7e0ac50b600f"),
                           Gender = Core.Enums.Gender.Female,
                           HatchDate = new DateTime(2015, 11, 02),
                           Image = "images/bird/canary1.jpg",
                           SpeciesId = Guid.Parse("024ff36d-ab70-4e63-80b4-6732179f1dc7"),
                           Food = "Canary Seed",
                           UserId = Guid.Parse("4e0f6789-5dc7-44e7-8158-40fb528cf3ed")
                        },



                        new Bird
                        {
                           Id = Guid.Parse("f3aecf28-88f9-45ea-87bd-2cb490e8f95c"),
                           Name = "Parro",
                           CageId=Guid.Parse("882960e6-4aa7-4db2-bebb-2085fca6e6ec"),
                           Gender = Core.Enums.Gender.Male,
                           HatchDate = new DateTime(2010, 10, 14),
                           Image = "images/bird/pacificparrotlet1.jpg",
                           SpeciesId = Guid.Parse("ec476ed6-7c6c-4550-abb7-01c088bebb98"),
                           Food = "Parrot Food",
                           UserId = Guid.Parse("933d1a9f-7bbb-43e2-b450-22ea20a2b252")
                        },



                        new Bird
                        {
                           Id = Guid.Parse("eb74bb0d-aa4e-4a08-8c51-a345a2364487"),
                           Name = "Bourkie",
                           CageId=Guid.Parse("dec5e6f3-aec0-4a64-ade1-1d27ee2551ed"),
                           Gender = Core.Enums.Gender.Female,
                           HatchDate = new DateTime(2012, 11, 04),
                           Image = "images/bird/bourkesparakeet1.jpg",
                           SpeciesId = Guid.Parse("26825fce-1d1a-48ef-b41f-a65b099d7469"),
                           Food = "Parakeet mix",
                           UserId = Guid.Parse("f5366b81-e363-40c8-a090-76ce62c2aec2")
                        },



                        new Bird
                        {
                           Id = Guid.Parse("e40bc83b-cefa-4df1-bfbe-6ef74fc1fea9"),
                           Name = "Rosie",
                           CageId=Guid.Parse("e4cf0b3d-0f7c-47d0-a3f4-61d6ebf5fdbb"),
                           Gender = Core.Enums.Gender.Female,
                           HatchDate = new DateTime(2011, 08, 14),
                           Image = "images/bird/lovebird1.jpg",
                           SpeciesId = Guid.Parse("76f07ff5-9f33-457d-9670-def36354afc4"),
                           Food = "Parrot food",
                           UserId = Guid.Parse("c896a1b4-aa50-4f24-ac69-022dbde764c4")
                        },


                        new Bird
                        {
                           Id = Guid.Parse("9d4fa8c1-8393-4f7d-9d69-8de0a0e6af25"),
                           Name = "Birdo",
                           CageId=Guid.Parse("e4cf0b3d-0f7c-47d0-a3f4-61d6ebf5fdbb"),
                           Gender = Core.Enums.Gender.Male,
                           HatchDate = new DateTime(2011, 04, 14),
                           Image = "images/bird/lovebird2.jpg",
                           SpeciesId = Guid.Parse("76f07ff5-9f33-457d-9670-def36354afc4"),
                           Food = "Parrot food",
                           UserId = Guid.Parse("c896a1b4-aa50-4f24-ac69-022dbde764c4")
                        },


                        new Bird
                        {
                           Id = Guid.Parse("4ab6a030-6f8b-47dc-abe5-e73a720825cb"),
                           Name = "Cheeky",
                           CageId=Guid.Parse("796ea575-67b8-492d-9dc9-9b146ddd46a7"),
                           Gender = Core.Enums.Gender.Male,
                           HatchDate = new DateTime(2012, 08, 19),
                           Image = "images/bird/greencheekedconure1.jpg",
                           SpeciesId = Guid.Parse("9dd9092f-3ee6-4912-a30e-5d6fa5a3cbbf"),
                           Food = "Classic Avi-Cakes for Small Birds",
                           UserId = Guid.Parse("c2f73340-7b1e-46fa-99de-f751716b8cb4")
                        },



                        new Bird
                        {
                           Id = Guid.Parse("bbc756d6-106f-4be0-a221-f977f2f11590"),
                           Name = "Goldie",
                           CageId=Guid.Parse("475f3d68-64c5-442c-9f9b-d78077bf86ce"),
                           Gender = Core.Enums.Gender.Female,
                           HatchDate = new DateTime(2021, 03, 30),
                           Image = "images/bird/goldianfinch1.jpg",
                           SpeciesId = Guid.Parse("77c58c3a-4d83-4aeb-9f52-3f6dcd220991"),
                           Food = "Birdseed",
                           UserId = Guid.Parse("5fe16af9-4ef4-4150-a117-7101fc54f5e7")
                        },



                        new Bird
                        {
                           Id = Guid.Parse("4a90f4c5-87e9-497b-a53d-7dba2e135a3d"),
                           Name = "Lily",
                           CageId=Guid.Parse("d3a15731-39c1-4d8b-8d92-f8b75a06de91"),
                           Gender = Core.Enums.Gender.Female,
                           HatchDate = new DateTime(2020, 08, 20),
                           Image = "images/bird/societyfinch1.jpg",
                           SpeciesId = Guid.Parse("d2100a88-4892-4727-bbb5-f2ab846a5568"),
                           Food = "Birdseed",
                           UserId = Guid.Parse("512dcc41-cc66-4ce7-98af-608784f78f72")
                        }


                });

        }

    }
}
