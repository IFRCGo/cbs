using FluentValidation;

namespace Domain.DataCollector.PhoneNumber
{
    public class PhoneNumberIsNotRegisteredValidator : AbstractValidator<string>
    {
        IPhoneNumberRules _rules;
        public PhoneNumberIsNotRegisteredValidator(IPhoneNumberRules rules)
        {
            _rules = rules;

            RuleFor(number => number)
                .Must(NotBeARegisteredNumber).WithMessage(number => $"Phone number {number} is already registered");
        }


        bool NotBeARegisteredNumber(string number)
        {
            return !_rules.PhoneNumberIsRegistered(number);
        }

    }
}