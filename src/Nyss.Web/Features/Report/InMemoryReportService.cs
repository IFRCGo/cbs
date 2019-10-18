using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nyss.Web.Features.Report
{
    public class InMemoryReportService : IReportService
    {
        public IEnumerable<ReportViewModel> All()
        {
            throw new NotImplementedException();
        }

        public Task InsertReportAsync(Data.Models.Report report)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
