﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Imi.Project.WPF.Models.Species
{
    public class SpeciesApiResponse
    {

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("scientificname")]
        public string ScientificName { get; set; }
    }
}
