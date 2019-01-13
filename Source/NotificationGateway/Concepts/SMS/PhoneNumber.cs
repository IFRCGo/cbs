using Dolittle.Concepts;

namespace Concepts.SMS
{
    public class PhoneNumber : ConceptAs<string>
    {
        public static implicit operator PhoneNumber(string value)
        {
            return new PhoneNumber {Value = value};
        }
    }
}
