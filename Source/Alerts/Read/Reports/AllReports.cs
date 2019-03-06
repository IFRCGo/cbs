using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Reports
{
    public class AllReports : IQueryFor<Report>
    {
        readonly IReadModelRepositoryFor<Report> _repositoryForReport;

        public AllReports(IReadModelRepositoryFor<Report> repositoryForReport)
        {
            _repositoryForReport = repositoryForReport;
        }

        public IQueryable<Report> Query => _repositoryForReport.Query;
    }
}
