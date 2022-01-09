using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Models
{
    public class Species : BaseEntity
    {
        public string Name { get; set; }
        public string ScientifcName { get; set; }
    }
}
