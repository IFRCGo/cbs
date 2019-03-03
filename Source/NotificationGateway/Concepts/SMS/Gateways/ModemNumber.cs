using Dolittle.Concepts;

namespace Concepts.SMS.Gateways
{
    public class ModemNumber : ConceptAs<int>
    {
        public static implicit operator ModemNumber(int value)
        {
            return new ModemNumber {Value = value};
        }
    }
}
