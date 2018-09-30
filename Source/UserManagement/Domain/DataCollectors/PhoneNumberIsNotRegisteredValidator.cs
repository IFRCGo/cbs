using FluentValidation;

namespace Domain.DataCollectors
{
    public class PhoneNumberIsNotRegisteredValidator : AbstractValidator<string>
    {
        readonly IPhoneNumberRules _rules;
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