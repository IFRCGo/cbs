using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollector.PhoneNumber
{
    public class AddPhoneNumberToDataCollectorBusinessValidator : CommandBusinessValidatorFor<AddPhoneNumberToDataCollector>
    {
        IPhoneNumberRules _rules;
        public AddPhoneNumberToDataCollectorBusinessValidator(IPhoneNumberRules rules)
        {
            _rules = rules;

            RuleFor(_ => _.PhoneNumber)
                .SetValidator(new PhoneNumberIsNotRegisteredValidator(_rules));
        }
    }
}