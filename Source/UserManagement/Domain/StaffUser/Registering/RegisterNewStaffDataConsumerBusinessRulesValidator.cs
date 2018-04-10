
namespace Domain.StaffUser.Registering
{
    public class RegisterNewStaffDataConsumerBusinessRulesValidator 
        : NewStaffRegistrationBusinessRulesValidator<RegisterNewStaffDataConsumer, Roles.DataConsumer>
    {
        public RegisterNewStaffDataConsumerBusinessRulesValidator(StaffUserIsRegistered isRegistered, bool isNewRegistration) : base(isRegistered, isNewRegistration)
        {
        }
    }
}