using Imi.Project.WPF.Models.Cages;
using Imi.Project.WPF.Models.Species;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Imi.Project.WPF.Models.Birds
{
    public class BirdApiResponse
    {

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("hatchDate")]
        public DateTime HatchDate { get; set; } 
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("food")]
        public string Food { get; set; }

        [JsonPropertyName("species")]
        public SpeciesApiResponse Species { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("cage")]
        public CageApiResponse Cage { get; set; }
        public string Date => HatchDate.ToString("dd/MM/yyyy");

    }
}
