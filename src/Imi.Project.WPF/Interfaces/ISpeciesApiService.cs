using Imi.Project.WPF.Models.Species;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.WPF.Interfaces
{
    public interface ISpeciesApiService
    {
        Task<IEnumerable<SpeciesApiResponse>> GetSpecies();
    }
}
