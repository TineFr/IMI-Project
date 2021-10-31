using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Models
{
    public class Prescription : BaseEntity
    {
        public Guid Medicine { get; set; }
        public IEnumerable<Guid> Birds { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
