
namespace Domain.StaffUser.Registering
{
    public class RegisterNewDataOwnerBusinessRulesValidator 
                    : NewStaffRegistrationBusinessRulesValidator<RegisterNewDataOwner, Roles.DataOwner>
    {
        public RegisterNewDataOwnerBusinessRulesValidator(StaffUserIsRegistered isRegistered) : base(isRegistered)
        {
        }
    }
}