using Imi.Project.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Common.Dtos
{
    public class SpeciesRequestDto : IHasImage
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string ScientificName { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }
        public IFormFile Image { get; set; }

    }
}
