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
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class CageService : ICageService
    {
        private readonly ICageRepository _cageRepository;
        protected readonly IImageService _imageService;

        public CageService(ICageRepository cageRepository,
                           IImageService imageService)
        {
            _cageRepository = cageRepository;
            _imageService = imageService;
        }

        public async Task<CageResponseDto> GetCageByIdAsync(Guid id)
        {
            var cage = await _cageRepository.GetByIdAsync(id);
            if (cage == null)
            {
                throw new BadRequestException($"Cage with id {id} does not exist");
            }
            CageResponseDto result = cage.MapToDto();
            return result;
        }
        public async Task<IEnumerable<CageResponseDto>> ListAllCagesAsync()
        {
            var cages = await _cageRepository.ListAllAsync();
            if (cages.Count() == 0)
            {
                throw new ItemNotFoundException($"No cages were found");
            }
            var result = cages.MapToDtoList();
            return result;
        }
        public async Task<CageResponseDto> AddCageAsync(CageRequestDto dto)
        {
            await ValidateRequest(dto);
            var newCageEntity = dto.MapToEntity();
            newCageEntity.Id = Guid.NewGuid();

            if (dto.Image != null)
            {
                _imageService.ValidateImage(dto);
                var databasePath = await _imageService.AddOrUpdateImageAsync<Cage>(newCageEntity.Id, dto.Image);
                newCageEntity.Image = databasePath;
            }
            else newCageEntity.Image = ImageConstant.defaultImagePath;

            var result = await _cageRepository.AddAsync(newCageEntity);
            var resultDto = result.MapToDto();
            return resultDto;
        }
        public async Task<CageResponseDto> UpdateCageAsync(Guid id, CageRequestDto dto)
        {
            var cage = await _cageRepository.GetByIdAsync(id);
            if (cage == null)
            {
                throw new BadRequestException($"Cage with id {id} does not exist");
            }
            await ValidateRequest(dto);
            var updatedCageEntity = cage.Update(dto);

            if (dto.Image != null)
            {
                _imageService.ValidateImage(dto);
                var databasePath = await _imageService.AddOrUpdateImageAsync<Cage>(id, dto.Image);
                updatedCageEntity.Image = databasePath;
            }
            else if (cage.Image != null) updatedCageEntity.Image = cage.Image;

            var result = await _cageRepository.UpdateAsync(updatedCageEntity);
            var resultDto = result.MapToDto();
            return resultDto;
        }
        public async Task DeleteCageAsync(Guid id)
        {
            var cage = await _cageRepository.GetByIdAsync(id);
            if (cage == null)
            {
                throw new BadRequestException($"Cage with id {id} does not exist");
            }
            await _cageRepository.DeleteAsync(cage);

        }
        public async Task DeleteMultiple(List<Cage> cages)
        {
            await _cageRepository.DeleteMultipleAsync(cages);
        }
        public async Task<IEnumerable<CageResponseDto>> GetCagesByUserIdAsync(Guid id)
        {
            if (await _cageRepository.EntityExists<ApplicationUser>(id))
            {
                var cages = await _cageRepository.GetByUserIdAsync(id);
                if (cages.Count() == 0)
                {
                    throw new ItemNotFoundException($"No cages were found for user with id {id}");
                }
                var result = cages.MapToDtoList();
                return result;
            }
            else throw new ItemNotFoundException($"User with id {id} does not exist");

        }
        private async Task ValidateRequest(CageRequestDto dto)
        {
            if (!(await _cageRepository.EntityExists<ApplicationUser>(dto.UserId)))
            {
                throw new ItemNotFoundException($"User with id {dto.UserId} does not exist");
            }
        }

        public async Task<IEnumerable<CageResponseDto>> GetFilteredCagesFromUser(Guid userId,string query)
        {
            if (await _cageRepository.EntityExists<ApplicationUser>(userId))
            {
                IEnumerable<Cage> cages = await _cageRepository.GetByUserIdAsync(userId);
                if (cages.Count() == 0)
                {
                    throw new ItemNotFoundException($"No cages were found");
                }
                if (!String.IsNullOrEmpty(query))
                {
                    List<Cage> results = new List<Cage>();
                    results.AddRange(cages.Where(b => b.Name.ToLower().Contains(query.ToLower())));
                    results.AddRange(cages.Where(b => b.Location.ToLower().Contains(query.ToLower()) && !results.Contains(b)));
                    if (results.Count == 0)
                    {
                        throw new ItemNotFoundException($"No cages were found");
                    }
                    else cages = results;
                }
                var result = cages.MapToDtoList();
                return result;
            }
            else throw new ItemNotFoundException($"User with id {userId} does not exist");
        }
    }
}
