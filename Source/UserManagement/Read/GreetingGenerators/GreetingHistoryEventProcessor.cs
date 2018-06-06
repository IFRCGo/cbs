using Dolittle.Events.Processing;
using Events;
using Events.DataCollector;

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

        public async void Process(MessageGenerated @event)
        {
            var greetingHistory = await _greetingHistories.GetByPhoneNumberAsync(@event.PhoneNumber) ??
                                  new GreetingHistory(@event.DataCollectorId);
            greetingHistory.PhoneNumber = @event.PhoneNumber;

            _greetingHistories.Update(greetingHistory);
        }

        public async void Process(PhoneNumberAddedToDataCollector @event)
        {
            var greetingHistory = await _greetingHistories.GetByPhoneNumberAsync(@event.PhoneNumber) ?? new GreetingHistory(@event.DataCollectorId);
            greetingHistory.PhoneNumber = @event.PhoneNumber; // Todo: THis does nothing if GetByPhoneNumberAsync doesn't return nul
            await _greetingHistories.UpdateAsync(greetingHistory);
            
        }

        public async void Process(PhoneNumberRemovedFromDataCollector @event)
        {
             await _greetingHistories.RemoveAsync(@event.PhoneNumber);
           
        }
    }
}
