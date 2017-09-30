using Events.External;
using Read;

namespace Policies
{
    public class CaseReportPolicy : Infrastructure.Events.IEventProcessor
    {
        readonly ICaseReports _caseReports;

        public CaseReportPolicy(ICaseReports caseReports)
        {
            _caseReports = caseReports;
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
