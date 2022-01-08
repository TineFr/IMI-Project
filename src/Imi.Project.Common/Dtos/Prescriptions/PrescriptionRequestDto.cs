using System;
using System.Collections.Generic;

namespace Imi.Project.Common.Dtos
{
    public class PrescriptionRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Medicine { get; set; }
        public List<Guid> Birds { get; set; }
        public Guid UserId { get; set; }
    }
}
