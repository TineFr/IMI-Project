﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Common
{
    public class CageResponseDto : BaseEntityDto
    {
        public ICollection<BirdResponseDto> Birds { get; set; }
        public ICollection<DailyTaskResponseDto> DailyTasks { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }

    }
}
