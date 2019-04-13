using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Web.Controllers
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SelectedSeries
    {
        Total,
        Female,
        Male,
        AgeUnderFive,
        AgeFiveOrAbove,
        FemaleUnderFive,
        FemaleFiveOrAbove,
        MaleUnderFive,
        MaleFiveOrAbove
    }
}