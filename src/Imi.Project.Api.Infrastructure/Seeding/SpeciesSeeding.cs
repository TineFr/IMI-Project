using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Seeding
{
    public class SpeciesSeeding
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Species>().HasData(
                new Species[]
                {
                    new Species
                    {
                        Id = Guid.Parse("5894D41B-E7C2-4125-8A66-92C802BF8ED2"),
                        Name = "Cockatiel",
                        ScientificName = "Nymphicus hollandicuss"
                    },

                    new Species
                    {
                        Id = Guid.Parse("DBCEBCEB-24EE-4477-8A09-7042512F1F6D"),
                        Name = "Budgerigar",
                        ScientificName ="Melopsittacus undulatus"
                    },

                }
                );
        }
    }
}
