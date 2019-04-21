using Concepts.CaseReports;
using Dolittle.Commands;

namespace Domain.Reporting.CaseReports
{
    public class ConvertToTrainingReport : ICommand
    {
        public CaseReportId CaseReportId {get; set;}
    }
}
