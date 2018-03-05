using doLittle.Commands;

namespace Domain.StaffUser.Registering
{
    public interface INewStaffRegistration : ICommand 
    {

    }
    public abstract class NewStaffRegistration<T> : INewStaffRegistration where T : Roles.StaffRole
    {
        public T Role { get; protected set; }
    }
}