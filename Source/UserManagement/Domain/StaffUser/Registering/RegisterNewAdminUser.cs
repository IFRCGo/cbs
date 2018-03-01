using doLittle.Commands;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewAdminUser : ICommand
    {
        public BasicInfo UserDetails { get; set;}
    }
}