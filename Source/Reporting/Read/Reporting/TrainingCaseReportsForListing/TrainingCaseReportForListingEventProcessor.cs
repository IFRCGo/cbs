/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.DataCollectors;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Events.Reporting.CaseReports;
using Read.Reporting.CaseReportsForListing;
using Read.Reporting.DataCollectors;
using Read.Reporting.HealthRisks;

namespace Read.Reporting.TrainingCaseReportsForListing
{
    public class TrainingCaseReportForListingEventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<TrainingCaseReportForListing> _caseReports;
        private readonly IReadModelRepositoryFor<ListedDataCollector> _dataCollectors;
        private readonly IReadModelRepositoryFor<HealthRisk> _healthRisks;

        public TrainingCaseReportForListingEventProcessor(
            IReadModelRepositoryFor<TrainingCaseReportForListing> caseReports,
            IReadModelRepositoryFor<ListedDataCollector> dataCollectors,
            IReadModelRepositoryFor<HealthRisk> healthRisks)
        {
            _caseReports = caseReports;
            _dataCollectors = dataCollectors;
            _healthRisks = healthRisks;
        }

        [EventProcessor("444a5102-9aa8-4e08-954e-effd399c637e")]
        public void Process(CaseReportReceived @event, EventSourceId caseReportId)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            var healthRisk = _healthRisks.GetById(@event.HealthRiskId);

            var caseReport = new TrainingCaseReportForListing(caseReportId.Value)
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
        [EventProcessor("e21469b2-d17a-4456-903c-47c47f0e8165")]
        public void Process(CaseReportFromUnknownDataCollectorReceived @event, EventSourceId caseReportId)
        {            
            var healthRisk = _healthRisks.GetById(@event.HealthRiskId);

            var caseReport = new TrainingCaseReportForListing(caseReportId.Value)
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

        [EventProcessor("53fcf080-7f3f-4e3d-a67d-1b26158858c3")]
        public void Process(InvalidReportReceived @event, EventSourceId caseReportId)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);

            var caseReport = new TrainingCaseReportForListing(caseReportId.Value)
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

        [EventProcessor("530c0799-fdfb-49da-a341-fd9f56585ddd")]
        public void Process(InvalidReportFromUnknownDataCollectorReceived @event, EventSourceId caseReportId)
        {
            var caseReport = new TrainingCaseReportForListing(caseReportId.Value)
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
    }
}