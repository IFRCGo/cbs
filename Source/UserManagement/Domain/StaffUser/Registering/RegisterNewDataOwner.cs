
namespace Domain.StaffUser.Registering
{
    public class RegisterNewDataOwner : NewStaffRegistration<Roles.DataOwner>
    {
        public RegisterNewDataOwner()
        {
            Role = new Roles.DataOwner();
        } 
    }
}