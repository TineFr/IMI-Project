using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Seeding
{
    public class NestSeeding
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nest>().HasData(
                new Nest[]
                {
                    new Nest
                    {
                        Id = Guid.Parse("666C1FA7-C317-4E84-BBA1-3590BA6FA5D9"),
                        Name = "Nest Box 1",
                        PairId = Guid.Parse("49F6A183-DF21-47A4-80BE-A3AC46714584"),
                        IsOccupied = true,
                        Image = "images/nest/nestbox2.jpg",
                        CageId = Guid.Parse("2FB04232-9775-4EF8-BB2D-CC1C0296E84C"),
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")
                    },

                    new Nest
                    {
                        Id = Guid.Parse("C29CF848-CDEF-4251-A78B-B76BFF142A7C"),
                        Name = "Nest Box 2",
                        PairId = Guid.Parse("87CA38AC-99B3-487A-85A4-68053940432A"),
                        IsOccupied = true,
                        Image = "images/nest/nestbox1.jpg",
                        CageId = Guid.Parse("ABA63D5F-8DD1-42E3-93B8-898C71554E5A"),
                        UserId = Guid.Parse("334CD0DB-6111-4A42-9F4D-6AF33FE6283B")
                    },

                }
                );
        }
    }
}
