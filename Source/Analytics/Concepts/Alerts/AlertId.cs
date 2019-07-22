using Dolittle.Concepts;
using System;

namespace Concepts.Alerts
{
    public class AlertId : ConceptAs<Guid>
    {
        public static implicit operator AlertId(Guid value)
        {
            return new AlertId {Value = value};
        }
    }
}
