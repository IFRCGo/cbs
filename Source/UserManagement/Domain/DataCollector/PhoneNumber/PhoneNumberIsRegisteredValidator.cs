using FluentValidation;

namespace Domain.DataCollector.PhoneNumber
{
    public class PhoneNumberIsRegisteredValidator : AbstractValidator<string>
    {
        readonly IPhoneNumberRules _rules;
        public PhoneNumberIsRegisteredValidator(IPhoneNumberRules rules)
        {
            _rules = rules;

            RuleFor(number => number)
                .Must(BeARegisteredNumber).WithMessage(number => $"Phone number {number} is not registered");
        }


        bool BeARegisteredNumber(string number)
        {
            return _rules.PhoneNumberIsRegistered(number);
        }

    }
}