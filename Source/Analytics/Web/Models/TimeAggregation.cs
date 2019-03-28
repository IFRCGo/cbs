using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Web.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TimeAggregation
    {
        Day,
        Week
    }
}