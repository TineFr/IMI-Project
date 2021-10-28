using Imi.Project.Api.Core.Dtos.Cages;
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
    public class CageService : ICageService
    {
        private readonly ICageRepository _cageRepository;

        public CageService(ICageRepository cageRepository)
        {
            _cageRepository = cageRepository;
        }

        public async Task<Cage> AddCageAsync(Cage cage)
        {
            var result = await _cageRepository.AddAsync(cage);
            return result;
        }
    
        public async Task DeleteCageAsync(Cage cage)
        {
           await _cageRepository.DeleteAsync(cage);
           
        }

        public async Task<Cage> GetCageByIdAsync(Guid id)
        {
            var cage = await _cageRepository.GetByIdAsync(id);
            return cage;
        }


        public async Task<IEnumerable<Cage>> GetCagesByUserIdAsync(Guid id)
        {
            var cages = await _cageRepository.GetCagesByUserIdAsync(id);
            return cages;
        }

        public async Task<IEnumerable<Cage>> ListAllCagesAsync()
        {
            var cageList = await _cageRepository.ListAllAsync();
            return cageList;
        }

        public async Task<Cage> UpdateCageAsync(Cage cage)
        {
            var result = await _cageRepository.UpdateAsync(cage);
            return result;
        }
    }
}
