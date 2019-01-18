using System;
using Dolittle.Concepts;

namespace Concepts.DataCollectors
{
    public class District : ConceptAs<string>
    {
        public static readonly District NotSet = String.Empty;

        public static implicit operator District(string value)
        {
            return new District { Value = value };
        }
    }
}