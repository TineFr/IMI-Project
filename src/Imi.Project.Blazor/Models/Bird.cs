using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Models
{
    public class Bird : BaseEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(30, ErrorMessage = "{0} cannt be longer than 30 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public DateTime HatchDate { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "{0} is required")]

        public Species SpeciesModel { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Species { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Food { get; set; }
        [Required(ErrorMessage = "{0} is required")]

        public Cage CageModel { get; set; }
        public string Cage { get; set; }
        public string Image { get; set; }
        public string GenderImage => $"{Gender}.png";
        public string Date => HatchDate.ToString("dd/MM/yyyy");
    }

}
