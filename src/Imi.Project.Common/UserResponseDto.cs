using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Common
{
    public class UserResponseDto : BaseEntityDto
    {
        public ICollection<BirdResponseDto> Birds { get; set; }
        public ICollection<CageResponseDto> Cages { get; set; }
        public ICollection<MedicineResponseDto> Medicines { get; set; }
    }

}
