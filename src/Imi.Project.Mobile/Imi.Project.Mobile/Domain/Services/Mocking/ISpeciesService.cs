using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Mocking
{
    public interface ISpeciesService
    {
        Task<ObservableCollection<Species>> GetAllSpecies();
        Task<Species> GetSpeciesById(Guid id);
        Task<Species> AddSpecies(Species species);
        Task<Species> UpdateSpecies(Species species);
        Task<Species> DeleteSpecies(Guid id);
    }
}
