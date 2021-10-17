using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Mocking
{
    public interface IBirdService
    {
        Task<IEnumerable<Bird>> GetAllBirds();
        Task<Bird> GetBirdById(Guid id);
        Task<Bird> AddBird(Bird bird);
        Task<Bird> UpdateBird(Bird bird);
        Task<Bird> DeleteBird(Guid id);


    }
}
