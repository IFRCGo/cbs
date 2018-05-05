using Concepts;
using Dolittle.Events.Processing;
using Events.StaffUser;
using Events.StaffUser.Registration;
using Read.StaffUsers.Admin;
using Read.StaffUsers.DataConsumer;
using Read.StaffUsers.DataCoordinator;
using Read.StaffUsers.DataOwner;
using Read.StaffUsers.DataVerifier;
using Read.StaffUsers.Models;
using Read.StaffUsers.SystemConfigurator;

namespace Read.StaffUsers
{
    public class UserEventProcessor : ICanProcessEvents
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IDataCoordinatorRepository _dataCoordinatorRepository;
        private readonly IDataOwnerRepository _dataOwnerRepository;
        private readonly IDataVerifierRepository _dataVerifierRepository;
        private readonly ISystemConfiguratorRepository _systemConfiguratorRepository;
        private readonly IDataConsumerRepository _dataConsumerRepository;

        public UserEventProcessor(
            IAdminRepository adminRepository,
            IDataConsumerRepository dataConsumerRepository,
            IDataCoordinatorRepository dataCoordinatorRepository,
            IDataOwnerRepository dataOwnerRepository,
            IDataVerifierRepository dataVerifierRepository,
            ISystemConfiguratorRepository systemConfiguratorRepository)
        {
            _adminRepository = adminRepository;
            _dataCoordinatorRepository = dataCoordinatorRepository;
            _dataOwnerRepository = dataOwnerRepository;
            _dataVerifierRepository = dataVerifierRepository;
            _systemConfiguratorRepository = systemConfiguratorRepository;
            _dataConsumerRepository = dataConsumerRepository;
        }

        public void Process(AdminRegistered @event)
        {
            _adminRepository.Insert(new Models.Admin(
                @event.StaffUserId,
                @event.FullName,
                @event.DisplayName,
                @event.Email,
                @event.RegisteredAt
            ));
        }
        public void Process(StaffDataConsumerRegistered @event)
        {
            _dataConsumerRepository.Insert(new Models.DataConsumer(
                @event.StaffUserId,
                @event.FullName,
                @event.DisplayName,
                @event.Email,
                @event.RegisteredAt,
                new Location(@event.Latitude, @event.Longitude),
                @event.NationalSociety,
                (Language)@event.PreferredLanguage,
                @event.BirthYear,
                (Sex)@event.Sex
                ));
        }
        public void Process(DataCoordinatorRegistered @event)
        {
            _dataCoordinatorRepository.Insert(new Models.DataCoordinator(
                @event.StaffUserId,
                @event.FullName,
                @event.DisplayName,
                @event.Email,
                @event.RegisteredAt,
                @event.BirthYear,
                (Sex)@event.Sex,
                @event.NationalSociety,
                (Language)@event.PreferredLanguage
            ));
        }
        public void Process(DataOwnerRegistered @event)
        {
            _dataOwnerRepository.Insert(new Models.DataOwner(
                @event.StaffUserId,
                @event.FullName,
                @event.DisplayName,
                @event.Email,
                @event.RegisteredAt,
                @event.BirthYear,
                (Sex)@event.Sex,
                @event.NationalSociety,
                (Language)@event.PreferredLanguage,
                @event.Position,
                @event.DutyStation
            ));
        }
        public void Process(StaffDataVerifierRegistered @event)
        {
            _dataVerifierRepository.Insert(new Models.DataVerifier(
                @event.StaffUserId,
                @event.FullName,
                @event.DisplayName,
                @event.Email,
                @event.RegisteredAt,
                @event.BirthYear,
                (Sex)@event.Sex,
                @event.NationalSociety,
                (Language)@event.PreferredLanguage,
                new Location(@event.Latitude, @event.Longitude)
            ));
        }
        public void Process(SystemConfiguratorRegistered @event)
        {
            _systemConfiguratorRepository.Insert(new Models.SystemConfigurator(
                @event.StaffUserId,
                @event.FullName,
                @event.DisplayName,
                @event.Email,
                @event.RegisteredAt,
                @event.BirthYear,
                (Sex)@event.Sex,
                @event.NationalSociety,
                (Language)@event.PreferredLanguage
            ));
        }
        public void Process(PhoneNumberAddedToDataCoordinator @event)
        {
            _dataCoordinatorRepository.AddPhoneNumber(@event.StaffUserId, @event.PhoneNumber);
        }

        public void Process(PhoneNumberRemovedFromDataCoordinator @event)
        {
            _dataCoordinatorRepository.RemovePhoneNumber(@event.StaffUserId, @event.PhoneNumber);
        }

        public void Process(NationalSocietyAssignedToDataCoordinator @event)
        {
            _dataCoordinatorRepository.AddAssignedNationalSociety(@event.StaffUserId, @event.NationalSociety);
        }
    }
}