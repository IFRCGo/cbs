using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.SMS.Gateways
{
    public class RegisterSmsGatewayBusinessValidator 
        : CommandBusinessValidatorFor<RegisterSmsGateway>
    {
        public RegisterSmsGatewayBusinessValidator(
            SmsGatewayDoesNotExist notExist
        )
        {
            RuleFor(_ => _.SmsGatewayId)
                .Must(_ => notExist(id: _.Value))
                .WithMessage("Sms gateway with this id is already added");
        }
    }
}
