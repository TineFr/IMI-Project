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
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Cockatiel",
                        ScientificName = "Nymphicus hollandicuss"
                    },

                    new Species
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Budgerigar",
                        ScientificName ="Melopsittacus undulatus"
                    },
                    new Species
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "Zebra finch",
                        ScientificName = "Taeniopygia guttata"
                    },

                    new Species
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Name = "Canary",
                        ScientificName = "Serinus canaria forma domestica"
                    },

                    new Species
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        Name = "Pacific parrotlet",
                        ScientificName = "Forpus coelestis"
                    },

                    new Species
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        Name = "Bourke’s parrot",
                        ScientificName = "Neopsephotus bourkii"
                    },

                    new Species
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        Name = "Rosy-faced lovebrid",
                        ScientificName = "Agapornis roseicollis"
                    },

                    new Species
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        Name = "Green-Cheeked Conure",
                        ScientificName = "Pyrrhura molinae"
                    },

                    new Species
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        Name = "Gouldian finch",
                        ScientificName = "Chloebia gouldiae"
                    },

                    new Species
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        Name = "Society finch",
                        ScientificName = "Lonchura striata domestica"
                    },


                }
                );
        }
    }
}
