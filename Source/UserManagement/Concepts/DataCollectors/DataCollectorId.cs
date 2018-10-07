using System;
using Dolittle.Concepts;

namespace Concepts.DataCollectors
{
    public class DataCollectorId : ConceptAs<Guid>
    {
        public static implicit operator DataCollectorId(Guid value)
        {
            return new DataCollectorId {Value = value};
        }
    }
}