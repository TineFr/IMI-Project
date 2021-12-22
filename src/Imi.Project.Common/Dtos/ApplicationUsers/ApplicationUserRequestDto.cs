using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Common.Dtos
{
    public class ApplicationUserRequestDto : BaseEntityDto
    {

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
    }
}
