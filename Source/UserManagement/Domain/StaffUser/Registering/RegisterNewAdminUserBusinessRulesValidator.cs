
namespace Domain.StaffUser.Registering
{
    public class RegisterNewAdminUserBusinessRulesValidator 
                    : NewStaffRegistrationBusinessRulesValidator<RegisterNewAdminUser, Roles.Admin>
    {
        public RegisterNewAdminUserBusinessRulesValidator(StaffUserIsRegistered isRegistered) : base(isRegistered)
        {
        }
    }
}