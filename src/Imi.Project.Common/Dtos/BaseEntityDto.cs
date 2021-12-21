using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Common.Dtos
{
    public abstract class BaseEntityDto
    {
        [Required(ErrorMessage = "{0} is required")]

        public Guid Id { get; set; }

    }
}
