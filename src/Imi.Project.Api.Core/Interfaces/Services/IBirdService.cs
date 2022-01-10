using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IBirdService
    {
        Task<IEnumerable<BirdResponseDto>> ListAllBirdsAsync(PaginationParameters parameters);
        Task<BirdResponseDto> GetBirdByIdAsync(Guid id);
        Task<BirdResponseDto> AddBirdAsync(BirdRequestDto bird);
        Task<BirdResponseDto> UpdateBirdAsync(Guid id, BirdRequestDto bird);
        Task DeleteMultiple(List<Bird> birds);
        Task DeleteBirdAsync(Guid id);
        Task<IEnumerable<BirdResponseDto>> GetBirdsByUserIdAsync(Guid id, PaginationParameters parameters);

        Task<IEnumerable<BirdResponseDto>> GetFilteredBirdsFromUser(Guid id, Guid? species, Guid? cage, PaginationParameters parameters);
        Task<IEnumerable<BirdResponseDto>> GetBirdsByCageIdAsync(Guid id, PaginationParameters parameters);


    }
}
