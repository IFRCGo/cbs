using Dolittle.Concepts;

namespace Concepts.SMS.Gateways
{
    public class MessageId : ConceptAs<int>
    {
        public static implicit operator MessageId(int value)
        {
            return new MessageId {Value = value};
        }
    }
}
