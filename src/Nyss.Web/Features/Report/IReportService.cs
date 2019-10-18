using System.Threading.Tasks;

namespace Nyss.Web.Features.Report
{
    public interface IReportService
    {
        Task InsertReportAsync(Data.Models.Report report);
        Task SaveChangesAsync();
    }
}
