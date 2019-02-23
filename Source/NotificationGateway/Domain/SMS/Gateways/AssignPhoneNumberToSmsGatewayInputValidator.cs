using Concepts.SMS.Gateways;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.SMS.Gateways
{
    public class AssignPhoneNumberToSmsGatewayInputValidator 
        : CommandInputValidatorFor<AssignPhoneNumberToSmsGateway>
    {
        public AssignPhoneNumberToSmsGatewayInputValidator()
        {
            RuleFor(_ => _.SmsGatewayId)
                .NotEmpty()
                .WithMessage("Sms Gateway Id must be set")
                .SetValidator(new SmsGatewayIdValidator());

            RuleFor(_ => _.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number must be specified")
                .Must(_ => !_.Value.Contains(" "))
                .WithMessage("Phone number is not valid")
                .Must(_ => _.Value.StartsWith("+"))
                .WithMessage("Phone number must start with '+'");
        }
    }
}
