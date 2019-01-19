using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.SMS.Gateways
{
    public class RegisterSmsGatewayInputValidator : CommandInputValidatorFor<RegisterSmsGateway>
    {
        public RegisterSmsGatewayInputValidator()
        {
            RuleFor(_ => _.Name)
                .NotEmpty()
                .WithMessage("Please specify a gateway name");
        }
    }
}
