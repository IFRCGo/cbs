using Dolittle.Concepts;

namespace Concepts.HealthRisk
{
    public class HealthRiskNumber : ConceptAs<int>
    {
        public static implicit operator HealthRiskNumber(int number) => new HealthRiskNumber { Value = number };
        public static implicit operator HealthRiskNumber(string number) => new HealthRiskNumber { Value = int.Parse(number) };
    }
}
