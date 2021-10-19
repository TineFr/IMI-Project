using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Nest : BaseEntity 
    {
        public Guid? PairId { get; set; }
        public Pair Pair { get; set; }
        public Guid? CageId { get; set; }
        public Cage Cage { get; set; }
        public string Image { get; set; }
        public bool IsOccupied { get; set; } = false;
        public User User { get; set; }
        public Guid? UserId { get; set; }
    }
}
