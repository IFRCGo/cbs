
namespace Domain.StaffUser.Registering
{
    public class RegisterNewDataOwnerBusinessRulesValidator 
                    : NewStaffRegistrationBusinessRulesValidator<RegisterNewDataOwner, Roles.DataOwner>
    {
        public RegisterNewDataOwnerBusinessRulesValidator(StaffUserIsRegistered isRegistered, bool isNewRegistration) : base(isRegistered, isNewRegistration)
        {
        }
    }
}