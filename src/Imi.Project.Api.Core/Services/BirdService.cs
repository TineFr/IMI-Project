using Imi.Project.Api.Core.Dtos.Birds;
using Imi.Project.Api.Core.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class BirdService : IBirdService
    {
        protected readonly IBirdRepository _birdRepository;

        public BirdService(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }


        public Task<BirdResponseDto> AddBirdAsync(BirdRequestDto birdRequestDto)
        {
            throw new NotImplementedException();
        }


        public Task DeleteBirdAsync(BirdRequestDto userRequestDto)
        {
            throw new NotImplementedException();
        }

        public async Task<BirdResponseDto> GetBirdByIdAsync(Guid id)
        {
            var bird = await _birdRepository.GetByIdAsync(id);
            return bird.MapToDto();
        }

        public async Task<IEnumerable<BirdResponseDto>> GetBirdsByCageIdAsync(Guid id)
        {
            var birds = await _birdRepository.GetByCageIdAsync(id);
            return birds.MapToDtoList();
        }

        public async Task<IEnumerable<BirdResponseDto>> GetBirdsByUserIdAsync(Guid id)
        {
            var birds = await _birdRepository.GetByUserIdAsync(id);
            return birds.MapToDtoList();
        }

        public async Task<IEnumerable<BirdResponseDto>> GetBirdsWithMedicineAsync()
        {
            var birds = await _birdRepository.GetBirdsWithMedicineAsync();
            return birds.MapToDtoList();
        }

        public async Task<IEnumerable<BirdResponseDto>> ListAllBirdsAsync()
        {
            var birds = await _birdRepository.ListAllAsync();
            return birds.MapToDtoList();
        }

        public Task<BirdResponseDto> UpdateBirdAsync(BirdRequestDto birdRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
