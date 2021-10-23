using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Responses
{
    public class UserResponseDto : BaseEntityDto
    {
        public IEnumerable<Guid> Birds { get; set; }
        public IEnumerable<Guid> Cages { get; set; }
        public IEnumerable<Guid> Medicines { get; set; }
    }
}
