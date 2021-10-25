using Imi.Project.Api.Core.Dtos.Cages;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface ICageService
    {
        Task<IEnumerable<Cage>> ListAllCagesAsync();
        Task<Cage> GetCageByIdAsync(Guid id);
        Task<IEnumerable<Cage>> GetCagesByUserIdAsync(Guid id);
        Task<Cage> AddCageAsync(CageRequestDto userRequestDto);
        Task<Cage> UpdateCageAsync(CageRequestDto userRequestDto);
        Task DeleteCageAsync(CageRequestDto userRequestDto);
    }
}
