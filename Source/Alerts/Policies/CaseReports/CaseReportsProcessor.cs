using Dolittle.Events.Processing;
using Dolittle.Domain;
using Domain.CaseReports;
using Events.Reporting.CaseReports;

namespace Policies.CaseReports
{
    /// <summary>
    /// Class for processing external event <see cref="CaseReportReceived"/>
    /// </summary>
    public class CaseReportsProcessor : ICanProcessEvents
    {
        private readonly IAggregateRootRepositoryFor<CaseReport> _caseReportAggregateRootRepository;

        public CaseReportsProcessor(IAggregateRootRepositoryFor<CaseReport> caseReportAggregateRootRepository)
        {
            _caseReportAggregateRootRepository = caseReportAggregateRootRepository;
        }

        public void Process(CaseReportReceived @event)
        {
            var root = _caseReportAggregateRootRepository.Get(@event.CaseReportId);
            var data = new CaseReportData
            {
                CaseReportId = @event.CaseReportId,
                DataCollectorId = @event.DataCollectorId,
                HealthRiskId = @event.HealthRiskId,
                Latitude = @event.Latitude,
                Longitude = @event.Longitude,
                Timestamp = @event.Timestamp,
                NumberOfMalesUnder5 = @event.NumberOfMalesUnder5,
                NumberOfMalesAged5AndOlder = @event.NumberOfMalesAged5AndOlder,
                NumberOfFemalesUnder5 = @event.NumberOfFemalesUnder5,
                NumberOfFemalesAged5AndOlder = @event.NumberOfFemalesAged5AndOlder
            };

            root.ProcessReport(data);
        }
    }
}
