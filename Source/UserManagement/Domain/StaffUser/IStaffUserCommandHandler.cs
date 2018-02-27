using doLittle.Runtime.Commands;
using Domain.StaffUser.Add;
using Domain.StaffUser.Delete;
using Domain.StaffUser.PhoneNumber;
using Domain.StaffUser.Update;

namespace Domain.StaffUser
{
    public interface IStaffUserCommandHandler : ICanHandleCommands
    {
        void Handle(AddAdmin command);
        void Handle(AddDataConsumer command);
        void Handle(AddDataCoordinator command);
        void Handle(AddDataOwner command);
        void Handle(AddDataVerifier command);
        void Handle(AddSystemCoordinator command);

        void Handle(UpdateStaffUser command);

        void Handle(DeleteStaffUser command);

        void Handle(AddPhoneNumberToStaffUser command);

        void Handle(RemovePhoneNumberFromStaffUser command);
    }
}