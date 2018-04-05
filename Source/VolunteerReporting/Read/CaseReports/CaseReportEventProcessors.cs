using Concepts;
using Dolittle.Events.Processing;
using Dolittle.Time;
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
                NumberOfFemalesAges0To4 = @event.NumberOfFemalesAges0To4,
                NumberOfFemalesAgedOver4 = @event.NumberOfFemalesAgedOver4,
                NumberOfMalesAges0To4 = @event.NumberOfMalesAges0To4,
                NumberOfMalesAgedOver4 = @event.NumberOfMalesAgedOver4,
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
                NumberOfFemalesAges0To4 = @event.NumberOfFemalesAges0To4,
                NumberOfFemalesAgedOver4 = @event.NumberOfFemalesAgedOver4,
                NumberOfMalesAges0To4 = @event.NumberOfMalesAges0To4,
                NumberOfMalesAgedOver4 = @event.NumberOfMalesAgedOver4,
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
