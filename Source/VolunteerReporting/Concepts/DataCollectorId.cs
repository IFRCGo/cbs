using System;
using Dolittle.Concepts;

namespace Concepts
{
    public class DataCollectorId : ConceptAs<Guid>
    {
        public static readonly DataCollectorId NotSet = Guid.Empty;

        public static implicit operator DataCollectorId(Guid id)
        {
            return new DataCollectorId { Value = id };
        }
        
    }
}