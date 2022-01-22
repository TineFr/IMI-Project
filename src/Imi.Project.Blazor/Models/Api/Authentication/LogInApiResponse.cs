using System.Text.Json.Serialization;

namespace Imi.Project.Blazor.Models.Api
{
    public class LogInApiResponse : BaseModel
    {
        [JsonPropertyName("jwt")]
        public string JWT { get; set; }
    }
}
