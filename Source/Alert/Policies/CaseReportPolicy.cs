using System;
using Events;
using Events.External;
using Read;
using Read.Alert;
using Read.HealthRiskObjects;
using doLittle.Events.Processing;
using doLittle.Runtime.Events.Coordination;
using doLittle.Runtime.Transactions;
using doLittle.Runtime.Events;

namespace Policies
{
    public class CaseReportPolicy : ICanProcessEvents
    {
        private readonly ICaseReports _caseReports;
        private readonly IHealthRisks _healthRisks;
        private readonly IAlerts _alerts;
        private readonly IAlertFeedbackService _feedbackService;
        private readonly IUncommittedEventStreamCoordinator _uncommittedEventStreamCoordinator;

        public CaseReportPolicy(ICaseReports caseReports, IHealthRisks healthRisks, IAlertFeedbackService feedbackService, IAlerts alerts, IUncommittedEventStreamCoordinator uncommittedEventStreamCoordinator)
        {
            _uncommittedEventStreamCoordinator = uncommittedEventStreamCoordinator;
            _caseReports = caseReports;
            _healthRisks = healthRisks;
            _feedbackService = feedbackService;
            _alerts = alerts;
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

            var disease = _healthRisks.GetById(caseReport.HealthRiskId) ?? new HealthRisk
            {
                Id = @event.HealthRiskId,
                ThresholdTimePeriodInDays = 7,
                ThresholdNumberOfCases = 3
            };

            var latestReports = _caseReports.GetCaseReportsAfterDate(
                DateTime.UtcNow.Subtract(TimeSpan.FromDays(disease.ThresholdTimePeriodInDays)), caseReport.HealthRiskId);

            if (latestReports.Count > disease.ThresholdNumberOfCases)
            {
                var alert = _alerts.Get(caseReport.HealthRiskId, caseReport.Location);
                if (alert == null)
                {
                    alert = new Alert
                    {
                        Id = Guid.NewGuid(),
                        HealthRiskId = caseReport.HealthRiskId,
                        Location = caseReport.Location,
                    };
                }
                alert.CaseReports.Add(caseReport);
                _alerts.Save(alert);


                // Todo: Temporary fix - we're not supposed to do this, awaiting the new Policy building block in doLittle to be ready
                var stream = new UncommittedEventStream(null);
                stream.Append(new AlertRaised(), EventSourceVersion.Zero.NextCommit());
                _uncommittedEventStreamCoordinator.Commit(TransactionCorrelationId.New(), stream);

                _feedbackService.SendFeedbackToDataCollecorsAndVerifiers(latestReports);
            }
        }


    }
}
