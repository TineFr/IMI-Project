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
                        BirdId = Guid.Parse("6668E055-E99C-4B50-AD12-5A28CA2AD422"),
                        PrescriptionId = Guid.Parse("53d1b65f-4785-4790-8f0f-62378de01f4e")
                    },

                    new BirdPrescription
                    {
                        BirdId = Guid.Parse("8E74A018-6D85-4E2A-BB85-F8DA2D58F3BF"),
                        PrescriptionId = Guid.Parse("f8dc77b5-ef08-4ce6-936c-fc3c44f682a8")
                    },

                    new BirdPrescription
                    {
                        BirdId = Guid.Parse("6668E055-E99C-4B50-AD12-5A28CA2AD422"),
                        PrescriptionId = Guid.Parse("f8dc77b5-ef08-4ce6-936c-fc3c44f682a8")
                    },

                }

            );
        }
    }
}
