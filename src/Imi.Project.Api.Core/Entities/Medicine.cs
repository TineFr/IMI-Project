using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Medicine : BaseEntity
    {
        public ICollection<BirdMedicine> BirdMedicine { get; set; }
        public string Usage { get; set; }
    }
}
