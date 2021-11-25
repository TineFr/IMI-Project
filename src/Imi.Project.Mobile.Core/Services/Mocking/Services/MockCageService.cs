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
    public class MockCageService : ICageService
    {
        private static ObservableCollection<Cage> Cagerepository = new ObservableCollection<Cage>
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
        public Task<Cage> AddCage(Cage cage)
        {
            Cagerepository.Add(cage);
            return Task.FromResult(cage);
        }

        public Task<Cage> DeleteCage(Guid id)
        {
            var cage = Cagerepository.FirstOrDefault(b => b.Id.Equals(id));
            Cagerepository.Remove(cage);
            return Task.FromResult(cage);
        }

        public Task<ObservableCollection<Cage>> GetAllCages()
        {
            return Task.FromResult(Cagerepository);
        }

        public Task<Cage> GetCageById(Guid id)
        {
            var cage = Cagerepository.FirstOrDefault(b => b.Id.Equals(id));
            return Task.FromResult(cage);
        }

        public Task<Cage> UpdateCage(Cage updatedCage)
        {
            var cage = Cagerepository.FirstOrDefault(b => b.Id.Equals(updatedCage.Id));
            Cagerepository.ToList().Remove(cage);
            Cagerepository.ToList().Add(updatedCage);
            return Task.FromResult(updatedCage);
        }
    }
}

