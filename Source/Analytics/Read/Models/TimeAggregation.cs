using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Read.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TimeAggregation
    {
        Day,
        Week
    }
}