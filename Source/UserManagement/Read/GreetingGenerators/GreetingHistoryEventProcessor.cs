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
        [EventProcessor("7ea881cf-ece0-4532-9b36-408dc53ccac6")]
        public void Process(MessageGenerated @event)
        {
            var greetingHistory = _greetingHistories.GetByPhoneNumber(@event.PhoneNumber) ??
                                  new GreetingHistory(@event.DataCollectorId);
            greetingHistory.PhoneNumber = @event.PhoneNumber;

            _greetingHistories.Update(greetingHistory);
        }
        [EventProcessor("328fe174-78c8-4944-88ec-dc620d694ef8")]
        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            var greetingHistory = _greetingHistories.GetByPhoneNumber(@event.PhoneNumber) ?? new GreetingHistory(@event.DataCollectorId);
            greetingHistory.PhoneNumber = @event.PhoneNumber; // Todo: THis does nothing if GetByPhoneNumberAsync doesn't return nul
            _greetingHistories.Update(greetingHistory);
            
        }
        [EventProcessor("f6a2bf79-6b73-4f35-8094-e792ea27546f")]
        public void Process(PhoneNumberRemovedFromDataCollector @event)
        {
            _greetingHistories.Remove(@event.PhoneNumber);
           
        }
    }
}
