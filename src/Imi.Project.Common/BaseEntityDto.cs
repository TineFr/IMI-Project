using System;

namespace Imi.Project.Common
{
    public abstract class BaseEntityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
