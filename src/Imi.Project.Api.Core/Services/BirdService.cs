using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Exceptions;
using Imi.Project.Api.Core.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Common.Dtos;

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class BirdService : IBirdService
    {
        protected readonly IBirdRepository _birdRepository;
        protected readonly IImageService _imageService;

        public BirdService(IBirdRepository birdRepository,
                           IImageService imageService)
        {
            _birdRepository = birdRepository;
            _imageService = imageService;
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

        public async Task<IEnumerable<Bird>> ListAllBirdsAsync()
        {
            var birds = await _birdRepository.ListAllAsync();
            return birds;
        }

        public async Task<BirdResponseDto> UpdateBirdAsync(Guid id, BirdRequestDto dto)
        {
            var bird = await _birdRepository.GetByIdAsync(id);
            if (bird == null)
            {
                throw new BadRequestException($"Bird with id {id} does not exist");
            }
            if ((await _birdRepository.EntityExistsForUser<Cage>(dto.UserId, dto.CageId)) == null)
            {
                throw new ItemNotFoundException($"Cage with id {dto.CageId} does not exist for this user");
            }
            var updatedBirdEntity = bird.Update(dto);

            if (dto.Image != null)
            {
                _imageService.ValidateImage(dto);
                var databasePath = await _imageService.AddOrUpdateImageAsync<Bird>(id, dto.Image);
                updatedBirdEntity.Image = databasePath;
            }

            var result = await _birdRepository.UpdateAsync(bird);
            var resultDto = result.MapToDto();
            return resultDto;
        }

        public async Task<BirdResponseDto> AddBirdAsync(BirdRequestDto dto)
        {
            if (!(await _birdRepository.EntityExists<ApplicationUser>(dto.UserId)))
            {
                throw new ItemNotFoundException($"User with id {dto.UserId} does not exist");
            }
            if (!(await _birdRepository.EntityExistsForUser<Cage>(dto.UserId, dto.CageId)))
            {
                throw new ItemNotFoundException($"Cage with id {dto.CageId} does not exist for this user");
            }
            var newBirdEntity = dto.MapToEntity();
            newBirdEntity.Id = Guid.NewGuid();

            if (dto.Image != null)
            {
                _imageService.ValidateImage(dto);
                var databasePath = await _imageService.AddOrUpdateImageAsync<Bird>(newBirdEntity.Id, dto.Image);
                newBirdEntity.Image = databasePath;
            }

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

        public async Task<IEnumerable<Bird>> GetBirdsByCageIdAsync(Guid id)
        {
            var birds = await _birdRepository.GetByCageIdAsync(id);
            return birds;
        }

        public async Task<IEnumerable<Bird>> GetBirdsByUserIdAsync(Guid id)
        {
            var birds = await _birdRepository.GetByUserIdAsync(id);
            return birds;
        }

    }
}
