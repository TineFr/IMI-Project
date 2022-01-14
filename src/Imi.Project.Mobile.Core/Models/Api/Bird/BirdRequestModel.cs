using Imi.Project.Common.Enums;
using System;

namespace Imi.Project.Mobile.Core.Models
{
    public class BirdRequestModel
    {
        public string Name { get; set; }
        public Guid? CageId { get; set; }
        public Guid? SpeciesId { get; set; }
        public DateTime HatchDate { get; set; }
        public Gender? Gender { get; set; }
        public string Food { get; set; }
        public ImageInfo ImageInfo { get; set; }
    }
}
