namespace Imi.Project.Common.Dtos
{
    public class DailyTaskResponseDto : BaseEntityDto
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
