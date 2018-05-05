using Dolittle.Domain;
using System;
using System.Collections.Generic;
using Concepts;
using Domain.StaffUser.Changing;
using Domain.StaffUser.Registering;
using Events.StaffUser;
using Events.StaffUser.Changing;
using Events.StaffUser.Registration;

namespace Domain.StaffUser
{
    public class StaffUser : AggregateRoot
    {
        private bool _isRegistered;
        
        public StaffUser(Guid staffUserId) : base(staffUserId)
        {}

        #region Visible Registration Commands

        public void RegisterNewAdminUser(string fullname, string displayname, string email, DateTimeOffset registeredAt)
        {
            Register(fullname, displayname, email, registeredAt);
            

            RegisterAdmin(fullname, displayname, email, registeredAt);
        }

        public void RegisterNewSystemConfigurator(string fullname, string displayname, string email, 
                                                    Guid nationalSociety, Language language, IEnumerable<string> phoneNumbers, 
                                                        IEnumerable<Guid> assignedTo, int? birthYear, Sex? sex, DateTimeOffset registeredAt)
        {
           
            Register(fullname, displayname, email, registeredAt);
            

            RegisterSystemConfigurator(fullname, displayname, email, registeredAt, nationalSociety, language, sex, birthYear);

            foreach (var number in phoneNumbers)
            {
                Apply(new PhoneNumberAddedToSystemConfigurator(
                    EventSourceId,
                    number
                ));
            }

            foreach (var _nationalSociety in assignedTo)
            {
                Apply(new NationalSocietyAssignedToSystemConfigurator(
                    EventSourceId,
                    _nationalSociety
                    ));
            }
            
        }

        public void RegisterNewDataCoordinator(string fullname, string displayname, string email, 
                                                Guid nationalSociety, Language language, IEnumerable<string> phoneNumbers, 
                                                    IEnumerable<Guid> assignedTo, int? birthYear, Sex? sex, DateTimeOffset registeredAt)
        {
            
            Register(fullname, displayname, email, registeredAt);
            

            RegisterDataCoordinator(fullname, displayname, email, registeredAt, nationalSociety, language, sex, birthYear);

            foreach (var number in phoneNumbers)
            {
                Apply(new PhoneNumberAddedToDataCoordinator(
                    EventSourceId,
                    number
                ));
            }

            foreach (var _nationalSociety in assignedTo)
            {
                Apply(new NationalSocietyAssignedToDataCoordinator(
                    EventSourceId,
                    _nationalSociety
                    ));
            }
        }
    
        public void RegisterNewDataOwner(string fullname, string displayname, string email, 
                                            Guid nationalSociety, Language language, IEnumerable<string> phoneNumbers, int? birthYear, 
                                                Sex? sex, string position, string dutyStation, DateTimeOffset registeredAt)
        {
            
            Register(fullname, displayname, email, registeredAt);
            

            RegisterDataOwner(fullname, displayname, email, registeredAt, nationalSociety, language, sex, birthYear, position, dutyStation);

            foreach (var number in phoneNumbers)
            {
                Apply(new PhoneNumberAddedToDataOwner(
                    EventSourceId,
                    number
                ));
            }
        }

        public void RegisterNewDataConsumer(string fullname, string displayname, string email, 
                                                    Guid nationalSociety, Language language, int? birthYear, Sex? sex, 
                                                        Location location, DateTimeOffset registeredAt)
        {
            
            Register(fullname, displayname, email, registeredAt);
            

            RegisterDataConsumer(fullname, displayname, email, registeredAt, nationalSociety, language, sex, birthYear, location);
        }

        public void RegisterNewDataVerifier(string fullname, string displayname, string email, 
                                                Guid nationalSociety, Language language, IEnumerable<string> phoneNumbers, 
                                                int? birthYear, Sex? sex, Location location, DateTimeOffset registeredAt)
        {
            
            Register(fullname, displayname, email, registeredAt);
           
            RegisterStaffDataVerifier(fullname, displayname, email, registeredAt, nationalSociety, language, sex, birthYear, location);

            foreach (var number in phoneNumbers)
            {
                Apply(new PhoneNumberAddedToDataVerifier(
                    EventSourceId,
                    number
                    ));
            }
        }

        #endregion

        #region Changing-Commands

        public void AddAssignedNationalSociety(Guid nationalSociety, Role role)
        {
            switch (role)
            {
                case Role.DataCoordinator:
                    Apply(new NationalSocietyAssignedToDataCoordinator(
                        EventSourceId,
                        nationalSociety
                        ));
                    break;
                case Role.SystemConfigurator:
                    Apply(new NationalSocietyAssignedToSystemConfigurator(
                        EventSourceId,
                        nationalSociety
                    ));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(role), role, "This role does not have assigned national societies");
            }
        }

        public void RemoveAssignedNationalSociety(Guid nationalSociety, Role role)
        {
            switch (role)
            {
                case Role.DataCoordinator:
                    Apply(new NationalSocietyDeasignedFromDataCoordinator(
                        EventSourceId,
                        nationalSociety
                    ));
                    break;
                case Role.SystemConfigurator:
                    Apply(new NationalSocietyDeasignedFromSystemConfigurator(
                        EventSourceId,
                        nationalSociety
                    ));
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(role), role, "This role does not have assigned national societies");
            }
        }

        public void ChangeAdminInformation(string fullName, string displayName, string email)
        {
            Apply(new BaseUserInformationChanged(
                EventSourceId,
                fullName,
                displayName,
                email
                ));
        }

        public void ChangeDataOwnerInformation(string position, string dutyStation)
        {
            Apply(new DataOwnerInformationChanged(
                EventSourceId,
                dutyStation,
                position
                ));
        }

        public void ChangeLocation(Location location, Role role)
        {
            switch (role)
            {
                case Role.DataVerifier:
                    Apply(new DataVerifierLocationChanged(
                        EventSourceId,
                        location.Latitude,
                        location.Longitude
                    ));
                    break;
                case Role.DataConsumer:
                    Apply(new DataConsumerLocationChanged(
                        EventSourceId,
                        location.Latitude,
                        location.Longitude
                        ));
                    break;
               
                default:
                    //TODO: Create a new exception
                    throw new ArgumentOutOfRangeException(nameof(role), role, "This role does not have a location");
            }
        }

        public void ChangeNationalSociety(Guid nationalSociety, Role role)
        {
            switch (role)
            {
                case Role.DataVerifier:
                    Apply(new DataVerifierNationalSocietyChanged(
                        EventSourceId,
                        nationalSociety
                        ));
                    break;
                
                case Role.DataCoordinator:
                    Apply(new DataCoordinatorNationalSocietyChanged(
                        EventSourceId,
                        nationalSociety
                    ));
                    break;
                case Role.SystemConfigurator:
                    Apply(new SystemConfiguratorNationalSocietyChanged(
                        EventSourceId,
                        nationalSociety
                    ));
                    break;
                case Role.DataOwner:
                    Apply(new DataOwnerNationalSocietyChanged(
                        EventSourceId,
                        nationalSociety
                    ));
                    break;

                default:
                    //TODO: Create new exception
                    throw new ArgumentOutOfRangeException(nameof(role), role, "This role does not have a national society");
            }
        }

        public void ChangePreferredLanguage(Language language, Role role)
        {
            switch (role)
            {
                case Role.DataVerifier:
                    Apply(new DataVerifierPreferredLanguageChanged(
                        EventSourceId,
                        (int)language
                    ));
                    break;

                case Role.DataCoordinator:
                    Apply(new DataCoordinatorPreferredLanguageChanged(
                        EventSourceId,
                        (int)language
                    ));
                    break;
                case Role.SystemConfigurator:
                    Apply(new SystemConfiguratorPreferredLanguageChanged(
                        EventSourceId,
                        (int)language
                    ));
                    break;
                case Role.DataOwner:
                    Apply(new DataOwnerPreferredLanguageChanged(
                        EventSourceId,
                        (int)language
                    ));
                    break;

                default:
                    //TODO: Create new exception
                    throw new ArgumentOutOfRangeException(nameof(role), role, "This role does not have a preferred language");
            }
        }

        #endregion

        #region Private Register-methods

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
            {
                throw new UserAlreadyRegistered(
                    $"User '{EventSourceId}' {fullname} {email} {displayname} is already registered.");
            }

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