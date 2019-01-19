using Dolittle.Concepts;
using System;

namespace Concepts.SMS.Gateways
{
    public class SmsGatewayId : ConceptAs<Guid>
    {
        public static implicit operator SmsGatewayId(Guid value)
        {
            return new SmsGatewayId {Value = value};
        }
    }
}
