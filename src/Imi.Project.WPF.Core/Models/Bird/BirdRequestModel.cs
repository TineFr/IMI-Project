using Imi.Project.Common.Enums;
using Imi.Project.WPF.Core.Entities;
using System;

namespace Imi.Project.WPF.Core.Models
{
    public class BirdRequestModel
    {
        public string Name { get; set; }
        public Guid? CageId { get; set; }
        public Guid? SpeciesId { get; set; }
        public DateTime HatchDate { get; set; }
        public Gender Gender { get; set; }
        public string Food { get; set; }
        public ImageInfo ImageInfo { get; set; }
    }
}
