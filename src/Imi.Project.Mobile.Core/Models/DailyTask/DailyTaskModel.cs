using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Models
{
    public class DailyTaskModel : BaseModel   
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public Guid CageId { get; set; }
    }
}
