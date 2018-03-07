using Concepts;
using doLittle.Events.Processing;
using Events.StaffUser.Registration;
using Read.StaffUsers.Models;
namespace Read.StaffUsers
{
    public class UserEventProcessor : ICanProcessEvents
    {
        private IStaffUsers _collection;

        public UserEventProcessor(IStaffUsers collection)
        {
            _collection = collection;
        }

        public void Process(NewUserRegistered @event)
        {
            _collection.Save(new Admin (
                    @event.StaffUserId,
                    @event.FullName,
                    @event.DisplayName,
                    @event.Email,
                    @event.RegisteredAt
                ));
        }

        public void Process(StaffDataConsumerRegistered @event)
        {
            var baseUser = _collection.GetById<BaseUser>(@event.StaffUserId);
            _collection.Save(new DataConsumer(
                @event.StaffUserId,
                baseUser.FullName,
                baseUser.DisplayName,
                baseUser.Email,
                baseUser.RegistrationDate,
                new Location(@event.Latitude, @event.Longitude),
                @event.NationalSociety,
                (Language)@event.PreferredLanguage,
                @event.BirthYear,
                (Sex)@event.Sex
                ));
        }
        public void Process(DataCoordinatorRegistered @event)
        {
            var baseUser = _collection.GetById<BaseUser>(@event.StaffUserId);
            _collection.Save(new DataCoordinator(
                @event.StaffUserId,
                baseUser.FullName,
                baseUser.DisplayName,
                baseUser.Email,
                baseUser.RegistrationDate,
                @event.BirthYear,
                (Sex)@event.Sex,
                @event.NationalSociety,
                (Language)@event.PreferredLanguage
            ));
        }
        public void Process(DataOwnerRegistered @event)
        {
            var baseUser = _collection.GetById<BaseUser>(@event.StaffUserId);
            _collection.Save(new DataOwner(
                @event.StaffUserId,
                baseUser.FullName,
                baseUser.DisplayName,
                baseUser.Email,
                baseUser.RegistrationDate,
                @event.BirthYear,
                (Sex)@event.Sex,
                @event.NationalSociety,
                (Language)@event.PreferredLanguage,
                new Location(@event.Latitude, @event.Longitude),
                @event.Position,
                @event.DutyStation
            ));
        }
        public void Process(StaffDataVerifierRegistered @event)
        {
            var baseUser = _collection.GetById<BaseUser>(@event.StaffUserId);
            _collection.Save(new DataVerifier(
                @event.StaffUserId,
                baseUser.FullName,
                baseUser.DisplayName,
                baseUser.Email,
                baseUser.RegistrationDate,
                @event.BirthYear,
                (Sex)@event.Sex,
                @event.NationalSociety,
                (Language)@event.PreferredLanguage,
                new Location(@event.Latitude, @event.Longitude)
            ));
        }
        public void Process(SystemConfiguratorRegistered @event)
        {
            var baseUser = _collection.GetById<BaseUser>(@event.StaffUserId);
            _collection.Save(new SystemConfigurator(
                @event.StaffUserId,
                baseUser.FullName,
                baseUser.DisplayName,
                baseUser.Email,
                baseUser.RegistrationDate,
                @event.BirthYear,
                (Sex)@event.Sex,
                @event.NationalSociety,
                (Language)@event.PreferredLanguage
            ));
        }
    }
}