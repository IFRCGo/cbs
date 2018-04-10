using System.Threading.Tasks;
using Concepts;
using doLittle.Events.Processing;
using Events.StaffUser.Registration;
using Read.StaffUsers.Models;
namespace Read.StaffUsers
{
    public class UserEventProcessor : ICanProcessEvents
    {
        private readonly IStaffUsers _collection;

        public UserEventProcessor(IStaffUsers collection)
        {
            _collection = collection;
        }

        public async Task Process(AdminRegistered @event)
        {
            await _collection.SaveAsync(new Admin(
                @event.StaffUserId,
                @event.FullName,
                @event.DisplayName,
                @event.Email,
                @event.RegisteredAt
            ));
        }
        public async Task Process(StaffDataConsumerRegistered @event)
        {
            await _collection.SaveAsync(new DataConsumer(
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
        public async Task Process(DataCoordinatorRegistered @event)
        {
            await _collection.SaveAsync(new DataCoordinator(
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
        public async Task Process(DataOwnerRegistered @event)
        {
            await _collection.SaveAsync(new DataOwner(
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
        public async Task Process(StaffDataVerifierRegistered @event)
        {
            await _collection.SaveAsync(new DataVerifier(
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
        public async Task Process(SystemConfiguratorRegistered @event)
        {
            await _collection.SaveAsync(new SystemConfigurator(
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

        public void Process(PhoneNumberRegistered @event)
        {
            var baseUser = _collection.GetById<BaseUser>(@event.StaffUserId);
            try
            {
                dynamic user = baseUser;
                user.PhoneNumbers.Add(new PhoneNumber(@event.PhoneNumber));
                _collection.Save(baseUser);
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                throw new UserNotOfExpectedType($"The user with id {@event.StaffUserId} was does not have phonenumbers");
            }
        }

        public void Process(NationalSocietyAssigned @event)
        {
            var baseUser = _collection.GetById<BaseUser>(@event.StaffUserId);
            try
            {
                dynamic user = baseUser;
                user.AssignedNationalSocieties.Add(@event.NationalSociety);
                _collection.Save(baseUser);
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                throw new UserNotOfExpectedType($"The user with id {@event.StaffUserId} was does not have assigned national societies");
            }
        }
    }
}