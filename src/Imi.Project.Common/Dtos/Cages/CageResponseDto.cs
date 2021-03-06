using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Common.Dtos
{
    public class CageResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Guid> Birds { get; set; }
        public IEnumerable<DailyTaskResponseDto> DailyTasks { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }

    }
}
