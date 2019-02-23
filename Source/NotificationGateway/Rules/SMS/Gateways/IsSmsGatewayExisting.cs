using System;
using Dolittle.ReadModels;
using Dolittle.Rules;
using Domain.SMS.Gateways;
using Read.SMS.Gateways;

namespace Rules.SMS.Gateways
{
    public class SmsGatewayDoesNotExist
        : IRuleImplementationFor<Domain.SMS.Gateways.SmsGatewayDoesNotExist>
    {
        private readonly IReadModelRepositoryFor<SmsGateway> _smsGateways;

        public SmsGatewayDoesNotExist(IReadModelRepositoryFor<SmsGateway> smsGateways)
        {
            _smsGateways = smsGateways;
        }

        public Domain.SMS.Gateways.SmsGatewayDoesNotExist Rule => (Guid id) =>
        {
            return _smsGateways.GetById(id) == null;
        };
    }
}