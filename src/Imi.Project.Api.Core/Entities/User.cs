using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }

        public List<Cage> Cages { get; set; }
    }
}
