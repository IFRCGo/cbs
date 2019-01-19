using System.Linq;
using Dolittle.ReadModels;
using Dolittle.Rules;
using Domain.SMS.Gateways;
using Read.SMS.Gateways;

namespace Rules.SMS.Gateways
{
    public class PhoneNumberNotExists 
        : IRuleImplementationFor<Domain.SMS.Gateways.PhoneNumberNotExists>
    {
        private readonly IReadModelRepositoryFor<SmsGateway> _smsGateways;

        public PhoneNumberNotExists(IReadModelRepositoryFor<SmsGateway> smsGateways)
        {
            _smsGateways = smsGateways;
        }

        public Domain.SMS.Gateways.PhoneNumberNotExists Rule => (string number) =>
        {
            return !_smsGateways.Query.Any(_ => _.PhoneNumber.Equals(number));
        };
    }
}