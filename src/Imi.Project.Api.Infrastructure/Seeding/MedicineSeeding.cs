using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Seeding
{
    public class MedicineSeeding
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine[]
                {
                    new Medicine
                    {
                        Id = Guid.Parse("EB6E6128-25CF-4B4B-B511-FCE4A801D1F0"),
                        Name = "Dextrotonic",
                        Usage ="15ml per liter of drinking water",
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")

                    },

                    new Medicine
                    {
                        Id = Guid.Parse("44411F0E-5E99-49B4-9BEB-922D3A97093D"),
                        Name = "Acox",
                        Usage ="6ml per liter of drinking water",
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")
                    },

                    new Medicine
                    {
                        Id = Guid.Parse("87583ef3-0f26-4f79-94a3-a54680e07505"),
                        Name = "Amoxicillin 10% ",
                        Usage ="administer 1 teaspoon per 1 gallon of drinking water",
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")

                    },

                    new Medicine
                    {
                        Id = Guid.Parse("44411F0E-5E99-49B4-9BEB-922D3A97093D"),
                        Name = "Acox",
                        Usage ="6ml per liter of drinking water",
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")
                    },
                    new Medicine
                    {
                        Id = Guid.Parse("EB6E6128-25CF-4B4B-B511-FCE4A801D1F0"),
                        Name = "Dextrotonic",
                        Usage ="15ml per liter of drinking water",
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")

                    },

                    new Medicine
                    {
                        Id = Guid.Parse("44411F0E-5E99-49B4-9BEB-922D3A97093D"),
                        Name = "Acox",
                        Usage ="6ml per liter of drinking water",
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")
                    },

                    new Medicine
                    {
                        Id = Guid.Parse("EB6E6128-25CF-4B4B-B511-FCE4A801D1F0"),
                        Name = "Dextrotonic",
                        Usage ="15ml per liter of drinking water",
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")

                    },

                    new Medicine
                    {
                        Id = Guid.Parse("44411F0E-5E99-49B4-9BEB-922D3A97093D"),
                        Name = "Acox",
                        Usage ="6ml per liter of drinking water",
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")
                    },
                    new Medicine
                    {
                        Id = Guid.Parse("EB6E6128-25CF-4B4B-B511-FCE4A801D1F0"),
                        Name = "Dextrotonic",
                        Usage ="15ml per liter of drinking water",
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")

                    },

                    new Medicine
                    {
                        Id = Guid.Parse("44411F0E-5E99-49B4-9BEB-922D3A97093D"),
                        Name = "Acox",
                        Usage ="6ml per liter of drinking water",
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")
                    },

                    new Medicine
                    {
                        Id = Guid.Parse("EB6E6128-25CF-4B4B-B511-FCE4A801D1F0"),
                        Name = "Dextrotonic",
                        Usage ="15ml per liter of drinking water",
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")

                    },

                    new Medicine
                    {
                        Id = Guid.Parse("44411F0E-5E99-49B4-9BEB-922D3A97093D"),
                        Name = "Acox",
                        Usage ="6ml per liter of drinking water",
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")
                    },
                    new Medicine
                    {
                        Id = Guid.Parse("EB6E6128-25CF-4B4B-B511-FCE4A801D1F0"),
                        Name = "Dextrotonic",
                        Usage ="15ml per liter of drinking water",
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")

                    },

                    new Medicine
                    {
                        Id = Guid.Parse("44411F0E-5E99-49B4-9BEB-922D3A97093D"),
                        Name = "Acox",
                        Usage ="6ml per liter of drinking water",
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")
                    },

                    new Medicine
                    {
                        Id = Guid.Parse("EB6E6128-25CF-4B4B-B511-FCE4A801D1F0"),
                        Name = "Dextrotonic",
                        Usage ="15ml per liter of drinking water",
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")

                    },

                    new Medicine
                    {
                        Id = Guid.Parse("44411F0E-5E99-49B4-9BEB-922D3A97093D"),
                        Name = "Acox",
                        Usage ="6ml per liter of drinking water",
                        UserId = Guid.Parse("5E146A05-34EC-4FF0-8DDE-6DC6D62C3591")
                    },
                }

            ) ;
        }
    }
}
