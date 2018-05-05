using FluentValidation;

namespace Domain.DataCollector.PhoneNumber
{
    public class RemovePhoneNumberFromDataCollectorValidator : AbstractValidator<RemovePhoneNumberFromDataCollector>
    {
        public RemovePhoneNumberFromDataCollectorValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("Data Collector Id is required");

            RuleFor(_ => _.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required")
                .Must(_ => !_.Contains(" ")).WithMessage("Phone number is not valid");
        }
    }
}