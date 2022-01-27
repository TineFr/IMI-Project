using Imi.Project.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Blazor.Models.Api
{
    public class BirdRequestModel
    {
        [Required(ErrorMessage =" {0} is required)")]
        [MaxLength(20, ErrorMessage = " {0} cannot be longer than 20 characters")]
        public string Name { get; set; }
        public string CageId { get; set; }
        public string SpeciesId { get; set; }
        public DateTime HatchDate { get; set; }

        [Required(ErrorMessage = " {0} is required")]
        public string Gender { get; set; }
        public string Food { get; set; }
        public ImageInfo ImageInfo { get; set; }
    }
}
