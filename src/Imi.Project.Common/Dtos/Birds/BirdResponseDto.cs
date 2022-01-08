using System;

namespace Imi.Project.Common.Dtos
{
    public class BirdResponseDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? HatchDate { get; set; }
        public string Gender { get; set; }
        public string Food { get; set; }
        public CageResponseDto Cage { get; set; }
        public SpeciesResponseDto Species { get; set; }
        public string Image { get; set; }
    }
}
