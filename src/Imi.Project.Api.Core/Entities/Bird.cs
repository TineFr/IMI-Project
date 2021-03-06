using Imi.Project.Api.Core.Interfaces.Entities;
using Imi.Project.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Entities
{
    public class Bird : BaseEntity, IHasUserId
    {

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        public DateTime HatchDate { get; set; }
        public Gender Gender { get; set; }
        public string Food { get; set; }
        public Cage Cage { get; set; }
        public Guid? CageId { get; set; }
        public Species Species { get; set; }
        public Guid? SpeciesId { get; set; }
        public ApplicationUser User { get; set; }
        public Guid? UserId { get; set; }
        public ICollection<BirdPrescription> BirdPrescriptions { get; set; }
        public string Image { get; set; }


    }
}
