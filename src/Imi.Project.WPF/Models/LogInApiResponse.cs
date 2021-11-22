using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Imi.Project.WPF.Models
{
    public class LogInApiResponse
    {
        [JsonPropertyName("jwt")]
        public string JWT { get; set; }
    }
}
