using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Models
{
    public class DailyTask : BaseEntity
    {
        public Guid CageId { get; set; }
        public bool IsDone { get; set; }
    }
}
