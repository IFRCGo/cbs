using Dolittle.Domain;
using Dolittle.Events.Processing;
using Read.DataCollectors;
using Domain.MessageGenerator;
using Events.DataCollector;

namespace Policies.GreetingGenerators
{
    using Read.GreetingGenerators;

    public class GreetingGeneratorEventProcessor : ICanProcessEvents
    {
        readonly IGreetingHistories _greetingHistories;
        readonly IDataCollectors _dataCollectors;
        readonly IAggregateRootRepositoryFor<MessageGenerator> _messageGeneratorsAggregateRootRepository;

        public GreetingGeneratorEventProcessor(
            IGreetingHistories greetingHistories,
            IDataCollectors dataCollectors,
            IAggregateRootRepositoryFor<MessageGenerator> messageGeneratorsAggregateRootRepository)
        {
            _greetingHistories = greetingHistories;
            _dataCollectors = dataCollectors;
            _messageGeneratorsAggregateRootRepository = messageGeneratorsAggregateRootRepository;
        }
        public async void Process(PhoneNumberAddedToDataCollector @event)
        {
            var dataCollector = await _dataCollectors.GetByIdAsync(@event.DataCollectorId);

            // Todo Get the correct welcome message based on the dataCollector.PreferredLanguage
            var welcomeMessage = "Welcome!";

            
            var smsGenerator = await _greetingHistories.GetByPhoneNumberAsync(@event.PhoneNumber);
            if (smsGenerator != null)
            {
                return;// TODO: Something should be thrown
            }

            var smsGeneratorAggregateRootRepository = _messageGeneratorsAggregateRootRepository.Get(@event.DataCollectorId);
            smsGeneratorAggregateRootRepository.GenerateMessage(new GenerateMessage
            {
                Id = @event.DataCollectorId,
                Message = welcomeMessage,
                PhoneNumber = @event.PhoneNumber
            });
            
            
        }
    }
}
