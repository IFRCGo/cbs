using FluentValidation;

namespace Domain
{
    public class AddVolunteerUserValidator : AbstractValidator<AddVolunteerUser>
    {
        AddVolunteerUserValidator()
        {
            RuleFor(_ => _.FirstName)
                .NotEmpty()
                .WithMessage("First name is not correct - Has to be defined");

            RuleFor(_ => _.LastName)
                .NotEmpty()
                .WithMessage("Last name is not correct - Has to be defined");

            //TODO: rest of the rules
        }
    }
}