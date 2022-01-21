using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Models
{
    public class PrescriptionModel : BaseModel
    {
        public Guid MedicationId { get; set; }
        public MedicineModel Medicine { get; set; }
        public List<Guid> BirdIds { get; set; }
        public List<BirdModel> Birds { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
