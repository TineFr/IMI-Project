namespace Imi.Project.Common
{
    public class MedicineResponseDto : BaseEntityDto
    {
        public UserResponseDto User { get; set; }
        public string Usage { get; set; }
    }
}