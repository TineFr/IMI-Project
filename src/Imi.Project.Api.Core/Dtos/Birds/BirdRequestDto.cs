using Imi.Project.Api.Core.Dtos.Species;
using Imi.Project.Api.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Birds
{
    public class BirdRequestDto : BaseEntityDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime HatchDate { get; set; }
        public Gender Gender { get; set; }
        public string Food { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public Guid UserId { get; set; }
        public Guid CageId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public Guid SpeciesId { get; set; }
        public IFormFile Image { get; set; }

    }
}
