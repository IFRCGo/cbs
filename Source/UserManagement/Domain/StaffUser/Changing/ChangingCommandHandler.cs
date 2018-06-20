using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.StaffUser.Changing
{
    public class ChangingCommandHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<StaffUser> _repository;

        public ChangingCommandHandler(IAggregateRootRepositoryFor<StaffUser> repository)
        {
            _repository = repository;
        }

        public void Handle(AddAssignedNationalSociety cmd)
        {
            var root = _repository.Get(cmd.StaffUserId);

            root.AddAssignedNationalSociety(cmd.NationalSociety, cmd.Role);
        }

        public void Handle(ChangeAdminInformation cmd)
        {
            var root = _repository.Get(cmd.StaffUserId);

            root.ChangeAdminInformation(cmd.FullName, cmd.DisplayName, cmd.Email);
        }

        public void Handle(ChangeDataOwnerInformation cmd)
        {
            var root = _repository.Get(cmd.StaffUserId);

            root.ChangeDataOwnerInformation(cmd.Position, cmd.DutyStation);
        }

        public void Handle(ChangeUserLocation cmd)
        {
            var root = _repository.Get(cmd.StaffUserId);

            root.ChangeLocation(cmd.Location, cmd.Role);
        }

        public void Handle(ChangeNationalSociety cmd)
        {
            var root = _repository.Get(cmd.StaffUserId);

            root.ChangeNationalSociety(cmd.NationalSociety, cmd.Role);
        }

        public void Handle(ChangeUserPreferredLanguage cmd)
        {
            var root = _repository.Get(cmd.StaffUserId);

            root.ChangePreferredLanguage(cmd.PreferredLanguage, cmd.Role);
        }

        public void Handle(RemoveAssignedNationalSociety cmd)
        {
            var root = _repository.Get(cmd.StaffUserId);

            root.RemoveAssignedNationalSociety(cmd.NationalSociety, cmd.Role);
        }
    }
}