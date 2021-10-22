using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Common
{
    public class UserResponseDto : BaseEntityDto
    {
        public IEnumerable<BirdResponseDto> Birds { get; set; }
        public IEnumerable<CageResponseDto> Cages { get; set; }
        public IEnumerable<MedicineResponseDto> Medicines { get; set; }
    }

}
