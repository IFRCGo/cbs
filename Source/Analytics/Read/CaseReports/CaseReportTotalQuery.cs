using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.CaseReports
{
    public class CaseReportTotalQuery : IQueryFor<CaseReport>
    {
        readonly IReadModelRepositoryFor<CaseReport> _repositoryForCaseReport;

        public CaseReportTotalQuery(IReadModelRepositoryFor<CaseReport> repositoryForCaseReport)
        {
            _repositoryForCaseReport = repositoryForCaseReport;
        }

        public IQueryable Query => _repositoryForCaseReport.Query;
    }
}
