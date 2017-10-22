using doLittle.Domain;
using Events;

namespace Domain.TextMessages
{
    public class CaseReporting : AggregateRoot
    {
        public CaseReporting(EventSourceId eventSourceId) : base(eventSourceId)
        {

        }


        public void UnknownMessage()
        {

            Apply(new UnknownMessageReceived 
            {
                Id = eventSourceId,

            });

        }
        
    }
}