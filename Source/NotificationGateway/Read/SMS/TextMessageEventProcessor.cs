using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.SMS;

namespace Read.SMS
{
    public class TextMessageEventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<ReceivedMessage> _repositoryForReceivedMessage;

        public TextMessageEventProcessor(
            IReadModelRepositoryFor<ReceivedMessage> repositoryForReceivedMessage            
        )
        {
            _repositoryForReceivedMessage = repositoryForReceivedMessage;
        }
        
        [EventProcessor("9a6bee58-b117-2589-e81d-e79ceb37cbaa")]
        public void Process(TextMessageReceived @event)
        { 
            _repositoryForReceivedMessage.Insert(new ReceivedMessage{
                Id = @event.Id,
                Sender = @event.Sender,
                Text = @event.Text,
                Received = @event.Received,
            });
        }
        
    }
}
