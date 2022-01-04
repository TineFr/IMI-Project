using Imi.Project.WPF.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.WPF.Core.Interfaces
{
    public interface IBaseApiService<T, resp> where T : BaseModel where resp : BaseModel, new()
    {
        Task<IEnumerable<resp>> GetAllAsync(string requestUri);
        Task<resp> AddAsync(string requestUri, T model);
        Task<resp> UpdateAsync(string requestUri, T model);
        Task<resp> DeleteAsync(string requestUri);
    }
}
