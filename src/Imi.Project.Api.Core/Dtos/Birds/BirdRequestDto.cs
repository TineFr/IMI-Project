using Imi.Project.Api.Core.Dtos.Species;
using Imi.Project.Api.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Birds
{
    public class BirdRequestDto : BaseEntityDto
    {
       
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Date)]
        public DateTime HatchDate { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Food { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public Guid UserId { get; set; }
        public Guid CageId { get; set; }
        public Guid SpeciesId { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Image { get; set; }

    }
}
