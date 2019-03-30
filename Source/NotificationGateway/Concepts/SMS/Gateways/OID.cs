using Dolittle.Concepts;

namespace Concepts.SMS.Gateways
{
    public class OID : ConceptAs<string>
    {
        public static implicit operator OID(string value)
        {
            return new OID {Value = value};
        }
    }
}
