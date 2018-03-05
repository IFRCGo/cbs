
namespace Domain.StaffUser.Registering
{

    public class RegisterNewDataCoordinator : NewStaffRegistration<Roles.DataCoordinator>
    {        
        public RegisterNewDataCoordinator()
        {
            Role = new Roles.DataCoordinator();
        }
    }
}