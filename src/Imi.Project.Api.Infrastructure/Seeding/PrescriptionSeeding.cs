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
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        MedicineId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(7)

                    },

                    new Prescription
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        MedicineId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(4)

                    },
                    new Prescription
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        MedicineId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(7)

                    },

                    new Prescription
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        MedicineId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(4)

                    },
                    new Prescription
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        MedicineId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(6)

                    },

                    new Prescription
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        MedicineId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(4)

                    },
                    new Prescription
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        MedicineId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(2)

                    },

                    new Prescription
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        MedicineId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(11)

                    },
                    new Prescription
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        MedicineId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(5)

                    },

                    new Prescription
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        MedicineId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(4)

                    },

                    new Prescription
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                        MedicineId = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(4)

                    },
                    new Prescription
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                        MedicineId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(7)

                    },

                    new Prescription
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                        MedicineId = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(4)

                    },
                }

            );
        }
    }
}
