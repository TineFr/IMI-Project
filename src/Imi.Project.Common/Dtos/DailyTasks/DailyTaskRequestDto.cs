using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Common.Dtos
{
    public class DailyTaskRequestDto : BaseEntityDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public Guid CageId { get; set; }
        public bool IsDone { get; set; }

    }
}
