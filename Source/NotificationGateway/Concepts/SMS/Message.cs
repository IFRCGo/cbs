using Dolittle.Concepts;

namespace Concepts.SMS
{
    public class Message : ConceptAs<string>
    {
        public static implicit operator Message(string value)
        {
            return new Message {Value = value};
        }
    }
}
