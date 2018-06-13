using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollector.PhoneNumber
{
    public class RemovePhoneNumberFromDataCollectorBusinessValidator : CommandBusinessValidatorFor<AddPhoneNumberToDataCollector>
    {
        IPhoneNumberRules _rules;
        public RemovePhoneNumberFromDataCollectorBusinessValidator(IPhoneNumberRules rules)
        {
            _rules = rules;

            RuleFor(_ => _.PhoneNumber)
                .SetValidator(new PhoneNumberIsRegisteredValidator(_rules));
        }
    }
}