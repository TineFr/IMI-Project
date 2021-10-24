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

        public Task<SpeciesResponseDto> AddSpeciesAsync(SpeciesRequestDto userRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSpeciesAsync(SpeciesRequestDto userRequestDto)
        {
            throw new NotImplementedException();
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

        public Task<SpeciesResponseDto> UpdateSpeciesAsync(SpeciesRequestDto userRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
