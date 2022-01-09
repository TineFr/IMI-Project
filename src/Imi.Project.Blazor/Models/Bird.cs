using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Models
{
    public class Bird : BaseEntity
    {
        public string Name { get; set; }
        public DateTime HatchDate { get; set; }
        public string Gender { get; set; }
        public string Species { get; set; }
        public string ScientificName { get; set; }
        public string Food { get; set; }
        public string Cage { get; set; }
        public string Image { get; set; }
        public string GenderImage => $"{Gender}.png";
        public string Date => HatchDate.ToString("dd/MM/yyyy");
    }

}
