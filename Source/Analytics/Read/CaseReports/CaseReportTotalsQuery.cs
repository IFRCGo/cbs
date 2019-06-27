using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.CaseReports
{
    public class CaseReportTotalsQuery : IQueryFor<CaseReportTotals>
    {
        readonly IReadModelRepositoryFor<CaseReportTotals> _repositoryForCaseReportTotals;

        public CaseReportTotalsQuery(IReadModelRepositoryFor<CaseReportTotals> repositoryForCaseReportTotals)
        {
            _repositoryForCaseReportTotals = repositoryForCaseReportTotals;
        }

        public IQueryable<CaseReportTotals> Query => _repositoryForCaseReportTotals.Query;
    }
}
