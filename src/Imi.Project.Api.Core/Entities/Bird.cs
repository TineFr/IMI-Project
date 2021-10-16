using Imi.Project.Api.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Bird : BaseEntity
    {
        public DateTime HatchDate { get; set; }
        public Gender Gender { get; set; }
        public Pair Pair { get; set; }
        public Guid? PairId { get; set; }
        public Cage Cage { get; set; }
        public Guid? CageId { get; set; }
        public Species Species { get; set; }
        public Guid? SpeciesId { get; set; }
        public Food Food { get; set; }
        public Guid? FoodId { get; set; }
        public User User { get; set; }
        public Guid? UserId { get; set; }
        public string Image { get; set; }
    }
}
