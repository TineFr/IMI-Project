using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Models
{
    public class PrescriptionRequestModel
    {
        public Guid Medicine { get; set; }
        public List<Guid> Birds { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
