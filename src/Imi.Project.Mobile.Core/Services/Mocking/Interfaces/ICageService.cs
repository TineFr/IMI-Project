
using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;


namespace Imi.Project.Mobile.Domain.Services.Interfaces
{
    public interface ICageService
    {
        Task<ObservableCollection<Cage>> GetAllCages();
        Task<Cage> GetCageById(Guid id);
        Task<Cage> AddCage(Cage Cage);
        Task<Cage> UpdateCage(Cage Cage);
        Task<Cage> DeleteCage(Guid id);
    }
}
