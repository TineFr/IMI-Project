using Imi.Project.Common.Enums;
using System;
using System.IO;

namespace Imi.Project.WPF.Models.Birds
{
    public class Bird
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime HatchDate { get; set; }
        public Gender Gender { get; set; }
        public string Food { get; set; }
        public Guid UserId { get; set; }
        public Guid CageId { get; set; }
        public Guid SpeciesId { get; set; }
        public Stream Image { get; set; }
        public string FileName { get; set; }
    }
}
