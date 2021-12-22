using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Common.Dtos
{
    public class SpeciesRequestDto : BaseEntityDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string ScientificName { get; set; }

    }
}
