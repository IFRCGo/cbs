using Concepts;
using Domain.StaffUser.Commands;
using FluentValidation;

namespace Domain.StaffUser.Add
{
    public class AddStaffUserValidator : AbstractValidator<BaseStaffUser>
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
                .NotEmpty().WithMessage("Email is invalid - Has to be defined")
                .EmailAddress().WithMessage("Email is invalid - Has to be of valid format");
            /* Move into other validators
            When(_ => _.Role.RequiresExtensiveInfo(), () =>
            {
                RuleFor(_ => _.NationalSociety)
                    .NotEmpty()
                    .WithMessage("National Society is not correct - Has to be a IRC Society");

                RuleFor(_ => _.PreferredLanguage)
                    .IsInEnum()
                    .WithMessage("Preferred language is not correct - Has to be a supported languge");

                //TODO: Validate MobilePhoneNumbers based on localization
                RuleFor(_ => _.MobilePhoneNumber)
                    .NotEmpty()
                    //.Matches(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")
                    .WithMessage("Mobile phone number is not correct - Has to be of correct form");
            });

            When(_ => _.Role.RequiresAgeAndSex(), () =>
            {
                RuleFor(_ => _.YearOfBirth)
                    .NotEmpty().WithMessage("YearOfBirth is not correct - Has to be specified");

                RuleFor(_ => _.Sex)
                    .IsInEnum().WithMessage("Sex is not correct - Has to be specified and have valid value");
            });

            When(_ => _.Role.RequiresPositionAndDutyStation(), () => {
                RuleFor(_ => _.Position)
                    .NotEmpty().WithMessage("Position within National Society is not correct - Has to be defined");
                RuleFor(_ => _.DutyStation)
                    .NotEmpty().WithMessage("Duty Station is not correct - Has to be defined");
            });

            When(_ => _.Role.RequiresAssignedNationalSocieties(), () =>
            {
                RuleFor(_ => _.AssignedNationalSocieties)
                    .NotEmpty().WithMessage("AssignedNationalSocieties list cannot be empty - Has to be defined");
            });

            When(_ => _.Role.RequiresLocation(), () => {
                RuleFor(_ => _.Location)
                    .NotEmpty().WithMessage("Location is not correct - Has to be defined");
                    //.NotEqual(Location.NotSet);
            });

            /* Stick to the same pattern as above (?)
            RuleFor(_ => _.Location)
                .NotEmpty()
                .When(_=> _.Role.RequiresLocation())
                .WithMessage("Location is not correct - Has to be defined");
            */
            
        }

    }
}
