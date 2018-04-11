using doLittle.Runtime.Commands;

namespace Domain.StaffUser.Registering
{
    public interface IRegisteringCommandHandlers : ICanHandleCommands
    {
        void Handle(RegisterNewAdminUser command);

        void Handle(RegisterNewDataCoordinator command);

        void Handle(RegisterNewSystemConfigurator command);

        void Handle(RegisterNewDataOwner command);

        void Handle(RegisterNewStaffDataVerifier command);

        void Handle(RegisterNewStaffDataConsumer command);
    }
}