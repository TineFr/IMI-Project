using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.WPF.Core.Models
{
    public class SpeciesModel : BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ScientificName { get; set; }
    }
}
