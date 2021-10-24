using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.DailyTasks
{
    public class DailyTaskResponseDto : BaseEntityDto
    {
        public bool IsDone { get; set; }
    }
}
