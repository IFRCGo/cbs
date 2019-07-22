using Dolittle.Concepts;
using System;

namespace Concepts
{
    public class RegionId : ConceptAs<Guid>
    {
        public static implicit operator RegionId(Guid value)
        {
            return new RegionId {Value = value};
        }
    }
}
