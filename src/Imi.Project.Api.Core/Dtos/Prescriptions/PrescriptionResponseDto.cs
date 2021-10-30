using Imi.Project.Api.Core.Dtos.Birds;
using Imi.Project.Api.Core.Dtos.Medicines;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Prescriptions
{
    public class PrescriptionResponseDto : BaseEntityDto
    {
        public MedicineResponseDto Medicine { get; set; }
        public IEnumerable<BirdResponseDto> Birds { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
