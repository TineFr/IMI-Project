using Imi.Project.Api.Core.Dtos.Birds;
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
    public class BirdService : IBirdService
    {
        protected readonly IBirdRepository _birdRepository;

        public BirdService(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }


        public Task<Bird> AddBirdAsync(BirdRequestDto birdRequestDto)
        {
            throw new NotImplementedException();
        }


        public Task DeleteBirdAsync(BirdRequestDto userRequestDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Bird> GetBirdByIdAsync(Guid id)
        {
            var bird = await _birdRepository.GetByIdAsync(id);
            return bird;
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

        public async Task<IEnumerable<Bird>> GetBirdsWithMedicineAsync()
        {
            var birds = await _birdRepository.GetBirdsWithMedicineAsync();
            return birds;
        }

        public async Task<IEnumerable<Bird>> ListAllBirdsAsync()
        {
            var birds = await _birdRepository.ListAllAsync();
            return birds;
        }

        public Task<Bird> UpdateBirdAsync(BirdRequestDto birdRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
