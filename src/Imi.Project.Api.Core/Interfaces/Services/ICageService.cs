
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
        Task<IEnumerable<CageResponseDto>> ListAllCagesAsync(PaginationParameters parameters);
        Task<CageResponseDto> GetCageByIdAsync(Guid id);
        Task<IEnumerable<CageResponseDto>> GetCagesByUserIdAsync(Guid id, PaginationParameters parameters);
        Task<CageResponseDto> AddCageAsync(CageRequestDto cage);
        Task DeleteMultiple(List<Cage> cages);
        Task<CageResponseDto> UpdateCageAsync(Guid id, CageRequestDto cage);
        Task DeleteCageAsync(Guid id);
    }
}
