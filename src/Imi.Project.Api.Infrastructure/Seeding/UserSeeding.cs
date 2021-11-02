using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Seeding
{
    public class UserSeeding
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User
                    {
                        Id = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591"),
                        Name = "Franchois",
                    },

                    new User
                    {
                        Id = Guid.Parse("334CD0DB-6111-4A42-9F4D-6AF33FE6283B"),
                        Name = "Dequinnemaere",
                    },

                    new User
                    {
                        Id = Guid.Parse("530eb08b-f676-480b-969f-8968efdbc1bf"),
                        Name = "Depotter",
                    },

                    new User
                    {
                        Id = Guid.Parse("4e0f6789-5dc7-44e7-8158-40fb528cf3ed"),
                        Name = "Haenebalcke",
                    },


                    new User
                    {
                        Id = Guid.Parse("933d1a9f-7bbb-43e2-b450-22ea20a2b252"),
                        Name = "De Wandel",
                    },


                    new User
                    {
                        Id = Guid.Parse("f5366b81-e363-40c8-a090-76ce62c2aec2"),
                        Name = "De Smet",
                    },


                    new User
                    {
                        Id = Guid.Parse("c896a1b4-aa50-4f24-ac69-022dbde764c4"),
                        Name = "Verbeke",
                    },


                    new User
                    {
                        Id = Guid.Parse("c2f73340-7b1e-46fa-99de-f751716b8cb4"),
                        Name = "Meerpoel",
                    },


                    new User
                    {
                        Id = Guid.Parse("5fe16af9-4ef4-4150-a117-7101fc54f5e7"),
                        Name = "Lootens",
                    },


                    new User
                    {
                        Id = Guid.Parse("512dcc41-cc66-4ce7-98af-608784f78f72"),
                        Name = "Van De Sompel",
                    },

                }
                );
        }
    }
}
