﻿using Imi.Project.Api.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Bird : BaseEntity
    {


        public DateTime HatchDate { get; set; }
        public Gender Gender { get; set; }
        public string Food { get; set; }
        public Cage Cage { get; set; }
        public Guid? CageId { get; set; }
        public Species Species { get; set; }
        public Guid? SpeciesId { get; set; }
        public User User { get; set; }
        public Guid? UserId { get; set; }
        public ICollection<BirdMedicine> BirdMedicines { get; set; }
        public string Image { get; set; }


    }
}
