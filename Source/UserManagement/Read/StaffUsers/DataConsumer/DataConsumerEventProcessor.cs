using System.Threading.Tasks;
using Concepts;
using doLittle.Events.Processing;
using Events.StaffUser;

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

        public async Task Process(DataConsumerAdded @event)
        {
            await _dataConsumers.SaveAsync(new DataConsumer
            {
                Location = new Location(@event.LocationLatitude, @event.LocationLongitude),
                DisplayName = @event.DisplayName,
                Email = @event.Email,
                FullName = @event.Email,
                Id = @event.StaffUserId
            });
        }

        public async Task Process(StaffUserDeleted @event)
        {
            if ((Role)@event.Role == Role.DataConsumer)
                await _dataConsumers.RemoveAsync(@event.StaffUserId);
        }
    }
}