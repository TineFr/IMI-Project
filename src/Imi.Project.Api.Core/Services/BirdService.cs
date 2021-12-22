using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Exceptions;
using Imi.Project.Api.Core.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Mvc;
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
        protected readonly IBaseRepository<ApplicationUser> _baseUserRepository;
        protected readonly IBaseRepository<Cage> _baseCageRepository;
        protected readonly ICageRepository _cageRepository;
        protected readonly IImageService _imageService;

        public BirdService(IBirdRepository birdRepository,
                           IBaseRepository<ApplicationUser> baseUserRepository,
                           IBaseRepository<Cage> baseCageRepository,
                           IImageService imageService,
                           ICageRepository cageRepository)
        {
            _birdRepository = birdRepository;
            _baseUserRepository = baseUserRepository;
            _baseCageRepository = baseCageRepository;
            _imageService = imageService;
            _cageRepository = cageRepository;
            }

        public async Task<BirdResponseDto> AddBirdAsync(BirdRequestDto bird)
        {
            var Bird = await _birdRepository.GetByIdAsync(bird.Id);
            if (Bird != null)
            {
                throw new BadRequestException($"Bird with id {bird.Id} already exists");
            }
            var user = await _baseUserRepository.GetByIdAsync(bird.UserId);
            if (user == null)
            {
                throw new ItemNotFoundException($"User with id {bird.UserId} does not exist");
            }
            var cage = (await _cageRepository.ExsistsForUserId(bird.UserId, bird.CageId));
            if (cage == null)
            {
                throw new ItemNotFoundException($"Cage with id {bird.CageId} does not exist for this user");
            }
            var newBirdEntity = bird.MapToEntity();

            if (bird.Image != null)
            {
                if (bird.Image.ContentType.Contains("image"))
                {
                    var databasePath = await _imageService.AddOrUpdateImageAsync<Bird>(bird.Id, bird.Image);
                    newBirdEntity.Image = databasePath;
                }
                throw new FormatException($"Image does not have the correct format");
            }

            var result = await _birdRepository.AddAsync(newBirdEntity);
            var resultDto = result.MapToDto();
            return resultDto;
        }

        public async Task DeleteBirdAsync(Bird bird)
        {
             await _birdRepository.DeleteAsync(bird);
       
        }

        public async Task DeleteMultiple(List<Bird> birds)
        {
            await _birdRepository.DeleteMultipleAsync(birds);
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

        public async Task<IEnumerable<Bird>> ListAllBirdsAsync()
        {
            var birds = await _birdRepository.ListAllAsync();
            return birds;
        }

        public async Task<Bird> UpdateBirdAsync(Bird bird)
        {
            var result = await _birdRepository.UpdateAsync(bird);
            return result;
        }
    }
}
