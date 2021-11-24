using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Cages

{
    public class CageRequestDto : BaseEntityDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Location { get; set; }

        public Guid UserId { get; set; }
        public IFormFile Image { get; set; }
    }
}
