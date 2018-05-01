
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.StaffUser.Registering
{

    public class RegisterNewAdminUserInputValidator : NewStaffRegistrationInputValidator<RegisterNewAdminUser, Roles.Admin>
    {
        
    }
}