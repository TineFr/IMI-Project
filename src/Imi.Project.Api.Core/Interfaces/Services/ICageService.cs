using Imi.Project.Api.Core.Dtos.Cages;
using Imi.Project.Api.Core.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface ICageService
    {
        Task<IEnumerable<CageResponseDto>> ListAllCagesAsync();
        Task<CageResponseDto> GetCageByIdAsync(Guid id);
        Task<IEnumerable<CageResponseDto>> GetCagesByUserIdAsync(Guid id);
        Task<CageResponseDto> AddCageAsync(CageRequestDto userRequestDto);
        Task<CageResponseDto> UpdateCageAsync(CageRequestDto userRequestDto);
        Task DeleteCageAsync(CageRequestDto userRequestDto);
    }
}
