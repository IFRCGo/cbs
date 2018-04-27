using System;
using Dolittle.Commands.Handling;
using Dolittle.Domain;
using Dolittle.Time;

namespace Domain.StaffUser.Registering
{
    public class RegisteringCommandHandlers : ICanHandleCommands
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
            user.RegisterNewAdminUser(command.Role.FullName, command.Role.DisplayName, 
                                        command.Role.Email, DateTimeOffset.UtcNow);
        }

        public void Handle(RegisterNewDataCoordinator command)
        {
            var user = _repository.Get(command.Role.StaffUserId);
            user.RegisterNewDataCoordinator(command.Role.FullName, command.Role.DisplayName, 
                                        command.Role.Email, command.Role.NationalSociety,
                                        command.Role.PreferredLanguage.Value, command.Role.PhoneNumbers,
                                        command.Role.AssignedNationalSocieties, command.Role.BirthYear, command.Role.Sex, DateTimeOffset.UtcNow);
        }

        public void Handle(RegisterNewSystemConfigurator command)
        {
            var user = _repository.Get(command.Role.StaffUserId);
            user.RegisterNewSystemConfigurator(command.Role.FullName, command.Role.DisplayName, 
                                        command.Role.Email, command.Role.NationalSociety,
                                        command.Role.PreferredLanguage.Value, command.Role.PhoneNumbers,
                                        command.Role.AssignedNationalSocieties, command.Role.BirthYear, command.Role.Sex, DateTimeOffset.UtcNow);
        }

        public void Handle(RegisterNewDataOwner command)
        {
            var user = _repository.Get(command.Role.StaffUserId);
            user.RegisterNewDataOwner(command.Role.FullName, command.Role.DisplayName, 
                                        command.Role.Email, command.Role.NationalSociety,
                                         command.Role.PreferredLanguage.Value, command.Role.PhoneNumbers, command.Role.BirthYear, 
                                         command.Role.Sex, command.Role.Position, command.Role.DutyStation, DateTimeOffset.UtcNow);
        }

        public void Handle(RegisterNewStaffDataVerifier command)
        {
            var user = _repository.Get(command.Role.StaffUserId);
            user.RegisterNewDataVerifier(command.Role.FullName, command.Role.DisplayName, 
                                                command.Role.Email,command.Role.NationalSociety,
                                                command.Role.PreferredLanguage.Value, command.Role.PhoneNumbers, command.Role.BirthYear,
                                                command.Role.Sex, command.Role.Location, DateTimeOffset.UtcNow);
        }

        public void Handle(RegisterNewStaffDataConsumer command)
        {
            var user = _repository.Get(command.Role.StaffUserId);
            user.RegisterNewDataConsumer(command.Role.FullName, command.Role.DisplayName, 
                                                command.Role.Email,command.Role.NationalSociety,
                                                command.Role.PreferredLanguage.Value, command.Role.BirthYear,
                                                command.Role.Sex, command.Role.Location, DateTimeOffset.UtcNow);
        }
    }
}