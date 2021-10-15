using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class DailyTask : BaseEntity
    {
        public Guid? CageId { get; set; }
        public Cage Cage { get; set; }
        public bool IsDone { get; set; }
    }
}
