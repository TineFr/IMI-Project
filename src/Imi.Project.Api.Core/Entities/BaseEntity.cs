using Imi.Project.Api.Core.Interfaces.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        public Guid Id { get; set; }

    }
}
