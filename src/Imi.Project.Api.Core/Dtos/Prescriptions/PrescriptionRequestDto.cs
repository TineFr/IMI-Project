using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Prescriptions
{
    public class PrescriptionRequestDto : BaseEntityDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Medicine { get; set; }
        public List<Guid> Birds { get; set; }
        public Guid UserId { get; set; }
    }
}
