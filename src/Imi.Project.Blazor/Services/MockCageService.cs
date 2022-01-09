using Imi.Project.Blazor.Models;
using Imi.Project.Blazor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services
{
    public class MockCageService : ICageService
    {
        private static List<Cage> Cagerepository = new List<Cage>
        {
                    new Cage
                    {
                    Id = Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E"),
                    Name = "Outside Cage 1",
                    Location ="Outside",
                    Image = "images/cage1.png",


                    },

                    new Cage
                    {
                    Id = Guid.Parse("36122865-A1B6-410E-AFB9-662F8EE16949"),
                    Name = "Outside Cage 2",
                    Location ="Outside",
                    Image = "images/cage2.png",

                    },
        };

        public Task<Cage> AddAsync(Cage cage)
        {
            cage.Id = Guid.NewGuid();
            cage.Image = "images/cage2.png"; // nog geen image functionaliteit
            Cagerepository.Add(cage);
            return Task.FromResult(cage);
        }



        public Task<bool> DeleteAsync(Guid id)
        {
            var cage = Cagerepository.FirstOrDefault(b => b.Id.Equals(id));
            var IsRemoved = Cagerepository.ToList().Remove(cage);
            return Task.FromResult(IsRemoved); 
        }

        public Task<List<Cage>> GetAllAsync()
        {
            return Task.FromResult(Cagerepository);
        }


        public Task<Cage> GetByIdAsync(Guid id)
        {
            var Cage = Cagerepository.FirstOrDefault(b => b.Id.Equals(id));
            return Task.FromResult(Cage);
        }
        public Task<Cage> UpdateAsync(Cage updatedCage)
        {
            var Cage = Cagerepository.FirstOrDefault(b => b.Id.Equals(updatedCage.Id));
            Cagerepository.ToList().Remove(Cage);
            Cagerepository.ToList().Add(updatedCage);
            return Task.FromResult(updatedCage);
        }


    }
}
