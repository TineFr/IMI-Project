using Imi.Project.Api.Core.Enums;
using System;
using System.Collections.Generic;

namespace Imi.Project.Common
{
    public class BirdResponseDto : BaseDto
    {
        public DateTime HatchDate { get; set; }
        public Gender Gender { get; set; }
        public string Food { get; set; }
        public CageResponseDto Cage { get; set; }
        public SpeciesResponseDto Species { get; set; }
        public UserResponseDto User { get; set; }
        public IEnumerable<MedicineResponseDto> Medicines { get; set; }
        public string Image { get; set; }
    }
}