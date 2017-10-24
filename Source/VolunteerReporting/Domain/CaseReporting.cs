using System;
using doLittle.Domain;
using doLittle.Runtime.Events;
using Concepts;
using Events;

namespace Domain
{
    public class CaseReporting : AggregateRoot
    {
        public CaseReporting(EventSourceId eventSourceId) : base(eventSourceId)
        {
        }

        public void InvalidReport(DataCollectorId collector, string originalMessage, string errorMessage)
        {
            Apply(new InvalidMessageReceived 
            {
                Id = EventSourceId,
                DataCollectorId = collector,
                Message = originalMessage,
                ParsingErrorMessage = errorMessage
            });
        }
    }
}