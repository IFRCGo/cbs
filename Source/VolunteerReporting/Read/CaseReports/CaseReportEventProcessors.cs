using Events;
using System;
using System.Collections.Generic;
using System.Text;
using doLittle.Events.Processing;
using Concepts;
using doLittle.Time;

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
            caseReport.NumberOfFemalesUnder5 = @event.Age <= 5 && (Sex)@event.Sex == Sex.Female ? 1 : 0;
            caseReport.NumberOfFemalesOver5 = @event.Age > 5 && (Sex)@event.Sex == Sex.Female ? 1 : 0;
            caseReport.NumberOfMalesUnder5 = @event.Age <= 5 && (Sex)@event.Sex == Sex.Male ? 1 : 0;
            caseReport.NumberOfMalesOver5 = @event.Age > 5 && (Sex)@event.Sex == Sex.Male ? 1 : 0;
            caseReport.Location = new Location(@event.Latitude, @event.Longitude);
            _caseReports.Save(caseReport);
        }

        public void Process(MultipleCaseReportsReceived @event)
        {
            var caseReport = new CaseReport(@event.CaseReportId);
            caseReport.DataCollectorId = @event.DataCollectorId;
            caseReport.HealthRiskId = @event.HealthRiskId;
            caseReport.NumberOfFemalesUnder5 = @event.NumberOfFemalesUnder5;
            caseReport.NumberOfFemalesOver5 = @event.NumberOfFemalesOver5;
            caseReport.NumberOfMalesUnder5 = @event.NumberOfFemalesUnder5;
            caseReport.NumberOfMalesOver5 = @event.NumberOfMalesOver5;
            caseReport.Location = new Location(@event.Latitude, @event.Longitude);
            _caseReports.Save(caseReport);
        }


        public void Process(CaseReportFromUnknownDataCollectorReceived @event)
        {
            var caseReport = new CaseReportFromUnknownDataCollector(@event.CaseReportId);
            caseReport.Origin = @event.Origin;
            caseReport.HealthRiskId = @event.HealthRiskId;
            caseReport.NumberOfFemalesUnder5 = @event.Age <= 5 && (Sex)@event.Sex == Sex.Female ? 1 : 0;
            caseReport.NumberOfFemalesOver5 = @event.Age > 5 && (Sex)@event.Sex == Sex.Female ? 1 : 0;
            caseReport.NumberOfMalesUnder5 = @event.Age <= 5 && (Sex)@event.Sex == Sex.Male ? 1 : 0;
            caseReport.NumberOfMalesOver5 = @event.Age > 5 && (Sex)@event.Sex == Sex.Male ? 1 : 0;
            caseReport.Timestamp = _systemClock.GetCurrentTime();
            caseReport.Location = new Location(@event.Latitude, @event.Longitude);
            _caseReportsFromUnknownDataCollectors.Save(caseReport);
        }


        public void Process(MultipleCaseReportsFromUnknownDataCollectorReceived @event)
        {
            var caseReport = new CaseReportFromUnknownDataCollector(@event.CaseReportId);
            caseReport.Origin = @event.Origin;
            caseReport.HealthRiskId = @event.HealthRiskId;
            caseReport.NumberOfFemalesUnder5 = @event.NumberOfFemalesUnder5;
            caseReport.NumberOfFemalesOver5 = @event.NumberOfFemalesOver5;
            caseReport.NumberOfMalesUnder5 = @event.NumberOfFemalesUnder5;
            caseReport.NumberOfMalesOver5 = @event.NumberOfMalesOver5;
            caseReport.Location = new Location(@event.Latitude, @event.Longitude);
            _caseReportsFromUnknownDataCollectors.Save(caseReport);
        }
    }
}
