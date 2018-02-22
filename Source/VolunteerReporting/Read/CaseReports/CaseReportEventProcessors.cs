using Concepts;
using doLittle.Events.Processing;
using doLittle.Time;
using Events;
using System.Threading.Tasks;

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
        
        public async Task Process(CaseReportReceived @event)
        {
            // Save CaseReport in the CaseReports DB
            var caseReport = new CaseReport(@event.CaseReportId)
            {
                DataCollectorId = @event.DataCollectorId,
                HealthRiskId = @event.HealthRiskId,
                NumberOfFemalesUnder5 = @event.NumberOfFemalesUnder5,
                NumberOfFemalesOver5 = @event.NumberOfFemalesOver5,
                NumberOfMalesUnder5 = @event.NumberOfMalesUnder5,
                NumberOfMalesOver5 = @event.NumberOfMalesOver5,
                Location = new Location(@event.Latitude, @event.Longitude),
                Timestamp = @event.Timestamp
            };
            await _caseReports.Save(caseReport);
        }
        public async Task Process(CaseReportFromUnknownDataCollectorReceived @event)
        {
            // Save CaseReport in the CaseReportsFromUnkown... DB
            var caseReport = new CaseReportFromUnknownDataCollector(@event.CaseReportId)
            {
                Origin = @event.Origin,
                HealthRiskId = @event.HealthRiskId,
                NumberOfFemalesUnder5 = @event.NumberOfFemalesUnder5,
                NumberOfFemalesOver5 = @event.NumberOfFemalesOver5,
                NumberOfMalesUnder5 = @event.NumberOfMalesUnder5,
                NumberOfMalesOver5 = @event.NumberOfMalesOver5,
                Timestamp = @event.Timestamp
            };
            await _caseReportsFromUnknownDataCollectors.Save(caseReport);
        }   
        
        public async Task Process(CaseReportIdentified @event)
        {
            await _caseReportsFromUnknownDataCollectors.Remove(@event.CaseReportId);            
        }
    }
}
