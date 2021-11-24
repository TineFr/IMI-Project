using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Users
{
    public class UserRequestDto: BaseEntityDto
    {

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
    }
}
