using doLittle.Domain;
using Events.StaffUser;
using System;
using System.Collections.Generic;
using Concepts;
using Domain.StaffUser.Registering;

namespace Domain.StaffUser
{
    public class StaffUser : AggregateRoot
    {
        bool _isRegistered;

        public StaffUser(Guid staffUserId) : base(staffUserId)
        {}

        #region Visible Registration Commands

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
                                            Guid nationalSociety, Language language, IEnumerable<string> phoneNumbers, int? birthYear, 
                                                Sex? sex, Location location, string position, string dutyStation)
        {
            Register(fullname,displayname,email,registeredAt);
            RegisterDataOwner(nationalSociety,language, sex, birthYear, location, position, dutyStation);
            RegisterPhoneNumbers(phoneNumbers);
        }

        public void RegisterNewDataConsumer(string fullname, string displayname, string email, DateTimeOffset registeredAt, 
                                                    Guid nationalSociety, Language language, int? birthYear, Sex? sex, 
                                                        Location location)
        {
            Register(fullname,displayname,email,registeredAt);
            RegisterDataConsumer(nationalSociety,language, sex, birthYear, location);
        }

        public void RegisterNewDataVerifier(string fullname, string displayname, string email, DateTimeOffset registeredAt, 
                                                Guid nationalSociety, Language language, IEnumerable<string> phoneNumbers, 
                                                int? birthYear, Sex? sex, Location location)
        {
            Register(fullname,displayname,email,registeredAt);
            RegisterStaffDataVerifier(nationalSociety,language, sex, birthYear, location);
            RegisterPhoneNumbers(phoneNumbers);
        }


        #endregion



        private void RegisterAssignedToNationalSocieties(IEnumerable<Guid> assignedNationalSocieties)
        {
            foreach(var nationalSociety in assignedNationalSocieties)
            {
                Apply(new NationalSocietyAssigned(EventSourceId,nationalSociety));
            }
        }
        //TODO: from woksin: Make this public? I think that there we can receive a command that adds phone numbers to user
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
                                                Location location)
        {
            var sex_ = sex.HasValue ? (int)sex.Value : Constants.NOT_KNOWN;
            var year = yearOfBirth.HasValue ? yearOfBirth.Value : Constants.NOT_KNOWN;
            Apply(new StaffDataVerifierRegistered(EventSourceId,nationalSociety,(int)language,sex_,year,
                                                    location.Latitude, location.Longitude));
        }

        private void RegisterDataConsumer(Guid nationalSociety, Language language, Sex? sex, int? yearOfBirth, 
                                        Location location)
        {
            var sex_ = sex.HasValue ? (int)sex.Value : Constants.NOT_KNOWN;
            var year = yearOfBirth.HasValue ? yearOfBirth.Value : Constants.NOT_KNOWN;
            Apply(new StaffDataConsumerRegistered(EventSourceId,nationalSociety,(int)language,sex_,year,
                                            location.Latitude, location.Longitude));
        }
        //TODO: from woksin: Shouldn't this be private?
        void Register(string fullname, string displayname, string email, DateTimeOffset registeredAt)
        {
            if(_isRegistered)
                throw new UserAlreadyRegistered($"User '{EventSourceId}' {email} {displayname} is already registered.");
            
            Apply(new NewUserRegistered(EventSourceId, fullname, displayname, email, registeredAt));
        }

        #region On Methods

        private void On(NewUserRegistered @event)
        {
            _isRegistered = true;
        }

        #endregion

    }
}