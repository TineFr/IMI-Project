namespace Imi.Project.Common
{
    public class MedicineResponseDto : BaseDto
    {
        public UserResponseDto User { get; set; }
        public string Usage { get; set; }
    }
}