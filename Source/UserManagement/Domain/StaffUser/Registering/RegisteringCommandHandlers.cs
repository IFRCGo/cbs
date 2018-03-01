using doLittle.Domain;
using doLittle.Time;
using doLittle.Runtime.Commands;

namespace Domain.StaffUser.Registering
{
    public class RegisteringCommandHandlers : ICanHandleCommands
    {
        IAggregateRootRepositoryFor<Domain.StaffUser.StaffUser> _repository;
        ISystemClock _systemClock;

        public RegisteringCommandHandlers(IAggregateRootRepositoryFor<Domain.StaffUser.StaffUser> repository, ISystemClock systemClock)
        {
            _repository = repository;
            _systemClock = systemClock;
        }

        public void Handle(RegisterNewAdminUser command)
        {
            var user = _repository.Get(command.UserDetails.StaffUserId);
            user.RegisterNewAdminUser(command.UserDetails.FullName, command.UserDetails.DisplayName, command.UserDetails.Email, _systemClock.GetCurrentTime());
        }
    }
}