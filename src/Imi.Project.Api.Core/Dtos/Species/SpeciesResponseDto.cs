using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Species
{
    public class SpeciesResponseDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string ScientificName { get; set; }
    }
}
