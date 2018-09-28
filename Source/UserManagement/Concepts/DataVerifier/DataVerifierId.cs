using System;
using Dolittle.Concepts;

namespace Concepts.DataVerifier
{
    public class DataVerifierId : ConceptAs<Guid>
    {
        public static implicit operator DataVerifierId(Guid value)
        {
            return new DataVerifierId { Value = value };
        }
    }
}
