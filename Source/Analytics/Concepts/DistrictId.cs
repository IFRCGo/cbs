using Dolittle.Concepts;
using System;

namespace Concepts
{
    public class DistrictId : ConceptAs<Guid>
    {
        public static implicit operator DistrictId(Guid value)
        {
            return new DistrictId {Value = value};
        }
    }
}
