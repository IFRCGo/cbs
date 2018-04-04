using doLittle.Domain;
using doLittle.Time;

namespace Domain.StaffUser.Registering
{
    public class RegisteringCommandHandlers : IRegisteringCommandHandlers
    {
        readonly IAggregateRootRepositoryFor<StaffUser> _repository;
        readonly ISystemClock _systemClock;

        public RegisteringCommandHandlers(IAggregateRootRepositoryFor<StaffUser> repository, ISystemClock systemClock)
        {
            _repository = repository;
            _systemClock = systemClock;
        }

        public void Handle(RegisterNewAdminUser command)
        {
            var user = _repository.Get(command.Role.StaffUserId);
            user.RegisterNewAdminUser(command.IsNewRegistration, command.Role.FullName, command.Role.DisplayName, 
                                        command.Role.Email);
        }

        public void Handle(RegisterNewDataCoordinator command)
        {
            var user = _repository.Get(command.Role.StaffUserId);
            user.RegisterNewDataCoordinator(command.IsNewRegistration, command.Role.FullName, command.Role.DisplayName, 
                                        command.Role.Email, command.Role.NationalSociety,
                                        command.Role.PreferredLanguage.Value, command.Role.PhoneNumbers,
                                        command.Role.AssignedNationalSocieties, command.Role.BirthYear, command.Role.Sex);
        }

        public void Handle(RegisterNewSystemConfigurator command)
        {
            var user = _repository.Get(command.Role.StaffUserId);
            user.RegisterNewSystemConfigurator(command.IsNewRegistration, command.Role.FullName, command.Role.DisplayName, 
                                        command.Role.Email, command.Role.NationalSociety,
                                        command.Role.PreferredLanguage.Value, command.Role.PhoneNumbers,
                                        command.Role.AssignedNationalSocieties, command.Role.BirthYear, command.Role.Sex);
        }

        public void Handle(RegisterNewDataOwner command)
        {
            var user = _repository.Get(command.Role.StaffUserId);
            user.RegisterNewDataOwner(command.IsNewRegistration, command.Role.FullName, command.Role.DisplayName, 
                                        command.Role.Email, command.Role.NationalSociety,
                                         command.Role.PreferredLanguage.Value, command.Role.PhoneNumbers, command.Role.BirthYear, 
                                         command.Role.Sex, command.Role.Position, command.Role.DutyStation);
        }

        public void Handle(RegisterNewStaffDataVerifier command)
        {
            var user = _repository.Get(command.Role.StaffUserId);
            user.RegisterNewDataVerifier(command.IsNewRegistration, command.Role.FullName, command.Role.DisplayName, 
                                                command.Role.Email,command.Role.NationalSociety,
                                                command.Role.PreferredLanguage.Value, command.Role.PhoneNumbers, command.Role.BirthYear,
                                                command.Role.Sex, command.Role.Location);
        }

        public void Handle(RegisterNewStaffDataConsumer command)
        {
            var user = _repository.Get(command.Role.StaffUserId);
            user.RegisterNewDataConsumer(command.IsNewRegistration, command.Role.FullName, command.Role.DisplayName, 
                                                command.Role.Email,command.Role.NationalSociety,
                                                command.Role.PreferredLanguage.Value, command.Role.BirthYear,
                                                command.Role.Sex, command.Role.Location);
        }
    }
}