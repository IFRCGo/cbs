using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.Reporting.CaseReports
{
    public class CaseReportsHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<CaseReporting>  _aggregateRootRepoForCaseReporting;

        public CaseReportsHandler(
            IAggregateRootRepositoryFor<CaseReporting>  aggregateRootRepoForCaseReporting            
        )
        {
             _aggregateRootRepoForCaseReporting =  aggregateRootRepoForCaseReporting;
        }

        public void Handle(ConvertToLiveReport cmd)
        {
            _aggregateRootRepoForCaseReporting.Get(cmd.CaseReportId.Value).ConvertToLiveReport();
        }
        
        public void Handle(ConvertToTrainingReport cmd)
        {
            _aggregateRootRepoForCaseReporting.Get(cmd.CaseReportId.Value).ConvertToTrainingReport();
        }
        
    }
}
