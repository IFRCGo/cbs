using doLittle.Domain;
using Events.StaffUser;
using doLittle.Events;
using System;
using System.Linq;
using System.Collections.Generic;
using Concepts;

namespace Domain.StaffUser
{
    public class StaffUser : AggregateRoot
    {
        bool _isRegistered;

        public StaffUser(Guid staffUserId) : base(staffUserId)
        {}

        public void RegisterNewAdminUser(string fullname, string displayname, string email, DateTimeOffset registeredAt)
        {
            Register(fullname,displayname,email,registeredAt);
        }

        public void RegisterNewSystemConfigurator(string fullname, string displayname, string email, DateTimeOffset registeredAt, Guid nationalSociety, Language language, IEnumerable<string> phoneNumbers, IEnumerable<Guid> assignedTo, int? birthYear, Sex? sex)
        {
            Register(fullname,displayname,email,registeredAt);
            RegisterSystemConfigurator(nationalSociety,language, sex, birthYear);
            RegisterPhoneNumbers(phoneNumbers);
            RegisterAssignedToNationalSocieties(assignedTo);
        }

        public void RegisterNewDataCoordinator(string fullname, string displayname, string email, DateTimeOffset registeredAt, Guid nationalSociety, Language language, IEnumerable<string> phoneNumbers, IEnumerable<Guid> assignedTo, int? birthYear, Sex? sex)
        {
            Register(fullname,displayname,email,registeredAt);
            RegisterDataCoordinator(nationalSociety,language, sex, birthYear);
            RegisterPhoneNumbers(phoneNumbers);
            RegisterAssignedToNationalSocieties(assignedTo);
        }

        private void RegisterAssignedToNationalSocieties(IEnumerable<Guid> assignedNationalSocieties)
        {
            foreach(var nationalSociety in assignedNationalSocieties)
            {
                Apply(new NationalSocietyAssigned(EventSourceId,nationalSociety));
            }
        }

        private void RegisterPhoneNumbers(IEnumerable<string> phoneNumbers)
        {
            foreach(var phoneNumber in phoneNumbers)
            {
                Apply(new PhoneNumberRegistered(EventSourceId,phoneNumber));
            }
        }

        private void RegisterPreferredLanguage(Language language)
        {
            Apply(new PreferredLanguageRegistered(EventSourceId,(int)language));
        }

        private void RegisterSystemConfigurator(Guid nationalSociety, Language language, Sex? sex, int? yearOfBirth)
        {
            var sex_ = sex.HasValue ? (int)sex.Value : Constants.NOT_KNOWN;
            var year = yearOfBirth.HasValue ? yearOfBirth.Value : Constants.NOT_KNOWN;
            Apply(new SystemConfiguratorRegistered(EventSourceId,nationalSociety, (int)language, sex_, year));
        }

        private void RegisterDataCoordinator(Guid nationalSociety, Language language, Sex? sex, int? yearOfBirth)
        {
            var sex_ = sex.HasValue ? (int)sex.Value : Constants.NOT_KNOWN;
            var year = yearOfBirth.HasValue ? yearOfBirth.Value : Constants.NOT_KNOWN;
            Apply(new DataCoordinatorRegistered(EventSourceId,nationalSociety, (int)language, sex_, year));
        }

        void On(NewUserRegistered @event)
        {
            _isRegistered = true;
        }

        void Register(string fullname, string displayname, string email, DateTimeOffset registeredAt)
        {
            if(_isRegistered)
                throw new UserAlreadyRegistered($"User '{EventSourceId}' {email} {displayname} is already registered.");
            
            Apply(new NewUserRegistered(EventSourceId, fullname, displayname, email, registeredAt));
        }
    }
}