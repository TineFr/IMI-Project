using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        public ICollection<Cage> Cages { get; set; } 
        public ICollection<Bird> Birds { get; set; }
        public ICollection<Medicine> Medicines { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
