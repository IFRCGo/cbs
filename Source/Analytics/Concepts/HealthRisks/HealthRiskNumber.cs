using Dolittle.Concepts;

namespace Concepts.HealthRisks
{
    public class HealthRiskNumber : ConceptAs<int>
    {
        public static implicit operator HealthRiskNumber(int number) => new HealthRiskNumber { Value = number };
    }
}
