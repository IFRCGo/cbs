using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.SMS.Gateways
{
    public class AssignPhoneNumberToSmsGatewayBusinessValidator 
        : CommandBusinessValidatorFor<AssignPhoneNumberToSmsGateway>
    {
        public AssignPhoneNumberToSmsGatewayBusinessValidator(
            PhoneNumberNotExists notExist)
        {
            RuleFor(_ => _.PhoneNumber)
                .Must(_ => notExist(_))
                .WithMessage("Phone number is already registered to a gateway");
        }
    }
}
