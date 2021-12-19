using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Common.Dtos.Species
{
    public class SpeciesRequestDto : BaseEntityDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string ScientificName { get; set; }
       
    }
}
