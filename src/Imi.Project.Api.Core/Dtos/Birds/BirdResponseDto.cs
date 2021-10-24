using Imi.Project.Api.Core.Dtos.Medicines;
using Imi.Project.Api.Core.Dtos.Species;
using Imi.Project.Api.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Birds
{
    public class BirdResponseDto : BaseEntityDto
    {
        public DateTime HatchDate { get; set; }
        public Gender Gender { get; set; }
        public string Food { get; set; }
        public string Cage { get; set; }
        public SpeciesResponseDto Species { get; set; }
        public ICollection<MedicineResponseDto> Medicines { get; set; }
        public string Image { get; set; }
    }
}
