using Imi.Project.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Blazor.Models.Api
{
    public class BirdModel : BaseModel
    {
        [Required(ErrorMessage = " {0} is required)")]
        [MaxLength(20, ErrorMessage = " {0} cannot be longer than 20 characters")]
        public string Name { get; set; }
        public DateTime HatchDate { get; set; }

        [Required(ErrorMessage = " {0} is required)")]
        public string Gender { get; set; }
        public string Food { get; set; }
        public SpeciesModel Species { get; set; }
        public CageModel Cage { get; set; }
        public string Image { get; set; }
        public string Date => HatchDate.ToString("dd/MM/yyyy");
        public string GenderImage => Gender.ToString().ToLower() + ".png";
    }
}
