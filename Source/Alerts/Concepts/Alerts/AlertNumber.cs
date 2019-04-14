using Dolittle.Concepts;

namespace Concepts.Alerts
{
    public class AlertNumber : ConceptAs<uint>
    {
        public static implicit operator AlertNumber(uint value)
        {
            return new AlertNumber { Value = value };
        }
    }
}