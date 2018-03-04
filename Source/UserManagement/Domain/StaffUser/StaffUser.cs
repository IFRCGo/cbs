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

        public void RegisterNewSystemConfigurator(string fullname, string displayname, string email, DateTimeOffset registeredAt, 
                                                    Guid nationalSociety, Language language, IEnumerable<string> phoneNumbers, 
                                                        IEnumerable<Guid> assignedTo, int? birthYear, Sex? sex)
        {
            Register(fullname,displayname,email,registeredAt);
            RegisterSystemConfigurator(nationalSociety,language, sex, birthYear);
            RegisterPhoneNumbers(phoneNumbers);
            RegisterAssignedToNationalSocieties(assignedTo);
        }

        public void RegisterNewDataCoordinator(string fullname, string displayname, string email, DateTimeOffset registeredAt, 
                                                Guid nationalSociety, Language language, IEnumerable<string> phoneNumbers, 
                                                    IEnumerable<Guid> assignedTo, int? birthYear, Sex? sex)
        {
            Register(fullname,displayname,email,registeredAt);
            RegisterDataCoordinator(nationalSociety,language, sex, birthYear);
            RegisterPhoneNumbers(phoneNumbers);
            RegisterAssignedToNationalSocieties(assignedTo);
        }
    
        public void RegisterNewDataOwner(string fullname, string displayname, string email, DateTimeOffset registeredAt, 
                                            Guid nationalSociety, Language language, int? birthYear, Sex? sex, 
                                                Location location, string position, string dutyStation)
        {
            Register(fullname,displayname,email,registeredAt);
            RegisterDataOwner(nationalSociety,language, sex, birthYear, location, position, dutyStation);
        }

        public void RegisterNewStaffDataVerifier(string fullname, string displayname, string email, DateTimeOffset registeredAt, 
                                                Guid nationalSociety, Language language, int? birthYear, Sex? sex, 
                                                Location location, string position)
        {
            Register(fullname,displayname,email,registeredAt);
            RegisterStaffDataVerifier(nationalSociety,language, sex, birthYear, location, position);
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

        private void RegisterDataOwner(Guid nationalSociety, Language language, Sex? sex, int? yearOfBirth, 
                                        Location location, string position, string dutyStation)
        {
            var sex_ = sex.HasValue ? (int)sex.Value : Constants.NOT_KNOWN;
            var year = yearOfBirth.HasValue ? yearOfBirth.Value : Constants.NOT_KNOWN;
            Apply(new DataOwnerRegistered(EventSourceId,nationalSociety,(int)language,sex_,year,
                                            location.Latitude, location.Longitude, position, dutyStation));
        }

        private void RegisterStaffDataVerifier(Guid nationalSociety, Language language, Sex? sex, int? yearOfBirth, 
                                                Location location, string position)
        {
            var sex_ = sex.HasValue ? (int)sex.Value : Constants.NOT_KNOWN;
            var year = yearOfBirth.HasValue ? yearOfBirth.Value : Constants.NOT_KNOWN;
            Apply(new StaffDataVerifierRegistered(EventSourceId,nationalSociety,(int)language,sex_,year,
                                                    location.Latitude, location.Longitude, position));
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