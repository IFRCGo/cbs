using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Events;
using Events.External;
using Infrastructure.Application;
using Infrastructure.Events;
using Read;
using Read.Alert;
using Read.HealthRiskObjects;

namespace Policies
{
    public class CaseReportPolicy : Infrastructure.Events.IEventProcessor
    {
        public static readonly Feature Feature = "CaseReport";

        private readonly ICaseReports _caseReports;
        private readonly IDataCollectors _dataCollectors;
        private readonly ISmsSendingService _smsSendingService;
        private readonly IEventEmitter _eventEmitter;
        private readonly IHealthRisks _healthRisks;
        private readonly IAlerts _alerts;
        private readonly IAlertFeedbackService _feedbackService;

        public CaseReportPolicy(ICaseReports caseReports, IEventEmitter eventEmitter, IHealthRisks healthRisks, IAlertFeedbackService feedbackService)
        public CaseReportPolicy(ICaseReports caseReports, IEventEmitter eventEmitter, IHealthRisks healthRisks, IAlerts alerts)
        {
            _caseReports = caseReports;
            _eventEmitter = eventEmitter;
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

            if (latestReports.Count() > disease.ThresholdNumberOfCases)
            {
                var alert = new Alert
                {
                    Id = Guid.NewGuid()
                };
                _alerts.Save(alert);

                _eventEmitter.Emit(Feature, new AlertRaised
                {
                });
                _feedbackService.SendFeedbackToDataCollecorsAndVerifiers(latestReports);
            }
        }

        
    }
}
