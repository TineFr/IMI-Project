using Imi.Project.Api.Core.Dtos.Species;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface ISpeciesService
    {
        Task<IEnumerable<Species>> ListAllSpeciessAsync();
        Task<Species> GetSpeciesByIdAsync(Guid id);
        Task<Species> AddSpeciesAsync(SpeciesRequestDto speciesRequestDto);
        Task<Species> UpdateSpeciesAsync(SpeciesRequestDto speciesRequestDto);
        Task DeleteSpeciesAsync(SpeciesRequestDto speciesRequestDto);
    }
}
