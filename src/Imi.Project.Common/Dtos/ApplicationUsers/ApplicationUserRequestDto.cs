using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Common.Dtos.ApplicationUsers
{
    public class ApplicationUserRequestDto: BaseEntityDto
    {

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
    }
}
