using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Models
{
    public class Cage : BaseEntity
    {
        public string Location { get; set; }

        public string Image { get; set; }

        public List<DailyTask> DailyTasks { get; set; }

    }
}
