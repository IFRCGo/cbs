using Dolittle.Concepts;
using System;

namespace Concepts
{
    public class MessageId : ConceptAs<Guid>
    {
        public static implicit operator MessageId(Guid value)
        {
            return new MessageId {Value = value};
        }
    }
}
