namespace Domain.StaffUser.Registering
{
    public class RegisterNewStaffDataVerifierBusinessRulesValidator 
        : NewStaffRegistrationBusinessRulesValidator<RegisterNewStaffDataVerifier, Roles.DataVerifier>
    {
        public RegisterNewStaffDataVerifierBusinessRulesValidator(StaffUserIsRegistered isRegistered, bool isNewRegistration) : base(isRegistered, isNewRegistration)
        {
        }
    }
}