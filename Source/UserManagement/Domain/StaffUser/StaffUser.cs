using doLittle.Domain;
using Events.StaffUser;
using System;
using System.Collections.Generic;
using Concepts;
using Domain.StaffUser.Registering;
using Events.StaffUser.Registration;

namespace Domain.StaffUser
{
    public class StaffUser : AggregateRoot
    {
        private bool _isRegistered;

        public StaffUser(Guid staffUserId) : base(staffUserId)
        {}

        #region Visible Registration Commands

        public void RegisterNewAdminUser(bool isNewRegistration, string fullname, string displayname, string email, DateTimeOffset registeredAt)
        {
            if (isNewRegistration)
            {
                Register(fullname, displayname, email, registeredAt);
            }
            RegisterAdmin(fullname, displayname, email, registeredAt);
        }

        public void RegisterNewSystemConfigurator(bool isNewRegistration, string fullname, string displayname, string email, DateTimeOffset registeredAt, 
                                                    Guid nationalSociety, Language language, IEnumerable<string> phoneNumbers, 
                                                        IEnumerable<Guid> assignedTo, int? birthYear, Sex? sex)
        {
            if (isNewRegistration)
            {
                Register(fullname, displayname, email, registeredAt);
            }
            RegisterSystemConfigurator(fullname, displayname, email, registeredAt, nationalSociety, language, sex, birthYear);
            RegisterPhoneNumbers(phoneNumbers);
            RegisterAssignedToNationalSocieties(assignedTo);
        }

        public void RegisterNewDataCoordinator(bool isNewRegistration, string fullname, string displayname, string email, DateTimeOffset registeredAt, 
                                                Guid nationalSociety, Language language, IEnumerable<string> phoneNumbers, 
                                                    IEnumerable<Guid> assignedTo, int? birthYear, Sex? sex)
        {
            if (isNewRegistration)
            {
                Register(fullname, displayname, email, registeredAt);
            }
            RegisterDataCoordinator(fullname, displayname, email, registeredAt, nationalSociety, language, sex, birthYear);
            RegisterPhoneNumbers(phoneNumbers);
            RegisterAssignedToNationalSocieties(assignedTo);
        }
    
        public void RegisterNewDataOwner(bool isNewRegistration, string fullname, string displayname, string email, DateTimeOffset registeredAt, 
                                            Guid nationalSociety, Language language, IEnumerable<string> phoneNumbers, int? birthYear, 
                                                Sex? sex, string position, string dutyStation)
        {
            if (isNewRegistration)
            {
                Register(fullname, displayname, email, registeredAt);
            }
            RegisterDataOwner(fullname, displayname, email, registeredAt, nationalSociety, language, sex, birthYear, position, dutyStation);
            RegisterPhoneNumbers(phoneNumbers);
        }

        public void RegisterNewDataConsumer(bool isNewRegistration, string fullname, string displayname, string email, DateTimeOffset registeredAt, 
                                                    Guid nationalSociety, Language language, int? birthYear, Sex? sex, 
                                                        Location location)
        {
            if (isNewRegistration)
            {
                Register(fullname, displayname, email, registeredAt);
            }
            RegisterDataConsumer(fullname, displayname, email, registeredAt, nationalSociety, language, sex, birthYear, location);
        }

        public void RegisterNewDataVerifier(bool isNewRegistration, string fullname, string displayname, string email, DateTimeOffset registeredAt, 
                                                Guid nationalSociety, Language language, IEnumerable<string> phoneNumbers, 
                                                int? birthYear, Sex? sex, Location location)
        {
            if (isNewRegistration)
            {
                Register(fullname, displayname, email, registeredAt);
            }
            RegisterStaffDataVerifier(fullname, displayname, email, registeredAt, nationalSociety, language, sex, birthYear, location);
            RegisterPhoneNumbers(phoneNumbers);
        }


        #endregion

        #region Private Register-methods

        private void RegisterAssignedToNationalSocieties(IEnumerable<Guid> assignedNationalSocieties)
        {
            foreach(var nationalSociety in assignedNationalSocieties)
            {
                Apply(new NationalSocietyAssigned(EventSourceId, nationalSociety));
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

        private void RegisterSystemConfigurator(string fullname, string displayname, string email, DateTimeOffset registeredAt,
            Guid nationalSociety, Language language, Sex? sex, int? yearOfBirth)
        {
            var sex_ = sex.HasValue ? (int)sex.Value : Constants.NOT_KNOWN;
            var year = yearOfBirth ?? Constants.NOT_KNOWN;
            Apply(new SystemConfiguratorRegistered(EventSourceId, fullname, displayname, email, registeredAt, nationalSociety, 
                (int)language, sex_, year));
        }

        private void RegisterDataCoordinator(string fullname, string displayname, string email, DateTimeOffset registeredAt,
            Guid nationalSociety, Language language, Sex? sex, int? yearOfBirth)
        {
            var sex_ = sex.HasValue ? (int)sex.Value : Constants.NOT_KNOWN;
            var year = yearOfBirth ?? Constants.NOT_KNOWN;
            Apply(new DataCoordinatorRegistered(EventSourceId, fullname, displayname, email, registeredAt, nationalSociety, 
                (int)language, sex_, year));
        }

        private void RegisterDataOwner(string fullname, string displayname, string email, DateTimeOffset registeredAt, 
            Guid nationalSociety, Language language, Sex? sex, int? yearOfBirth, 
            string position, string dutyStation)
        {
            var sex_ = sex.HasValue ? (int)sex.Value : Constants.NOT_KNOWN;
            var year = yearOfBirth ?? Constants.NOT_KNOWN;
            Apply(new DataOwnerRegistered(EventSourceId, fullname, displayname, email, registeredAt, nationalSociety, 
                (int)language, sex_, year, position, dutyStation));
        }

        private void RegisterStaffDataVerifier(string fullname, string displayname, string email, DateTimeOffset registeredAt, 
            Guid nationalSociety, Language language, Sex? sex, int? yearOfBirth, Location location)
        {
            var sex_ = sex.HasValue ? (int)sex.Value : Constants.NOT_KNOWN;
            var year = yearOfBirth ?? Constants.NOT_KNOWN;
            Apply(new StaffDataVerifierRegistered(EventSourceId, fullname, displayname, email, registeredAt, nationalSociety, 
                (int)language, sex_, year, location.Latitude, location.Longitude));
        }

        private void RegisterDataConsumer(string fullname, string displayname, string email, DateTimeOffset registeredAt, 
            Guid nationalSociety, Language language, Sex? sex, int? yearOfBirth, Location location)
        {
            var sex_ = sex.HasValue ? (int)sex.Value : Constants.NOT_KNOWN;
            var year = yearOfBirth ?? Constants.NOT_KNOWN;
            Apply(new StaffDataConsumerRegistered(EventSourceId, fullname, displayname, email, registeredAt, nationalSociety,
                (int)language, sex_, year, location.Latitude, location.Longitude));
        }
        
        private void RegisterAdmin(string fullname, string displayname, string email, DateTimeOffset registeredAt)
        {   
            Apply(new AdminRegistered(EventSourceId, fullname, displayname, email, registeredAt));
        }

        private void Register(string fullname, string displayname, string email, DateTimeOffset registeredAt)
        {
            
            if (_isRegistered)
                throw new UserAlreadyRegistered($"User '{EventSourceId}' {fullname} {email} {displayname} is already registered.");
            Apply(new NewUserRegistered(EventSourceId, fullname, displayname, email, registeredAt));
        }
        #endregion

        #region On Methods

        private void On(NewUserRegistered @event)
        {
            _isRegistered = true;
        }

        #endregion

    }
}