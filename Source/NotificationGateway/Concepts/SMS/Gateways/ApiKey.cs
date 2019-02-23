using Dolittle.Concepts;

namespace Concepts.SMS.Gateways
{
    public class ApiKey : ConceptAs<string>
    {
        public static implicit operator ApiKey(string value)
        {
            return new ApiKey {Value = value};
        }
    }
}
