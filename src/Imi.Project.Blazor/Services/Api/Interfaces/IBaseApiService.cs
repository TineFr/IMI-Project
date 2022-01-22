using Imi.Project.Blazor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Api.Interfaces
{
    public interface IBaseApiService<T, resp> where T : class where resp : new()
    {
        Task<IEnumerable<resp>> GetAllAsync(string requestUri);
        Task<resp> GetByIdAsync(string requestUri);
        Task<resp> AddAsync(string requestUri, T model);
        Task<resp> UpdateAsync(string requestUri, T model);
        Task<resp> DeleteAsync(string requestUri);
    }
}
