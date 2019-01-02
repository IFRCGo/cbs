using Dolittle.Concepts;

namespace Concepts.HealthRisk
{
    public class HealthRiskName : ConceptAs<string>
    {
        public static implicit operator HealthRiskName(string name) => new HealthRiskName { Value = name };
    }
}