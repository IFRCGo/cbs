using System.Collections.Generic;

using System.Threading.Tasks;

namespace Nyss.Web.Features.Report
{
    public interface IReportService
    {
        IEnumerable<ReportViewModel> All();
        Task InsertReportAsync(Data.Models.Report report);
        Task SaveChangesAsync();
    }
}
