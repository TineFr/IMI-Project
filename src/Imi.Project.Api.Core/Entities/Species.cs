using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Entities
{
    public class Species : BaseEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string ScientificName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<Bird> Birds { get; set; }
    }
}
