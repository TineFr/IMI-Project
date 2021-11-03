using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Medicines

{
    public class MedicineResponseDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string Usage { get; set; }
    }
}
