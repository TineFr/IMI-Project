 using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Seeding
{
    public class BirdPrescriptionSeeding
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BirdPrescription>().HasData(
                new BirdPrescription[]
                {
                    new BirdPrescription
                    {
                        BirdId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        PrescriptionId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    },

                    new BirdPrescription
                    {
                        BirdId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        PrescriptionId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    },

                    new BirdPrescription
                    {
                        BirdId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        PrescriptionId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    },
                    new BirdPrescription
                    {
                        BirdId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        PrescriptionId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                    },

                    new BirdPrescription
                    {
                        BirdId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        PrescriptionId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                    },
                    new BirdPrescription
                    {
                        BirdId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        PrescriptionId = Guid.Parse("00000000-0000-0000-0000-000000000005")
                    },
                    new BirdPrescription
                    {
                        BirdId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        PrescriptionId = Guid.Parse("00000000-0000-0000-0000-000000000005")
                    },
                    new BirdPrescription
                    {
                        BirdId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        PrescriptionId = Guid.Parse("00000000-0000-0000-0000-000000000006")
                    },
                    new BirdPrescription
                    {
                        BirdId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        PrescriptionId = Guid.Parse("00000000-0000-0000-0000-000000000007")
                    },
                    new BirdPrescription
                    {
                        BirdId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        PrescriptionId = Guid.Parse("00000000-0000-0000-0000-000000000008")
                    },
                    new BirdPrescription
                    {
                        BirdId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        PrescriptionId = Guid.Parse("00000000-0000-0000-0000-000000000009")
                    },
                    new BirdPrescription
                    {
                        BirdId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        PrescriptionId = Guid.Parse("00000000-0000-0000-0000-000000000010")
                    },
                    new BirdPrescription
                    {
                        BirdId = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                        PrescriptionId = Guid.Parse("00000000-0000-0000-0000-000000000011")
                    },
                    new BirdPrescription
                    {
                        BirdId = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                        PrescriptionId = Guid.Parse("00000000-0000-0000-0000-000000000012")
                    },
                    new BirdPrescription
                    {
                        BirdId = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                        PrescriptionId = Guid.Parse("00000000-0000-0000-0000-000000000013")
                    },
                    new BirdPrescription
                    {
                        BirdId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                        PrescriptionId = Guid.Parse("00000000-0000-0000-0000-000000000013")
                    },
                }

            );
        }
    }
}
