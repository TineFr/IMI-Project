using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Nest : BaseEntity 
    {
        public Guid PairId { get; set; }
        public Pair Pair { get; set; }
        public string Image { get; set; }
        public bool IsOccupied { get; set; } = false;
    }
}
