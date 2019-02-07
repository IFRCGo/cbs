using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.Reports
{
    public class CasesCommandHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<CaseReport>  _aggregateRootRepoForCaseReport;

        public CasesCommandHandler(
            IAggregateRootRepositoryFor<CaseReport>  aggregateRootRepoForCaseReport)
        {
             _aggregateRootRepoForCaseReport =  aggregateRootRepoForCaseReport;
        }

        public void Handle(ForcePublishNewCaseReport cmd)
        {
            var aggrRoot = _aggregateRootRepoForCaseReport.Get(cmd.CaseReportId);
            var data = new CaseReportData
            {
                CaseReportId = cmd.CaseReportId,
                DataCollectorId = cmd.DataCollectorId,
                HealthRiskId = cmd.HealthRiskId,
                Latitude = cmd.Latitude,
                Longitude = cmd.Longitude,
                Timestamp = cmd.Timestamp,
                NumberOfMalesUnder5 = cmd.NumberOfMalesUnder5,
                NumberOfMalesAged5AndOlder = cmd.NumberOfMalesAged5AndOlder,
                NumberOfFemalesUnder5 = cmd.NumberOfFemalesUnder5,
                NumberOfFemalesAged5AndOlder = cmd.NumberOfFemalesAged5AndOlder,
                Message = cmd.Message,
                PhoneNumber = cmd.Origin
            };
            aggrRoot.ProcessReport(data);
        }
    }
}
