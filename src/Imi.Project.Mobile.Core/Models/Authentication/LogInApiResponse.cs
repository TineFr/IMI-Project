using System.Text.Json.Serialization;

namespace Imi.Project.Mobile.Core.Models
{
    public class LogInApiResponse : BaseModel
    {
        [JsonPropertyName("jwt")]
        public string JWT { get; set; }
    }
}
