using Concepts;
using Dolittle.Commands.Validation;
using Domain.StaffUser.Roles;
using FluentValidation;

namespace Domain.StaffUser.Changing
{
    // public class ChangeLocationValidator : CommandInputValidatorFor<ChangeLocation>
    // {
    //     public ChangeLocationValidator()
    //     {
    //         RuleFor(_ => _.StaffUserId)
    //             .NotEmpty().WithMessage("Staffuser Id must be set");

    //         RuleFor(_ => _.Role)
    //             .Must(role => role.HasLocation()).WithMessage("This kind of Staffuser does not have a location");

    //         RuleFor(_ => _.Location)
    //             .Cascade(CascadeMode.StopOnFirstFailure)
    //             .NotNull().WithMessage("Location must be provided")
    //             .Must(l => l.IsValid()).WithMessage(
    //                 "Location is invalid. Latitude must be in the range -90 to 90 and longitude in the range -180 to 180")
    //             .Must(l => !l.Equals(Location.NotSet)).WithMessage("Location cannot be -1, -1");
    //     }
    // }
}