using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewDataCoordinatorInputValidator : NewExtendedRegistrationInputValidator<RegisterNewDataCoordinator>
    {
        public RegisterNewDataCoordinatorInputValidator()
        {
            RuleFor(_ => (_ as IAmAssignedToNationalSocieties))
                .NotNull()
                .SetValidator(new AssignedToNationalSocietiesValidator());
        }
    }
}