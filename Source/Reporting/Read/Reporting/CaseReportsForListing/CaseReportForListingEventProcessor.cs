/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.DataCollectors;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Events.Reporting.CaseReports;
using Read.Reporting.DataCollectors;
using Read.Reporting.HealthRisks;

namespace Read.Reporting.CaseReportsForListing
{
    public class CaseReportForListingEventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<CaseReportForListing> _caseReports;
        private readonly IReadModelRepositoryFor<ListedDataCollector> _dataCollectors;
        private readonly IReadModelRepositoryFor<HealthRisk> _healthRisks;

        public CaseReportForListingEventProcessor(
            IReadModelRepositoryFor<CaseReportForListing> caseReports,
            IReadModelRepositoryFor<ListedDataCollector> dataCollectors,
            IReadModelRepositoryFor<HealthRisk> healthRisks)
        {
            _caseReports = caseReports;
            _dataCollectors = dataCollectors;
            _healthRisks = healthRisks;
        }

        [EventProcessor("0d17954b-eaeb-4936-a7a6-153b61767206")]
        public void Process(CaseReportReceived @event, EventSourceId caseReportId)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            var healthRisk = _healthRisks.GetById(@event.HealthRiskId);

            var caseReport = new CaseReportForListing(caseReportId.Value)
            {
                Status = CaseReportStatus.Success,
                Message = @event.Message,
                DataCollectorId = dataCollector.Id,
                DataCollectorDisplayName = dataCollector.DisplayName,
                DataCollectorDistrict = dataCollector.District,
                DataCollectorRegion = dataCollector.Region,
                DataCollectorVillage = dataCollector.Village,
                Location = dataCollector.Location,
                Origin = @event.Origin,

                HealthRiskId = healthRisk.Id,
                HealthRisk = healthRisk.Name,

                NumberOfMalesUnder5 = @event.NumberOfMalesUnder5,
                NumberOfMalesAged5AndOlder = @event.NumberOfMalesAged5AndOlder,
                NumberOfFemalesUnder5 = @event.NumberOfFemalesUnder5,
                NumberOfFemalesAged5AndOlder = @event.NumberOfFemalesAged5AndOlder,
                Timestamp = @event.Timestamp
            };
            _caseReports.Insert(caseReport);
        }

        //QUESTION: Should we also listen to datacollector and health risk changes to update names? Or is there a better way to do this?
        [EventProcessor("9b505b35-54e3-4e35-bccd-79d330de9c54")]
        public void Process(CaseReportFromUnknownDataCollectorReceived @event, EventSourceId caseReportId)
        {            
            var healthRisk = _healthRisks.GetById(@event.HealthRiskId);

            var caseReport = new CaseReportForListing(caseReportId.Value)
            {
                Status = CaseReportStatus.UnknownDataCollector,
                DataCollectorDisplayName = "Unknown",
                DataCollectorId = null,

                HealthRisk = healthRisk.Name,
                HealthRiskId = healthRisk.Id,

                Location = Location.NotSet,
                Message = @event.Message,
                Origin = @event.Origin,
                Timestamp = @event.Timestamp,

                DataCollectorDistrict = null,
                DataCollectorRegion = null,
                DataCollectorVillage = null
            };
            _caseReports.Insert(caseReport);
        }

        [EventProcessor("c44c06e9-822f-41de-9d1e-0cdddcf1da0a")]
        public void Process(InvalidReportReceived @event, EventSourceId caseReportId)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);

            var caseReport = new CaseReportForListing(caseReportId.Value)
            {
                Status = CaseReportStatus.TextMessageParsingError,
                DataCollectorDisplayName = dataCollector.DisplayName,
                DataCollectorId = dataCollector.Id,
                DataCollectorRegion = dataCollector.Region,
                DataCollectorDistrict = dataCollector.District,
                DataCollectorVillage = dataCollector.Village,

                HealthRiskId = null,
                HealthRisk = "Unknown",

                Location = dataCollector.Location,
                Message = @event.Message,
                Origin = @event.Origin,
                ParsingErrorMessage = @event.ErrorMessages,
                Timestamp = @event.Timestamp
            };

            _caseReports.Insert(caseReport);
        }

        [EventProcessor("d4f5e727-c2fa-4140-b5de-d14ba3a22f13")]
        public void Process(InvalidReportFromUnknownDataCollectorReceived @event, EventSourceId caseReportId)
        {
            var caseReport = new CaseReportForListing(caseReportId.Value)
            {
                Status = CaseReportStatus.TextMessageParsingErrorAndUnknownDataCollector,
                DataCollectorDisplayName = "Unknown",
                DataCollectorId = null,
                HealthRiskId = null,
                HealthRisk = "Unknown",
                Location = Location.NotSet,
                Message = @event.Message,
                Origin = @event.Origin,
                ParsingErrorMessage = @event.ErrorMessages,
                Timestamp = @event.Timestamp,

                DataCollectorDistrict = null,
                DataCollectorRegion = null,
                DataCollectorVillage = null,
            };
            _caseReports.Insert(caseReport);
        }

        [EventProcessor("46928d1f-987a-4a2d-804f-8e4b686d2262")]
        public void Process(CaseReportIdentified @event, EventSourceId caseReportId)
        {
            var caseReport = _caseReports.GetById(caseReportId.Value);

            _caseReports.Delete(caseReport);
        }
    }
}