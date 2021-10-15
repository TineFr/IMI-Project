using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Seeding
{
    public class FoodSeeder
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().HasData(
                new Food[]
                {
                    new Food
                    {
                        Id = Guid.Parse("2191CBE2-9F0C-4064-94D6-E66834BD9064"),
                        Name = "Parrot mix",

                    },

                    new Food
                    {
                        Id = Guid.Parse("A1A2AF92-244D-4A49-BF3A-E220298F49B3"),
                        Name = "Parakeet mix",
                    },

                }
                );
        }
    }
}
