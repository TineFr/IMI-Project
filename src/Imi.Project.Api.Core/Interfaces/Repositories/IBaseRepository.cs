using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
using Imi.Project.Api.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class, IBaseEntity
    {
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> ListAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> UpdateAsync(T entity);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteMultipleAsync(List<T> entities);
        Task<bool> EntityExists<E>(Guid? id) where E : class, IBaseEntity;
        Task<bool> EntityExistsForUser<E>(Guid userId, Guid id) where E : class, IHasUserId;
    }
}
