using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Medicine : BaseEntity
    {
        public ICollection<Prescription> Prescriptions { get; set; }
        public User User { get; set; }
        public Guid? UserId { get; set; }
        public string Usage { get; set; }
    }
}
