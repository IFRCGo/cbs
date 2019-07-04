using Dolittle.Concepts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Concepts.Alerts
{
    public class AlertId : ConceptAs<Guid>
    {
        public static readonly AlertId Empty = Guid.Empty;

        public static implicit operator AlertId(Guid value)
        {
            return new AlertId { Value = value };
        }
        public static implicit operator AlertId(string value)
        {
            return new AlertId { Value = Guid.Parse(value) };
        }
    }
}
