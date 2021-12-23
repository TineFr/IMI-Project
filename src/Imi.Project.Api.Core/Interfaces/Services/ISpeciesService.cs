using Imi.Project.Api.Core.Entities;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface ISpeciesService
    {
        Task<IEnumerable<Species>> ListAllSpeciessAsync();
        Task<SpeciesResponseDto> GetSpeciesByIdAsync(Guid id);
        Task<SpeciesResponseDto> AddSpeciesAsync(SpeciesRequestDto species);
        Task<SpeciesResponseDto> UpdateSpeciesAsync(Guid id, SpeciesRequestDto species);
        Task DeleteSpeciesAsync(Guid id);
    }
}
