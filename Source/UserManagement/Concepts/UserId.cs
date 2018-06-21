using System;
using Dolittle.Concepts;

namespace Concepts
{
    public class UserId : ConceptAs<Guid>
    {
        public static implicit operator UserId(Guid value)
        {
            return new UserId { Value = value };
        }
    }
}