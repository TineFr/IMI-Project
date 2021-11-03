using Imi.Project.Api.Core.Dtos.Birds;
using Imi.Project.Api.Core.Dtos.DailyTasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Cages
{
    public class CageResponseDto : BaseEntityDto
    {
        public string Name { get; set; }
        public IEnumerable<Guid> Birds { get; set; }
        public IEnumerable<DailyTaskResponseDto> DailyTasks { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }

    }
}
