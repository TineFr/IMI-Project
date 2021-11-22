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
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Dextrotonic",
                        Usage ="15ml per liter of drinking water",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000001")

                    },

                    new Medicine
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Acox",
                        Usage ="6ml per liter of drinking water",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    },

                    new Medicine
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "Amoxicillin 10% ",
                        Usage ="administer 1 teaspoon per 1 gallon of drinking water",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000002")

                    },

                    new Medicine
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Name = "Amtyl",
                        Usage ="Mix 3g into 2 teaspoons of water and give 1ml of solution per 100grams of body weight.",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                    },
                    new Medicine
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        Name = "Aureomycin",
                        Usage ="1/4 teaspoon to 1 quart of water",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000003")

                    },

                    new Medicine
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        Name = "Penicillin",
                        Usage ="Mix 1/4 teaspoon to 1 gallon of water",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                    },

                    new Medicine
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        Name = "Dextrotonic",
                        Usage ="15ml per liter of drinking water",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000004")

                    },

                    new Medicine
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        Name = "Calciboost",
                        Usage ="In water (10-20 mls per liter) or on soft-food 0.1-0.2 mls per 100g bodyweight. ",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000004")
                    },
                    new Medicine
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        Name = "CocciPlus",
                        Usage ="use 1/2 teaspoon to 1 gallon of water.",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000005")

                    },

                    new Medicine
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        Name = "Acox",
                        Usage ="6ml per liter of drinking water",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000005")
                    },

                    new Medicine
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                        Name = "Colloidal Silver",
                        Usage ="15ml per liter of drinking water",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000006")

                    },

                    new Medicine
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                        Name = "Acox",
                        Usage ="6ml per liter of drinking water",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000010")
                    },
                    new Medicine
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                        Name = "Doxyvet Liquid",
                        Usage ="Use at the rate of 1ml (20 drops) in 100ml of drinking water",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000007")

                    },

                    new Medicine
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                        Name = "Endocox Powder",
                        Usage ="1 teaspoon (5 grams) per 1 gallon of drinking water",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000007")
                    },

                    new Medicine
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                        Name = "Dextrotonic",
                        Usage ="15ml per liter of drinking water",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000008")

                    },

                    new Medicine
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                        Name = "Acox",
                        Usage ="6ml per liter of drinking water",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000008")
                    },

                    new Medicine
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000017"),
                        Name = "Enrofloxacin 10%",
                        Usage ="Mix 1 tsp. per 1 Gallon of water",
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000009")
                    },
                }

            ) ;
        }
    }
}
