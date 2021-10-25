using Imi.Project.Api.Core.Dtos.Birds;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IBirdService
    {
        Task<IEnumerable<Bird>> ListAllBirdsAsync();
        Task<Bird> GetBirdByIdAsync(Guid id);
        Task<Bird> AddBirdAsync(BirdRequestDto birdRequestDto);
        Task<Bird> UpdateBirdAsync(BirdRequestDto birdRequestDto);
        Task DeleteBirdAsync(BirdRequestDto userRequestDto);
        Task<IEnumerable<Bird>> GetBirdsByUserIdAsync(Guid id);
        Task<IEnumerable<Bird>> GetBirdsByCageIdAsync(Guid id);
        Task<IEnumerable<Bird>> GetBirdsWithMedicineAsync();
    }
}
