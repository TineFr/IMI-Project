using Imi.Project.Api.Core.Dtos.Species;
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

        public async Task<SpeciesResponseDto> AddSpeciesAsync(SpeciesRequestDto speciesRequestDto)
        {
            var species = speciesRequestDto.MapToEntity();
            var result = await _speciesRepository.AddAsync(species);
            var dto = result.MapToDto();

            return dto;
        }

        public async Task DeleteSpeciesAsync(SpeciesRequestDto speciesRequestDto)
        {
            var species = speciesRequestDto.MapToEntity();

            await _speciesRepository.DeleteAsync(species);
            
        }

        public async Task<SpeciesResponseDto> GetSpeciesByIdAsync(Guid id)
        {
            var species = await _speciesRepository.GetByIdAsync(id);
            return species.MapToDto();
        }

        public async Task<IEnumerable<SpeciesResponseDto>> ListAllSpeciessAsync()
        {
            var species = await _speciesRepository.ListAllAsync();
            return species.MapToDtoList();
        }

        public async Task<SpeciesResponseDto> UpdateSpeciesAsync(SpeciesRequestDto speciesRequestDto)
        {
            var species = speciesRequestDto.MapToEntity();
            var result = await _speciesRepository.UpdateAsync(species);
            var dto = result.MapToDto();

            return dto;
        }
    }
}
