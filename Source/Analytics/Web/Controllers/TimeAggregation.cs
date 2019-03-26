using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Web.Controllers
{
    // Todo: Move to proper place
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TimeAggregation
    {
        Day,
        Week
    }
}