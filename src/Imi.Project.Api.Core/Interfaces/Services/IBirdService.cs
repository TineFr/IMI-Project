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
        Task<Bird> AddBirdAsync(Bird bird);
        Task<Bird> UpdateBirdAsync(Bird bird);
        Task DeleteBirdAsync(Bird bird);
        Task<IEnumerable<Bird>> GetBirdsByUserIdAsync(Guid id);
        Task<IEnumerable<Bird>> GetBirdsByCageIdAsync(Guid id);

    }
}
