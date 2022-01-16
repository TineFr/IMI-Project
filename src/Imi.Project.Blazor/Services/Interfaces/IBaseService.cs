using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Interfaces
{
    public interface IBaseService<T>
    {

        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T item);
        Task<T> GetByIdAsync(Guid id);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
    }
}
