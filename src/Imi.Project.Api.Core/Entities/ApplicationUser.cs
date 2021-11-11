using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Cage> Cages { get; set; } 
        public ICollection<Bird> Birds { get; set; }
        public ICollection<Medicine> Medicines { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
