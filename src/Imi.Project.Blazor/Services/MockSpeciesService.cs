using Imi.Project.Blazor.Models;
using Imi.Project.Blazor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services
{
    public class MockSpeciesService : ISpeciesService
    {
        private  static List<Species> speciesrepository = new List<Species>
        {
                    new Species
                    {
                    Id = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    Name = "Budgerigar",
                    ScientificName = "lorem ipsum"
                    },

                    new Species
                    {
                    Id = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    Name = "Monk parakeet",
                    ScientificName = "lorem ipsum"
                    },
                    new Species
                    {
                    Id = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    Name = "Cockatiel",
                    ScientificName = "lorem ipsum"
                    },

                    new Species
                    {
                    Id = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    Name = "Indian ringneck parakeet",
                    ScientificName = "lorem ipsum"
                    },

                    new Species
                    {
                    Id = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    Name = "Regent parakeet",
                    ScientificName ="lorem ipsum"
                    },

                    new Species
                    {
                    Id = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    Name = "Bourke’s parakeet",
                    ScientificName = "lorem ipsum",
                    },
        };

        public Task<Species> AddAsync(Species item)
        {
            throw new NotImplementedException();
        }


        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }



        public Task<List<Species>> GetAllAsync()
        {
            return Task.FromResult(speciesrepository);
        }



        public Task<Species> GetByIdAsync(Guid id)
        {
            var species = speciesrepository.FirstOrDefault(b => b.Id.Equals(id));
            return Task.FromResult(species);
        }

        public Task<Species> UpdateAsync(Species item)
        {
            throw new NotImplementedException();
        }

    }
}
