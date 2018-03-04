using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewDataCoordinatorInputValidator 
                    : NewStaffRegistrationInputValidator<RegisterNewDataCoordinator, Domain.StaffUser.Roles.DataCoordinator>
    {
        public RegisterNewDataCoordinatorInputValidator()
        {
            RuleFor(_ => (_ as IRequireAssignedNationalSocieties))
                .NotNull()
                .SetValidator(new RequireAssignedNationalSocietiesInputValidator());
        }
    }
}