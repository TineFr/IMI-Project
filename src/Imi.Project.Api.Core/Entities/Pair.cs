using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Pair : BaseEntity
    {
        public List<Bird> Birds { get; set; }
        public Nest Nest { get; set; }
    }
}
