using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Dtos
{
    public abstract class BaseEntityDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
