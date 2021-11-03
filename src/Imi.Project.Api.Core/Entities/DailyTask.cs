using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class DailyTask : BaseEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; }
        public Guid CageId { get; set; }
        public Cage Cage { get; set; }
        public bool IsDone { get; set; }
    }
}
