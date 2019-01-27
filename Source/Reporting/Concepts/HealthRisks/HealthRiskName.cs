using Dolittle.Concepts;

namespace Concepts.HealthRisks
{
    public class HealthRiskName : ConceptAs<string>
    {
        public static HealthRiskName NotSet = string.Empty;
        public static implicit operator HealthRiskName(string name) => new HealthRiskName { Value = name };
    }
}