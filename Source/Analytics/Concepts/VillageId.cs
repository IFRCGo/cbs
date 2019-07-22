using Dolittle.Concepts;
using System;

namespace Concepts
{
    public class VillageId : ConceptAs<Guid>
    {
        public static implicit operator VillageId(Guid value)
        {
            return new VillageId {Value = value};
        }
    }
}
