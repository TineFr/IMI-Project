using Imi.Project.Api.Core.Dtos.Species;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface ISpeciesService
    {
        Task<IEnumerable<SpeciesResponseDto>> ListAllSpeciessAsync();
        Task<SpeciesResponseDto> GetSpeciesByIdAsync(Guid id);
        Task<SpeciesResponseDto> AddSpeciesAsync(SpeciesRequestDto userRequestDto);
        Task<SpeciesResponseDto> UpdateSpeciesAsync(SpeciesRequestDto userRequestDto);
        Task DeleteSpeciesAsync(SpeciesRequestDto userRequestDto);
    }
}
