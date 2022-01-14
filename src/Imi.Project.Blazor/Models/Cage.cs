using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Models
{
    public class Cage : BaseEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(30, ErrorMessage = "{0} cannt be longer than 30 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(30, ErrorMessage = "{0} cannot be longer than 30 characters")]
        public string Location { get; set; }

        public string Image { get; set; }

    }
}
