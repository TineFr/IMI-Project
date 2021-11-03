using Imi.Project.Api.Core.Dtos.Cages;
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

        public string Name { get; set; }
        public DateTime? HatchDate { get; set; }
        public string Gender { get; set; }
        public string Food { get; set; }
        public CageResponseDto Cage { get; set; }
        public SpeciesResponseDto Species { get; set; }
        public string Image { get; set; }
    }
}
