using Concepts.CaseReports;
using Dolittle.Commands;

namespace Domain.Reporting.CaseReports
{
    public class ConvertToLiveReport : ICommand
    {
        public CaseReportId CaseReportId {get; set;}
    }
}
