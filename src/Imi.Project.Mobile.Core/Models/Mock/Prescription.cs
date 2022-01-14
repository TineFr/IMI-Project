using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Models
{
    public class Prescription : BaseEntity
    {
        public Guid MedicationId { get; set; }
        public Medication Medication { get; set; }
        public IEnumerable<Guid> BirdIds { get; set; }
        public IEnumerable<Bird> Birds { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
