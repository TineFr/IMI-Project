using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Exceptions;
using Imi.Project.Api.Core.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
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

        public async Task<SpeciesResponseDto> GetSpeciesByIdAsync(Guid id)
        {
            var species = await _speciesRepository.GetByIdAsync(id);
            if (species == null)
            {
                throw new BadRequestException($"Species with id {id} does not exist");
            }
            SpeciesResponseDto result = species.MapToDto();
            return result;
        }

        public async Task<SpeciesResponseDto> AddSpeciesAsync(SpeciesRequestDto dto)
        {
            var newSpeciesEntity = dto.MapToEntity();
            var result = await _speciesRepository.AddAsync(newSpeciesEntity);
            var resultDto = result.MapToDto();
            return resultDto;
        }

        public async Task DeleteSpeciesAsync(Guid id)
        {
            var species = await _speciesRepository.GetByIdAsync(id);
            if (species == null)
            {
                throw new BadRequestException($"Species with id {id} does not exist");
            }
            await _speciesRepository.DeleteAsync(species);
        }

        public async Task<IEnumerable<Species>> ListAllSpeciessAsync()
        {
            var species = await _speciesRepository.ListAllAsync();
            return species;
        }

        public async Task<SpeciesResponseDto> UpdateSpeciesAsync(Guid id, SpeciesRequestDto dto)
        {
            var species = await _speciesRepository.GetByIdAsync(id);
            if (species == null)
            {
                throw new BadRequestException($"Species with id {id} does not exist");
            }
            var newSpeciesEntity = dto.MapToEntity();
            var result = await _speciesRepository.AddAsync(newSpeciesEntity);
            var resultDto = result.MapToDto();
            return resultDto;
        }
    }
}
