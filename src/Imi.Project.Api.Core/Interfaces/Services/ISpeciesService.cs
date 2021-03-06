using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface ISpeciesService
    {
        Task<IEnumerable<SpeciesResponseDto>> ListAllSpeciessAsync(string search);
        Task<SpeciesResponseDto> GetSpeciesByIdAsync(Guid id);
        Task<SpeciesResponseDto> AddSpeciesAsync(SpeciesRequestDto species);
        Task<SpeciesResponseDto> UpdateSpeciesAsync(Guid id, SpeciesRequestDto species);
        Task DeleteSpeciesAsync(Guid id);
    }
}
