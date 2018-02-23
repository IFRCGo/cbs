using doLittle.Events.Processing;
using Events;

namespace Read.GreetingGenerators
{
    public class GreetingHistoryEventProcessor : ICanProcessEvents 
    {
        readonly IGreetingHistories _greetingHistories;

        public GreetingHistoryEventProcessor(IGreetingHistories greetingHistories)
        {
            _greetingHistories = greetingHistories;
        }

        public async void Process(PhoneNumberAddedToDataCollector @event)
        {
            var greetingHistory = await _greetingHistories.GetByPhoneNumberAsync(@event.PhoneNumber) ?? new GreetingHistory(@event.Id);
            greetingHistory.PhoneNumber = @event.PhoneNumber;
           await _greetingHistories.Save(greetingHistory);
        }

        public async void Process(PhoneNumberRemovedFromDataCollector @event)
        {
            await _greetingHistories.Remove(@event.PhoneNumber);
        }
    }
}
