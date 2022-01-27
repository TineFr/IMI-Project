
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface ICageService
    {
        Task<IEnumerable<CageResponseDto>> ListAllCagesAsync();
        Task<CageResponseDto> GetCageByIdAsync(Guid id);
        Task<IEnumerable<CageResponseDto>> GetCagesByUserIdAsync(Guid id);
        Task<CageResponseDto> AddCageAsync(CageRequestDto cage);
        Task DeleteMultiple(List<Cage> cages);
        Task<IEnumerable<CageResponseDto>> GetFilteredCagesFromUser(Guid id, string query);
        Task<CageResponseDto> UpdateCageAsync(Guid id, CageRequestDto cage);
        Task DeleteCageAsync(Guid id);
    }
}
