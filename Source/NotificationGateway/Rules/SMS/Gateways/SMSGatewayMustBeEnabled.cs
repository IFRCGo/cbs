using Concepts.SMS.Gateways;
using Dolittle.ReadModels;
using Dolittle.Rules;
using Read.SMS.Gateways;
using System.Linq;

namespace Rules.SMS.Gateways
{
    public class SMSGatewayMustBeEnabled : IRuleImplementationFor<Domain.SMS.Gateways.SMSGatewayMustBeEnabled>
    {
        readonly IReadModelRepositoryFor<SmsGateway> _gateways;

        public SMSGatewayMustBeEnabled(IReadModelRepositoryFor<SmsGateway> gateways)
        {
            _gateways = gateways;
        }

        public Domain.SMS.Gateways.SMSGatewayMustBeEnabled Rule => (ApiKey apiKey) =>
        {
            return _gateways.Query.FirstOrDefault(_ => _.ApiKey == apiKey.Value)?.Enabled ?? false;
        };
    }
}