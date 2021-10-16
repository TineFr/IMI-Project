using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Seeding
{
    public class CageSeeding
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cage>().HasData(
                new Cage[]
                {
                    new Cage
                    {
                        Id = Guid.Parse("2FB04232-9775-4EF8-BB2D-CC1C0296E84C"),
                        Name = "Outside Cage 1",
                        Location = "Outside",
                        Image =  "images/cage/cage1.png",
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")
                    },

                    new Cage
                    {
                        Id = Guid.Parse("ABA63D5F-8DD1-42E3-93B8-898C71554E5A"),
                        Name = "Outside Cage 2",
                        Location = "Outside",
                        Image =  "images/cage/cage2.png",
                        UserId = Guid.Parse("334CD0DB-6111-4A42-9F4D-6AF33FE6283B")
                    },

                }

            );
        }
    }
}
