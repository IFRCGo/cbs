using Events;
using System;
using System.Collections.Generic;
using System.Text;
using doLittle.Events.Processing;

namespace Read.CaseReportFeatures
{
    public class CaseReportProcessor : ICanProcessEvents
    {
        readonly ICaseReports _caseReports;

        public CaseReportProcessor(ICaseReports caseReports)
        {
            _caseReports = caseReports;
        }

        public void Process(CaseReportReceived @event)
        {
            var caseReport = new CaseReport(@event.Id);
            caseReport.DataCollectorId = @event.DataCollectorId;
            caseReport.HealthRiskId = @event.HealthRiskId;
            caseReport.NumberOfFemalesOver5 = @event.NumberOfFemalesOver5;
            caseReport.NumberOfFemalesUnder5 = @event.NumberOfFemalesUnder5;
            caseReport.NumberOfMalesOver5 = @event.NumberOfMalesOver5;
            caseReport.NumberOfMalesUnder5 = @event.NumberOfMalesUnder5;
            caseReport.Timestamp = @event.Timestamp;
            caseReport.Location = new Location(@event.Latitude, @event.Longitude);
            _caseReports.Save(caseReport);
        }

        public void Process(AnonymousCaseReportRecieved @event)
        {
            var caseReport = new CaseReport(@event.Id);
            caseReport.DataCollectorId = Guid.Empty;
            caseReport.HealthRiskId = @event.HealthRiskId;
            caseReport.NumberOfFemalesOver5 = @event.NumberOfFemalesOver5;
            caseReport.NumberOfFemalesUnder5 = @event.NumberOfFemalesUnder5;
            caseReport.NumberOfMalesOver5 = @event.NumberOfMalesOver5;
            caseReport.NumberOfMalesUnder5 = @event.NumberOfMalesUnder5;
            caseReport.Timestamp = @event.Timestamp;
            caseReport.Location = new Location(@event.Latitude, @event.Longitude);
            _caseReports.Save(caseReport);
        }
    }
}
