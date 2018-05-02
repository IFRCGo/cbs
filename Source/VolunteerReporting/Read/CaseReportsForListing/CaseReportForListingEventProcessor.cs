using System.Collections.Generic;
using Concepts;
using Dolittle.Events.Processing;
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
        public void Process(CaseReportReceived @event)
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
                NumberOfFemalesAged5AndOlder = @event.NumberOfFemalesAged5AndOlder,
                NumberOfMalesUnder5 = @event.NumberOfMalesUnder5,
                NumberOfMalesAged5AndOlder = @event.NumberOfMalesAged5AndOlder,
                Location = new Location(@event.Latitude, @event.Longitude),
                Timestamp = @event.Timestamp,
                Origin = @event.Origin,
                Message = @event.Message,
                ParsingErrorMessage = new List<string>()
            };
             _caseReports.Save(caseReport);
        }

        //QUESTION: Should we also listen to datacollector and health risk changes to update names? Or is there a better way to do this?

        public void Process(CaseReportFromUnknownDataCollectorReceived @event)
        {            
            var healthRisk = _healthRisks.GetById(@event.HealthRiskId);
            var caseReport = new CaseReportForListing(@event.CaseReportId)
            {
                Status = CaseReportStatus.UnknownDataCollector,                
                HealthRiskId = @event.HealthRiskId,
                HealthRisk = healthRisk.Name,
                NumberOfFemalesUnder5 = @event.NumberOfFemalesUnder5,
                NumberOfFemalesAged5AndOlder = @event.NumberOfFemalesAged5AndOlder,
                NumberOfMalesUnder5 = @event.NumberOfMalesUnder5,
                NumberOfMalesAged5AndOlder = @event.NumberOfMalesAged5AndOlder,
                Timestamp = @event.Timestamp,
                Origin = @event.Origin,
                Message = @event.Message,
                DataCollectorDisplayName = "Unknown",
                ParsingErrorMessage = new List<string>(),
                Location = Location.NotSet
            };
             _caseReports.Save(caseReport);
        }

        public void Process(CaseReportIdentified @event)
        {
            _caseReports.Remove(@event.CaseReportId);
        }

        public void Process(InvalidReportReceived @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            var caseReport = new CaseReportForListing(@event.CaseReportId)
            {
                Status = CaseReportStatus.TextMessageParsingError,
                DataCollectorId = @event.DataCollectorId,
                DataCollectorDisplayName = dataCollector.DisplayName,
                Message = @event.Message,
                Timestamp = @event.Timestamp,
                Origin = @event.Origin,
                ParsingErrorMessage = @event.ErrorMessages,
                Location = new Location(@event.Latitude, @event.Longitude),
                HealthRisk = "Unknown"
            };
            _caseReports.Save(caseReport);
        }

        public void Process(InvalidReportFromUnknownDataCollectorReceived @event)
        {            
            var caseReport = new CaseReportForListing(@event.CaseReportId)
            {
                Status = CaseReportStatus.TextMessageParsingErrorAndUnknownDataCollector,
                Message = @event.Message,
                Timestamp = @event.Timestamp,
                Origin = @event.Origin,
                ParsingErrorMessage = @event.ErrorMessages,
                DataCollectorDisplayName = "Unknown",
                Location = Location.NotSet,
                HealthRisk = "Unknown"
            };
            _caseReports.Save(caseReport);
        }

        //TODO: Remove error reports if they get fixed when we have events for that
    }
}
