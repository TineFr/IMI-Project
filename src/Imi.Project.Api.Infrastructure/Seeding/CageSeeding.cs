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

                    new Cage
                    {
                        Id = Guid.Parse("f1a017b4-a9ee-44d0-96f6-ceef146399d5"),
                        Name = "White Cage",
                        Location = "Living room",
                        Image =  "images/cage/cage3.jpg",
                        UserId = Guid.Parse("530eb08b-f676-480b-969f-8968efdbc1bf")
                    },


                    new Cage
                    {
                        Id = Guid.Parse("9e192a55-6ba4-4551-a266-7e0ac50b600f"),
                        Name = "Desk Cage",
                        Location = "Study room",
                        Image = "images/cage/cage4.jpg",
                        UserId = Guid.Parse("4e0f6789-5dc7-44e7-8158-40fb528cf3ed")
                    },


                    new Cage
                    {
                        Id = Guid.Parse("882960e6-4aa7-4db2-bebb-2085fca6e6ec"),
                        Name = "Gold Cage",
                        Location = "Living room",
                        Image =  "images/cage/cage9.jpg",
                        UserId = Guid.Parse("933d1a9f-7bbb-43e2-b450-22ea20a2b252")
                    },


                    new Cage
                    {
                        Id = Guid.Parse("dec5e6f3-aec0-4a64-ade1-1d27ee2551ed"),
                        Name = "House-shaped Cage",
                        Location = "Kitchen",
                        Image =  "images/cage/cage6.jpg",
                        UserId = Guid.Parse("f5366b81-e363-40c8-a090-76ce62c2aec2")
                    },


                    new Cage
                    {
                        Id = Guid.Parse("e4cf0b3d-0f7c-47d0-a3f4-61d6ebf5fdbb"),
                        Name = "Small Black Cage",
                        Location = "Dining room",
                        Image =  "images/cage/cage7.jpg",
                        UserId = Guid.Parse("c896a1b4-aa50-4f24-ac69-022dbde764c4")
                    },


                    new Cage
                    {
                        Id = Guid.Parse("796ea575-67b8-492d-9dc9-9b146ddd46a7"),
                        Name = "Mansion Cage",
                        Location = "Dining room",
                        Image =  "images/cage/cage8.jpg",
                        UserId = Guid.Parse("c2f73340-7b1e-46fa-99de-f751716b8cb4")
                    },



                    new Cage
                    {
                        Id = Guid.Parse("475f3d68-64c5-442c-9f9b-d78077bf86ce"),
                        Name = "Pink Cage",
                        Location = "Outside",
                        Image =  "images/cage/cage5.jpg",
                        UserId = Guid.Parse("5fe16af9-4ef4-4150-a117-7101fc54f5e7")
                    },


                    new Cage
                    {
                        Id = Guid.Parse("d3a15731-39c1-4d8b-8d92-f8b75a06de91"),
                        Name = "Vintage Cage",
                        Location = "Outside",
                        Image =  "images/cage/cage10.png",
                        UserId = Guid.Parse("512dcc41-cc66-4ce7-98af-608784f78f72")
                    },


                }

            );
        }
    }
}
