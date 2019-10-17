using System;
using System.Threading.Tasks;
using Nyss.Data.Models;

namespace Nyss.SmsGateway.Data
{
    public class ReportRepository : IReportRepository
    {
        public async Task<Report> InsertAsync(Report report)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }
    }
}
