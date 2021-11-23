using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class SpeciesService : ISpeciesService
    {
        protected readonly ISpeciesRepository _speciesRepository;

        public SpeciesService(ISpeciesRepository speciesRepository)
        {
            _speciesRepository = speciesRepository;
        }

        public async Task<Species> AddSpeciesAsync(Species species)
        {

            var result = await _speciesRepository.AddAsync(species);
            return result;
        }

        public async Task DeleteSpeciesAsync(Species species)
        {
            await _speciesRepository.DeleteAsync(species);       
        }

        public async Task<Species> GetSpeciesByIdAsync(Guid id)
        {
            var species = await _speciesRepository.GetByIdAsync(id);
            return species;
        }

        public async Task<IEnumerable<Species>> ListAllSpeciessAsync()
        {
            var species = await _speciesRepository.ListAllAsync();
            return species;
        }

        public async Task<Species> UpdateSpeciesAsync(Species species)
        {
            var result = await _speciesRepository.UpdateAsync(species);
            return result;

        }
    }
}
