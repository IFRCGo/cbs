using Dolittle.Concepts;

namespace Concepts.HealthRisk
{
    public class HealthRisk : Value<HealthRisk>
    {
        public HealthRiskGuid Id { get; set; }
        public HealthRiskName HealthRiskName { get; set; }

        public HealthRisk(HealthRiskName HealthRiskName)
        {
            this.HealthRiskName = HealthRiskName;
            this.Id = new HealthRiskGuid();
        }
    }
}