using Imi.Project.Common.Enums;
using Imi.Project.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Common.Dtos
{
    public class BirdRequestDto : BaseEntityDto, IHasImage
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
