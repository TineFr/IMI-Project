using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Prescription : BaseEntity
    {

        public ICollection<BirdPrescription> BirdPrescriptions { get; set; }
        public Medicine Medicine { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public Guid MedicineId { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }



    }
}
