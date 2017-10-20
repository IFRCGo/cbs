using Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Read.AnonymousCaseReportFeatures
{
    public class AnonymousCaseReportProcessor : Infrastructure.Events.IEventProcessor
    {
        readonly IAnonymousCaseReports _anonymousCaseReports;

        public AnonymousCaseReportProcessor(IAnonymousCaseReports caseReports)
        {
            _anonymousCaseReports = caseReports;
        }
        
        public void Process(AnonymousCaseReportRecieved @event)
        {
            var anonymousCaseReport = new AnonymousCaseReport(@event.Id);
            anonymousCaseReport.HealthRiskId = @event.HealthRiskId;
            anonymousCaseReport.NumberOfFemalesOver5 = @event.NumberOfFemalesOver5;
            anonymousCaseReport.NumberOfFemalesUnder5 = @event.NumberOfFemalesUnder5;
            anonymousCaseReport.NumberOfMalesOver5 = @event.NumberOfMalesOver5;
            anonymousCaseReport.NumberOfMalesUnder5 = @event.NumberOfMalesUnder5;
            anonymousCaseReport.Timestamp = @event.Timestamp;
            anonymousCaseReport.Location = new Location(@event.Latitude, @event.Longitude);
            _anonymousCaseReports.Save(anonymousCaseReport);
        }
    }
}
