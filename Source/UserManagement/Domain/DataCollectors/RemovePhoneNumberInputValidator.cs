using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.DataCollectors
{
    public class RemovePhoneNumberInputValidator : CommandInputValidator<RemovePhoneNumber>
    {
        public RemovePhoneNumberInputValidator()
        {            
            RuleFor(c => c.PhoneNumber)
                .NotEmpty();
            RuleFor(c => c.DataCollectorId)
                .NotEmpty();
        }
    }
}
