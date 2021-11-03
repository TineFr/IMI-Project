using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Users
{
    public class UserResponseDto : BaseEntityDto
    {
        public string Name { get; set; }
        public IEnumerable<Guid> Birds { get; set; }
        public IEnumerable<Guid> Cages { get; set; }
        public IEnumerable<Guid> Medicines { get; set; }
    }
}
