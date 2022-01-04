using System;

namespace Imi.Project.WPF.Core.Models
{
    public class BirdModel : BaseModel
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime HatchDate { get; set; }
        public string Gender { get; set; }
        public string Food { get; set; }
        public SpeciesModel Species { get; set; }
        public string Image { get; set; }
        public CageModel Cage { get; set; }
        public string Date => HatchDate.ToString("dd/MM/yyyy");
    }
}
