using doLittle.Domain;
using doLittle.Events.Processing;
using Read.DataCollectors;
using Domain.MessageGenerator;
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
        /*TODO: What is this class? I would suggest to have another system for adding WelcomeMessages to datacollectors
        public async void Process(PhoneNumberAddedToDataCollector @event)
        {
            var dataCollector = await _dataCollectors.GetByIdAsync(@event.DataCollectorId);

            // Todo Get the correct welcome message based on the dataCollector.PreferredLanguage
            var welcomeMessage = "Welcome!";

            var smsGenerator =await  _greetingHistories.GetByPhoneNumberAsync(@event.PhoneNumber);
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
        */
    }
}
