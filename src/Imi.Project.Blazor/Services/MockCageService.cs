using Imi.Project.Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services
{
    public class MockCageService
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
        public Task<Cage> AddCage(Cage Cage)
        {
            Cagerepository.Add(Cage);
            return Task.FromResult(Cage);
        }

        public Task<Cage> DeleteCage(Guid id)
        {
            var Cage = Cagerepository.FirstOrDefault(b => b.Id.Equals(id));
            Cagerepository.Remove(Cage);
            return Task.FromResult(Cage);
        }

        public Task<List<Cage>> GetAllCages()
        {
            return Task.FromResult(Cagerepository);
        }

        public Task<Cage> GetCageById(Guid id)
        {
            var Cage = Cagerepository.FirstOrDefault(b => b.Id.Equals(id));
            return Task.FromResult(Cage);
        }

        public Task<Cage> UpdateCage(Cage updatedCage)
        {
            var Cage = Cagerepository.FirstOrDefault(b => b.Id.Equals(updatedCage.Id));
            Cagerepository.ToList().Remove(Cage);
            Cagerepository.ToList().Add(updatedCage);
            return Task.FromResult(updatedCage);
        }
    }
}
