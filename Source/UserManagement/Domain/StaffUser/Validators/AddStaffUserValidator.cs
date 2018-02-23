using Concepts;
using FluentValidation;

namespace Domain.StaffUser.Validators
{
    public class AddStaffUserValidator : AbstractValidator<AddStaffUser>
    {
        //TODO: Work to be done.
        public AddStaffUserValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(_ => _.Role)
                .IsInEnum()
                .WithMessage("Role is not correct - Has to be defined");

            RuleFor(_ => _.FullName)
                .NotEmpty()
                .WithMessage("Full name is not correct - Has to be defined");

            RuleFor(_ => _.DisplayName)
                .NotEmpty()
                .WithMessage("Display name is not correct - Has to be defined");

            RuleFor(_ => _.Email)
                .NotEmpty()
                .WithMessage("Email is invalid - Has to be defined");

            RuleFor(_ => _.Email)
                .EmailAddress()
                .WithMessage("Email is invalid - Has to be of valid format");

            When(_ => _.Role.RequiresExtensiveInfo(), () =>
            {
                RuleFor(_ => _.Age)
                    .GreaterThan(0)
                    .WithMessage("Age is not correct - Has to be greater than 0");
                RuleFor(_ => _.Sex)
                    .IsInEnum()
                    .WithMessage("Sex is not correct - Has to be a valid value");

                RuleFor(_ => _.NationalSociety)
                    .NotEmpty()
                    .WithMessage("National Society is not correct - Has to be a IRC Society");

                RuleFor(_ => _.PreferredLanguage)
                    .IsInEnum()
                    .WithMessage("Preferred language is not correct - Has to be a supported languge");

                //TODO: Validate MobilePhoneNumber based on localization
                RuleFor(_ => _.MobilePhoneNumber)
                    .NotEmpty()
                    //.Matches(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")
                    .WithMessage("Mobile phone number is not correct - Has to be of correct form");
            });

            When(_ => _.Role.RequiresPositionAndDutyStation(), () => {
                RuleFor(_ => _.Position)
                    .NotEmpty()
                    .WithMessage("Position within National Society is not correct - Has to be defined");
                RuleFor(_ => _.DutyStation)
                    .NotEmpty()
                    .WithMessage("Duty Station is not correct - Has to be defined");
            });

            RuleFor(_ => _.Location)
                .NotEmpty()
                .When(_=> _.Role.RequiresLocation())
                .WithMessage("Location is not correct - Has to be defined");
        }

    }
}
