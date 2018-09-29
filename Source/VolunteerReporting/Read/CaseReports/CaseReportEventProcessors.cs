using Concepts;
using Concepts.DataCollector;
using Dolittle.Events.Processing;
using Events;
using Concepts.CaseReport;
using Events.CaseReports;

namespace Read.CaseReports
{
    public class CaseReportEventProcessor : ICanProcessEvents
    {
        readonly ICaseReports _caseReports;
        readonly ICaseReportsFromUnknownDataCollectors _caseReportsFromUnknownDataCollectors;

        public CaseReportEventProcessor(
            ICaseReports caseReports,
            ICaseReportsFromUnknownDataCollectors caseReportsFromUnknownDataCollectors)
        {
            _caseReports = caseReports;
            _caseReportsFromUnknownDataCollectors = caseReportsFromUnknownDataCollectors;
        }
        [EventProcessor("7f3b6037-6b2f-448b-8f14-0735330a50e0")]
        public void Process(CaseReportReceived @event)
        {
            var caseReport = new CaseReport(@event.CaseReportId)
            {
                DataCollectorId = @event.DataCollectorId,
                HealthRiskId = @event.HealthRiskId,
                NumberOfFemalesUnder5 = @event.NumberOfFemalesUnder5,
                NumberOfFemalesAged5AndOlder = @event.NumberOfFemalesAged5AndOlder,
                NumberOfMalesUnder5 = @event.NumberOfMalesUnder5,
                NumberOfMalesAged5AndOlder = @event.NumberOfMalesAged5AndOlder,
                Location = new Location(@event.Latitude, @event.Longitude),
                Timestamp = @event.Timestamp,
                Message = @event.Message
            };
            _caseReports.Update(caseReport);
        }
        [EventProcessor("980f8db1-2e3a-4609-b7e6-29cee5190ea8")]
        public void Process(CaseReportFromUnknownDataCollectorReceived @event)
        {
            // Save CaseReport in the CaseReportsFromUnkown... DB
            var caseReport = new CaseReportFromUnknownDataCollector(@event.CaseReportId)
            {
                Origin = @event.Origin,
                HealthRiskId = @event.HealthRiskId,
                NumberOfFemalesUnder5 = @event.NumberOfFemalesUnder5,
                NumberOfFemalesAged5AndOlder = @event.NumberOfFemalesAged5AndOlder,
                NumberOfMalesUnder5 = @event.NumberOfMalesUnder5,
                NumberOfMalesAged5AndOlder = @event.NumberOfMalesAged5AndOlder,
                Timestamp = @event.Timestamp,
                Message = @event.Message
            };
            _caseReportsFromUnknownDataCollectors.Update(caseReport);
        }   
        [EventProcessor("cc5e94eb-7944-419d-9637-1a6807e8991c")]
        public void Process(CaseReportIdentified @event)
        {
            _caseReportsFromUnknownDataCollectors.Delete(e => e.Id == (CaseReportId)@event.CaseReportId);            
        }
    }
}
