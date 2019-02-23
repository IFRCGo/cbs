using Dolittle.Validation;
using FluentValidation;

namespace Concepts.SMS.Gateways
{
    public class SmsGatewayIdValidator : InputValidator<SmsGatewayId>
    {
        public SmsGatewayIdValidator()
        {
            RuleFor(x => x.Value)
                .NotEmpty()
                .WithMessage("Sms Gateway Id cannot be empty");
        }
    }
}