using System;
using System.Collections.Generic;
using System.Linq;
using Events;
using Events.External;
using Infrastructure.Application;
using Infrastructure.Events;
using MongoDB.Driver;
using Read;
using Read.Disease;

namespace Policies
{
    public class CaseReportPolicy : Infrastructure.Events.IEventProcessor
    {
        public static readonly Feature Feature = "CaseReport";

        private readonly ICaseReports _caseReports;
        private readonly IDataCollectors _dataCollectors;
        private readonly IEventEmitter _eventEmitter;
        private readonly IDiseases _diseases;

        public CaseReportPolicy(ICaseReports caseReports, IDataCollectors dataCollectors, IEventEmitter eventEmitter, IDiseases diseases)
        {
            _caseReports = caseReports;
            _dataCollectors = dataCollectors;
            _eventEmitter = eventEmitter;
            _diseases = diseases;
        }
        public void Process(SingleCaseReported @event)
        {
            var caseReport = _caseReports.GetById(@event.Id);
            if (caseReport == null)
            {
                caseReport = new CaseReport
                {
                    Id = @event.Id,
                    DataCollectorId = @event.DataCollectorId,
                    DiseaseId = @event.DiseaseId,
                    Location = @event.Location,
                    SubmissionTimestamp = @event.CaseOccured
                };
            }
            else
            {
                caseReport.Id = @event.Id;
                caseReport.DataCollectorId = @event.DataCollectorId;
                caseReport.DiseaseId = @event.DiseaseId;
                caseReport.Location = @event.Location;
                caseReport.SubmissionTimestamp = @event.CaseOccured;
            }
            _caseReports.Save(caseReport);

            var disease = _diseases.GetById(caseReport.DiseaseId) ?? new Disease()
            {
                Id = @event.DiseaseId,
                ThresholdTimePeriodInDays = 7,
                ThresholdNumberOfCases = 3
            };

            var latestReports = _caseReports.GetCaseReportsAfterDate(
                DateTime.UtcNow.Subtract(TimeSpan.FromDays(disease.ThresholdTimePeriodInDays)), caseReport.DiseaseId);

            // Number of reports last n days for area and health risk above threshold

            if (latestReports.Count() > disease.ThresholdNumberOfCases)
            {
                // Raise alert, send form
                _eventEmitter.Emit(Feature, new AlertRaised
                {
                });

                SendFeedbackToDataCollecorsAndVerifiers(latestReports);
            }
        }

        private void SendFeedbackToDataCollecorsAndVerifiers(IEnumerable<CaseReport> latestReports)
        {
            var dataCollectors = _dataCollectors.Get(latestReports.Select(o => o.DataCollectorId).ToArray());
            var dataVerifiers = dataCollectors.GroupBy(o => o.DataVerifier.UserId).Select(o => o.First().DataVerifier).ToArray();

            // send sms to all data verifiers
            foreach (DataVerifier dataVerifier in dataVerifiers)
            {
               // TODO: send
            }

            // send sms to all data collecors
            foreach (DataCollector dataCollector in dataCollectors)
            {
                // TODO: send
            }
        }

        
        public void Process(AggregateCaseReported @event)
        {
            var caseReport = _caseReports.GetById(@event.Id);
            if (caseReport == null)
            {
                caseReport = new CaseReport
                {
                    Id = @event.Id
                };
            }
            else
            {
                caseReport.Id = @event.Id;
            }

            _caseReports.Save(caseReport);
        }
    }
}
