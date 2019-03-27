using Dolittle.Events.Processing;
using Events.Reporting.CaseReports;
using Read.CaseReports;

namespace Read.Dolittle.CaseReports
{
    public class CaseReportsEventProcessor : ICanProcessEvents
    {
        private readonly ICaseReportsEventHandler _caseReportsEventHandler;

        public CaseReportsEventProcessor(ICaseReportsEventHandler caseReportsEventHandler){
            _caseReportsEventHandler = caseReportsEventHandler;
        }

       [EventProcessor("cb01aaaf-7998-4692-81ef-1ceb5ab38e12")]
        public void Process(CaseReportReceived @event)
        {
            var caseReport = new Read.CaseReports.CaseReport(@event.CaseReportId, @event.DataCollectorId, 
            @event.HealthRiskId, @event.Origin, @event.Message, @event.NumberOfMalesUnder5, @event.NumberOfMalesAged5AndOlder, 
            @event.NumberOfFemalesUnder5, @event.NumberOfFemalesAged5AndOlder, @event.Longitude, @event.Latitude,
            @event.Timestamp);
            
            _caseReportsEventHandler.Handle(caseReport);
        }
    }
}