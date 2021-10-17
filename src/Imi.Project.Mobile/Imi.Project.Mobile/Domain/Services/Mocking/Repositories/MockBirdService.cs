using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Mocking.Repositories
{
    public class MockBirdService : IBirdService
    {
        private static List<Bird> birdrepository = new List<Bird>
        {
                    new Bird
                    {
                    Id = Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E"),
                    Name = "Jake",
                    Cage ="Outside cage",
                    Gender = "Male",
                    HatchDate = new DateTime(2015, 12, 25),
                    Image = "budgie1.jpg",
                    Species = "Budgerigar",
                    ScientificName ="Melopsittacus undulatus",
                    Food = "Parakeet mix"
                    },

                    new Bird
                    {
                    Id = Guid.Parse("6668E055-E99C-4B50-AD12-5A28CA2AD422"),
                    Name = "Holly",
                    Cage = "Outside cage",
                    Gender = "Female",
                    HatchDate = new DateTime(2017, 07, 13),
                    Image = "budgie4.jpg",
                    Species = "Budgerigar",
                    ScientificName ="Melopsittacus undulatus",
                    Food = "Parakeet mix"
                    },

                    new Bird
                    {
                    Id = Guid.Parse("8E74A018-6D85-4E2A-BB85-F8DA2D58F3BF"),
                    Name = "Steven",
                    Cage = "Outside cage 2",
                    Gender = "Male",
                    HatchDate = new DateTime(2012, 09, 03),
                    Image = "cockatiel1.jpg",
                    Species = "Cockatiel",
                    ScientificName = "Nymphicus hollandicuss",
                    Food = "Parakeet mix"
                    },

                    new Bird
                    {
                    Id = Guid.Parse("8E74A018-6D85-4E2A-BB85-F8DA2D58F3BF"),
                    Name = "July",
                    Cage = "Outside cage 2",
                    Gender = "Female",
                    HatchDate = new DateTime(2017, 07, 13),
                    Image = "cockatiel3.jpg",
                    Species = "Cockatiel",
                    ScientificName = "Nymphicus hollandicuss",
                    Food = "Parakeet mix"
                    },

                    new Bird
                    {
                    Id = Guid.Parse("8E74A018-6D85-4E2A-BB85-F8DA2D58F3BF"),
                    Name = "July",
                    Cage = "Outside cage 2",
                    Gender = "Female",
                    HatchDate = new DateTime(2017, 07, 13),
                    Image = "cockatiel3.jpg",
                    Species = "Cockatiel",
                    ScientificName = "Nymphicus hollandicuss",
                    Food = "Parakeet mix"
                    }

        };
        public Task<Bird> AddBird(Bird bird)
        {
            birdrepository.Add(bird);
            return Task.FromResult(bird);
        }

        public Task<Bird> DeleteBird(Guid id)
        {
            var bird = birdrepository.FirstOrDefault(b => b.Id.Equals(id));
            birdrepository.ToList().Remove(bird);
            return Task.FromResult(bird);
        }

        public Task<List<Bird>> GetAllBirds()
        {
            return Task.FromResult(birdrepository);
        }

        public Task<Bird> GetBirdById(Guid id)
        {
            var bird = birdrepository.FirstOrDefault(b => b.Id.Equals(id));
            return Task.FromResult(bird);
        }

        public Task<Bird> UpdateBird(Bird updatedBird)
        {
            var bird = birdrepository.FirstOrDefault(b => b.Id.Equals(updatedBird.Id));
            birdrepository.ToList().Remove(bird);
            birdrepository.ToList().Add(updatedBird);
            return Task.FromResult(updatedBird);
        }
    }
}
