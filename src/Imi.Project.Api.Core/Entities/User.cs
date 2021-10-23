using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class User : BaseEntity
    {
        public ICollection<Cage> Cages { get; set; } 
        public ICollection<Bird> Birds { get; set; }
        public ICollection<Medicine> Medicines { get; set; } 
    }
}
