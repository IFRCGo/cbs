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

        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            var greetingHistory = _greetingHistories.GetByPhoneNumber(@event.PhoneNumber) ?? new GreetingHistory(@event.Id);
            greetingHistory.PhoneNumber = @event.PhoneNumber;
            _greetingHistories.Save(greetingHistory);
        }

        public void Process(PhoneNumberRemovedFromDataCollector @event)
        {
            _greetingHistories.RemovePhoneNumber(@event.PhoneNumber);
        }
    }
}
