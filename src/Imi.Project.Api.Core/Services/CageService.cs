using Imi.Project.Api.Core.Dtos.Requests;
using Imi.Project.Api.Core.Dtos.Responses;
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

        public Task<CageResponseDto> AddCageAsync(CageRequestDto userRequestDto)
        {
            throw new NotImplementedException();
        }
    

        public Task DeleteCageAsync(CageRequestDto userRequestDto)
        {
            throw new NotImplementedException();
        }

        public async Task<CageResponseDto> GetCageByIdAsync(Guid id)
        {
            var cage = await _cageRepository.GetByIdAsync(id);
            return cage.MapToDto();
        }


        public async Task<IEnumerable<CageResponseDto>> GetCagesByUserIdAsync(Guid id)
        {
            var cages = await _cageRepository.GetCagesByUserIdAsync(id);
            return cages.MapToDtoList();
        }

        public async Task<IEnumerable<CageResponseDto>> ListAllCagesAsync()
        {
            var cageList = await _cageRepository.ListAllAsync();
            return cageList.MapToDtoList();
        }

        public Task<CageResponseDto> UpdateCageAsync(CageRequestDto userRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
