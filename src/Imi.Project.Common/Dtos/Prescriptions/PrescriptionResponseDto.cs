using System;
using System.Collections.Generic;

namespace Imi.Project.Common.Dtos
{
    public class PrescriptionResponseDto 
    {
        public Guid Id { get; set; }
        public MedicineResponseDto Medicine { get; set; }
        public IEnumerable<BirdResponseDto> Birds { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
