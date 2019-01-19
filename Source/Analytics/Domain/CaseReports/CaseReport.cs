using System;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.VolunteerReporting.CaseReports;

namespace Domain.CaseReports
{
    public class CaseReport : AggregateRoot
    {
        public CaseReport(EventSourceId id) : base(id)
        { 
            
        }
            public void Report(
            Guid dataCollectorId,
            Guid healthRiskId,
            string origin,
            int numberOfMalesUnder5,
            int numberOfMalesAged5AndOlder,
            int numberOfFemalesUnder5,
            int numberOfFemalesAged5AndOlder,
            double longitude,
            double latitude,
            DateTimeOffset timestamp,
            string message)
        {
            Apply(new CaseReportReceived(EventSourceId, dataCollectorId, healthRiskId, origin, message, 
                numberOfMalesUnder5, numberOfMalesAged5AndOlder, numberOfFemalesUnder5, numberOfFemalesAged5AndOlder,
                longitude, latitude, timestamp));
        }       
    }
}
