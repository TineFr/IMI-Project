using System;

namespace Imi.Project.Common.Dtos
{
    public class DailyTaskResponseDto 
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
