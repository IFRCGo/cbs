using System;
using System.Collections.Generic;
using Concepts;
using Dolittle.Events.Processing;
using Events;
using Read.DataCollectors;
using Read.HealthRisks;

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
            if (dataCollector == null)
                throw new Exception("Data collector was not found");

            var healthRisk = _healthRisks.GetById(@event.HealthRiskId);
            if (healthRisk == null)
                throw new Exception("Health risk was not found");

            _caseReports.SaveCaseReport(
                @event.CaseReportId,
                dataCollector,
                healthRisk,
                @event.Message,
                @event.Origin,
                @event.NumberOfMalesUnder5,
                @event.NumberOfMalesAged5AndOlder,
                @event.NumberOfFemalesUnder5,
                @event.NumberOfFemalesAged5AndOlder,
                @event.Timestamp);

            var caseReport = new CaseReportForListing(@event.CaseReportId)
            {
                Status = CaseReportStatus.Success,
                DataCollectorId = @event.DataCollectorId,
                DataCollectorDisplayName = dataCollector.DisplayName,
                DataCollectorRegion = dataCollector.Region,
                DataCollectorDistrict = dataCollector.District,
                DataCollectorVillage = dataCollector.Village,
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
            if (healthRisk == null)
                throw new Exception("Health risk was not found");

            _caseReports.SaveCaseReportFromUnknownDataCollector(
                @event.CaseReportId,
                healthRisk,
                @event.Message,
                @event.Origin,
                @event.NumberOfMalesUnder5,
                @event.NumberOfMalesAged5AndOlder,
                @event.NumberOfFemalesUnder5,
                @event.NumberOfFemalesAged5AndOlder,
                @event.Timestamp);

        }

        public void Process(InvalidReportReceived @event)
        {
            
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            if (dataCollector == null)
                throw new Exception("Data collector was not found");

            _caseReports.SaveInvalidReport(
                @event.CaseReportId,
                dataCollector,
                @event.Message,
                @event.Origin,
                @event.Latitude,
                @event.Longitude,
                @event.ErrorMessages,
                @event.Timestamp);
        }

        public void Process(InvalidReportFromUnknownDataCollectorReceived @event)
        {
            _caseReports.SaveInvalidReportFromUnknownDataCollector(
                @event.CaseReportId,
                @event.Message,
                @event.Origin,
                @event.ErrorMessages,
                @event.Timestamp);
        }

        public void Process(CaseReportIdentified @event)
        {
            _caseReports.Delete(@event.CaseReportId);
        }
    }
}
