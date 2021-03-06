using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
         IBaseRepository<T> _baseRepository { get; }
    }
}
