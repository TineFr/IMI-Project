using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Imi.Project.WPF.Models.Birds
{
    public class BirdApiResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("hatchdate")]
        public DateTime? HatchDate { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("food")]
        public string Food { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
