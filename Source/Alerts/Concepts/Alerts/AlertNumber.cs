using Dolittle.Concepts;

namespace Concepts.Alerts
{
    public class AlertNumber : ConceptAs<int>
    {
        public static implicit operator AlertNumber(int value)
        {
            return new AlertNumber { Value = value };
        }
    }
}