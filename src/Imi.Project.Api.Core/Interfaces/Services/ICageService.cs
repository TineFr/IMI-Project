
using Imi.Project.Api.Core.Entities;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface ICageService
    {
        Task<IEnumerable<Cage>> ListAllCagesAsync();
        Task<CageResponseDto> GetCageByIdAsync(Guid id);
        Task<IEnumerable<Cage>> GetCagesByUserIdAsync(Guid id);
        Task<CageResponseDto> AddCageAsync(CageRequestDto cage);

        Task DeleteMultiple(List<Cage> cages);
        Task<CageResponseDto> UpdateCageAsync(Guid id, CageRequestDto cage);
        Task DeleteCageAsync(Guid id);
    }
}
