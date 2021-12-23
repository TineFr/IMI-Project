using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Interfaces.Entities
{
    public interface IHasUserId : IBaseEntity
    {
        Guid UserId { get; set; }   
    }
}
