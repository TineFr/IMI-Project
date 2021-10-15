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
                    PairId = Guid.Parse("49F6A183-DF21-47A4-80BE-A3AC46714584"),
                    FoodId = Guid.Parse("A1A2AF92-244D-4A49-BF3A-E220298F49B3")
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
                    PairId = Guid.Parse("49F6A183-DF21-47A4-80BE-A3AC46714584"),
                    FoodId = Guid.Parse("A1A2AF92-244D-4A49-BF3A-E220298F49B3")
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
                    PairId = Guid.Parse("87CA38AC-99B3-487A-85A4-68053940432A"),
                    FoodId = Guid.Parse("A1A2AF92-244D-4A49-BF3A-E220298F49B3")
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
                    PairId = Guid.Parse("87CA38AC-99B3-487A-85A4-68053940432A"),
                    FoodId = Guid.Parse("A1A2AF92-244D-4A49-BF3A-E220298F49B3")
                    }
                });

        }

    }
}
