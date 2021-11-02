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
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Franchois",
                    },

                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Dequinnemaere",
                    },

                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "Depotter",
                    },

                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Name = "Haenebalcke",
                    },


                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        Name = "De Wandel",
                    },


                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        Name = "De Smet",
                    },


                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        Name = "Verbeke",
                    },


                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        Name = "Meerpoel",
                    },


                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        Name = "Lootens",
                    },


                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        Name = "Van De Sompel",
                    },

                }
                );
        }
    }
}
