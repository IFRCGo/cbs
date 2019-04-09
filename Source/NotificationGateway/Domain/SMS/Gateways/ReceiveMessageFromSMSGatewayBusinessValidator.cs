using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.SMS.Gateways
{
    public class ReceiveMessageFromSMSGatewayBusinessValidator : CommandBusinessValidatorFor<ReceiveMessageFromSMSGateway>
    {
        public ReceiveMessageFromSMSGatewayBusinessValidator(SMSGatewayMustBeEnabled beEnabled)
        {
            RuleFor(_ => _.ApiKey).Must(_ => beEnabled(_)).WithMessage("Messages from disabled gateways are not accepted");
        }
    }
}
