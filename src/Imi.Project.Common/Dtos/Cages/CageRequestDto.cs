using Imi.Project.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Common.Dtos

{
    public class CageRequestDto : IHasImage
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Location { get; set; }

        public Guid UserId { get; set; }
        public IFormFile Image { get; set; }
    }
}
