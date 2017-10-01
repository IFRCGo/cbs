using System;
using System.Linq;
using Events;
using Events.External;
using Infrastructure.Application;
using Infrastructure.Events;
using Read;
using Read.HealthRiskObjects;

namespace Policies
{
    public class CaseReportPolicy : Infrastructure.Events.IEventProcessor
    {
        public static readonly Feature Feature = "CaseReport";

        private readonly ICaseReports _caseReports;
        private readonly IEventEmitter _eventEmitter;
        private readonly IHealthRisks _healthRisks;

        public CaseReportPolicy(ICaseReports caseReports, IEventEmitter eventEmitter, IHealthRisks healthRisks)
        {
            _caseReports = caseReports;
            _eventEmitter = eventEmitter;
            _healthRisks = healthRisks;
        }
        public void Process(CaseReported @event)
        {
            var caseReport = _caseReports.GetById(@event.Id);
            if (caseReport == null)
            {
                caseReport = new CaseReport
                {
                    Id = @event.Id,
                    DataCollectorId = @event.DataCollectorId,
                    HealthRiskId = @event.HealthRiskId,
                    Location = @event.Location,
                    SubmissionTimestamp = @event.CaseOccured
                };
            }
            else
            {
                caseReport.Id = @event.Id;
                caseReport.DataCollectorId = @event.DataCollectorId;
                caseReport.HealthRiskId = @event.HealthRiskId;
                caseReport.Location = @event.Location;
                caseReport.SubmissionTimestamp = @event.CaseOccured;
            }
            _caseReports.Save(caseReport);

            var disease = _healthRisks.GetById(caseReport.HealthRiskId) ?? new HealthRisk()
            {
                Id = @event.HealthRiskId,
                ThresholdTimePeriodInDays = 7,
                ThresholdNumberOfCases = 3
            };

            var latestReports = _caseReports.GetCaseReportsAfterDate(
                DateTime.UtcNow.Subtract(TimeSpan.FromDays(disease.ThresholdTimePeriodInDays)), caseReport.HealthRiskId);

            // Number of reports last n days for area and health risk above threshold

            if (latestReports.Count() > disease.ThresholdNumberOfCases)
            {
                // Raise alert, send form
                _eventEmitter.Emit(Feature, new AlertRaised
                {
                });
            }
        }
    }
}
