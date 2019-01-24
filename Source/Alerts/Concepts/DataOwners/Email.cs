using Dolittle.Concepts;

namespace Concepts.DataOwners
{
    public class Email : ConceptAs<string>
    {
        public static implicit operator Email(string value)
        {
            return new Email {Value = value};
        }
    }
}
