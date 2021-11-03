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
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),                                        
                        Name = "Outside Cage 1",
                        Location = "Outside",
                        Image =  "images/cage/cage1.png",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                                             
                    },

                    new Cage
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Outside Cage 2",
                        Location = "Outside",
                        Image =  "images/cage/cage2.png",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                    },

                    new Cage
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "White Cage",
                        Location = "Living room",
                        Image =  "images/cage/cage3.jpg",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                    },


                    new Cage
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Name = "Desk Cage",
                        Location = "Study room",
                        Image = "images/cage/cage4.jpg",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000004")
                    },


                    new Cage
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        Name = "Gold Cage",
                        Location = "Living room",
                        Image =  "images/cage/cage9.jpg",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000005")
                    },


                    new Cage
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        Name = "House-shaped Cage",
                        Location = "Kitchen",
                        Image =  "images/cage/cage6.jpg",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000006")
                    },


                    new Cage
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        Name = "Small Black Cage",
                        Location = "Dining room",
                        Image =  "images/cage/cage7.jpg",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000007")
                    },


                    new Cage
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        Name = "Mansion Cage",
                        Location = "Dining room",
                        Image =  "images/cage/cage8.jpg",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000008")
                    },



                    new Cage
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        Name = "Pink Cage",
                        Location = "Outside",
                        Image =  "images/cage/cage5.jpg",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000009")
                    },


                    new Cage
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),                   
                        Name = "Vintage Cage",
                        Location = "Outside",
                        Image =  "images/cage/cage10.png",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000010")

                    },


                }

            );
        }
    }
}
