using System;
using System.Collections.Generic;

namespace Imi.Project.Common.Dtos
{
    public class ApplicationUserResponseDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IEnumerable<Guid> Birds { get; set; }
        public IEnumerable<Guid> Cages { get; set; }
        public IEnumerable<Guid> Medicines { get; set; }
    }
}
