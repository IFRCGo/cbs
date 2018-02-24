using doLittle.Runtime.Commands;
using Domain.StaffUser.Commands;

namespace Domain.StaffUser.CommandHandlers
{
    public interface IStaffUserCommandHandler : ICanHandleCommands
    {
        void Handle(AddStaffUser command);

        void Handle(DeleteStaffUser command);

        void Handle(AddPhoneNumberToStaffUser command);

        void Handle(RemovePhoneNumberFromStaffUser command);
    }
}