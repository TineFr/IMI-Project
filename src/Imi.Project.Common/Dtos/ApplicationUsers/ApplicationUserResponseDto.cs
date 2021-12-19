using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Common.Dtos.ApplicationUsers
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
