using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Common.Dtos.Medicines

{
    public class MedicineResponseDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string Usage { get; set; }
    }
}
