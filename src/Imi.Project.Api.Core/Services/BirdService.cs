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
    public class BirdService : IBirdService
    {
        protected readonly IBirdRepository _birdRepository;
        protected readonly IImageService _imageService;
        protected readonly ICageRepository _cageRepository;
        public BirdService(IBirdRepository birdRepository,
                           IImageService imageService,
                           ICageRepository cageRepository)
        {
            _birdRepository = birdRepository;
            _imageService = imageService;
            _cageRepository = cageRepository;
        }

        public async Task<BirdResponseDto> GetBirdByIdAsync(Guid id)
        {
            var bird = await _birdRepository.GetByIdAsync(id);
            if (bird == null)
            {
                throw new BadRequestException($"Bird with id {id} does not exist");
            }
            BirdResponseDto result = bird.MapToDto();
            return result;
        }

        public async Task<IEnumerable<BirdResponseDto>> ListAllBirdsAsync(PaginationParameters parameters)
        {
            var birds = await _birdRepository.ListAllAsync();
            if (birds.Count() == 0)
            {
                throw new ItemNotFoundException($"No birds were found");
            }
            var result = birds.MapToDtoList();
            return result;
        }

        public async Task<BirdResponseDto> UpdateBirdAsync(Guid id, BirdRequestDto dto)
        {
            var bird = await _birdRepository.GetByIdAsync(id);
            if (bird == null)
            {
                throw new BadRequestException($"Bird with id {id} does not exist");
            }
            await ValidateRequest(dto);
            var updatedBirdEntity = bird.Update(dto);

            if (dto.Image != null)
            {
                _imageService.ValidateImage(dto);
                var databasePath = await _imageService.AddOrUpdateImageAsync<Bird>(id, dto.Image);
                updatedBirdEntity.Image = databasePath;
            }
            else if (bird.Image != null) updatedBirdEntity.Image = bird.Image;

            var result = await _birdRepository.UpdateAsync(updatedBirdEntity);
            var resultDto = result.MapToDto();
            return resultDto;
        }

        public async Task<BirdResponseDto> AddBirdAsync(BirdRequestDto dto)
        {
            await ValidateRequest(dto);
            var newBirdEntity = dto.MapToEntity();
            newBirdEntity.Id = Guid.NewGuid();

            if (dto.Image != null)
            {
                _imageService.ValidateImage(dto);
                var databasePath = await _imageService.AddOrUpdateImageAsync<Bird>(newBirdEntity.Id, dto.Image);
                newBirdEntity.Image = databasePath;
            }

            else newBirdEntity.Image = ImageConstant.defaultImagePath;

            var result = await _birdRepository.AddAsync(newBirdEntity);
            var resultDto = result.MapToDto();
            return resultDto;
        }

        public async Task DeleteBirdAsync(Guid id)
        {
            var bird = await _birdRepository.GetByIdAsync(id);
            if (bird == null)
            {
                throw new BadRequestException($"Bird with id {id} does not exist");
            }
            await _birdRepository.DeleteAsync(bird);
        }

        public async Task DeleteMultiple(List<Bird> birds)
        {
            await _birdRepository.DeleteMultipleAsync(birds);
        }

        public async Task<IEnumerable<BirdResponseDto>> GetBirdsByCageIdAsync(Guid id, PaginationParameters parameters)
        {
            if (await _birdRepository.EntityExists<Cage>(id))
            {
                var birds = await _birdRepository.GetByCageIdAsync(id);
                if (birds.Count() == 0)
                {
                    throw new ItemNotFoundException($"No birds were found for cage with id {id}");
                }
                var birdsPaginated = Pagination.AddPagination<Bird>(birds, parameters);
                var result = birdsPaginated.MapToDtoList();
                return result;
            }
            else throw new ItemNotFoundException($"Cage with id {id} does not exist");
        }

        public async Task<IEnumerable<BirdResponseDto>> GetBirdsByUserIdAsync(Guid id, PaginationParameters parameters)
        {
            if (await _birdRepository.EntityExists<ApplicationUser>(id))
            {
                var birds = await _birdRepository.GetByUserIdAsync(id);
                if (birds.Count() == 0)
                {
                    throw new ItemNotFoundException($"No birds were found for user with id {id}");
                }
                var result = birds.MapToDtoList();
                return result;
            }
            else throw new ItemNotFoundException($"User with id {id} does not exist");
        }

        private async Task ValidateRequest(BirdRequestDto dto)
        {
            if ( !(await _birdRepository.EntityExists<ApplicationUser>(dto.UserId)))
            {
                throw new ItemNotFoundException($"User with id {dto.UserId} does not exist");
            }

            if (dto.CageId != null)
            {
                var cage = await _cageRepository.ExsistsForUserId(dto.UserId, dto.CageId);
                if (cage == null)
                {
                    throw new ItemNotFoundException($"Cage with id {dto.CageId} does not exist for this user");
                }
            }

            if (dto.SpeciesId != null)
            {
                if (dto.CageId != new Guid())
                    if (!(await _birdRepository.EntityExists<Species>(dto.SpeciesId)))
                    {
                        throw new ItemNotFoundException($"Species with id {dto.UserId} does not exist");
                    }
            }


            if (dto.HatchDate != new DateTime())
            {
                if (dto.HatchDate > DateTime.Today)
                {
                    throw new BadRequestException($"Can not set a future date as hatchdate");
                }
            }
        }

    }
}
