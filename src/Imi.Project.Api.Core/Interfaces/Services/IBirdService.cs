using Imi.Project.Api.Core.Entities;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IBirdService
    {
        Task<IEnumerable<Bird>> ListAllBirdsAsync();
        Task<BirdResponseDto> GetBirdByIdAsync(Guid id);
        Task<BirdResponseDto> AddBirdAsync(BirdRequestDto bird);
        Task<Bird> UpdateBirdAsync(Bird bird);
        Task DeleteMultiple(List<Bird> birds);
        Task DeleteBirdAsync(Bird bird);
        Task<IEnumerable<Bird>> GetBirdsByUserIdAsync(Guid id);
        Task<IEnumerable<Bird>> GetBirdsByCageIdAsync(Guid id);


    }
}
