using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.SMS.Gateways
{
    public class AssignPhoneNumberToSmsGatewayCommandBusinessValidator 
        : CommandBusinessValidatorFor<AssignPhoneNumberToSmsGateway>
    {
        public AssignPhoneNumberToSmsGatewayCommandBusinessValidator(
            PhoneNumberNotExists notExist)
        {
            RuleFor(_ => _.PhoneNumber).Must(_ => notExist(_)).WithMessage("Stuff");
        }
    }
}
