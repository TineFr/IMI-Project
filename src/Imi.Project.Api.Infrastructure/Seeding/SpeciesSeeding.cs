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
                    new Species
                    {
                        Id = Guid.Parse("ea4b7aa4-9855-487d-ab36-d361a7bf0dfd"),
                        Name = "Zebra finch",
                        ScientificName = "Taeniopygia guttata"
                    },

                    new Species
                    {
                        Id = Guid.Parse("024ff36d-ab70-4e63-80b4-6732179f1dc7"),
                        Name = "Canary",
                        ScientificName = "Serinus canaria forma domestica"
                    },

                    new Species
                    {
                        Id = Guid.Parse("ec476ed6-7c6c-4550-abb7-01c088bebb98"),
                        Name = "Pacific parrotlet",
                        ScientificName = "Forpus coelestis"
                    },

                    new Species
                    {
                        Id = Guid.Parse("26825fce-1d1a-48ef-b41f-a65b099d7469"),
                        Name = "Bourke’s parrot",
                        ScientificName = "Neopsephotus bourkii"
                    },

                    new Species
                    {
                        Id = Guid.Parse("76f07ff5-9f33-457d-9670-def36354afc4"),
                        Name = "Rosy-faced lovebrid",
                        ScientificName = "Agapornis roseicollis"
                    },

                    new Species
                    {
                        Id = Guid.Parse("9dd9092f-3ee6-4912-a30e-5d6fa5a3cbbf"),
                        Name = "Green-Cheeked Conure",
                        ScientificName = "Pyrrhura molinae"
                    },

                    new Species
                    {
                        Id = Guid.Parse("77c58c3a-4d83-4aeb-9f52-3f6dcd220991"),
                        Name = "Gouldian finch",
                        ScientificName = "Chloebia gouldiae"
                    },

                    new Species
                    {
                        Id = Guid.Parse("d2100a88-4892-4727-bbb5-f2ab846a5568"),
                        Name = "Society finch",
                        ScientificName = "Lonchura striata domestica"
                    },


                }
                );
        }
    }
}
