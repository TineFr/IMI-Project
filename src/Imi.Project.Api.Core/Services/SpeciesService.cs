using Imi.Project.Api.Core.Dtos.Species;
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

        public async Task<Species> AddSpeciesAsync(SpeciesRequestDto speciesRequestDto)
        {
            var species = speciesRequestDto.MapToEntity();
            var result = await _speciesRepository.AddAsync(species);
            var dto = result;

            return dto;
        }

        public async Task DeleteSpeciesAsync(SpeciesRequestDto speciesRequestDto)
        {
            var species = speciesRequestDto.MapToEntity();

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

        public async Task<Species> UpdateSpeciesAsync(SpeciesRequestDto speciesRequestDto)
        {
            var species = speciesRequestDto.MapToEntity();
            var result = await _speciesRepository.UpdateAsync(species);
            var dto = result;

            return dto;
        }
    }
}
