using System;

namespace Imi.Project.Common
{
    public abstract class BaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
