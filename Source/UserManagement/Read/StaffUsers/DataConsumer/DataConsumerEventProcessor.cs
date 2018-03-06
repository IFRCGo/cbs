using System.Threading.Tasks;
using Concepts;
using doLittle.Events.Processing;
using Events.StaffUser;
using Events.StaffUser.Registration;

namespace Read.StaffUsers.DataConsumer
{
    public class DataConsumerEventProcessor : ICanProcessEvents
    {
        private readonly IDataConsumers _dataConsumers;

        public DataConsumerEventProcessor(
            IDataConsumers dataConsumers
        )
        {
            _dataConsumers = dataConsumers;
        }

        public async Task Process(StaffDataConsumerRegistered @event)
        {
            await _dataConsumers.SaveAsync(new DataConsumer(
                @event.StaffUserId,
                new Location(@event.Latitude, @event.Longitude),
                @event.NationalSociety,
                (Language)@event.PreferredLanguage,
                @event.BirthYear,
                (Sex)@event.Sex 
                ));
        }

        //TODO: Update to the new system
        //public async Task Process(StaffUserDeleted @event)
        //{
        //    if ((Role)@event.Role == Role.DataConsumer)
        //        await _dataConsumers.RemoveAsync(@event.StaffUserId);
        //}
    }
}