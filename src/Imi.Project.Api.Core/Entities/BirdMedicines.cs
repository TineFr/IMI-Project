using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class BirdMedicines
    {
        public Bird Bird { get; set; }
        public Guid BirdId { get; set; }
        public Medicine Medicine { get; set; }
        public Guid MedicineId { get; set; }


    }
}
