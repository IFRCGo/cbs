using System;
using System.Linq;
using Events;
using Events.External;
using Infrastructure.Application;
using Infrastructure.Events;
using Read;

namespace Policies
{
    public class CaseReportPolicy : Infrastructure.Events.IEventProcessor
    {
        public static readonly Feature Feature = "CaseReport";

        readonly ICaseReports _caseReports;
        readonly IEventEmitter _eventEmitter;

        public CaseReportPolicy(ICaseReports caseReports, IEventEmitter eventEmitter)
        {
            _caseReports = caseReports;
            _eventEmitter = eventEmitter;
        }
        public void Process(SingleCaseReported @event)
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

            var timeWindowInDays = 7;
            var alertThreshold = 3;

            var latestReports = _caseReports.GetCaseReportsAfterDate(DateTime.UtcNow.Subtract(TimeSpan.FromDays(timeWindowInDays)));

            // Number of reports last n days for area and health risk above threshold

            if (latestReports.Count() > alertThreshold)
            {
                // Raise alert, send form

                _eventEmitter.Emit(Feature, new AlertRaised
                {
                });
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
