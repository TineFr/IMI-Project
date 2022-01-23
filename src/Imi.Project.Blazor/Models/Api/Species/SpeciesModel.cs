using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Models.Api
{
    public class SpeciesModel : BaseModel
    {
        public string Name { get; set; }
        public string ScientificName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
