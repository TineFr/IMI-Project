using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.DailyTasks
{
    public class DailyTaskResponseDto : BaseEntityDto
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
