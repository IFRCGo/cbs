
namespace Domain.StaffUser.Registering
{
    public class RegisterNewStaffDataConsumer : NewStaffRegistration<Roles.DataConsumer>
    {
        public RegisterNewStaffDataConsumer()
        {
            Role = new Roles.DataConsumer();
        }
    }
}