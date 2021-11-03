using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Cage : BaseEntity
    {
        public List<Bird> Birds { get; set; }
        public IEnumerable<DailyTask> DailyTasks { get; set; }
        public string Image { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public User User { get; set; }
        public Guid? UserId { get; set; }

    }
}
