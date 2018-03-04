using System;
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
            user.RegisterNewAdminUser(command.UserDetails.FullName, command.UserDetails.DisplayName, 
                                        command.UserDetails.Email, _systemClock.GetCurrentTime());
        }

        public void Handle(RegisterNewDataCoordinator command)
        {
            var user = _repository.Get(command.UserDetails.StaffUserId);
            user.RegisterNewDataCoordinator(command.UserDetails.FullName, command.UserDetails.DisplayName, 
                                        command.UserDetails.Email, _systemClock.GetCurrentTime(), command.Role.NationalSociety,
                                        command.Role.PreferredLanguage, command.Role.PhoneNumbers,
                                        command.AssignedNationalSocieties, command.Role.YearOfBirth, command.Role.Sex);
        }

        public void Handle(RegisterNewSystemConfigurator command)
        {
            var user = _repository.Get(command.UserDetails.StaffUserId);
            user.RegisterNewSystemConfigurator(command.UserDetails.FullName, command.UserDetails.DisplayName, 
                                        command.UserDetails.Email, _systemClock.GetCurrentTime(),command.Role.NationalSociety,
                                        command.Role.PreferredLanguage, command.Role.PhoneNumbers,
                                        command.AssignedNationalSocieties, command.Role.YearOfBirth, command.Role.Sex);
        }

        public void Handle(RegisterNewDataOwner command)
        {
            var user = _repository.Get(command.UserDetails.StaffUserId);
            user.RegisterNewDataOwner(command.UserDetails.FullName, command.UserDetails.DisplayName, 
                                        command.UserDetails.Email, _systemClock.GetCurrentTime(),command.Role.NationalSociety,
                                         command.Role.PreferredLanguage, command.Role.PhoneNumbers, command.Role.YearOfBirth, 
                                         command.Role.Sex, command.Location, command.Position, command.DutyStation);
        }

        public void Handle(RegisterNewStaffDataVerifier command)
        {
            var user = _repository.Get(command.UserDetails.StaffUserId);
            user.RegisterNewDataVerifier(command.UserDetails.FullName, command.UserDetails.DisplayName, 
                                                command.UserDetails.Email, _systemClock.GetCurrentTime(),command.Role.NationalSociety,
                                                command.Role.PreferredLanguage, command.Role.PhoneNumbers, command.Role.YearOfBirth,
                                                command.Role.Sex, command.Location);
        }

        public void Handle(RegisterNewStaffDataConsumer command)
        {
            var user = _repository.Get(command.UserDetails.StaffUserId);
            user.RegisterNewDataConsumer(command.UserDetails.FullName, command.UserDetails.DisplayName, 
                                                command.UserDetails.Email, _systemClock.GetCurrentTime(),command.Role.NationalSociety,
                                                command.Role.PreferredLanguage, command.Role.YearOfBirth,
                                                command.Role.Sex, command.Location);
        }
    }
}