using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Services.Mocking.Services
{
    public class MockBirdService : IBirdService
    {
        private static ObservableCollection<Bird> birdrepository = new ObservableCollection<Bird>
        {
                    new Bird
                    {
                    Id = Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E"),
                    Name = "Jake",
                    Cage ="Outside cage",
                    Gender = "Male",
                    HatchDate = new DateTime(2015, 12, 25),
                    Image = "images/budgie1.jpg",
                    Species = "Budgerigar",
                    ScientificName ="Melopsittacus undulatus",
                    Food = "Parakeet mix",

                    },

                    new Bird
                    {
                    Id = Guid.Parse("6668E055-E99C-4B50-AD12-5A28CA2AD422"),
                    Name = "Holly",
                    Cage = "Outside cage",
                    Gender = "Female",
                    HatchDate = new DateTime(2017, 07, 13),
                    Image = "images/budgie2.jpg",
                    Species = "Budgerigar",
                    ScientificName ="Melopsittacus undulatus",
                    Food = "Parakeet mix",

                    },

                    new Bird
                    {
                    Id = Guid.Parse("8E74A018-6D85-4E2A-BB85-F8DA2D58F3BF"),
                    Name = "Steven",
                    Cage = "Outside cage 2",
                    Gender = "Male",
                    HatchDate = new DateTime(2012, 09, 03),
                    Image = "images/cockatiel1.jpg",
                    Species = "Cockatiel",
                    ScientificName = "Nymphicus hollandicuss",
                    Food = "Parakeet mix",

                    },

                    new Bird
                    {
                    Id = Guid.Parse("F797C0C1-B01A-4F54-9C5D-7C66D5EDDC52"),
                    Name = "July",
                    Cage = "Outside cage 2",
                    Gender = "Female",
                    HatchDate = new DateTime(2017, 07, 13),
                    Image = "images/cockatiel2.jpg",
                    Species = "Cockatiel",
                    ScientificName = "Nymphicus hollandicuss",
                    Food = "Parakeet mix",
                    Medications = new List<Guid>
                    {
                        Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                        Guid.Parse("13931038-e515-45f4-b036-ea22c0c24d62")

                    }
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
            birdrepository.Remove(bird);
            return Task.FromResult(bird);
        }

        public Task<ObservableCollection<Bird>> GetAllBirds()
        {
            return Task.FromResult(birdrepository);
        }

        public Task<Bird> GetBirdById(Guid id)
        {
            var bird = birdrepository.FirstOrDefault(b => b.Id.Equals(id));
            return Task.FromResult(bird);
        }

        public  IEnumerable<Bird> GetBirdsByMedication(Medication medication)
        {
            var birds = birdrepository.Where(b => b.Medications.Contains(medication.Id)).ToList();
            return birds;
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
