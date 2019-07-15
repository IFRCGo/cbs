using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.CaseReports
{
    public class AllCaseReports : IQueryFor<CaseReport>
    {
        readonly IReadModelRepositoryFor<CaseReport> _repositoryForCaseReport;

        public AllCaseReports(IReadModelRepositoryFor<CaseReport> repositoryForCaseReport)
        {
            _repositoryForCaseReport = repositoryForCaseReport;
        }

        public IQueryable<CaseReport> Query => _repositoryForCaseReport.Query;
    }
}
