using Dolittle.Concepts;

namespace Concepts.SMS.Gateways
{
    public class Name : ConceptAs<string>
    {
        public static implicit operator Name(string value)
        {
            return new Name {Value = value};
        }
    }
}
