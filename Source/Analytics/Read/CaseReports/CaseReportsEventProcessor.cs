using Dolittle.Events.Processing;
using Events.Reporting.CaseReports;
using Read.CaseReports;
using Dolittle.ReadModels;
using Dolittle.Logging;

namespace Read.CaseReports
{
    public class CaseReportsEventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<CaseReport> _caseReportRepository;

        public CaseReportsEventProcessor(IReadModelRepositoryFor<CaseReport> caseReportRepository)
        {
            _caseReportRepository = caseReportRepository;
        }

       [EventProcessor("cb01aaaf-7998-4692-81ef-1ceb5ab38e12")]
        public void Process(CaseReportReceived @event)
        {
            var caseReport = new CaseReport(@event.DataCollectorId, 
            @event.HealthRiskId, @event.Origin, @event.Message, @event.NumberOfMalesUnder5, @event.NumberOfMalesAged5AndOlder, 
            @event.NumberOfFemalesUnder5, @event.NumberOfFemalesAged5AndOlder, @event.Longitude, @event.Latitude,
            @event.Timestamp);
            
            _caseReportRepository.Insert(caseReport);
        }
    }
}