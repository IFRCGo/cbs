using System.Linq;
using FluentValidation;

namespace Domain.DataCollector.PhoneNumber
{
    public class AddPhoneNumberToDataCollectorValidator : AbstractValidator<AddPhoneNumberToDataCollector>
    {
        public AddPhoneNumberToDataCollectorValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("Data Collector Id is required");

            RuleFor(_ => _.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required")
                .Must(_ => !_.Contains(" ")).WithMessage("Phone number is not valid");

        }
    }
}