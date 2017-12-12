using Concepts;
using doLittle.Events.Processing;
using doLittle.Time;
using Events;

namespace Read.CaseReports
{
    public class CaseReportEventProcessor : ICanProcessEvents
    {
        readonly ICaseReports _caseReports;
        readonly ICaseReportsFromUnknownDataCollectors _caseReportsFromUnknownDataCollectors;
        readonly ISystemClock _systemClock;

        public CaseReportEventProcessor(
            ICaseReports caseReports,
            ICaseReportsFromUnknownDataCollectors caseReportsFromUnknownDataCollectors,
            ISystemClock systemClock)
        {
            _caseReports = caseReports;
            _caseReportsFromUnknownDataCollectors = caseReportsFromUnknownDataCollectors;
            _systemClock = systemClock;
        }

        public void Process(CaseReportReceived @event)
        {
            var caseReport = new CaseReport(@event.CaseReportId);
            caseReport.DataCollectorId = @event.DataCollectorId;
            caseReport.HealthRiskId = @event.HealthRiskId;
            caseReport.NumberOfFemalesUnder5 = @event.NumberOfFemalesUnder5;
            caseReport.NumberOfFemalesOver5 = @event.NumberOfFemalesOver5;
            caseReport.NumberOfMalesUnder5 = @event.NumberOfMalesUnder5;
            caseReport.NumberOfMalesOver5 = @event.NumberOfMalesOver5;
            caseReport.Location = new Location(@event.Latitude, @event.Longitude);
            caseReport.Timestamp = @event.Timestamp;
            _caseReports.Save(caseReport);
        }
        public void Process(CaseReportFromUnknownDataCollectorReceived @event)
        {
            var caseReport = new CaseReportFromUnknownDataCollector(@event.CaseReportId);
            caseReport.Origin = @event.Origin;
            caseReport.HealthRiskId = @event.HealthRiskId;
            caseReport.NumberOfFemalesUnder5 = @event.NumberOfFemalesUnder5;
            caseReport.NumberOfFemalesOver5 = @event.NumberOfFemalesOver5;
            caseReport.NumberOfMalesUnder5 = @event.NumberOfMalesUnder5;
            caseReport.NumberOfMalesOver5 = @event.NumberOfMalesOver5;
            caseReport.Timestamp = @event.Timestamp;
            caseReport.Location = new Location(@event.Latitude, @event.Longitude);
            _caseReportsFromUnknownDataCollectors.Save(caseReport);
        }        
    }
}
