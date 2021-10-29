using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Services.Mocking.Interfaces
{
    public interface IBirdService
    {
        Task<ObservableCollection<Bird>> GetAllBirds();
        Task<Bird> GetBirdById(Guid id);
        Task<Bird> AddBird(Bird bird);
        Task<Bird> UpdateBird(Bird bird);
        Task<Bird> DeleteBird(Guid id);
        IEnumerable<Bird> GetBirdsByMedication(Medication medicine);


    }
}
