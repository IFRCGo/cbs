using Concepts.DataCollectors;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollectors
{
    public class AddPhoneNumberToDataCollectorBusinessValidator : CommandBusinessValidatorFor<AddPhoneNumberToDataCollector>
    {
        public AddPhoneNumberToDataCollectorBusinessValidator(MustExist beAnActualDataCollector, PhoneNumberShouldNotBeRegistered notBeARegisteredNumber)
        {
            RuleFor(_ => _.DataCollectorId)
                .Must(_ => beAnActualDataCollector(_))
                .WithMessage(_ => $"Data Collector with id {_.DataCollectorId.Value} is not registered");

            RuleFor(_ => _.PhoneNumber)
                .Must(_ => notBeARegisteredNumber(_)).WithMessage(number => $"Phone number {number} is already registered");
        }
    }
}