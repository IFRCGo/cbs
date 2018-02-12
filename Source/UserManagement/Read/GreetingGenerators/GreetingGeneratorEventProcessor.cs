using Concepts;
using doLittle.Domain;
using doLittle.Events.Processing;
using Events;
using Events.External;
using Read.DataCollectors;

namespace Read.GreetingGenerators
{
    public class GreetingGeneratorEventProcessor : ICanProcessEvents
    {

        readonly IGreetingHistories _greetingHistories;
        readonly IDataCollectors _dataCollectors;
        readonly IAggregateRootRepositoryFor<Domain.MessageGenerators.MessageGenerator> _messageGeneratorsAggregateRootRepository;

        public GreetingGeneratorEventProcessor(
            IGreetingHistories greetingHistories,
            IDataCollectors dataCollectors,
            IAggregateRootRepositoryFor<Domain.MessageGenerators.MessageGenerator> messageGeneratorsAggregateRootRepository)
        {
            _greetingHistories = greetingHistories;
            _dataCollectors = dataCollectors;
            _messageGeneratorsAggregateRootRepository = messageGeneratorsAggregateRootRepository;
        }

        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);

            // Todo Get the correct welcome message based on the dataCollector.PreferredLanguage
            var welcomeMessage = "Welcome!";

            var smsGenerator = _greetingHistories.GetByPhoneNumber(@event.PhoneNumber);
            if (smsGenerator != null)
            {
                return;
            }

            var smsGeneratorAggregateRootRepository = _messageGeneratorsAggregateRootRepository.Get(@event.Id);
            smsGeneratorAggregateRootRepository.GenerateMessage(new Domain.MessageGenerators.GenerateMessage()
            {
                Id = @event.Id,
                Message = welcomeMessage,
                PhoneNumber = @event.PhoneNumber
            });
        }
    }
}
