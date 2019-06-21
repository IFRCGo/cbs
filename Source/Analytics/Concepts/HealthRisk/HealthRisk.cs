using Dolittle.Concepts;

namespace Concepts
{
    public class HealthRisk : Value<HealthRisk>
    {
        public HealthRiskGuid Id { get; set; }
        public HealthRiskName name { get; set; }
    }
}
