using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public abstract class BaseEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
    }
}
