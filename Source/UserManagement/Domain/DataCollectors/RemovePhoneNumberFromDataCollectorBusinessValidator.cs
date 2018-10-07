using Concepts.DataCollectors;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollectors
{
    public class RemovePhoneNumberFromDataCollectorBusinessValidator : CommandBusinessValidatorFor<RemovePhoneNumberFromDataCollector>
    {
        public RemovePhoneNumberFromDataCollectorBusinessValidator(MustExist beAnActualDataCollector, PhoneNumberShouldBeRegistered beARegisteredNumber)
        {
            RuleFor(_ => _.DataCollectorId)
                .Must(_ => beAnActualDataCollector(_))
                .WithMessage(_ => $"Data Collector with id {_.DataCollectorId.Value} is not registered");

            RuleFor(_ => _.PhoneNumber)
                .Must(_ => beARegisteredNumber(_)).WithMessage(number => $"Phone number {number} is not registered");
        }
    }
}