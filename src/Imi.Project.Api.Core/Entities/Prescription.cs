using Imi.Project.Api.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Entities
{
    public class Prescription : BaseEntity, IHasUserId
    {

        public ICollection<BirdPrescription> BirdPrescriptions { get; set; }
        public Medicine Medicine { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public Guid MedicineId { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }



    }
}
