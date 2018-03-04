using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewDataCoordinatorInputValidator 
                    : NewStaffRegistrationInputValidator<RegisterNewDataCoordinator, Domain.StaffUser.Roles.DataCoordinator>
    {
    }
}