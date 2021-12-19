using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Common.Dtos.Medicines
{
    public class MedicineRequestDto : BaseEntityDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Usage { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public Guid UserId { get; set; }


    }
}
