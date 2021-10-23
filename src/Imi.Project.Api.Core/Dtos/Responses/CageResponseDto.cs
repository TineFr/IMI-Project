using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Responses
{
    public class CageResponseDto : BaseEntityDto
    {
        public IEnumerable<BirdResponseDto> Birds { get; set; }
        public IEnumerable<DailyTaskResponseDto> DailyTasks { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }

    }
}
