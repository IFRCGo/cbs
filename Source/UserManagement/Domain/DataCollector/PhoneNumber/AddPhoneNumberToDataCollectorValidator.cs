using System.Linq;
using Concepts.DataCollector;
using FluentValidation;

namespace Domain.DataCollector.PhoneNumber
{
    public class AddPhoneNumberToDataCollectorValidator : AbstractValidator<AddPhoneNumberToDataCollector>
    {
        public AddPhoneNumberToDataCollectorValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("Data Collector Id must be set")
                .SetValidator(new DataCollectorIdValidator());

            RuleFor(_ => _.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required")
                .Must(_ => !_.Contains(" ")).WithMessage("Phone number is not valid");

        }
    }
}