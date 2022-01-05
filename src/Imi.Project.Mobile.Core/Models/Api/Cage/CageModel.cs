using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Models
{
    public class CageModel : BaseModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public IEnumerable<DailyTaskModel> DailyTasks { get; set; }
    }
}
