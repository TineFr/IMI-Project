using Imi.Project.Api.Core.Dtos.Birds;
using Imi.Project.Api.Core.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IBirdService
    {
        Task<IEnumerable<BirdResponseDto>> ListAllBirdsAsync();
        Task<BirdResponseDto> GetBirdByIdAsync(Guid id);
        Task<BirdResponseDto> AddBirdAsync(BirdRequestDto birdRequestDto);
        Task<BirdResponseDto> UpdateBirdAsync(BirdRequestDto birdRequestDto);
        Task DeleteBirdAsync(BirdRequestDto userRequestDto);
        Task<IEnumerable<BirdResponseDto>> GetBirdsByUserIdAsync(Guid id);
        Task<IEnumerable<BirdResponseDto>> GetBirdsByCageIdAsync(Guid id);
        Task<IEnumerable<BirdResponseDto>> GetBirdsWithMedicineAsync();
    }
}
