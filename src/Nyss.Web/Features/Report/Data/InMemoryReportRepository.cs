using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyss.Web.Features.Report.Data
{
    public class InMemoryReportRepository : IReportRepository
    {
        private static List<Nyss.Data.Models.Report> _reports;

        public InMemoryReportRepository()
        {
            _reports = new List<Nyss.Data.Models.Report>();
        }

        public IEnumerable<ReportViewModel> All()
        {
            throw new NotImplementedException();
        }

        public Task<Nyss.Data.Models.Report> InsertReportAsync(Nyss.Data.Models.Report report)
        {
            report.Id = _reports.Count + 1;
            _reports.Add(report);

            return Task.FromResult(report);
        }

        public async Task SaveChangesAsync()
        {
            await Task.Delay(0);
        }
    }
}
