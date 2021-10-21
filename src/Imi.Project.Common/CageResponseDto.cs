using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Common
{
    public class CageResponseDto
    {
        public List<BirdResponseDto> Birds { get; set; }
        public List<DailyTaskResponseDto> DailyTasks { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public UserResponseDto User { get; set; }

    }
}
