using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Seeding
{
    public class PrescriptionSeeding
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription[]
                {
                    new Prescription
                    {
                        Id = Guid.Parse("53d1b65f-4785-4790-8f0f-62378de01f4e"),
                        MedicineId = Guid.Parse("EB6E6128-25CF-4B4B-B511-FCE4A801D1F0"),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(7)

                    },

                    new Prescription
                    {
                        Id = Guid.Parse("f8dc77b5-ef08-4ce6-936c-fc3c44f682a8"),
                        MedicineId = Guid.Parse("44411F0E-5E99-49B4-9BEB-922D3A97093D"),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(4)

                    },

                }

            );
        }
    }
}
