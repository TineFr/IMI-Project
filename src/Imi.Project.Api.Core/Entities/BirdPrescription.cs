using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class BirdPrescription
    {
        [Required(ErrorMessage = "{0} is required")]
        public Guid BirdId { get; set; }
        public Bird Bird { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public Guid PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
    }
}
