using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Food : BaseEntity
    {
        public List<Bird> Birds { get; set; }
    }
}
