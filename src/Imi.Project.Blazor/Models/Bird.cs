using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Models
{
    public class Bird : BaseEntity
    {
        public string Image { get; set; }
        public string Gender { get; set; }
        public Species Species { get; set; }
        public Cage Cage { get; set; }
    }
}
