using System;
using Dolittle.Concepts;

namespace Concepts.HealthRisks
{
    public class KeyMessageId : ConceptAs<Guid>
    {
        public static implicit operator KeyMessageId(Guid keyMessageId) => new KeyMessageId { Value = keyMessageId };
    }
}