using System.Text.Json.Serialization;

namespace Healix_WebApp.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        Active,
        Disabled
    }
}
