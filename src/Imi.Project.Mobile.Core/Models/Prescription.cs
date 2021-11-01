using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Models
{
    public class Prescription : BaseEntity
    {
        public Guid MedicationId { get; set; }
        public Medication Medication { get; set; }
        public IEnumerable<Guid> BirdIds { get; set; }
        public IEnumerable<Bird> Birds { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
