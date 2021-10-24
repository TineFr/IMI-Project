using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Species
{
    public class SpeciesRequestDto : BaseEntityDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public string ScientificName { get; set; }
       
    }
}
