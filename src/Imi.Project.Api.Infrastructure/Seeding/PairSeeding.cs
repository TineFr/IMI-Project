using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Seeding
{
    public class PairSeeding
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pair>().HasData(
                new Pair[]
                {
                    new Pair
                    {
                        Id = Guid.Parse("49F6A183-DF21-47A4-80BE-A3AC46714584"),
                        Name = "Jake X Holly",
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")
                    },

                    new Pair
                    {
                        Id = Guid.Parse("87CA38AC-99B3-487A-85A4-68053940432A"),
                        Name = "Steven X July",
                        UserId = Guid.Parse("334CD0DB-6111-4A42-9F4D-6AF33FE6283B")

                    },
                }
                );
        }
    }
}
