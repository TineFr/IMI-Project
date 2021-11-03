﻿using Imi.Project.Mobile.Core.Models;
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
        private static ICageService cageService = new MockCageService();
        private static ISpeciesService speciesService = new MockSpeciesService();
        private static ObservableCollection<Bird> birdrepository = new ObservableCollection<Bird>
        {
                    new Bird
                    {
                    Id = Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E"),
                    Name = "Jake",
                    CageId = Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E"),
                    Gender = "Male",
                    HatchDate = new DateTime(2015, 12, 25),
                    Image = "images/budgie1.jpg",
                    SpeciesId = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    Food = "Parakeet mix",
                    Prescriptions = new List<Guid>
                    {
                        Guid.Parse("E7FE31F2-1996-4102-90E3-9530A0838217"),
                        Guid.Parse("5206461d-3ba9-4701-a6a1-6a563ccceff2"),
                        Guid.Parse("bd2670bb-392c-44a9-b2d8-88e6e413c165"),
                        Guid.Parse("6cdff968-d2fb-45af-a916-957a00ff5fe1")
                    }

                    },

                    new Bird
                    {
                    Id = Guid.Parse("6668E055-E99C-4B50-AD12-5A28CA2AD422"),
                    Name = "Holly",
                    CageId = Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E"),
                    Gender = "Female",
                    HatchDate = new DateTime(2017, 07, 13),
                    Image = "images/budgie2.jpg",
                    SpeciesId = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    Food = "Parakeet mix",
                    Prescriptions = new List<Guid>
                    {

                        Guid.Parse("5206461d-3ba9-4701-a6a1-6a563ccceff2"),
                        Guid.Parse("bd2670bb-392c-44a9-b2d8-88e6e413c165"),
                        Guid.Parse("6cdff968-d2fb-45af-a916-957a00ff5fe1")
                    }

                    },

                    new Bird
                    {
                    Id = Guid.Parse("8E74A018-6D85-4E2A-BB85-F8DA2D58F3BF"),
                    Name = "Steven",
                    CageId = Guid.Parse("36122865-A1B6-410E-AFB9-662F8EE16949"),
                    SpeciesId = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    Gender = "Male",
                    HatchDate = new DateTime(2012, 09, 03),
                    Image = "images/cockatiel1.jpg",
                    Food = "Parakeet mix",
                    Prescriptions = new List<Guid>
                    {
                        Guid.Parse("6cdff968-d2fb-45af-a916-957a00ff5fe1")
                    }
                    },

                    new Bird
                    {
                    Id = Guid.Parse("F797C0C1-B01A-4F54-9C5D-7C66D5EDDC52"),
                    Name = "July",
                    CageId = Guid.Parse("36122865-A1B6-410E-AFB9-662F8EE16949"),
                    SpeciesId = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),                    
                    Gender = "Female",
                    HatchDate = new DateTime(2017, 07, 13),
                    Image = "images/cockatiel2.jpg",
                    Food = "Parakeet mix",
                     Prescriptions = new List<Guid>
                    {
                         Guid.Parse("6cdff968-d2fb-45af-a916-957a00ff5fe1")
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
            birdrepository.ToList().ForEach(async b => b.Cage = await cageService.GetCageById(b.CageId));
            birdrepository.ToList().ForEach(async b => b.Species = await speciesService.GetSpeciesById(b.SpeciesId));
            return Task.FromResult(birdrepository);
        }

        public Task<Bird> GetBirdById(Guid id)
        {
            var bird = birdrepository.FirstOrDefault(b => b.Id.Equals(id));
            return Task.FromResult(bird);
        }

        public  IEnumerable<Bird> GetBirdsByPrescription(Prescription prescription)
        {
            var birds = birdrepository.Where(b => b.Prescriptions.Contains(prescription.Id)).ToList();
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