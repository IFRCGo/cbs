using doLittle.Commands;

namespace Domain.StaffUser.Registering
{
    public abstract class NewRegistration : ICommand
    {
        public UserInfo UserDetails { get; set;}
    }
}