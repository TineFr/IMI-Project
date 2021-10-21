using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Cage : BaseEntity
    {
        public List<Bird> Birds { get; set; }
        public List<DailyTask> DailyTasks { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }

    }
}
