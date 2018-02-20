using Concepts;
using doLittle.Events.Processing;
using Events;
using Read.DataCollectors;
using Read.HealthRisks;
using System.Threading.Tasks;

namespace Read.CaseReportsForListing
{
    public class CaseReportForListingEventProcessor : ICanProcessEvents
    {
        private readonly ICaseReportsForListing _caseReports;
        private readonly IDataCollectors _dataCollectors;
        private readonly IHealthRisks _healthRisks;

        public CaseReportForListingEventProcessor(
            ICaseReportsForListing caseReports,
            IDataCollectors dataCollectors,
            IHealthRisks healthRisks)
        {
            _caseReports = caseReports;
            _dataCollectors = dataCollectors;
            _healthRisks = healthRisks;
        }
        public async Task Process(CaseReportReceived @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            var healthRisk = _healthRisks.GetById(@event.HealthRiskId);
            var caseReport = new CaseReportForListing(@event.CaseReportId)
            {
                Status = CaseReportStatus.Success,
                DataCollectorId = @event.DataCollectorId,
                DataCollectorDisplayName = dataCollector.DisplayName,
                HealthRiskId = @event.HealthRiskId,
                HealthRisk = healthRisk.Name,
                NumberOfFemalesUnder5 = @event.NumberOfFemalesUnder5,
                NumberOfFemalesOver5 = @event.NumberOfFemalesOver5,
                NumberOfMalesUnder5 = @event.NumberOfMalesUnder5,
                NumberOfMalesOver5 = @event.NumberOfMalesOver5,
                Location = new Location(@event.Latitude, @event.Longitude),
                Timestamp = @event.Timestamp
            };
            await _caseReports.Save(caseReport);
        }

        //QUESTION: Should we also listen to datacollector and health risk changes to update names? Or is there a better way to do this?

        public async Task Process(CaseReportFromUnknownDataCollectorReceived @event)
        {            
            var healthRisk = _healthRisks.GetById(@event.HealthRiskId);
            var caseReport = new CaseReportForListing(@event.CaseReportId)
            {
                Status = CaseReportStatus.UnknownDataCollector,                
                HealthRiskId = @event.HealthRiskId,
                HealthRisk = healthRisk.Name,
                NumberOfFemalesUnder5 = @event.NumberOfFemalesUnder5,
                NumberOfFemalesOver5 = @event.NumberOfFemalesOver5,
                NumberOfMalesUnder5 = @event.NumberOfMalesUnder5,
                NumberOfMalesOver5 = @event.NumberOfMalesOver5,
                Timestamp = @event.Timestamp
            };
            await _caseReports.Save(caseReport);
        }

        public async Task Process(CaseReportIdentified @event)
        {
            await _caseReports.Remove(@event.CaseReportId);
        }

        public async Task Process(InvalidReportReceived @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            var caseReport = new CaseReportForListing(@event.CaseReportId)
            {
                Status = CaseReportStatus.TextMessageParsingError,
                DataCollectorId = @event.DataCollectorId,
                DataCollectorDisplayName = dataCollector.DisplayName,
                Message = @event.Message,
                Timestamp = @event.Timestamp
            };
            await _caseReports.Save(caseReport);
        }

        public async Task Process(InvalidReportFromUnknownDataCollectorReceived @event)
        {            
            var caseReport = new CaseReportForListing(@event.CaseReportId)
            {
                Status = CaseReportStatus.TextMessageParsingErrorAndUnknownDataCollector,
                Message = @event.Message,
                Timestamp = @event.Timestamp
            };
            await _caseReports.Save(caseReport);
        }

        //TODO: Remove error reports if they get fixed when we have events for that
    }
}
