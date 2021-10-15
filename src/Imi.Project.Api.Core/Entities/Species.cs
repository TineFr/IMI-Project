using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Species : BaseEntity
    {
        public string ScientificName { get; set; }
        public List<Bird> Birds { get; set; }
    }
}
