using Concepts;
using Dolittle.Events.Processing;
using Events.StaffUser;
using Events.StaffUser.Registration;

namespace Read.StaffUsers
{
    public class UserEventProcessor : ICanProcessEvents
    {
        private readonly IStaffUserRepositoryContext _context;

        public UserEventProcessor(IStaffUserRepositoryContext context)
        {
            _context = context;
        }

        public void Process(AdminRegistered @event)
        {
            _context.AdminRepository.Insert(new Models.Admin(
                @event.StaffUserId,
                @event.FullName,
                @event.DisplayName,
                @event.Email,
                @event.RegisteredAt
            ));
        }
        public void Process(StaffDataConsumerRegistered @event)
        {
            _context.DataConsumerRepository.Insert(new Models.DataConsumer(
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
            _context.DataCoordinatorRepository.Insert(new Models.DataCoordinator(
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
            _context.DataOwnerRepository.Insert(new Models.DataOwner(
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
            _context.DataVerifierRepository.Insert(new Models.DataVerifier(
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
            _context.SystemConfiguratorRepository.Insert(new Models.SystemConfigurator(
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
            _context.DataCoordinatorRepository.AddPhoneNumber(@event.StaffUserId, @event.PhoneNumber);
        }

        public void Process(PhoneNumberRemovedFromDataCoordinator @event)
        {
            _context.DataCoordinatorRepository.RemovePhoneNumber(@event.StaffUserId, @event.PhoneNumber);
        }

        public void Process(NationalSocietyAssignedToDataCoordinator @event)
        {
            _context.DataCoordinatorRepository.AddAssignedNationalSociety(@event.StaffUserId, @event.NationalSociety);
        }
    }
}