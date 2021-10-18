using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Mocking
{
    public interface IBirdService
    {
        Task<ObservableCollection<Bird>> GetAllBirds();
        Task<Bird> GetBirdById(Guid id);
        Task<Bird> AddBird(Bird bird);
        Task<Bird> UpdateBird(Bird bird);
        Task<Bird> DeleteBird(Guid id);


    }
}
