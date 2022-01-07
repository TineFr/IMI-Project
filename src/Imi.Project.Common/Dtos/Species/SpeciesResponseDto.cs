namespace Imi.Project.Common.Dtos
{
    public class SpeciesResponseDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string ScientificName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
