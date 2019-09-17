/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Reporting.CaseReports;
using Dolittle.Runtime.Events;
using Read.Management.DataCollectors;
using Read.Reporting.CaseReportsForListing;
using Read.Reporting.HealthRisks;

namespace Read.Reporting.CaseReports
{
    public class EventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<CaseReport> _caseReports;
        readonly IReadModelRepositoryFor<CaseReportFromUnknownDataCollector> _caseReportsFromUnknownDataCollectors;
        readonly IReadModelRepositoryFor<TrainingReport> _trainingReports;
        readonly IReadModelRepositoryFor<DataCollector> _dataCollectors;
        readonly IReadModelRepositoryFor<HealthRisk> _healthRisks;

        public EventProcessor(
            IReadModelRepositoryFor<CaseReport> caseReports,
            IReadModelRepositoryFor<CaseReportFromUnknownDataCollector> caseReportsFromUnknownDataCollectors,
            IReadModelRepositoryFor<TrainingReport> trainingReports,
            IReadModelRepositoryFor<DataCollector> dataCollectors,
            IReadModelRepositoryFor<HealthRisk> healthRisks)
        {
            _caseReports = caseReports;
            _caseReportsFromUnknownDataCollectors = caseReportsFromUnknownDataCollectors;
            _trainingReports = trainingReports;
            _dataCollectors = dataCollectors;
            _healthRisks = healthRisks;
        }
        [EventProcessor("3a8fbc62-d9d4-49d0-b61f-abe420bf412f")]
        public void Process(TrainingReportReceived @event, EventSourceId caseReportId)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            var healthRisk = _healthRisks.GetById(@event.HealthRiskId);

            var report = new TrainingReport(caseReportId.Value)
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
                Timestamp = @event.Timestamp,
            };
            _trainingReports.Insert(report);
        }

        [EventProcessor("a7202162-c745-486c-9cd2-b1f7f26b6162")]
        public void Process(InvalidTrainingReportReceived @event, EventSourceId caseReportId)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);

            var report = new TrainingReport(caseReportId.Value)
            {
                Status = CaseReportStatus.TextMessageParsingError,
                Message = @event.Message,
                DataCollectorId = dataCollector.Id,
                DataCollectorDisplayName = dataCollector.DisplayName,
                DataCollectorDistrict = dataCollector.District,
                DataCollectorRegion = dataCollector.Region,
                DataCollectorVillage = dataCollector.Village,
                Location = dataCollector.Location,
                Origin = @event.Origin,

                HealthRiskId = null,
                HealthRisk = "Unknown",
                Timestamp = @event.Timestamp,
            };
            _trainingReports.Insert(report);
        }
    }
}
