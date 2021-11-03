using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Medicine : BaseEntity
    {
        public ICollection<Prescription> Prescriptions { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public User User { get; set; }
        public Guid? UserId { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Usage { get; set; }
    }
}
