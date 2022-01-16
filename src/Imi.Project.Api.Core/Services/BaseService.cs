using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        public IBaseRepository<T> _baseRepository { get; }

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

    }
}
