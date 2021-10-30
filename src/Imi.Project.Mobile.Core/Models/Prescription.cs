using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Models
{
    public class Prescription
    {
        public Medication medicine { get; set; }

        public IEnumerable<Bird> bird { get; set; }
    }
}
