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
        // void Handle(AddDataConsumer command);
        // void Handle(AddDataCoordinator command);
        // void Handle(AddDataOwner command);
        // void Handle(AddDataVerifier command);
        // void Handle(AddSystemCoordinator command);

        // void Handle(UpdateAdmin command);
        // void Handle(UpdateDataConsumer command);
        // void Handle(UpdateDataCoordinator command);
        // void Handle(UpdateDataOwner command);
        // void Handle(UpdateDataVerifier command);
        // void Handle(UpdateSystemCoordinator command);

        void Handle(DeleteStaffUser command);

        void Handle(AddPhoneNumberToStaffUser command);

        void Handle(RemovePhoneNumberFromStaffUser command);
    }
}