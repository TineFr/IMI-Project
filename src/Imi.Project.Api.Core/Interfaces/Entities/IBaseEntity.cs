using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Interfaces.Entities
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
    }
}
