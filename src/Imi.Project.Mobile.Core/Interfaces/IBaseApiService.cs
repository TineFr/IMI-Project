using Imi.Project.Mobile.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Interfaces
{
    public interface IBaseApiService<T, resp> where T : class where resp : BaseModel, new()
    {
        Task<IEnumerable<resp>> GetAllAsync(string requestUri);
        Task<resp> AddAsync(string requestUri, T model);
        Task<resp> UpdateAsync(string requestUri, T model);
        Task<resp> DeleteAsync(string requestUri);
    }
}
