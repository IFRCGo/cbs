using Dolittle.Events.Processing;
using Events;
using Events.DataCollector;
using Events.MessageGenerator;

namespace Read.GreetingGenerators
{
    public class GreetingHistoryEventProcessor : ICanProcessEvents 
    {
        readonly IGreetingHistories _greetingHistories;

        public GreetingHistoryEventProcessor(IGreetingHistories greetingHistories)
        {
            _greetingHistories = greetingHistories;
        }
        
        //TODO: QUESTION: Shouldn't this listen to MessageGenerated-event?

        public void Process(MessageGenerated @event)
        {
            var greetingHistory = _greetingHistories.GetByPhoneNumber(@event.PhoneNumber) ??
                                  new GreetingHistory(@event.DataCollectorId);
            greetingHistory.PhoneNumber = @event.PhoneNumber;

            _greetingHistories.Update(greetingHistory);
        }

        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            var greetingHistory = _greetingHistories.GetByPhoneNumber(@event.PhoneNumber) ?? new GreetingHistory(@event.DataCollectorId);
            greetingHistory.PhoneNumber = @event.PhoneNumber; // Todo: THis does nothing if GetByPhoneNumberAsync doesn't return nul
            _greetingHistories.Update(greetingHistory);
            
        }

        public void Process(PhoneNumberRemovedFromDataCollector @event)
        {
            _greetingHistories.Remove(@event.PhoneNumber);
           
        }
    }
}
