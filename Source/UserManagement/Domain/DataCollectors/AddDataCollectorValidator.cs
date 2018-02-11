using FluentValidation;

namespace Domain
{
    //QUESTION: Should we use CommandInputValidator or AbstractValidator?
    public class AddDataCollectorValidator : AbstractValidator<AddDataCollector>
    {
        public AddDataCollectorValidator()
        {
            RuleFor(_ => _.FullName)
                .NotEmpty()
                .WithMessage("First name is not correct - Has to be defined");

            RuleFor(_ => _.DisplayName)
                .NotEmpty()
                .WithMessage("Last name is not correct - Has to be defined");

            //TODO: rest of the rules
        }
    }
}