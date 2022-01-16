using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Common.Dtos
{ 
    public class MedicineRequestDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Usage { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public Guid UserId { get; set; }
    }
}
