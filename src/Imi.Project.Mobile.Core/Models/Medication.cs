using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Models
{
    public class Medication : BaseEntity
    {
        public string Usage { get; set; }

        public List<Guid> Birds { get; set; } 

        public int AmountOfBirds { get; set; }


    }
}
