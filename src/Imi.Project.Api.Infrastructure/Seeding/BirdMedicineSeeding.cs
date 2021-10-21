using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Seeding
{
    public class BirdMedicineSeeding
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BirdMedicines>().HasData(
                new BirdMedicines[]
                {
                    new BirdMedicines
                    {
                        BirdId = Guid.Parse("6668E055-E99C-4B50-AD12-5A28CA2AD422"),
                        MedicineId = Guid.Parse("44411F0E-5E99-49B4-9BEB-922D3A97093D")
                    },

                    new BirdMedicines
                    {
                        BirdId = Guid.Parse("8E74A018-6D85-4E2A-BB85-F8DA2D58F3BF"),
                        MedicineId = Guid.Parse("EB6E6128-25CF-4B4B-B511-FCE4A801D1F0")
                    },

                }

            );
        }
    }
}
