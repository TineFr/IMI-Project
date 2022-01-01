using Imi.Project.Api.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Entities
{
    public class Medicine : BaseEntity, IHasUserId
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public ApplicationUser User { get; set; }
        public Guid? UserId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Usage { get; set; }
    }
}
