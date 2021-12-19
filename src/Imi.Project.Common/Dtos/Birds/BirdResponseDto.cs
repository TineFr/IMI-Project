
using Imi.Project.Common.Dtos;
using Imi.Project.Common.Dtos.Cages;
using Imi.Project.Common.Dtos.Species;
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
