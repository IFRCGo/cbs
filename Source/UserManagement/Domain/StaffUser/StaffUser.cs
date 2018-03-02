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
            RegisterSystemConfigurator(nationalSociety,language);
            RegisterPhoneNumbers(phoneNumbers);
            RegisterAssignedToNationalSocieties(assignedTo);
            RegisterBirthYear(birthYear);
            RegisterSex(sex);
        }

        private void RegisterSex(Sex? sex)
        {
            if(sex.HasValue)
                Apply(new SexRegistered(EventSourceId, (int)sex.Value));
        }

        private void RegisterBirthYear(int? birthYear)
        {
            if(birthYear.HasValue)
                Apply(new BirthYearRegistered(EventSourceId, (int)birthYear.Value));
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

        private void RegisterSystemConfigurator(Guid nationalSociety, Language language)
        {
            Apply(new SystemConfiguratorRegistered(EventSourceId,nationalSociety, (int)language));
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