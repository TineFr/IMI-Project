using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Cage> Cages { get; set; } 
        public ICollection<Bird> Birds { get; set; }
        public ICollection<Medicine> Medicines { get; set; } 

    }
}
