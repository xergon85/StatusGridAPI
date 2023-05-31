using System.Text.Json.Serialization;

namespace StatusGridAPI.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusCode
    {
        Untouched = 0,
        Ok = 1,
        Error = 2,
    }
}