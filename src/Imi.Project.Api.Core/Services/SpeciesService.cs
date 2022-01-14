using Imi.Project.Api.Core.Defaults;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
using Imi.Project.Api.Core.Exceptions;
using Imi.Project.Api.Core.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class SpeciesService : ISpeciesService
    {
        protected readonly ISpeciesRepository _speciesRepository;
        protected readonly IImageService _imageService;

        public SpeciesService(ISpeciesRepository speciesRepository, 
                              IImageService imageService)
        {
            _speciesRepository = speciesRepository;
            _imageService = imageService;
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
        public async Task<IEnumerable<SpeciesResponseDto>> ListAllSpeciessAsync()
        {
            var species = await _speciesRepository.ListAllAsync();
            if (species.Count() == 0)
            {
                throw new ItemNotFoundException($"No species were found");
            }
            var result = species.MapToDtoList();
            return result;
        }
        public async Task<SpeciesResponseDto> AddSpeciesAsync(SpeciesRequestDto dto)
        {
            var newSpeciesEntity = dto.MapToEntity();
            newSpeciesEntity.Id = Guid.NewGuid();

            if (dto.Image != null)
            {
                _imageService.ValidateImage(dto);
                var databasePath = await _imageService.AddOrUpdateImageAsync<Species>(newSpeciesEntity.Id, dto.Image);
                newSpeciesEntity.Image = databasePath;
            }
            else newSpeciesEntity.Image = ImageConstant.defaultImagePath;

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
        public async Task<SpeciesResponseDto> UpdateSpeciesAsync(Guid id, SpeciesRequestDto dto)
        {
            var species = await _speciesRepository.GetByIdAsync(id);
            if (species == null)
            {
                throw new BadRequestException($"Species with id {id} does not exist");
            }
            var updatedSpeciesEntity = species.Update(dto);

            if (dto.Image != null)
            {
                _imageService.ValidateImage(dto);
                var databasePath = await _imageService.AddOrUpdateImageAsync<Species>(id, dto.Image);
                updatedSpeciesEntity.Image = databasePath;
            }

            var result = await _speciesRepository.UpdateAsync(updatedSpeciesEntity);
            var resultDto = result.MapToDto();
            return resultDto;
        }
    }
}
