using System;
using Dolittle.Concepts;

namespace Concepts
{
    public class RuleId:ConceptAs<Guid>
    {
        public static readonly RuleId Empty = Guid.Empty;

        public static implicit operator RuleId(Guid value)
        {
            return new RuleId { Value = value };
        }
        public static implicit operator RuleId(string value)
        {
            return new RuleId { Value = Guid.Parse(value) };
        }
    }
}