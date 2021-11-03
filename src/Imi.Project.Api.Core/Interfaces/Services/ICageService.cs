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
        Task<Cage> AddCageAsync(Cage cage);

        Task DeleteMultiple(List<Cage> cages);
        Task<Cage> UpdateCageAsync(Cage cage);
        Task DeleteCageAsync(Cage cage);
    }
}
