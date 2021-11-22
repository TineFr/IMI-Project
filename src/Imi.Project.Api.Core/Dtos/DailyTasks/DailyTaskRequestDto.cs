using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.DailyTasks
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
