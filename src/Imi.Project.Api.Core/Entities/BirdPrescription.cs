using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class BirdPrescription
    {
        public Guid BirdId { get; set; }
        public Bird Bird { get; set; }
        public Guid PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
    }
}
