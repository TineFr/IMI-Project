using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Common
{
    public class UserResponseDto : BaseDto
    {
        public List<BirdResponseDto> Birds { get; set; }
        public List<CageResponseDto> Cages { get; set; }
        public List<MedecineResponseDto> Medicines { get; set; }
    }

}
