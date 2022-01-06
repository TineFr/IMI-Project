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
                        ScientificName = "Nymphicus hollandicuss",
                        Description = "The cockatiel (Nymphicus hollandicus), also known as weiro bird, or quarrion, " +
                        "is a medium sized parrot that is a member of its own branch of the cockatoo family endemic to Australia. " +
                        "They are prized as household pets and companion parrots throughout the world and are relatively easy to breed. " +
                        "As a caged bird, cockatiels are second in popularity only to the budgerigar. Source:The Spruce Pets",
                        Image = "images/species/cockatiel.jpg",
                    },

                    new Species
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Budgerigar",
                        ScientificName ="Melopsittacus undulatus",
                        Description = "The budgerigar , also known as the common parakeet or shell parakeet, is a small, long-tailed, " +
                        "seed-eating parrot usually nicknamed the budgie, or in American English, the parakeet." +
                        "Budgies are the only species in the genus Melopsittacus. Naturally, the species is green and yellow with black, " +
                        "scalloped markings on the nape, back, and wings. Budgies are bred in captivity with colouring of blues, " +
                        "whites, yellows, greys, and even with small crests. Source:The Spruce Pets",
                        Image = "images/species/budgie.jpg",
                    },
                    new Species
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "Zebra Finch",
                        ScientificName = "Taeniopygia guttata",
                        Image = "images/species/zebrafinch.jpg",
                        Description = "Perhaps the most popular finch due to its availability and price, the zebra finch has been kept in captivity for more than a 100 years." +
                        "Zebra finches breed readily, and are a good beginner’s bird, easy to care for and requiring a minimal time commitment. Source:The Spruce Pets"
                    },

                    new Species
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Name = "Canary",
                        ScientificName = "Serinus canaria forma domestica",
                        Image = "images/species/canary.jpg",
                        Description = "A canary is an undemanding little charmer that is usually a beginner's cana bird. This small finch has the power to turn most people into lifelong canary enthusiasts. It is a pleasant companion bird with a cheerful disposition. It communicates its content with a melodious song that is soft and pleasant. " +
                        "The canary has been carefully bred to be available in a variety of colors, sizes, and singing varieties. Source:The Spruce Pets"
                    },

                    new Species
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        Name = "Pacific Parrotlet",
                        ScientificName = "Forpus coelestis",
                        Image = "images/species/pacificparrotlet.jpg",
                        Description = "Colorful, charming, and intelligent, Pacific parrotlets are the smallest members of the parrot family. Nicknamed pocket parrots for one of their favorite hiding spots, they have become increasingly popular pets. " +
                        "Their small size and quiet nature make them an ideal choice for people who live in apartments or condos or those who do not have the space to house a larger bird. Some can learn to talk quite well, although it is not known for being a big talker. " +
                        "They make perfectly affectionate and adorable pets. Source:The Spruce Pets"
                    },

                    new Species
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        Name = "Bourke’s Parrot",
                        ScientificName = "Neopsephotus bourkii",
                        Image = "images/species/bourkesparakeet.jpg",
                        Description = "Bourke's parakeets are an excellent introductory bird for those new to hookbills or parrots; they have a calm demeanor and can entertain themselves. They are quiet birds that are ideal apartment dwellers and are equally suited for individual cages or small aviaries, where they are excellent partners for finches and cockatiels as well as other Bourke's parakeets. " +
                        "Keep gentle Bourke's parakeets away from larger, aggressive birds. Source:The Spruce Pets"
                    },

                    new Species
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        Name = "Rosy-faced Lovebird",
                        ScientificName = "Agapornis roseicollis",
                        Image = "images/species/lovebird.jpg",
                        Description ="Lovebirds are so named because of their strong pair bonds. Lovebirds range in size from just over 5 inches to just over 6½ inches, which makes them among the smaller parrot species. Lovebirds have short, blunt tail feathers, " +
                        "unlike budgies (“parakeets”), which have long pointed tails, and lovebirds are also stockier. Source:The Spruce Pets"
                    },

                    new Species
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        Name = "Green-Cheeked Conure",
                        ScientificName = "Pyrrhura molinae",
                        Description = "Popular as pets due to their small size, beauty, and intelligence, green-cheeked conures have stolen many bird lover's hearts. Their curiosity, spunk, and playful nature are great characteristics in a pet bird. Mischievous and engaging, green-cheeked conures pack a lot of personality into a small package. " +
                        "The fact that they are less noisy than most other parrots—and more affordable—adds to their appeal. Source:The Spruce Pets",
                        Image = "images/species/greencheekedconure.jpg",
                    },

                    new Species
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        Name = "Gouldian Finch",
                        ScientificName = "Chloebia gouldiae",
                        Image = "images/species/gouldianfinch.jpg",
                        Description = "The Gouldian finch is one of the most beautiful of all pet bird species. It is a brilliant, multicolored bird with vibrant plumage. Its shyness with humans makes it a favorite bird for those who enjoy looking at birds but do not want to handle them. This finch is very social with birds of its kind. " +
                        "A small group of these diminutive birds makes for an excellent display in a large enclosure. Source:The Spruce Pets"
                    },

                    new Species
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        Name = "Society Finch",
                        ScientificName = "Lonchura striata domestica",
                        Image = "images/species/societyfinch.jpg",
                        Description = "Society finches are not the kind of bird that one would choose if they want an avian friend that talks and plays with them, " +
                        "but they do make wonderful pets for those that prefer to be spectators. " +
                        "Society finches are not birds that are easily handled, but that is because of their small size and not because they are aggressive. " +
                        "Society finches may be easily startled and fly around their enclosures when they aren't nesting or eating, but they are typically peaceful."
                    },


                }
                );
        }
    }
}
