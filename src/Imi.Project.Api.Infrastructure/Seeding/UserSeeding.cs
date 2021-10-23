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

                }
                );
        }
    }
}
