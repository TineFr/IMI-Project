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
        public List<Cage> Cages { get; set; }
        public List<Bird> Birds { get; set; }

    }
}
